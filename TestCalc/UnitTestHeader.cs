using Calc.Parsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCalc
{

    public class UnitTestHeader
    {
        Header header;
        public UnitTestHeader()
        {
            header = new Header();
        }
        [Theory]
        [InlineData("//;\n", ";")]
        [InlineData("//[***]\n", "[***]")]
        [InlineData("//[??][rr][--]\n", "[??][rr][--]")]
        public void TestExtractHeader(string input, string expectedHeaderString)
        {
            string actualHeaderString = header.ExtractHeader(input);
            Assert.Equal(expectedHeaderString, actualHeaderString); 
        }
        [Theory]
        [InlineData("//;\n", new string[] { ";" })]
        [InlineData("//[***]\n", new string[] { "***" })]
        [InlineData("//[??][rr][--]\n", new string[] { "??", "rr", "--" })]
        public void TestParseHeader(string input, string[] expectedDelimiters)
        {
            string[] actualDelimiters = header.Parse(input);
            Assert.Equal(expectedDelimiters, actualDelimiters);
        }
    }
}
