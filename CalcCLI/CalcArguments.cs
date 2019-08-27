﻿using System;
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
        public bool ShouldDenyNegativeNumbers { get; set; }
        [CLIArgument("add", "{expression} The given expression will be added")]
        public string AddExpression { get; set; }
    }
}
