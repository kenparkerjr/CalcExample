using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Calc
{
    public class NegativeNumbersException : Exception
    {
        public  long[] NegativeNumbers { get; private set;}
        public const string ERROR_MESSAGE = "Negative numbers are not supported. ";
        public NegativeNumbersException(IEnumerable<long> negativeNumbers) : base(GetErrorMessage(negativeNumbers))
        {
            NegativeNumbers = new List<long>(negativeNumbers).ToArray();         
        }
        static string GetErrorMessage(IEnumerable<long> numbers)
        {
            return ERROR_MESSAGE + String.Join<long>(' ', numbers);
        }
    }
}
