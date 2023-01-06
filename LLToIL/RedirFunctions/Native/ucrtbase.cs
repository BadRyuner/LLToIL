using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLToIL.RedirFunctions.Native;
public class ucrtbase : IRedirs
{
	ModuleRefUser ucrtbasedll = new ModuleRefUser(Program.assembly, "ucrtbase.dll");

	bool init = false;

	public bool RedirThis(MethodDefUser method)
	{
		if (!init)
		{
			methods = File.ReadAllLines("NativeExports/ucrtbase.txt");
			init = true;
		}

		if (methods.Contains(method.Name.ToString()))
		{
			MarkAsUcrtbaseMethod(method);
			return true;
		}

		return false;
	}

	void MarkAsUcrtbaseMethod(MethodDefUser method)
	{
		method.ImplMap = new ImplMapUser(ucrtbasedll, method.Name, PInvokeAttributes.SupportsLastError | PInvokeAttributes.CallConvCdecl);
		method.ImplAttributes |= MethodImplAttributes.PreserveSig;
	}

	public bool RedirField(FieldDefUser field, CilBody inithere)
	{
		return false;
	}

	string[] methods = null;
}
