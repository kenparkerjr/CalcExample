using Calc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CalcCLI
{
    public class CalcApplication
    {
        private CLI cli; 
        private ArgumentExpressionReader argumentExpression;
        private readonly ConsoleHelper consoleHelper;
        private CalcService calcService;
        public CalcApplication()
        {
            consoleHelper = new ConsoleHelper();
        }
        [CLIProgram("Reads a list of numbers and calulates the result " +
            "based on the given operator.", "0.0.1")]
        public void Run(string[] args)
        {



            cli = new CLI(args);
            cli.Run();


            var arguments = new CLI(args).ReadArguments<CalcArguments>();
            argumentExpression = new ArgumentExpressionReader(arguments);


            calcService = new CalcService(new MathOptions(arguments.ShouldDenyNegative, arguments.LargestNumber, arguments.MaximumNumbers));

            MathExpressionResult mathExpression = null;
            if (argumentExpression.HasArgumentExpression())
                mathExpression = argumentExpression.Get();
            else
                mathExpression = GetExpressionFromConsole();                              

            var result = calcService.RunExpression(mathExpression.Op, mathExpression.Expression);

            WriteResult(mathExpression, result);
        }
        public void WriteResult(MathExpressionResult mathExpression, ExpressionResult result)
        {
            Console.WriteLine("Expression: {0}", mathExpression.Expression);
            Console.WriteLine("Results:");

            string valuesString = String.Join<long>(mathExpression.OpChar, result.Values.ToArray());
            Console.WriteLine("{0}={1}", valuesString, result.Result);
        }
        MathExpressionResult GetExpressionFromConsole()
        {
            string op = String.Empty;
            
            Console.Write("operator(+ | - | * | /) ? ");
            op = Console.ReadLine();

            Console.WriteLine("Expression (//[delimiter][delimiter]*{EOL}{delimited list})");
            string input = consoleHelper.ReadUntilCtrlC();

            char opChar = op.TrimEnd()[0];
            return new MathExpressionResult(EnumHelper.MathOperatorFromString(op), opChar, input);

        }
    }
}
