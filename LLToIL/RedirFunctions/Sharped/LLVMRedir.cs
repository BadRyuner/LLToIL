using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace LLToIL.RedirFunctions.Sharped;
public class LLVMRedir : IRedirs
{
	TypeDef thistype;

	public LLVMRedir()
	{
		thistype = RedirManager.ThisAssembly.Types.First(t => t.Name == "LLVMRedir");
	}

	public bool RedirThis(MethodDefUser method)
	{
		if (method.Name.StartsWith("llvm"))
		{
			method.Body = new CilBody();

			var splitted = method.Name.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);

			if (splitted[1] == "smax")
			{
				LLVMMethods.Add(method);
				EmitSmax(method.Body);
				return true;
			}
			else if (splitted[1] == "umax")
			{
				LLVMMethods.Add(method);
				EmitUmax(method.Body);
				return true;
			}
			else if (splitted[1] == "memcpy")
			{
				LLVMMethods.Add(method);
				if (splitted[4] == "i64")
					method.Body = thistype.Methods.First(m => m.Name == "memcopylong").Body;
				else if (splitted[4] == "i32")
					method.Body = thistype.Methods.First(m => m.Name == "memcopyint").Body;
				else throw new NotImplementedException();
				return true;
			}
			else if (splitted[1] == "memset")
			{
				if (splitted[2] == "p0" && splitted[3] == "i64")
				{
					LLVMMethods.Add(method);
					method.Body = thistype.Methods.First(m => m.Name == "memsetlong").Body;
					return true;
				}
			}

			if (method.Name == "llvm.stacksave")
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4_0));
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				return true;
			}
			else if (method.Name == "llvm.stackrestore")
			{
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				return true;
			}

			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
			LLVMMethods.Add(method);
			return true;
		}
		return false;
	}

	void EmitSmax(CilBody body)
	{
		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
		body.Instructions.Add(Instruction.Create(OpCodes.Conv_U));
		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
		body.Instructions.Add(Instruction.Create(OpCodes.Conv_U));
		body.Instructions.Add(Instruction.Create(OpCodes.Cgt));
		var retfirst = Instruction.Create(OpCodes.Ldarg_0);
		body.Instructions.Add(Instruction.Create(OpCodes.Brtrue_S, retfirst));
		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
		body.Instructions.Add(Instruction.Create(OpCodes.Ret));
		body.Instructions.Add(retfirst);
		body.Instructions.Add(Instruction.Create(OpCodes.Ret));
	}

	void EmitUmax(CilBody body)
	{
		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
		body.Instructions.Add(Instruction.Create(OpCodes.Cgt));
		var retfirst = Instruction.Create(OpCodes.Ldarg_0);
		body.Instructions.Add(Instruction.Create(OpCodes.Brtrue_S, retfirst));
		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_1));
		body.Instructions.Add(Instruction.Create(OpCodes.Ret));
		body.Instructions.Add(retfirst);
		body.Instructions.Add(Instruction.Create(OpCodes.Ret));
	}

	static unsafe void memsetlong(IntPtr dest, byte fill, long length, bool @volatile)
	{
		byte* destp = (byte*)dest.ToPointer();
		while (length > 0)
		{
			*destp = fill;
			destp++;
			length--;
		}
	}

	static unsafe void memcopylong(IntPtr dest, IntPtr src, long length, bool @volatile)
	{
		byte* srcp = (byte*)src.ToPointer();
		byte* destp = (byte*)dest.ToPointer();
		while (length > 0)
		{
			*destp = *srcp;
			srcp++;
			destp++;
			length--;
		}
	}

	static unsafe void memcopyint(IntPtr dest, IntPtr src, int length, bool @volatile)
	{
		byte* srcp = (byte*)src.ToPointer();
		byte* destp = (byte*)dest.ToPointer();
		while(length > 0)
		{
			*destp = *srcp;
			srcp++;
			destp++;
			length--;
		}
	}

	public bool RedirField(FieldDefUser field, CilBody inithere)
	{
		return false;
	}

	public static List<MethodDefUser> LLVMMethods = new List<MethodDefUser>();
}
