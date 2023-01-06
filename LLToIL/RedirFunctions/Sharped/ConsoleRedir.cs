using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LLToIL.RedirFunctions.Sharped;
public unsafe class ConsoleRedir : IRedirs
{
	TypeDef thistype;

	public ConsoleRedir()
	{
		thistype = RedirManager.ThisAssembly.Types.First(t => t.Name == "ConsoleRedir");
	}

	public bool RedirField(FieldDefUser field, CilBody inithere)
	{
		return false;
	}

	public bool RedirThis(MethodDefUser method)
	{
		switch(method.Name)
		{
			/* // for example
			case "puts":
				Program.assembly.Import(typeof(Console));
				Program.assembly.Import(typeof(Console).GetMethod("Write", new Type[] { typeof(char) }));
				method.Body = thistype.Methods.First(m => m.Name == "PutsRedir").Body;
				return true;
				*/
			default:
				return false;
		}

		return false;
	}

	/* // for example
	private static int PutsRedir(byte* chars)
	{
		for(byte* c = chars; *c != (byte)'\0'; c++)
			Console.Write((char)*c);

		Console.Write('\n');

		return 0;
	}
	*/
}
