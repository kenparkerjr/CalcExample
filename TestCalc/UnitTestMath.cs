using Calc;
using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCalc
{
    public class TestMath
    {
        private IMathOptions MockOptions(int? maximumNumbers=int.MaxValue, long largestNumber=long.MaxValue, bool shouldDenyNegative=false)
        {
            var options = new Moq.Mock<IMathOptions>();
            options.Setup(x => x.MaximumNumbers).Returns(maximumNumbers);
            options.Setup(x => x.LargestNumber).Returns(largestNumber);
            options.Setup(x => x.ShouldDenyNegative).Returns(shouldDenyNegative);
            return options.Object;
        }
        [Theory]
        [InlineData("", new long[] { -100, 0, 100, -9, 0 }, new long[] { -100, -9} )]
        [InlineData("", new long[] { -1 }, new long[] { -1 })]
        public void TestShouldDenyNegativeNumbers(string s, long[] numbers, long[] expectedErrors)
        {
            var math = new Calc.Math(MockOptions(shouldDenyNegative: true));

            var exception = Record.Exception(() => math.AddNumbers(numbers));
            Assert.IsType<NegativeNumbersException>(exception);
            Assert.Equal(expectedErrors, ((NegativeNumbersException)exception).NegativeNumbers);
        }
        [Theory]
        [InlineData(1000, new long[] { 4, 1001, 4 }, 8)]
        public void TestValidateShouldIgnoreLargeNumbers(int largestNumber, long[] numbers, long expectedResult)
        {        
            var math = new Calc.Math(MockOptions(largestNumber: largestNumber));

            var actualResult = math.AddNumbers(numbers);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData(2,new long[] { 1, 1, 1 })]
        [InlineData(5, new long[] { 1, 1, 1, 1,1,1 })]
        [InlineData(0, new long[] { 1 })]
        public void TestValidateMaximumNumberThrowsException(int? maximumNumbers, long[] numbers)
        {
            var math = new Calc.Math(MockOptions(maximumNumbers: maximumNumbers));

            var exception = Record.Exception(() => math.ValidateNumbers(numbers));
            Assert.IsType<Calc.MaximumNumberExeption>(exception);
        }
        
       
    }
}
