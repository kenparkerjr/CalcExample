using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class MaximumNumberExeption : Exception
    {
        public const string ERROR_MESSAGE = "Exceeded maximum number of values. Expected {0} but got {1}";
        public MaximumNumberExeption(int expected, int actual) : base(String.Format(ERROR_MESSAGE, expected, actual))
        {

        }
    }
}
