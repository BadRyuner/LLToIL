using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLToIL.RedirFunctions;
public static class RedirManager
{
	public static List<IRedirs> redirs = new List<IRedirs>();

	static RedirManager()
	{
		redirs.Add(new Sharped.LLVMRedir());
		redirs.Add(new Sharped.Allocators());
		redirs.Add(new Sharped.ConsoleRedir());
		redirs.Add(new Sharped.ImHateExceptions());

		redirs.Add(new Native.ucrtbase());
		redirs.Add(new Native.kernel32());
	}

	public static void RedirThis(MethodDefUser user)
	{
		foreach(var i in redirs)
			if (i.RedirThis(user))
			{
				if (user.HasBody)
					user.Attributes ^= MethodAttributes.PinvokeImpl;
				return;
			}

		Console.WriteLine($"Cant redirect {user.FullName} method!");
	}

	public static bool RedirField(FieldDefUser field, CilBody inithere)
	{
		foreach (var i in redirs)
			if (i.RedirField(field, inithere))
			{
				return true;
			}

		Console.WriteLine($"Cant redirect {field.FullName} field!");
		return false;
	}

	public static ModuleDef ThisAssembly = AssemblyDef.Load(typeof(RedirManager).Assembly.Location).Modules.First();
}
