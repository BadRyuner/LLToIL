using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace LLToIL.RedirFunctions;
public interface IRedirs
{
	public bool RedirThis(MethodDefUser method);

	public bool RedirField(FieldDefUser field, CilBody inithere);
}
