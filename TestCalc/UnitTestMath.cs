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
        private readonly TestObjects.MathOptionsProvider optionsProvider;
        public TestMath()
        {
            optionsProvider = new TestObjects.MathOptionsProvider();
        }
        [Theory]
        [InlineData("", new long[] { -100, 0, 100, -9, 0 }, new long[] { -100, -9 })]
        [InlineData("", new long[] { -1 }, new long[] { -1 })]
        public void TestShouldDenyNegativeNumbers(string s, long[] numbers, long[] expectedErrors)
        {
            var math = new Calc.Math(optionsProvider.MockOptions(shouldDenyNegative: true));
            var exception = Record.Exception(() => math.Add(numbers));
            Assert.IsType<NegativeNumbersException>(exception);
            Assert.Equal(expectedErrors, ((NegativeNumbersException)exception).NegativeNumbers);
        }
        [Theory]
        [InlineData(1000, new long[] { 4, 1001, 4 }, 8)]
        public void TestValidateShouldIgnoreLargeNumbers(int largestNumber, long[] numbers, long expectedResult)
        {
            var math = new Calc.Math(optionsProvider.MockOptions(largestNumber: largestNumber));
            var actualResult = math.Add(numbers);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData(2, new long[] { 1, 1, 1 })]
        [InlineData(5, new long[] { 1, 1, 1, 1, 1, 1 })]
        [InlineData(0, new long[] { 1 })]
        public void TestValidateMaximumNumberThrowsException(int? maximumNumbers, long[] numbers)
        {
            var math = new Calc.Math(optionsProvider.MockOptions(maximumNumbers: maximumNumbers));
            var exception = Record.Exception(() => math.ValidateNumbers(numbers));
            Assert.IsType<Calc.MaximumNumberExeption>(exception);
        }
        [Theory]
        [InlineData(4, new long[]{2,2})]
        public void TestAdd(long expectedResult, long[] values)
        {
            var math = new Calc.Math(optionsProvider.MockOptions());
            long actualResult = math.Add(values);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData(4, new long[] { 8, 4 })]
        public void TestSubtract(long expectedResult, long[] values)
        {
            var math = new Calc.Math(optionsProvider.MockOptions());
            long actualResult = math.Subtract(values);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData(8, new long[] { 2,2,2 })]
        public void TestMultiply(long expectedResult, long[] values)
        {
            var math = new Calc.Math(optionsProvider.MockOptions());
            long actualResult = math.Multiply(values);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData(2, new long[] { 8, 2, 2 })]
        public void TestDivide(long expectedResult, long[] values)
        {
            var math = new Calc.Math(optionsProvider.MockOptions());
            long actualResult = math.Divide(values);
            Assert.Equal(expectedResult, actualResult);
        }


    }
}
