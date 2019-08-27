using CLI;
using System;

namespace CalcCLI
{
    class Program 
    {
        [CLIProgram("Reads a list of numbers and calulates the result " +
                    "based on the given operator.", "0.0.1")]
        public static void Main(string[] args)
        {
            var cli = new CLI(args);
            cli.Run();
            var arguments = new CLI(args).ReadArguments<CalcArguments>();


        }
    }
}
