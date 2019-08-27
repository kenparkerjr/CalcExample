using CalcCLI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace TestCLI
{
    public class TestConsoleWriter
    {
 
        private ConsoleWriter CreateWriter(StringBuilder sb, string usageText = "")
        {
             var usageProvider = new Moq.Mock<CLI.IUsageProvider>();
            usageProvider.Setup(x => x.GetUsage()).Returns(new CLIProgram(usageText));

            return new ConsoleWriter(new StringWriter(sb), usageProvider.Object);
        }
        [Fact]
        public void TestWriteUsageConsoleWriter()
        {
            string usageText = "Usage Example";
            var sb = new StringBuilder();
            var writer = CreateWriter(sb, usageText);
           
            writer.WriteUsage();
            Assert.Contains("Usage Example", sb.ToString());
        }
        [Fact]
        public void TestWriteArguments()
        {
            StringBuilder sb = new StringBuilder();
            var writer = CreateWriter(sb, String.Empty);

            var mockReader = new Moq.Mock<IArgumentReader>();
            var fakeArguments = new List<CLIArgument>();
            fakeArguments.Add(new CLIArgument("Command1", "Test1"));
            fakeArguments.Add(new CLIArgument("Command2", "Test2"));
            mockReader.Setup(x => x.GetAllArguments()).Returns(() => fakeArguments);
            writer.WriteAllArguments(mockReader.Object);

            Assert.Contains("Command1", sb.ToString());
            Assert.Contains("Test1", sb.ToString());
            Assert.Contains("Command2", sb.ToString());
            Assert.Contains("Test2", sb.ToString());
        }
    }
}
