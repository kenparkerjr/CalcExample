using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Calc.Interfaces;

namespace Calc
{
    public class CalcService
    {
        private readonly IMath math;
        private readonly ITokenizer tokenizer;
        private readonly IMathOptions options;
        public CalcService(IMathOptions options) : this(new Math(options), new Tokenizer())
        {

        }
        public CalcService(IMath math, ITokenizer tokenizer)
        {
            this.math = math;
            this.tokenizer = tokenizer;
        }
        public ExpressionResult RunExpression(MathOperator op, string expression)
        {
            long result = 0;
            var values = tokenizer.Parse(expression);
            switch(op)
            {
                case MathOperator.Add:
                    result = math.Add(values.ToArray());
                    break;
                case MathOperator.Subtract:
                    result = math.Subtract(values.ToArray());
                    break;
                case MathOperator.Divide:
                    result = math.Divide(values.ToArray());
                    break;
                case MathOperator.Multiply:
                    result = math.Multiply(values.ToArray());
                    break;
            }        
            return new ExpressionResult(result, values.ToArray());
        }
    }
}
