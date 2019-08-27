using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using CLI;

namespace CalcCLI
{
    public class CLI
    {
        public CLI(string[] args)
        {
            CommandParser = new CommandParser();
            ArgumentReader = new ArgumentReader();
            rawCommands = CommandParser.Parse(args);
        }
        public ICommandParser CommandParser { get; set;}
        public IArgumentReader ArgumentReader { get; set; }
        public IConsoleWriter ConsoleWriter { get; set; }
        private MethodBase callingMethod;


        private IDictionary<string, string> rawCommands;
      
        public void Run()
        {

            callingMethod = new StackTrace().GetFrame(1).GetMethod();

            ConsoleWriter = new ConsoleWriter(new UsageProvider(callingMethod));


            ConsoleWriter.WriteUsage();
            ConsoleWriter.WriteAllArguments(ArgumentReader);




        }
        public T ReadArguments<T>() where T: new()
        {
            return ArgumentReader.Read<T>(rawCommands);
        }
    }
}
