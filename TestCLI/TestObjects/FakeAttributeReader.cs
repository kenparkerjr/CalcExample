using CLI.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCLI.TestObjects
{
    public class FakeAttributeReader : IAttributeHelper
    {
        public IEnumerable<AttributeInfo> GetAllAttributes<T>()
        {
            var attribute1 = new CalcCLI.CLIArgument("test1", "testarg1");
            yield return new AttributeInfo { Attribute = attribute1, PropertyName = "Test1", PropertyType = typeof(string) };

            var attribute2 = new CalcCLI.CLIArgument("test2", "testarg2");
            yield return new AttributeInfo { Attribute = attribute2, PropertyName = "Test2", PropertyType = typeof(string) };
        }
    }
}
