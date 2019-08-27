using Calc;
using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestCalc
{
    public class UnitTestMathCommands
    {
        private readonly IMathOptions options;
        public UnitTestMathCommands()
        {
            options = new TestObjects.MathOptionsProvider().MockOptions();
        }
        [Fact]
        public void TestAddCommand()
        {
            var c = new AddCommand(options);
            var actualResult = c.Execute(new long[] { 2, 2, 2 });
            Assert.Equal(6, actualResult);
        }
        [Fact]
        public void TestSubractCommand()
        {
            var c = new SubtractCommand(options);
            var actualResult = c.Execute(new long[] { 4, 1, 1 });
            Assert.Equal(2, actualResult);

        }
        [Fact]
        public void TestMultiplyCommand()
        {
            var c = new MultiplyCommand(options);
            var actualResult = c.Execute(new long[] { 2, 2, 2 });
            Assert.Equal(8, actualResult);
        }
        [Fact]
        public void TestDivideCommand()
        {
            var c = new DivideCommand(options);
            var actualResult = c.Execute(new long[] { 4, 2, 1 });
            Assert.Equal(2, actualResult);
        }
        [Fact]
        public void TestDivideByZero()
        {
            var c = new DivideCommand(options);
            var exception = Record.Exception(() => c.Execute(new long[] { 8, 0 }));
            Assert.IsType<DivideByZeroException>(exception);
        }
    }
}
