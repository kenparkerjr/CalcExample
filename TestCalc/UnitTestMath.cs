using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCalc
{
    public class TestMath
    {
        //[Theory]
        //[InlineData("1,-100,100", new long[] { -100 })]
        //public void TestShouldDenyNegativeNumbers(string s, long[] expectedErrors)
        //{
        //    var exception = Record.Exception(() => tokenizer.Parse(s, ParseOptions.Create(shouldDenyNegativeNumbers: true)));
        //    Assert.IsType<NegativeNumbersException>(exception);
        //    Assert.Equal(expectedErrors, ((NegativeNumbersException)exception).NegativeNumbers);
        //}
        //[Theory]
        //[InlineData("2,1001,6", new long[] { 2, 0, 6 })]
        //public void TestShouldIgnoreLargeNumbers(string s, long[] expected)
        //{
        //    var tokens = tokenizer.Parse(s, ParseOptions.Create(upperBound: 1000));
        //    Assert.Equal(tokens, expected);
        //}
        //[Theory]
        //[InlineData("1,2,3")]
        //public void TestMaximumNumber(string s)
        //{
        //    var exception = Record.Exception(() => tokenizer.Parse(s, ParseOptions.Create(maximumNumbers: 2)));
        //    Assert.IsType<MaximumNumberExeption>(exception);
        //}
    }
}
