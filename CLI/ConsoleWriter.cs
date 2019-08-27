using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CalcCLI
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly MethodBase callingMethod;
        public ConsoleWriter(MethodBase callingMethod)
        {
            this.callingMethod = callingMethod;
        }
        public void WriteAllArguments(IArgumentReader reader)
        {
            foreach (var a in reader.GetAllArguments())
                Console.WriteLine("\t{0}\t {1}", a.Command, a.Help);
        }

        public void WriteUsage()
        {
            var usage = (CLIProgram)callingMethod.GetCustomAttribute<CLIProgram>();
            Console.WriteLine(usage.Usage);
            Console.WriteLine();
        }
    }
}
