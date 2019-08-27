using System.Collections.Generic;

namespace CalcCLI
{
    public interface IConsoleWriter
    {
        void WriteUsage();
        void WriteAllArguments(IArgumentReader reader);
    }
}