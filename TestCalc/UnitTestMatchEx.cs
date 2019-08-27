using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;
using Calc;
namespace TestCalc
{
    public class UnitTestMatchEx
    {
        [Theory]
        [InlineData("Sally Sells Seashells", @"\bS\S*", new string[] {"Sally", "Sells", "Seashells" })]
        [InlineData("", @"\bS\S*", new string[] { })]
        public void TestToStringArray(string input, string pattern, string[] expectedStringArray)
        {
            var actualStringArray = Regex.Matches(input, pattern).ToStringArray();
            Assert.Equal(expectedStringArray, actualStringArray);
        }
    }
}
