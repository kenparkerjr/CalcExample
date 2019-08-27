using CalcCLI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCLI
{
    public class TestArgumentReader
    {
        [Fact]
        public void TestRead()
        {
            var reader = new ArgumentReader(new TestObjects.FakeAttributeReader());
            var rawCommands = new Dictionary<string, string>();
            rawCommands["test1"] = "test1arg";
            rawCommands["test2"] = "test2arg";
            var actualResult = (TestObjects.FakeArguments)reader.Read<TestObjects.FakeArguments>(rawCommands);

            Assert.Equal("test1arg", actualResult.Test1);
            Assert.Equal("test2arg",actualResult.Test2);
        }

    }
}
