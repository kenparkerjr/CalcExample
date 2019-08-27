﻿using System;
using System.Collections.Generic;
using System.Text;
using Calc;
using Xunit;

namespace TestCalc
{
    public class TestCalcService
    {
        private CalcService CreateCalc()
        {
            var mockMath = new Moq.Mock<IMath>();
            mockMath.Setup(x => x.AddNumbers(new long[] { })).Returns(0);
            mockMath.Setup(x => x.AddNumbers(new long[] { 2, 2, 2 })).Returns(6);
        
            var mockTokenizer = new Moq.Mock<ITokenizer>();
            mockTokenizer.Setup(x => x.Parse("")).Returns(new long[] { });
            mockTokenizer.Setup(x => x.Parse("2,2,2")).Returns(new long[] { 2, 2, 2 });
            return new CalcService(mockMath.Object, mockTokenizer.Object);
        }
        [Theory]
        [InlineData("2,2,2", 6)]
        [InlineData("",0)]
        public void TestAddNumbers(string expression, long expectedResult)
        {
            var calc = CreateCalc();
            long actualResult = calc.RunExpression(expression);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData("2,2,2", -2)]
        [InlineData("", 0)]
        public void TestSubtractNumbers(string expression, long expectedResult)
        {
            var calc = CreateCalc();
            long actualResult = calc.RunExpression(expression);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData("2,2,2", 8)]
        [InlineData("", 0)]
        public void TestMultiplyNumbers(string expression, long expectedResult)
        {
            var calc = CreateCalc();
            long actualResult = calc.RunExpression(expression);
            Assert.Equal(expectedResult, actualResult);
        }
        [Theory]
        [InlineData("8,2,2", 2)]
        [InlineData("", 0)]
        public void TestDivideNumbers(string expression, long expectedResult)
        {
            var calc = CreateCalc();
            long actualResult = calc.RunExpression(expression);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
