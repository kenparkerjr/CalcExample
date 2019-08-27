using System;
using System.Collections.Generic;
using System.Text;

namespace CLI.Reflection
{
    public class AttributeInfo
    {
       public Attribute Attribute { get; set; }
        public string PropertyName { get; set; }
        public Type PropertyType { get; set; }
    }
}
