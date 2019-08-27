using Calc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcCLI
{
    public class ArgumentExpressionReader
    {
        private readonly CalcArguments arguments;
        public ArgumentExpressionReader(CalcArguments arguments)
        {
            this.arguments = arguments;
        }
        public bool HasArgumentExpression()
        {
            return Get() != null;
        }
        public MathExpressionResult Get()
        {
            if (String.IsNullOrWhiteSpace(this.arguments.AddExpression) == false)
                return new MathExpressionResult(MathOperator.Add, '+', this.arguments.AddExpression);
            if (String.IsNullOrWhiteSpace(this.arguments.SubtractExpression) == false)
                return new MathExpressionResult(MathOperator.Subtract, '-', this.arguments.AddExpression);
            if (String.IsNullOrWhiteSpace(this.arguments.MultiplyExpression) == false)
                return new MathExpressionResult(MathOperator.Multiply, '*', this.arguments.AddExpression);
            if (String.IsNullOrWhiteSpace(this.arguments.DivideExpression) == false)
                return new MathExpressionResult(MathOperator.Divide, '/',  this.arguments.AddExpression);
            return null;
        }
    }
   
}
