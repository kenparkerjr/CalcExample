using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class MathOptions : IMathOptions
    {
        private readonly bool shouldDenyNegative;
        private readonly long largestNumber;
        private readonly int? maximumNumbers;
        public MathOptions(bool shouldDenyNegative=true, long largestNumber=1000, int? maximumNumbers=null)
        {
            this.shouldDenyNegative = shouldDenyNegative;
            this.largestNumber = largestNumber;
            this.maximumNumbers = maximumNumbers; 
        }
        public bool ShouldDenyNegative { get => shouldDenyNegative; }
        public long LargestNumber { get => largestNumber; }
        public int? MaximumNumbers { get => maximumNumbers;  }
    }
}
