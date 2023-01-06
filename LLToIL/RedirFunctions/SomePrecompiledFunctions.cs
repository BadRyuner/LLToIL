using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LLToIL.RedirFunctions;
public unsafe static class SomePrecompiledFunctions
{
	public static unsafe int CStyleMain(string[] args)
	{
		if (args.Length == 0)
			return DummyMain(0, (byte**)0);

		byte** alloced = stackalloc byte*[args.Length];
		for(int i = 0; i < args.Length; i++)
		{
			byte[] picked = ASCIIEncoding.ASCII.GetBytes(args[i]);
			fixed (byte* parg = picked)
				alloced[i] = parg;
		}
		return DummyMain(args.Length, alloced);
	}

	private static int DummyMain(int argc, byte** argv)
	{
		return 0;
	}
}
