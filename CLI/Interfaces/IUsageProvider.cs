using CalcCLI;

namespace CLI
{
    public interface IUsageProvider
    {
        CLIProgram GetUsage();
    }
}