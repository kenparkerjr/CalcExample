using System;
using Xunit;
using CLI;

namespace TestCLI
{
    public class TestCommandParser
    {
        private readonly CommandParser parser;
        public TestCommandParser()
        {
            parser = new CommandParser();
        }
        [Theory]
        [InlineData("", new string[] { "/test1", "test1arg", "/test2", "test2arg" },
                        new string[] { "test1", "test2" },
                        new string[] { "test1arg", "test2arg"})]
        public void TestCommands(string s, string[] inputArgs, string[] expectedCommands, string[] expectedArgs)
        {
            var actualResult = parser.Parse(inputArgs);
            var actualCommands = actualResult.Keys;
            var actualArgs = actualResult.Values;
            Assert.Equal(expectedCommands, actualCommands);
            Assert.Equal(expectedArgs, actualArgs);
        }
    }
}
