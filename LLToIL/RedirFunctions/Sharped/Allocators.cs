using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLToIL.RedirFunctions.Sharped;
public unsafe class Allocators : IRedirs
{
	TypeDef thistype;

	public Allocators()
	{
		thistype = RedirManager.ThisAssembly.Types.First(t => t.Name == "Allocators");
	}

	public bool RedirThis(MethodDefUser method)
	{
		if (method.Name == "??_U@YAPAXI@Z" || method.Name == "??2@YAPAXI@Z")
		{
			method.Body = thistype.Methods.First(m => m.Name == "CPPAlloc").Body;
			method.Name = "NEW";
			return true;
		}
		else if (method.Name == "??_V@YAXPAX@Z")
		{
			method.Body = thistype.Methods.First(m => m.Name == "CPPFree").Body;
			method.Name = "DELETE";
			return true;
		}
		else if (method.Name == "??3@YAXPAXI@Z" || method.Name == "??3@YAXPAX@Z")
		{
			method.Body = thistype.Methods.First(m => m.Name == "CPPDelete").Body;
			method.Name = "DELETE";
			return true;
		}
		return false;
	}

	public static void* CPPAlloc(int size)
	{
		return NativeMemory.Alloc((nuint)size);
	}

	public static void CPPFree(void* ptr)
	{
		NativeMemory.Free(ptr);
	}

	public static void CPPDelete(void* ptr, int count)
	{
		NativeMemory.Free(ptr);
	}

	public bool RedirField(FieldDefUser field, CilBody inithere)
	{
		return false;
	}
}
