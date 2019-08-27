using System;
using System.Collections.Generic;
using System.Text;

namespace TestCLI.TestObjects
{
    [AttributeUsage(System.AttributeTargets.Method)]
    public class FakeAttribute : Attribute
    {
    }
    public class FakeAttributeClass
    {
        [FakeAttribute]
        public void TestMethod1() { }
        [FakeAttribute]
        public void TestMethod2() { }
        [FakeAttribute]
        public void TestMethod3() { }

    }
}
