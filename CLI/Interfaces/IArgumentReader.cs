using System.Collections.Generic;

namespace CalcCLI
{
    public interface IArgumentReader
    {
        T Read<T>(IDictionary<string, string> rawCommands) where T : new();
        IEnumerable<CLIArgument> GetAllArguments();
    }
}