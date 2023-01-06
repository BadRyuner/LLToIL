using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLToIL.RedirFunctions.Native;
public class kernel32 : IRedirs
{
	ModuleRefUser kernel32dll = new ModuleRefUser(Program.assembly, "kernel32.dll");

	bool init = false;

	public bool RedirThis(MethodDefUser method)
	{
		if (!init)
		{
			methods = File.ReadAllLines("NativeExports/kernel32.txt");
			init = true;
		}

		if (methods.Contains(method.Name.ToString()))
		{
			MarkAsKernelMethod(method);
			return true;
		}

		return false;
	}

	void MarkAsKernelMethod(MethodDefUser method)
	{
		method.ImplMap = new ImplMapUser(kernel32dll, method.Name, PInvokeAttributes.SupportsLastError | PInvokeAttributes.CallConvCdecl);
		method.ImplAttributes |= MethodImplAttributes.PreserveSig;
	}

	public bool RedirField(FieldDefUser field, CilBody inithere)
	{
		return false;
	}

	string[] methods = null;
}
