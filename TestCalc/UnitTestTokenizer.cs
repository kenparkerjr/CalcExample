using System;
using Xunit;
using Calc;
namespace TestCalc
{
    public class UnitTestTokenizer
    {
        public Tokenizer tokenizer;
        public UnitTestTokenizer()
        {
            tokenizer = new Tokenizer();
        }
        [Theory]
        [InlineData("3,3", new long[] { 3, 3 })]
        public void TestSupportsTwoNumbers(string s, long[] expected)
        {
            var tokens = tokenizer.Parse(s, ParseOptions.Create(maximumNumbers:2));
            Assert.Equal(tokens, expected);
        }
        [Theory]
        [InlineData("1,2,3")]
        public void TestMaximumNumber(string s)
        {
            var exception = Record.Exception(()=> tokenizer.Parse(s, ParseOptions.Create(maximumNumbers: 2)));
            Assert.IsType<MaximumNumberExeption>(exception);
        }
        [Theory]
        [InlineData("5,tytyt", new long[] { 5, 0 })]
        public void TestInvalidMissingNumbers(string s, long[] expected)
        {
            var tokens = tokenizer.Parse(s);
            Assert.Equal(tokens, expected);
        }
        [Theory]
        [InlineData("1,2,3,4", new long[] { 1, 2, 3, 4 })]
        public void TestSupportsMoreThanTwoNumbers(string s, long[] expected)
        {
            var tokens = tokenizer.Parse(s);
            Assert.Equal(tokens, expected);
        }
        [Theory]
        [InlineData("1\n2", new long[] { 1, 2 })]
        public void TestAllowNewlineDelimiter(String s, long[] expected)
        {
            var tokens = tokenizer.Parse(s);
            Assert.Equal(tokens, expected);
        }
        [Theory]
        [InlineData("1,-100,100", new long[] {-100})]
        public void TestShouldDenyNegativeNumbers(string s, long[] expectedErrors)
        {
            var exception = Record.Exception(() => tokenizer.Parse(s, ParseOptions.Create(shouldDenyNegativeNumbers: true)));
            Assert.IsType<NegativeNumbersException>(exception);
            Assert.Equal(expectedErrors, ((NegativeNumbersException)exception).NegativeNumbers);
        }
        [Theory]
        [InlineData("2,1001,6", new long[] { 2,0,6 })]
        public void TestShouldIgnoreLargeNumbers(string s, long[] expected)
        {
            var tokens = tokenizer.Parse(s, ParseOptions.Create(upperBound: 1000));
            Assert.Equal(tokens, expected);
        }
        [Theory]
        [InlineData("//;\n2;5", new long[] { 2, 5 })]
        public void SupportSingleCharacterCustomDelimiter(string s, long[] expected)
        {
            var tokens = tokenizer.Parse(s);
            Assert.Equal(tokens, expected);
        }
        [Theory]
        [InlineData("//[***]\n11***22***33", new long[] { 11,22,33})]
        [InlineData("//[*][!!][rrr]\n11rrr22*33!!44", new long[] { 11, 22, 33, 44 })]
        public void SupportMultipleCharacterDelimiter(string s, long[] expected)
        {
            var tokens = tokenizer.Parse(s);
            Assert.Equal(tokens, expected);
        }

    }
}
