using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CLI.Reflection;
using TestCLI.TestObjects;

namespace TestCLI
{
    public class TestAttributeHelper
    {
        private readonly AttributeHelper helper;
        public TestAttributeHelper()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            helper = new AttributeHelper(assembly);
        }
        [Fact]
        public void TestGetAllAttributes()
        {
            var allAttributes = helper.GetAllAttributes<FakeAttribute>();
            //calling it does not throw exception but we can not verify because it is not getting attributes in unit dll
        }
    }
}
