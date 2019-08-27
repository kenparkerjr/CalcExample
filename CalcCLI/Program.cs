using Calc;
using CLI;
using System;
using System.Linq;
using System.Text;

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

            CalcService calc = new CalcService();
            ExpressionResult result;

            char op ;
            if(String.IsNullOrEmpty(arguments.AddExpression) == false)
            {
               result = calc.RunExpression(arguments.AddExpression);
                op = '+';
            }
            else
            {
                Console.WriteLine("Input Expression: //{delimiter}{EOL}{list of numbers}");
                var sb = new StringBuilder();
                string input;
                while (!string.IsNullOrEmpty(input = Console.ReadLine()))
                    sb.Append(input + '\n');
                result = calc.RunExpression(sb.ToString());
                op = '+';
            }
            Console.WriteLine("Results:");
            string valuesString = String.Join<long>(op, result.Values.ToArray());
            Console.WriteLine("{0}={1}", valuesString, result.Result);


        }
    }
}
