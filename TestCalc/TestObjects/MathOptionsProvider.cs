using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCalc.TestObjects
{
    public class MathOptionsProvider
    {
        public IMathOptions MockOptions(int? maximumNumbers = int.MaxValue, long largestNumber = long.MaxValue, bool shouldDenyNegative = false)
        {
            var options = new Moq.Mock<IMathOptions>();
            options.Setup(x => x.MaximumNumbers).Returns(maximumNumbers);
            options.Setup(x => x.LargestNumber).Returns(largestNumber);
            options.Setup(x => x.ShouldDenyNegative).Returns(shouldDenyNegative);
            return options.Object;
        }
    }
}
