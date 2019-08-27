using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Calc
{
    public class CalcService
    {
        private readonly IMath math;
        private readonly ITokenizer tokenizer;
        public CalcService() : this(new Math(), new Tokenizer())
        {

        }
        public CalcService(IMath math, ITokenizer tokenizer)
        {
            this.math = math;
            this.tokenizer = tokenizer;
        }
        public ExpressionResult RunExpression(string expression)
        {
            var values = tokenizer.Parse(expression);
            long result = math.AddNumbers(values.ToArray());
            return new ExpressionResult(result, values.ToArray());
        }
    }
}
