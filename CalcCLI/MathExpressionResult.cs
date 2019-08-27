using Calc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcCLI
{
    public class MathExpressionResult
    {
        private readonly MathOperator op;
        private readonly string expression;
        private readonly char opChar;
        public MathExpressionResult(MathOperator op, char opChar, string expression)
        {
            this.op = op;
            this.opChar = opChar;
            this.expression = expression;
        }
        public MathOperator Op { get => op; }
        public char OpChar { get => opChar;  } 
        public string Expression { get => expression; }
    }
}
