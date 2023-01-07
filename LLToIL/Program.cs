using LLVMSharp;
using LLVMSharp.Interop;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

using ILInstruction = dnlib.DotNet.Emit.Instruction;
using Type = System.Type;
using LLToIL.RedirFunctions;
using System.Runtime.InteropServices;

namespace LLToIL;

public unsafe class Program
{
	public static ModuleDefUser assembly;
	public static ITypeDefOrRef ValueType;
	public static IMethod Alloc;
	public static IMethod AllocAllign;
	public static IMethod Free;

	public static IMethod ExceptionCctor;

	public static Dictionary<LLVMValueRef, MethodDefUser> MethodsLink = new Dictionary<LLVMValueRef, MethodDefUser>();
	public static Dictionary<LLVMValueRef, FieldDefUser> FieldsLink = new Dictionary<LLVMValueRef, FieldDefUser>();

	static TypeDefUser maintype;
	static CilBody initVarsBody;

	static void ImportBasicTypes()
	{
		ValueType = assembly.Import(System.Type.GetType("System.ValueType", true, false));
		assembly.Import(assembly.CorLibTypes.Byte);
		assembly.Import(assembly.CorLibTypes.Int16);
		assembly.Import(assembly.CorLibTypes.Int32);
		assembly.Import(assembly.CorLibTypes.Int64);
		assembly.Import(assembly.CorLibTypes.IntPtr);

		ExceptionCctor = assembly.Import(typeof(Exception).GetConstructors().First(c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(string)));
		
		Alloc = assembly.Import(typeof(NativeMemory).GetMethod("Alloc", new Type[] { typeof(nuint) }));
		AllocAllign = assembly.Import(typeof(NativeMemory).GetMethod("AlignedAlloc"));
		Free = assembly.Import(typeof(NativeMemory).GetMethod("Free")); NativeMemory.Alloc(2);

		assembly.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)assembly.Import(typeof(System.Security.UnverifiableCodeAttribute).GetConstructors().First())));
	}

	static void Main(string[] args)
	{
#if true
		//args = new[] { "D:\\test.ll" };
#endif

		if (args.Length == 0) throw new Exception("USE: LLToIL path/to/code.ll");

		var prog = args[0];
		var progname = new FileInfo(prog).Name;

		byte[] path = Encoding.ASCII.GetBytes(prog);
		LLVMOpaqueMemoryBuffer* membuf = (LLVMOpaqueMemoryBuffer*)0;
		fixed(byte* b = &path[0])
			LLVM.CreateMemoryBufferWithContentsOfFile((sbyte*)b, &membuf, (sbyte**)0);
		LLVMModuleRef module = LLVMContextRef.Global.ParseIR(membuf);

		assembly = new ModuleDefUser(progname, Guid.NewGuid(), new AssemblyRefUser(typeof(int).Assembly.GetName()));
		ImportBasicTypes();
		maintype = new TypeDefUser("Main", assembly.CorLibTypes.Object.ScopeType);
		maintype.Attributes |= TypeAttributes.Public;
		assembly.Types.Add(maintype);

		{
			var function = module.FirstFunction;
			while (function.Handle != IntPtr.Zero)
			{
				var ret = function;

				string funcname = function.Name;

				LLVMTypeRef functype = new LLVMTypeRef((IntPtr)LLVM.GetElementType((LLVMOpaqueType*)function.Handle));

				List<TypeSig> param = new List<TypeSig>();
				foreach (var i in function.Params)
					param.Add(TypeSigFromTypeOf(i.TypeOf));

				MethodSig methodsig = MethodSig.CreateStatic(TypeSigFromTypeOf(functype.ReturnType, true), param.ToArray());

				if (function.ToString().Split(')', StringSplitOptions.RemoveEmptyEntries)[0].Contains("...")) // shitcode
				{
					//if (function.BasicBlocksCount == 0)
					//	methodsig.CallingConvention = dnlib.DotNet.CallingConvention.NativeVarArg;
					//else
					methodsig.CallingConvention = dnlib.DotNet.CallingConvention.VarArg;
				}

				MethodDefUser sharpmethod = new MethodDefUser(funcname, methodsig);
				sharpmethod.Attributes |= MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig;
				maintype.Methods.Add(sharpmethod);

				for(int i = 0; i < function.ParamsCount; i++)
				{
					sharpmethod.Parameters[i].CreateParamDef();
					sharpmethod.Parameters[i].Name = GetSlot(function.Params[i].ToString(), 1);
				}

				if (function.BasicBlocksCount == 0)
					sharpmethod.IsPinvokeImpl = true;

				MethodsLink.Add(function, sharpmethod);

				function = function.NextFunction;
			}

			var field = module.FirstGlobal;
			while (field.Handle != IntPtr.Zero)
			{
				CreateField(field);

				field = field.NextGlobal;
			}
		}

		var initVars = new MethodDefUser("CreateVars", MethodSig.CreateStatic(assembly.CorLibTypes.Void));
		initVars.Attributes |= MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.Public;

		initVarsBody = new CilBody();
		initVars.Body = initVarsBody;

		maintype.Methods.Add(initVars);

		foreach(var funcs in MethodsLink)
		{
			var function = funcs.Key;
			var sharp = funcs.Value;

			if (sharp.IsPinvokeImpl)
			{
				RedirManager.RedirThis(sharp);
				continue;
			}

			var body = new CilBody();
			var instructions = body.Instructions;
			sharp.Body = body;

			// sharp.Body.KeepOldMaxStack = true; // force write body if there error

			Dictionary<IntPtr, ILInstruction> jumps = new Dictionary<IntPtr, ILInstruction>();
			Dictionary<IntPtr, ILInstruction> blockends = new Dictionary<IntPtr, ILInstruction>();
			Dictionary<IntPtr, byte> jumpid = new Dictionary<IntPtr, byte>();

			Local jidlocal = new Local(assembly.CorLibTypes.Byte, "jid");
			body.Variables.Add(jidlocal);

			byte jid = 0;
			var block = function.FirstBasicBlock;
			while (block.Handle != IntPtr.Zero)
			{
				jumps.Add(block.Handle, ILInstruction.Create(OpCodes.Nop));
				blockends.Add(block.Handle, ILInstruction.Create(OpCodes.Nop));
				jumpid.Add(block.Handle, jid);
				block = block.Next;
				jid++;
			}


			block = function.FirstBasicBlock;
			while (block.Handle != IntPtr.Zero)
			{
				body.Instructions.Add(jumps[block.Handle]);
				var instr = block.FirstInstruction;
				while (instr.Handle != IntPtr.Zero)
				{
					LLVMOpcode opcode = LLVM.GetInstructionOpcode(instr);

#if false
					body.Instructions.Add(ILInstruction.Create(OpCodes.Nop));
					body.Instructions.Add(ILInstruction.Create(OpCodes.Nop));
					body.Instructions.Add(ILInstruction.Create(OpCodes.Ldstr, instr.ToString()));
					body.Instructions.Add(ILInstruction.Create(OpCodes.Pop));
					body.Instructions.Add(ILInstruction.Create(OpCodes.Nop));
					body.Instructions.Add(ILInstruction.Create(OpCodes.Nop));
#endif

					switch (opcode)
					{
						case LLVMOpcode.LLVMAlloca:
							{
								var operand = instr.GetOperand(0);
								LLVMTypeRef _rettype = LLVM.GetAllocatedType(instr);
								var rettype = TypeSigFromTypeOf(_rettype);
								//var allign = instr.Alignment;

								var what = GetSlot(instr.ToString(), 2);

								if (operand.IsAArgument.Handle != IntPtr.Zero)
								{
									LoadValue(operand, sharp);
									instructions.Add(ILInstruction.Create(OpCodes.Sizeof, rettype.ToTypeDefOrRef()));
									instructions.Add(ILInstruction.Create(OpCodes.Mul));
								}
								else if (operand.IsAInstruction.Handle != IntPtr.Zero)
								{
									LoadValue(operand, sharp);
									instructions.Add(ILInstruction.Create(OpCodes.Sizeof, rettype.ToTypeDefOrRef()));
									instructions.Add(ILInstruction.Create(OpCodes.Mul));
								}
								else if (what == "ptr")
									instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, 8));
								else if (!rettype.IsPrimitive)
								{
									//var typesize = TypeCache[_rettype].CalcSize();
									//instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)(operand.ConstIntSExt * typesize)));
									instructions.Add(ILInstruction.Create(OpCodes.Sizeof, rettype.ToTypeDefOrRef()));
									instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)operand.ConstIntSExt));
									instructions.Add(ILInstruction.Create(OpCodes.Mul));
								}
								else
									instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)((int)operand.ConstIntSExt * (int)operand.TypeOf.IntWidth / 8)));
								
								//instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)allign));
								//instructions.Add(ILInstruction.Create(OpCodes.Call, AllocAllign));
								instructions.Add(ILInstruction.Create(OpCodes.Localloc));
								SaveValue(instr, sharp, true);
								break;
							}

						case LLVMOpcode.LLVMStore:
							{
								var op1 = instr.GetOperand(1);
								var op0 = instr.GetOperand(0);

								var what = GetSlot(instr.ToString(), 1);

								var tothis = LoadValue(op1, sharp); 
								var tothisInstruction = instructions.Last();
								var savethis = LoadValue(op0, sharp);
								var savethisInstruction = instructions.Last();

								if (tothis.TypeName == "IntPtr" && savethis.TypeName != "IntPtr")
									FixType(tothisInstruction, savethis);

								switch (savethis.TypeName)
								{
									case "Byte":
										instructions.Add(ILInstruction.Create(OpCodes.Stind_I1));
										break;
									case "Int16":
										instructions.Add(ILInstruction.Create(OpCodes.Stind_I2));
										break;
									case "Int32":
										instructions.Add(ILInstruction.Create(OpCodes.Stind_I4));
										break;
									case "Single":
										instructions.Add(ILInstruction.Create(OpCodes.Stind_R4));
										break;
									case "Int64":
										instructions.Add(ILInstruction.Create(OpCodes.Stind_I8));
										break;
									case "IntPtr":
										instructions.Add(ILInstruction.Create(OpCodes.Stind_I));
										break;
									default:
										if (tothis.IsPointer)
											instructions.Add(ILInstruction.Create(OpCodes.Stind_I));
										else
											instructions.Add(ILInstruction.Create(OpCodes.Stind_Ref));
										break;
								}
								break;
							}

						case LLVMOpcode.LLVMLoad:
							{
								var from = LoadValue(instr.GetOperand(0), sharp);
								var what = GetSlot(instr.ToString(), 2);
								switch (from.TypeName)
								{
									case "Byte":
										instructions.Add(ILInstruction.Create(OpCodes.Ldind_I1));
										break;
									case "Int16":
										instructions.Add(ILInstruction.Create(OpCodes.Ldind_I2));
										break;
									case "Int32":
										instructions.Add(ILInstruction.Create(OpCodes.Ldind_I4));
										break;
									case "Single":
										instructions.Add(ILInstruction.Create(OpCodes.Ldind_R4));
										break;
									case "Int64":
										instructions.Add(ILInstruction.Create(OpCodes.Ldind_I8));
										break;
									case "IntPtr":
										instructions.Add(ILInstruction.Create(OpCodes.Ldind_I));
										break;
									default:
										if (from.IsPointer)
										{
											instructions.Add(ILInstruction.Create(OpCodes.Ldind_I));
											break;
										}
										else
											throw new NotImplementedException();
								}
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMFAdd:
						case LLVMOpcode.LLVMAdd:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								instructions.Add(ILInstruction.Create(OpCodes.Add));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMFSub:
						case LLVMOpcode.LLVMSub:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								instructions.Add(ILInstruction.Create(OpCodes.Sub));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMFMul:
						case LLVMOpcode.LLVMMul:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Mul));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMFDiv:
						case LLVMOpcode.LLVMSDiv:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								instructions.Add(ILInstruction.Create(OpCodes.Div));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMUDiv:
							{
								LoadValue(instr.GetOperand(0), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
								instructions.Add(ILInstruction.Create(OpCodes.Div));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMURem: // signed = unsigned target % unsigned by
							{
								var target = instr.GetOperand(0);
								var by = instr.GetOperand(1);

								var type = LoadValue(target, sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U8));
								LoadValue(by, sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U8));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Rem));
								switch(type.TypeName)
								{
									case "Boolean":
									case "SByte":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I1));
										break;
									case "Byte":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U1));
										break;
									case "Int16":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I2));
										break;
									case "YInt16":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U2));
										break;
									case "Int32":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I4));
										break;
									case "UInt32":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U4));
										break;
									case "UInt64":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U8));
										break;
									default:
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I8));
										break;
								}
								SaveValue(instr, sharp);

								break;
							}

						case LLVMOpcode.LLVMFRem:
						case LLVMOpcode.LLVMSRem: // target % by
							{
								var target = instr.GetOperand(0);
								var by = instr.GetOperand(1);

								LoadValue(target, sharp);
								LoadValue(by, sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Rem));
								SaveValue(instr, sharp);

								break;
							}

						case LLVMOpcode.LLVMTrunc:
							{
								LoadValue(instr.GetOperand(0), sharp);
								switch(instr.TypeOf.ToString())
								{
									case "i8":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I1));
										break;
									case "i16":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I2));
										break;
									case "i32":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I4));
										break;
									case "i64":
										body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_I8));
										break;
									default:
										throw new NotImplementedException();
								}
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMFPExt:
							{
								LoadValue(instr.GetOperand(0), sharp);
								instructions.Add(ILInstruction.Create(OpCodes.Conv_R8));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMFPTrunc:
							{
								LoadValue(instr.GetOperand(0), sharp);
								instructions.Add(ILInstruction.Create(OpCodes.Conv_R4));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMOr:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Or));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMAnd:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Or));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMShl:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Shl));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMAShr: // idk
						case LLVMOpcode.LLVMLShr:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Shr));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMXor:
							{
								LoadValue(instr.GetOperand(0), sharp);
								LoadValue(instr.GetOperand(1), sharp);
								body.Instructions.Add(ILInstruction.Create(OpCodes.Xor));
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMBr:
							{
								var operands = instr.OperandCount;
								if (operands == 1)
								{
									// get target block
									var to = instr.GetOperand(0).AsBasicBlock();

									// write current block id in local var
									body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)jumpid[block.Handle]));
									body.Instructions.Add(ILInstruction.Create(OpCodes.Stloc, jidlocal));

									// do jump
									body.Instructions.Add(ILInstruction.Create(OpCodes.Br, jumps[to.Handle]));
									goto writenextblock;
								}
								else if (operands == 3)
								{
									// write current block id in local var
									body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)jumpid[block.Handle]));
									body.Instructions.Add(ILInstruction.Create(OpCodes.Stloc, jidlocal));

									// get condition
									var condition = instr.GetOperand(0);
									LoadValue(condition,sharp); // load condition
									var iffalse = instr.GetOperand(1).AsBasicBlock(); // get target iffalse
									var iftrue = instr.GetOperand(2).AsBasicBlock(); // get target iftrue 
									body.Instructions.Add(ILInstruction.Create(OpCodes.Brtrue, jumps[iftrue.Handle])); // do jump
									body.Instructions.Add(ILInstruction.Create(OpCodes.Br, jumps[iffalse.Handle]));
									goto writenextblock;
								}
								else throw new NotImplementedException();
							}

						case LLVMOpcode.LLVMICmp:
							{
								switch (instr.ICmpPredicate)
								{
									case LLVMIntPredicate.LLVMIntEQ:
										{
											LoadValue(instr.GetOperand(0), sharp);
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											break;
										}
									case LLVMIntPredicate.LLVMIntNE:
										{
											LoadValue(instr.GetOperand(0), sharp);
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4_0));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											break;
										}

									case LLVMIntPredicate.LLVMIntUGT:
										{
											LoadValue(instr.GetOperand(0), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Cgt));
											break;
										}
									case LLVMIntPredicate.LLVMIntUGE:
										{
											LoadValue(instr.GetOperand(0), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Clt));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4_0));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											break;
										}
									case LLVMIntPredicate.LLVMIntULT:
										{
											LoadValue(instr.GetOperand(0), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Clt));
											break;
										}
									case LLVMIntPredicate.LLVMIntULE:
										{
											LoadValue(instr.GetOperand(0), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Cgt));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4_0));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											break;
										}

									case LLVMIntPredicate.LLVMIntSGT:
										{
											LoadValue(instr.GetOperand(0), sharp);
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Cgt));
											break;
										}
									case LLVMIntPredicate.LLVMIntSGE:
										{
											LoadValue(instr.GetOperand(0), sharp);
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Clt));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4_0));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											break;
										}
									case LLVMIntPredicate.LLVMIntSLT:
										{
											LoadValue(instr.GetOperand(0), sharp);
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Clt));
											break;
										}
									case LLVMIntPredicate.LLVMIntSLE:
										{
											LoadValue(instr.GetOperand(0), sharp);
											LoadValue(instr.GetOperand(1), sharp);
											body.Instructions.Add(ILInstruction.Create(OpCodes.Cgt));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4_0));
											body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq));
											break;
										}
									default:
										throw new NotImplementedException();
								}

								SaveValue(instr, sharp);

								break;
							}

						case LLVMOpcode.LLVMSelect:
							{
								var exit = ILInstruction.Create(OpCodes.Nop);
								LoadValue(instr.GetOperand(1), sharp); // if true value
								LoadValue(instr.GetOperand(0), sharp); // condition
								body.Instructions.Add(ILInstruction.Create(OpCodes.Brtrue, exit)); // exit
								body.Instructions.Add(ILInstruction.Create(OpCodes.Pop)); // if condition == false, then pop true value
								LoadValue(instr.GetOperand(2), sharp); // if false value
								body.Instructions.Add(exit);
								SaveValue(instr,sharp);
								break;
							}

						case LLVMOpcode.LLVMPHI:
							{
								var exit = ILInstruction.Create(OpCodes.Nop);
								for (uint i = 0; i < instr.IncomingCount; i++)
								{
									var val = instr.GetIncomingValue(i);
									var from = instr.GetIncomingBlock(i);
									
									LoadValue(val, sharp); // load val for target block
									body.Instructions.Add(ILInstruction.Create(OpCodes.Ldloc, jidlocal)); // get last block
									body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)jumpid[from.Handle])); // get target block
									body.Instructions.Add(ILInstruction.Create(OpCodes.Ceq)); // check
									body.Instructions.Add(ILInstruction.Create(OpCodes.Brtrue, exit)); // if true, then jump to normal flow with val for target block
									//if (i != instr.IncomingCount - 1)
									body.Instructions.Add(ILInstruction.Create(OpCodes.Pop)); // else no, then pop val for target block
								}

								body.Instructions.Add(ILInstruction.Create(OpCodes.Ldstr, "Bad Jump!"));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Newobj, ExceptionCctor));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Throw));
								body.Instructions.Add(exit);

								SaveValue(instr, sharp);

								break;
							}

						case LLVMOpcode.LLVMGetElementPtr:
							{
								var what = instr.GetOperand(0);
								var lv = LoadValue(what, sharp, false);

								LLVMTypeRef inType = LLVM.GetGEPSourceElementType(instr);
								TypeDefUser resolved = TypeDataFromTypeOf(inType)?.inSharp;

								uint start = lv.IsPointer ? 2u : 1u;

								if (start == 2u)
								{
									var at = instr.GetOperand(1);
									if (at.IsConstant && at.ConstIntSExt == 0) { }
									else
									{
										LoadValue(at, sharp, false);
										body.Instructions.Add(ILInstruction.CreateLdcI4(SizeFromTypeOf(inType)));
										body.Instructions.Add(ILInstruction.Create(OpCodes.Mul));
										body.Instructions.Add(ILInstruction.Create(OpCodes.Add));
									}
								}

								for (uint i = start; i < instr.OperandCount; i++)
								{
									tryagain:
									if (resolved == null)
									{
										LoadValue(instr.GetOperand(i), sharp, false);
										var val = body.Instructions.Last();
										body.Instructions.Add(ILInstruction.CreateLdcI4(SizeFromTypeOf(inType)));
										body.Instructions.Add(ILInstruction.Create(OpCodes.Mul));
										body.Instructions.Add(ILInstruction.Create(OpCodes.Add));

										bool isldc = val.IsLdcI4();
										int ldcval = isldc ? val.GetLdcI4Value() : 0;
										recurse:
										if (inType.ArrayLength > 0)
											inType = inType.ElementType;
										else if (inType.StructElementTypesCount > 0 && isldc)
										{
											if (ldcval < inType.StructElementTypesCount)
												inType = inType.StructElementTypes[ldcval];
											else
											{
												ldcval = ldcval - (int)inType.StructElementTypesCount;
												inType = inType.StructElementTypes.Last();
												goto recurse;
											}
										}
										else
										{
											//inType = LLVMTypeRef.Int64; // intptr basic size
											Console.WriteLine("*unknown type*");
										}
									}
									else
									{
										var at = instr.GetOperand(i);
										if (at.IsAInstruction.Handle != IntPtr.Zero)
										{
#if DEBUG
											Console.WriteLine("*bad GEP*");
#endif
											resolved = null; // very bad thing
											goto tryagain;
										}
										if (resolved.Fields.Count <= (int)at.ConstIntSExt)
										{
											resolved = null; // bad thing
											goto tryagain;
										}

										var id = (int)at.ConstIntSExt;
										var field = resolved.Fields[id];
										body.Instructions.Add(ILInstruction.Create(OpCodes.Ldflda, field));
										resolved = field.FieldType.ToTypeDefOrRef() as TypeDefUser;
										if (inType.ArrayLength > 0)
											inType = inType.ElementType;
										else if (inType.StructElementTypesCount > 0)
											inType = inType.StructElementTypes[id];
									}
								}

								SaveValue(instr, sharp, false);

								if (resolved != null)
									FixType(instructions.Last(), resolved.ToTypeSig());
								break;
							}

						case LLVMOpcode.LLVMSExt:
						case LLVMOpcode.LLVMZExt:
						case LLVMOpcode.LLVMPtrToInt: // idk
						case LLVMOpcode.LLVMIntToPtr: // idk
							{
								LoadValue(instr.GetOperand(0), sharp);
								SaveValue(instr, sharp);
								break;
							}

						case LLVMOpcode.LLVMInvoke:
							{
								Console.WriteLine($"LLVMInvoke is unsupported. Instruction -> {instr}");

								var to = (uint)instr.OperandCount - 3;

								List<LLVMValueRef> arguments = new List<LLVMValueRef>();

								for (uint i = 0; i < to; i++)
									arguments.Add(instr.GetOperand(i));

								var normal = instr.GetOperand((uint)instr.OperandCount - 3).AsBasicBlock();
								var catcherror = instr.GetOperand((uint)instr.OperandCount - 2).AsBasicBlock();
								var call = instr.GetOperand((uint)instr.OperandCount-1);
								var callmethod = MethodsLink[call];

								var exceptionCatcher = new ExceptionHandler(ExceptionHandlerType.Catch);
								if (arguments.Count > 0)
								{
									LoadValue(arguments[0], sharp);
									exceptionCatcher.TryStart = instructions.Last();
									for (int i = 1; i < arguments.Count; i++)
										LoadValue(arguments[i], sharp);
								}
								
								body.Instructions.Add(ILInstruction.Create(OpCodes.Call, callmethod));

								if (arguments.Count == 0)
									exceptionCatcher.TryStart = instructions.Last();

								if (callmethod.ReturnType.TypeName != "Void")
									SaveValue(instr, sharp);

								//body.Instructions.Add(ILInstruction.Create(OpCodes.Leave, jumps[normal.Handle]));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Br, jumps[normal.Handle]));

								/* exceptionCatcher.TryEnd = instructions.Last();
								exceptionCatcher.HandlerStart = jumps[catcherror.Handle];
								blockends[catcherror.Handle].OpCode = OpCodes.Leave;
								blockends[catcherror.Handle].Operand = jumps[normal.Handle];
								exceptionCatcher.HandlerEnd = blockends[catcherror.Handle]; */

								//body.ExceptionHandlers.Add(exceptionCatcher);

								goto writenextblock;
							}

						case LLVMOpcode.LLVMCatchPad:
							{
								Console.WriteLine($"LLVMCatchPad is unsupported. Instruction -> {instr}");
								break;
							}

						case LLVMOpcode.LLVMLandingPad:
							{
								Console.WriteLine($"LLVMLandingPad is unsupported. Instruction -> {instr}");
								break;
							}

						case LLVMOpcode.LLVMCleanupPad:
							{
								Console.WriteLine($"LLVMCleanupPad is unsupported. Instruction -> {instr}");
								break;
							}

						case LLVMOpcode.LLVMCleanupRet:
							{
								Console.WriteLine($"LLVMCleanupRet is unsupported. Instruction -> {instr}");
								break;
							}

						case LLVMOpcode.LLVMUnreachable:
							{
								body.Instructions.Add(ILInstruction.Create(OpCodes.Ldstr, "unreachable!!!"));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Newobj, ExceptionCctor));
								body.Instructions.Add(ILInstruction.Create(OpCodes.Throw));
								goto writenextblock;
							}

						case LLVMOpcode.LLVMCall:
							{
								var call = instr.GetOperand((uint)instr.OperandCount - 1);

								bool isPtrCall = call.IsAFunction.Handle == IntPtr.Zero;
								if (isPtrCall)
								{
									List<TypeSig> usedtypes = new List<TypeSig>();
									for (uint i = 0; i < instr.OperandCount - 1; i++)
										usedtypes.Add(LoadValue(instr.GetOperand(i), sharp));

									var rettype = TypeSigFromTypeOf(instr.TypeOf, true);

									LoadValue(call, sharp);

									MethodSig calli = new MethodSig();
									var callconv = (LLVMCallConv)LLVM.GetFunctionCallConv(call);
									switch (callconv)
									{
										case LLVMCallConv.LLVMCCallConv:
											calli.CallingConvention = dnlib.DotNet.CallingConvention.C;
											break;
										case LLVMCallConv.LLVMX86StdcallCallConv:
											calli.CallingConvention = dnlib.DotNet.CallingConvention.StdCall;
											break;
										case LLVMCallConv.LLVMX86FastcallCallConv:
										case LLVMCallConv.LLVMFastCallConv:
											calli.CallingConvention = dnlib.DotNet.CallingConvention.FastCall;
											break;
										case LLVMCallConv.LLVMX86ThisCallCallConv:
											calli.CallingConvention = dnlib.DotNet.CallingConvention.ThisCall;
											break;
										default:
											throw new NotImplementedException($"{callconv} is not implemented!");
									}

									calli.RetType = rettype;
									foreach(var i in usedtypes)
										calli.Params.Add(i);

									instructions.Add(ILInstruction.Create(OpCodes.Calli, calli));

									if (instr.TypeOf.ToString() != "void")
										SaveValue(instr, sharp);
									break;
								}

								var sharptarget = MethodsLink[call];

								if (sharptarget.Name == "llvm.va_start") // inline instrincis
								{
									instructions.Add(ILInstruction.Create(OpCodes.Arglist));
									//instructions.Add(ILInstruction.Create(OpCodes.Conv_U));
									var loc = new Local(assembly.CorLibTypes.IntPtr, "ref_arglist");
									body.Variables.Add(loc);
									instructions.Add(ILInstruction.Create(OpCodes.Stloc, loc));
									instructions.Add(ILInstruction.Create(OpCodes.Ldloca, loc));
									SaveValue(instr.GetOperand(0), sharp);
									break;
								}

								if (sharptarget.CallingConvention == dnlib.DotNet.CallingConvention.VarArg)
								{
									var sig = sharptarget.MethodSig.Clone();

									List<TypeSig> usedtypes = new List<TypeSig>();
									for (uint i = 0; i < instr.OperandCount - 1; i++)
										usedtypes.Add(LoadValue(instr.GetOperand(i), sharp));

									sig.ParamsAfterSentinel = usedtypes.Skip(sig.Params.Count).ToArray();

									instructions.Add(ILInstruction.Create(OpCodes.Call, new MemberRefUser(assembly, sharptarget.Name, sig, sharptarget.DeclaringType)));
									if (sharptarget.ReturnType.FullName != "System.Void")
										SaveValue(instr, sharp);
								}
								else
								{
									for (uint i = 0; i < instr.OperandCount - 1; i++)
										LoadValue(instr.GetOperand(i), sharp);
									instructions.Add(ILInstruction.Create(OpCodes.Call, sharptarget));
									if (sharptarget.ReturnType.FullName != "System.Void")
										SaveValue(instr, sharp);
								}
								
								break;
							}

						case LLVMOpcode.LLVMExtractElement:
							{
								var from = instr.GetOperand(0);
								var at = instr.GetOperand(1);

								var vector = TypeDataFromTypeOf(from.TypeOf).inSharp;

								LoadValue(from, sharp);

								if (at.IsConstant == false) throw new NotImplementedException();

								instructions.Add(ILInstruction.Create(OpCodes.Ldfld, vector.Fields[(int)at.ConstIntSExt]));

								SaveValue(instr, sharp);

								break;
							}

						case LLVMOpcode.LLVMInsertElement:
							{
								var to = instr.GetOperand(0);
								var what = instr.GetOperand(1);
								var at = instr.GetOperand(2);

								var vector = TypeDataFromTypeOf(to.TypeOf);

								if (to.IsPoison)
								{
									instructions.Add(ILInstruction.CreateLdcI4((int)vector.CalcSize()));
									instructions.Add(ILInstruction.Create(OpCodes.Localloc));
									instructions.Add(ILInstruction.Create(OpCodes.Dup));
								}
								else
								{
									LoadValue(to, sharp);
									throw new NotImplementedException();
								}

								LoadValue(what,sharp);

								if (at.IsConstant == false) throw new NotImplementedException();

								instructions.Add(ILInstruction.Create(OpCodes.Stfld, vector.inSharp.Fields[(int)at.ConstIntSExt]));

								SaveValue(instr, sharp);

								break;
							}

						case LLVMOpcode.LLVMShuffleVector:
							{
								throw new NotImplementedException("LLVMShuffleVector not implemented, because its very hard for me ><");
								//break;
							}

						case LLVMOpcode.LLVMSwitch:
							{
								var forval = instr.GetOperand(0);
								var defaultjmp = instr.GetOperand(1);

								for(uint i = 2; i < instr.OperandCount; i += 2)
								{
									var ifval = instr.GetOperand(i);
									var to = instr.GetOperand(i+1);

									LoadValue(forval, sharp);
									LoadValue(ifval, sharp);
									instructions.Add(ILInstruction.Create(OpCodes.Ceq));
									instructions.Add(ILInstruction.Create(OpCodes.Brtrue, jumps[to.Handle]));
								}

								instructions.Add(ILInstruction.Create(OpCodes.Br, jumps[defaultjmp.Handle]));
								goto writenextblock;
							}

						case LLVMOpcode.LLVMRet:
							{
								if (sharp.ReturnType.TypeName != "Void")
								{
									var operand = instr.GetOperand(0);
									if (operand.IsAConstant.Handle != IntPtr.Zero)
										LoadConstant(instr, sharp);
									else if (operand.IsAInstruction.Handle != IntPtr.Zero || operand.IsAArgument.Handle != IntPtr.Zero)
										LoadValue(instr, sharp);
								}
								instructions.Add(ILInstruction.Create(OpCodes.Ret));
								goto writenextblock;
							}

						default:
							throw new NotImplementedException($"Not implemented - {opcode}");
					}

					instr = instr.NextInstruction;
				}

				// write current block id in local var
				body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)jumpid[block.Handle]));
				body.Instructions.Add(ILInstruction.Create(OpCodes.Stloc, jidlocal));

				writenextblock:

				if (body.Instructions.Last().OpCode.Code != Code.Ret && body.Instructions.Last().OpCode.Code != Code.Br)
					body.Instructions.Add(blockends[block.Handle]);
				else
					body.Instructions.Insert(body.Instructions.Count-1 ,blockends[block.Handle]);

				block = block.Next;
			}
