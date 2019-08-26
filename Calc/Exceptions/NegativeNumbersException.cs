using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class NegativeNumbersException : Exception
    {
        public  long[] NegativeNumbers { get; private set;}
        public const string ERROR_MESSAGE = "Negative numbers are not supported.";
        public NegativeNumbersException(string message, IEnumerable<long> negativeNumbers) : base(ERROR_MESSAGE)
        {
            NegativeNumbers = new List<long>(negativeNumbers).ToArray();

        }
    }
}
