using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLToIL.RedirFunctions.Sharped;
public class ImHateExceptions : IRedirs
{
	public bool RedirField(FieldDefUser field, CilBody inithere)
	{
		return false;
	}

	public bool RedirThis(MethodDefUser method)
	{
		if (method.Name.Contains("std") && method.Name.Contains("error"))
		{
			method.Body = new dnlib.DotNet.Emit.CilBody();
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
			return true;
		}

		return false;
	}
}
