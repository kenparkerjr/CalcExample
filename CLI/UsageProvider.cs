using CalcCLI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CLI
{
    public class UsageProvider : IUsageProvider
    {
        private readonly MethodBase callingMethod;
        public UsageProvider(MethodBase callingMethod)
        {
            this.callingMethod = callingMethod;
        }
        public CalcCLI.CLIProgram GetUsage()
        {
            return (CLIProgram)callingMethod.GetCustomAttribute<CLIProgram>();
        }
    }
}
