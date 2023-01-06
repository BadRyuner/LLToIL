using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;

namespace LLToIL.MagicArea;
public static class Optimizations
{

	public static void TryOptimizeThis(MethodDefUser target) // TODO
	{
		target.Body.OptimizeBranches();
		target.Body.OptimizeMacros();
	}
}
