using CLI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CalcCLI
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly TextWriter writer;
        private readonly IUsageProvider usageProvider;
        public ConsoleWriter(IUsageProvider usageProvider) : this(Console.Out, usageProvider)
        {
            
        }
        public ConsoleWriter(TextWriter writer, IUsageProvider usageProvider)
        {
            this.writer = writer;
            this.usageProvider = usageProvider;
        }

    
        public void WriteAllArguments(IArgumentReader reader)
        {
            foreach (var a in reader.GetAllArguments())
                writer.WriteLine("\t{0}\t {1}", a.Command, a.Help);
        }

        public void WriteUsage()
        {
            var usage = usageProvider.GetUsage();
            writer.WriteLine(usage.Usage);
            writer.WriteLine();
        }
    }
}