#if true
			MagicArea.Optimizations.TryOptimizeThis(sharp);
#endif

#if false
			Console.WriteLine($"Vars for {sharp.FullName} method: ");
			foreach(var i in sharp.Body.Variables)
				Console.WriteLine($"{i.Name} -> {i.Index}");
#endif
		}

		//foreach (var link in FieldsLink)
		for (int iter = 0; iter < FieldsLink.Count; iter++)
		{
			var link = FieldsLink.ElementAt(iter);
			var ll = link.Key;
			var sharp = link.Value;

			if (sharp.Name == "unknown" || sharp.Attributes.HasFlag(FieldAttributes.NotSerialized)) continue;

			var init = ll.Initializer;

			sharp.Name = ClearName(sharp.Name);


			if (init.Handle != IntPtr.Zero)
			{
				var type = sharp.FieldType.TryGetTypeDefOrRef();

				//cctorbody.Instructions.Add(ILInstruction.Create(OpCodes.Newobj, type.Methods.First(m => m.Name == ".ctor")));
				//cctorbody.Instructions.Add(ILInstruction.Create(OpCodes.Stsfld, sharp));

				if (ll.TypeOf.Kind == LLVMTypeKind.LLVMPointerTypeKind)
				{
					sharp.FieldType = new PtrSig(type.ToTypeSig());
					initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Sizeof, type));
					initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Call, Alloc));
					initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stsfld, sharp));
				}
				else
				{
					if (ll.TypeOf.Kind == LLVMTypeKind.LLVMStructTypeKind)
					{
						initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldflda, sharp));
						initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Initblk, type));
					}
					else if (ll.TypeOf.Kind == LLVMTypeKind.LLVMArrayTypeKind)
						throw new NotImplementedException();
				}

				if (init.IsConstantString)
				{
					SetStaticField_String(initVarsBody, init, type.ResolveTypeDef(),
						() => initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldsfld, sharp)));
					continue;
				}
				else if (init.IsConstant)
				{
					SetStaticField_Other(initVarsBody, init, sharp,
						() => initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldsfld, sharp)));

					continue;
				}

				throw new NotImplementedException();
			}
		}

		initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ret));

		foreach (var m in RedirFunctions.Sharped.LLVMRedir.LLVMMethods)
			m.Name = m.Name.Replace('.', '_');

		var possiblemain = maintype.Methods.FirstOrDefault(m => m.Name == "main");
		if (possiblemain != null && possiblemain.ParamDefs.Count == 2)
		{
			var spf = RedirManager.ThisAssembly.Types.First(t => t.Name == "SomePrecompiledFunctions");
			var goodentry = spf.Methods.First(m => m.Name == "CStyleMain");
			var newentrypoint = new MethodDefUser("Main", goodentry.MethodSig, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Static);
			newentrypoint.Body = goodentry.Body;

			foreach(var i in newentrypoint.Body.Instructions)
				if (i.OpCode.Code == Code.Call)
					if (((IMethodDefOrRef)i.Operand).Name == "DummyMain")
						i.Operand = possiblemain;

			maintype.Methods.Add(newentrypoint);

			possiblemain = newentrypoint;
		}

		assembly.EntryPoint = possiblemain;

		if (possiblemain != null)
		{
			var entrypointbody = possiblemain.Body;
			entrypointbody.Instructions.Insert(0, ILInstruction.Create(OpCodes.Call, initVars));
		}

		assembly.Kind = ModuleKind.Console;

		assembly.Is32BitPreferred = false;
		assembly.Is32BitRequired = false;

		var save = new AssemblyDefUser(progname, new Version(1,0,0,0));
		save.Modules.Add(assembly);
		save.DeclSecurities.Add(RedirManager.ThisAssembly.Assembly.DeclSecurities.First());

		save.Write(prog.Replace(progname, progname.Replace(".ll", ".dll")));

		Console.WriteLine("Good!");
		//Console.ReadLine();
	}

	private static void FixType(ILInstruction tothisInstruction, TypeSig savethis)
	{
		if (tothisInstruction.IsLdarg())
			((Parameter)tothisInstruction.Operand).Type = new PtrSig(savethis);
		else if (tothisInstruction.IsLdloc())
			((Local)tothisInstruction.Operand).Type = new PtrSig(savethis);
		else if (tothisInstruction.IsStarg())
			((Parameter)tothisInstruction.Operand).Type = new PtrSig(savethis);
		else if (tothisInstruction.IsStloc())
			((Local)tothisInstruction.Operand).Type = new PtrSig(savethis);
		else throw new Exception();
		return;
	}

	private static void CreateField(LLVMValueRef field)
	{
		var fieldsig = new FieldSig(TypeSigFromTypeOf(field.Initializer.TypeOf));
		string fieldname = string.IsNullOrWhiteSpace(field.Name) || string.IsNullOrEmpty(field.Name) ? "unknown" : field.Name;
		var sharpfield = new FieldDefUser(fieldname, fieldsig);
		sharpfield.Access = FieldAttributes.Public;
		sharpfield.IsStatic = true;

		maintype.Fields.Add(sharpfield);

		if (field.IsDeclaration)
		{
			RedirManager.RedirField(sharpfield, initVarsBody);
			sharpfield.Attributes |= FieldAttributes.NotSerialized;
		}

		FieldsLink.Add(field, sharpfield);
	}

	private static TypeSig GetClearType(TypeSig from)
	{
		if (from.IsPointer)
		{
			from = from.ToPtrSig().Next;
			return GetClearType(from);
		}
		return from;
	}

	public static string ClearName(string name)
	{
		return name.Replace('.', '_').Replace('@', '_').Replace('?', '_').Replace('$', '_');
	}

	public static Dictionary<LLVMTypeRef, TypeData> TypeCache = new Dictionary<LLVMTypeRef, TypeData>();

	static TypeData TypeDataFromTypeOf(LLVMTypeRef typeOf)
	{
		if (TypeCache.ContainsKey(typeOf))
			return TypeCache[typeOf];
		TypeSigFromTypeOf(typeOf);
		if (TypeCache.ContainsKey(typeOf))
			return TypeCache[typeOf];
		return null;
	}

	static TypeSig TypeSigFromTypeOf(LLVMTypeRef typeOf, bool forfunc = false)
	{
		if (TypeCache.ContainsKey(typeOf))
			return TypeCache[typeOf].asTypeSig;

		if (typeOf.Kind == LLVMTypeKind.LLVMVoidTypeKind)
			return forfunc ? assembly.CorLibTypes.Void : assembly.CorLibTypes.IntPtr;
		if (typeOf.Kind == LLVMTypeKind.LLVMIntegerTypeKind)
		{
			var size = typeOf.IntWidth;
			if (size == 1)
			{
				return assembly.CorLibTypes.Boolean;
			}
			if (size > 1 && size <= 8)
			{
				return assembly.CorLibTypes.Byte;
			}
			if (size > 8 && size <= 16)
			{
				return assembly.CorLibTypes.Int16;
			}
			if (size > 16 && size <= 32)
			{
				return assembly.CorLibTypes.Int32;
			}
			if (size > 32 && size <= 64)
			{
				return assembly.CorLibTypes.Int64;
			}
		}
		if (typeOf.Kind == LLVMTypeKind.LLVMPointerTypeKind)
		{
			return assembly.CorLibTypes.IntPtr;
		}
		if (typeOf.Kind == LLVMTypeKind.LLVMFloatTypeKind)
		{
			return assembly.CorLibTypes.Single;
		}
		if (typeOf.Kind == LLVMTypeKind.LLVMDoubleTypeKind)
		{
			return assembly.CorLibTypes.Double;
		}

		if (typeOf.Kind == LLVMTypeKind.LLVMArrayTypeKind)
		{
			TypeDefUser type = new TypeDefUser($"Array_{typeOf.ElementType.ToString()}_{typeOf.ArrayLength}", ValueType);
			type.Attributes |= TypeAttributes.Public | TypeAttributes.SequentialLayout;
			var element = TypeSigFromTypeOf(typeOf.ElementType);
			for(int i = 0; i < typeOf.ArrayLength; i++)
				type.Fields.Add(new FieldDefUser($"element_{i}", new FieldSig(element), FieldAttributes.Public));
			assembly.Types.Add(type);

			TypeCache.Add(typeOf, new TypeData(typeOf, type));
			return type.ToTypeSig();
		}

		if (typeOf.Kind == LLVMTypeKind.LLVMStructTypeKind)
		{
			var structname = $"Struct_{typeOf.StructName.Replace(':', '_').Replace(',', '_').Replace('.', '_')}";
			if (structname == "Struct_")
			{
				structname = $"UnknownStruct_{unknownstruct}";
				unknownstruct++;
			}
			TypeDefUser type = new TypeDefUser(structname, ValueType);
			type.Attributes |= TypeAttributes.Public | TypeAttributes.SequentialLayout;

			for (int i = 0; i < typeOf.StructElementTypesCount; i++)
				type.Fields.Add(new FieldDefUser($"element_{i}", new FieldSig(TypeSigFromTypeOf(typeOf.StructElementTypes[i])), FieldAttributes.Public));

			assembly.Types.Add(type);
			TypeCache.Add(typeOf, new TypeData(typeOf, type));
			return type.ToTypeSig();
		}

		if (typeOf.Kind == LLVMTypeKind.LLVMVectorTypeKind)
		{
			var innerType = typeOf.ElementType;
			var count = typeOf.VectorSize;

			TypeDefUser type = new TypeDefUser($"Vector_{innerType}_{count}", ValueType);
			type.Attributes |= TypeAttributes.Public | TypeAttributes.SequentialLayout;
			var element = TypeSigFromTypeOf(innerType);
			for (int i = 0; i < typeOf.VectorSize; i++)
				type.Fields.Add(new FieldDefUser($"_{i}", new FieldSig(element), FieldAttributes.Public));
			assembly.Types.Add(type);

			TypeCache.Add(typeOf, new TypeData(typeOf, type));
			return type.ToTypeSig();
		}

		if (typeOf.ToString() == "token")
			return assembly.CorLibTypes.Int32;
		if (typeOf.ToString() == "metadata")
			return assembly.CorLibTypes.Int32;

		throw new NotImplementedException();
	}

	static int unknownstruct = 0;

	static TypeSig TypeSigFromString(string str)
	{
		switch(str)
		{
			case "i1":
				return assembly.CorLibTypes.Boolean.ToTypeDefOrRefSig();
			case "i8":
				return assembly.CorLibTypes.Byte.ToTypeDefOrRefSig();
			case "i16":
				return assembly.CorLibTypes.Int16.ToTypeDefOrRefSig();
			case "i32":
				return assembly.CorLibTypes.Int32.ToTypeDefOrRefSig();
			case "float":
				return assembly.CorLibTypes.Single.ToTypeDefOrRefSig();
			case "i64":
				return assembly.CorLibTypes.Int64.ToTypeDefOrRefSig();
			case "double":
				return assembly.CorLibTypes.Double.ToTypeDefOrRefSig();
			case "void":
				return assembly.CorLibTypes.Void.ToTypeDefOrRefSig();
			case "ptr":
				return assembly.CorLibTypes.IntPtr.ToTypeDefOrRefSig();
			default:
				var ret = TypeCache.FirstOrDefault(a => a.Key.ToString().StartsWith(str));
				if (ret.Value != null)
					return ret.Value.asTypeSig;
				return null;
		}
	}

	static string GetSlot(string str, byte at = 0)
	{
		return str.Split(new char[] { ' ', ',', '=' }, StringSplitOptions.RemoveEmptyEntries)[at];
	}

	static void SaveValue(LLVMValueRef instr, MethodDefUser method, bool isptr = false)
	{
		bool param = false;
		Parameter parameter = null;

		string slot;
		if (instr.IsAInstruction.Handle != IntPtr.Zero)
			slot = GetSlot(instr.ToString(), 0);
		else
			slot = GetSlot(instr.ToString(), 1);

		foreach (var p in method.Parameters)
			if (p.Name == slot)
			{
				param = true;
				parameter = p;
				break;
			}
		if (param)
		{
			method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Starg, parameter));
		}
		else
		{
			foreach (var l in method.Body.Variables)
			{
				if (l.Name == slot)
				{
					method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Stloc, l));
					return;
				}
			}
			//TypeSig a = instr.IsAAllocaInst.Handle == IntPtr.Zero ? default : TypeSigFromTypeOf(instr.GetOperand(0).TypeOf);
			//var a = instr.IsAAllocaInst.Handle == IntPtr.Zero ? default : instr.GetOperand(0);
			var type = instr.IsAAllocaInst.Handle == IntPtr.Zero ? TypeSigFromString(instr.TypeOf.ToString()) 
				: TypeSigFromTypeOf((LLVMTypeRef)LLVM.GetAllocatedType(instr));
			if (isptr)
				type = new PtrSig(type);
			var local = new Local(type, slot);
			method.Body.Variables.Add(local);
			method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Stloc, local));
			return;
		}
	}

	static TypeSig LoadValue(LLVMValueRef instr, MethodDefUser method, bool asref = false)
	{
		string slot;

		if (instr.IsAInstruction.Handle != IntPtr.Zero)
			slot = GetSlot(instr.ToString(), 0);
		else 
			slot = GetSlot(instr.ToString(), 1);

		if (slot == "ret")
			slot = GetSlot(instr.ToString(), 2);
		else if (slot[0] != '%')
		{
			return LoadConstant(instr, method);
		}

		foreach(var i in method.Parameters)
			if (i.Name == slot)
			{
				if (asref)
					method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldarga, i));
				else
					method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldarg, i));
				return i.Type;
			}

		foreach (var i in method.Body.Variables)
			if (i.Name == slot)
			{
				if (asref)
					method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldloca, i));
				else
					method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldloc, i));
				return i.Type;
			}
		
		var type = instr.TypeOf;
		var loc = new Local(TypeSigFromTypeOf(type), slot);
		method.Body.Variables.Add(loc);
		if (asref)
			method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldloca, loc));
		else
			method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldloc, loc));
		return loc.Type;

		//throw new NotImplementedException();
	}

	static TypeSig LoadConstant(LLVMValueRef instr, MethodDefUser method)
	{
		string checkType;

		bool wtf;

		if (instr.IsAGlobalValue.Handle != IntPtr.Zero)
		{
			if (instr.IsAFunction.Handle != IntPtr.Zero)
			{
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldftn, MethodsLink[instr]));
				return null;
			}
			if (!FieldsLink.ContainsKey(instr) && !instr.IsDeclaration)
			{
				CreateField(instr);
			}
			FieldDefUser field = instr.IsDeclaration ? ResolveDeclare(instr) : FieldsLink[instr];
			var typeOf = TypeSigFromTypeOf(instr.TypeOf);
			if (field.FieldSig.Type != typeOf)
			{
				if (typeOf.GetName() == "IntPtr")
				{
					method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldsfld, field));
					return typeOf;
				}
			}

			method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldsfld, field));
			return field.FieldType;
		}

		if (instr.IsAConstantDataVector.Handle != IntPtr.Zero)
		{
			throw new NotImplementedException();
		}

		
		if (instr.TypeOf.Kind == LLVMTypeKind.LLVMVectorTypeKind)
		{
			var vec = TypeDataFromTypeOf(instr.TypeOf);
			if (instr.IsAConstantAggregateZero.Handle != IntPtr.Zero)
			{
				method.Body.Instructions.Add(ILInstruction.CreateLdcI4((int)vec.CalcSize()));
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Localloc));
				//method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Dup));
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Call, vec.GetVectorZeroInit()));
				return vec.asTypeSig;
			}
			else throw new NotImplementedException();
		}

		string instruction = instr.ToString();
		var firstopcode = GetSlot(instruction, 0);
		if (firstopcode == "ret")
		{
			var op = instr.GetOperand(0);
			if (op.IsAGlobalValue.Handle != IntPtr.Zero)
			{
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldsfld, FieldsLink[op]));
				return assembly.CorLibTypes.IntPtr;
			}
			checkType = GetSlot(instruction, 1);
			wtf = true;
		}
		else
		{
			checkType = firstopcode;
			wtf = false;
		}

		if (instr.TypeOf.ToString() == "metadata")
		{
			method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4,0));
			return null;
		}

		switch(checkType)
		{
			case "i1":
			case "i8":
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, wtf ? (int)instr.GetOperand(0).ConstIntSExt : (int)instr.ConstIntSExt));
				return assembly.CorLibTypes.Byte;
			case "i16":
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, wtf ? (int)instr.GetOperand(0).ConstIntSExt : (int)instr.ConstIntSExt));
				return assembly.CorLibTypes.Int16;
			case "i32":
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, wtf ? (int)instr.GetOperand(0).ConstIntSExt : (int)instr.ConstIntSExt));
				return assembly.CorLibTypes.Int32;
			case "float":
				{
					int a = 0;
					var i = wtf ? instr.GetOperand(0) : instr;
					if (i.IsNull)
						method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_R4, (float)0));
					else
						method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_R4, (float)LLVM.ConstRealGetDouble(i, &a))); 
					return assembly.CorLibTypes.Single;
				}
			case "double":
				{
					int b = 0;
					var i = wtf ? instr.GetOperand(0) : instr;
					if (i.IsNull)
						method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_R8, (double)0));
					else
						method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_R8, LLVM.ConstRealGetDouble(i, &b)));
					return assembly.CorLibTypes.Double;
				}
			case "ptr":
			case "i64":
				method.Body.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I8, wtf ? (long)instr.GetOperand(0).ConstIntSExt : (long)instr.ConstIntSExt));
				return assembly.CorLibTypes.Int64;
			default: throw new NotImplementedException();
		}
	}

	static void SetStaticField_String(CilBody initVarsBody, LLVMValueRef init, TypeDef type, Action writeAccess)
	{
		var chars = init.GetAsString(out _);
		uint sizeofelement = type.Fields[0].GetFieldSize();
		int pos = 0;
		foreach (var field in type.Fields)
		{
			writeAccess();

			initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)chars[(int)pos]));
			initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stfld, field));
			pos++;
		}
	}

	static void SetStaticField_Other(CilBody initVarsBody, LLVMValueRef init, FieldDefUser field, Action writeAccess)
	{
		if (field == null)
			throw new Exception("PANIC!!!");

		if (init.IsAGlobalValue.Handle != IntPtr.Zero)
		{
			if (init.IsAFunction.Handle != IntPtr.Zero)
			{
				writeAccess();
				initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldftn, MethodsLink[init]));
				initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stfld, field));
				return;
			}

			writeAccess();

			if (!FieldsLink.ContainsKey(init))
				CreateField(init);

			initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldsflda, FieldsLink[init])); // maybe without ref?
			initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stfld, field));
			return;
		}

		if (init.IsUndef || init.IsDeclaration)
		{
			if (init.IsDeclaration)
				Console.WriteLine($"WARNING! Init ({init}) is external!!!");

			writeAccess();
			if (init.IsDeclaration)
				initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldsflda, ResolveDeclare(init)));
			else
				initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4_0));
			initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stfld, field));
			return;
		}

		if (init.IsAConstantAggregateZero.Handle != IntPtr.Zero)
			return;

		if (init.IsConstant && init.TypeOf.StructElementTypesCount == 0)
		{
			if (init.IsNull || init.ConstIntSExt != 0)
			{
				writeAccess();
				initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, (int)init.ConstIntSExt));
				if (field.FieldType.IsPointer)
					WriteBySize(initVarsBody, init.TypeOf);
				else
					initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stfld, field));
				return;
			}
			if (init.TypeOf.Kind == LLVMTypeKind.LLVMFloatTypeKind)
			{
				writeAccess();
				var val = init.GetConstRealDouble(out _);
				initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_R4, (float)val));
				if (field.FieldType.IsPointer)
					initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stind_R4));
				else
					initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Stfld, field));
				return;
			}
		}
		if (init.IsAConstantDataArray.Handle != IntPtr.Zero)
		{
			uint opCount = init.TypeOf.ArrayLength;
			var fields = TypeCache[init.TypeOf].inSharp.Fields;
			for (uint i = 0; i < opCount; i++)
			{
				var infield = (FieldDefUser)fields[(int)i];
				var op = init.GetAggregateElement(i);
				SetStaticField_Other(initVarsBody, op, infield, () => { 
					writeAccess();
					//initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldc_I4, offsetcopy));
					//initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Add));
				});
			}
			return;
		}
		if (init.OperandCount > 0)
		{
			uint opCount = (uint)init.OperandCount;
			var fields = TypeCache[init.TypeOf].inSharp.Fields;
			for (uint i = 0; i < opCount; i++)
			{
				var infield = (FieldDefUser)fields[(int)i];
				var op = init.GetOperand(i);
				SetStaticField_Other(initVarsBody, op, infield, () => {
					writeAccess();
					//initVarsBody.Instructions.Add(ILInstruction.Create(OpCodes.Ldflda, infield));
				});
			}
			return;
		}

		throw new NotImplementedException();
	}

	static uint WriteBySize(CilBody inBody, LLVMTypeRef type, int @override = int.MaxValue)
	{
		switch (@override != int.MaxValue ? @override : SizeFromTypeOf(type))
		{
			case 1:
				inBody.Instructions.Add(ILInstruction.Create(OpCodes.Stind_I1)); return 1;
			case 2:
				inBody.Instructions.Add(ILInstruction.Create(OpCodes.Stind_I2)); return 2;
			case 4:
				inBody.Instructions.Add(ILInstruction.Create(OpCodes.Stind_I4)); return 4;
			case 8:
				inBody.Instructions.Add(ILInstruction.Create(OpCodes.Stind_I8)); return 8;
			default:
				throw new NotImplementedException();
		}
	}

	static int SizeFromTypeOf(LLVMTypeRef type)
	{
		var typesig = TypeSigFromTypeOf(type);
		switch(typesig.GetName())
		{
			case "Boolean":
			case "Byte":
				return 1;
			case "Int16":
				return 2;
			case "Single":
			case "Int32":
				return 4;
			case "Double":
			case "IntPtr":
			case "Int64":
				return 8;
			default:
				return SizeFromTypeSig(typesig);
		}
	}

	static int SizeFromTypeSig(TypeSig sig)
	{
		int size = 0;

		var type = sig.ToTypeDefOrRef() as TypeDefUser;
		if (type == null)
			throw new NotImplementedException();

		foreach(var field in type.Fields)
		{
			switch (field.FieldType.GetName())
			{
				case "Boolean":
				case "Byte":
					size += 1; break;
				case "Int16":
					size += 2; break;
				case "Single":
				case "Int32":
					size += 4; break;
				case "Double":
				case "IntPtr":
				case "Int64":
					size += 8; break;
				default:
					size += SizeFromTypeSig(field.FieldType); break;
			}
		}

		return size;
	}

	static FieldDefUser ResolveDeclare(LLVMValueRef declare)
	{
		if (DeclarsLink.ContainsKey(declare))
			return DeclarsLink[declare];

		if (FieldsLink.ContainsKey(declare))
			return FieldsLink[declare];

		//var fld = new FieldDefUser(declare.Name, new FieldSig(TypeSigFromTypeOf(declare.TypeOf)));
		CreateField(declare);
		var fld = FieldsLink[declare];
		DeclarsLink.Add(declare, fld);
		return fld;
	}

	static Dictionary<LLVMValueRef, FieldDefUser> DeclarsLink = new Dictionary<LLVMValueRef, FieldDefUser>();
}
