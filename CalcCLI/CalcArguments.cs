using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcCLI
{
    public class CalcArguments 
    {
        [CLIArgument("maxnumbers", "{n} Sets the maximum numbers allowed to calculate.")]
        public int MaximumNumbers { get; set; }

        [CLIArgument("largestnumber", "{n} Sets the largest number allowed in the input.")]
        public int LargestNumber { get; set; }

        [CLIArgument("denynegative", "{Y | N } If Y negative numbers will produce an error.")]
        public bool ShouldDenyNegative { get; set; }
        [CLIArgument("add", "{expression} The given expression will be added")]
        public string AddExpression { get; set; }
        [CLIArgument("subtract", "{expression} The given expression will be subtracted")]
        public string SubtractExpression { get; internal set; }
        [CLIArgument("multiply", "{expression} The given expression will be multiplied")]
        public string MultiplyExpression { get; internal set; }
        [CLIArgument("divide", "{expression} The given expression will be divided")]
        public string DivideExpression { get; internal set; }
    }
}
