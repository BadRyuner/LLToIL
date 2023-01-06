using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using LLVMSharp.Interop;

namespace LLToIL;
public class TypeData
{
	public TypeDefUser inSharp;
	public TypeSig asTypeSig;
	public LLVMTypeRef llvmType;

	uint cachedSize = 0;
	bool iscached = false;

	public TypeData(LLVMTypeRef typeref, TypeDefUser insharp)
	{
		llvmType = typeref; inSharp = insharp; asTypeSig = insharp.ToTypeSig();
	}

	public uint CalcSize(int depth = 0)
	{
		if (iscached)
			return cachedSize;

		if (depth > 15)
			return 8;

		uint size = 0;
		foreach (var field in inSharp.Fields)
		{
			if (field.FieldType.IsPrimitive)
			{
				var fsize = field.GetFieldSize();
				if (fsize == 0)
					throw new NotImplementedException();
				size += fsize;
			}
			else
				size += Program.TypeCache.Values.First(t => t.asTypeSig == asTypeSig).CalcSize(depth + 1);
		}

		cachedSize = size;
		iscached = true;
		return size;
	}

	public MethodDef GetVectorZeroInit()
	{
		if (llvmType.VectorSize == 0) throw new Exception("Wrong call!");

		if (ZeroInit != null) return ZeroInit;

		var ptr = new PtrSig(asTypeSig);
		var sig = MethodSig.CreateStatic(asTypeSig, ptr);
		var method = new MethodDefUser("zeroinit", sig);

		method.Access = MethodAttributes.Public;
		method.IsStatic = true;

		var body = new CilBody();
		method.Body = body;

		var element = inSharp.Fields[0].FieldType.GetName();

		foreach(var f in inSharp.Fields)
		{
			body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4_0));
			body.Instructions.Add(Instruction.Create(OpCodes.Stfld, f));
		}

		body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
		body.Instructions.Add(Instruction.Create(OpCodes.Ret));

		ZeroInit = method;
		return method;
	}

	MethodDef ZeroInit;
}
