using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Exceptions
{
    public class InvalidHeaderException : Exception
    {
        const string ERROR_MESSAGE = "Ivalid header - should start with // and end with a new line";
        public InvalidHeaderException() : base(ERROR_MESSAGE)
        { }
    }
}
