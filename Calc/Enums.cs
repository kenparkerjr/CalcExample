using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public enum MathOperator
    {
        Add,
        Subtract,
        Divide,
        Multiply
    }
    public static class EnumHelper
    {
        public static MathOperator MathOperatorFromString(string op)
        {
            char ch = op[0];
            switch(ch)
            {
                case '+':
                    return MathOperator.Add;
                case '-':
                    return MathOperator.Subtract;
                case '*':
                    return MathOperator.Multiply;
                case '/':
                    return MathOperator.Divide;
                default:
                    return MathOperator.Add;
            }
        }
    }
}
