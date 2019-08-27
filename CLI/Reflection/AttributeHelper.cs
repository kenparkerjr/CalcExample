using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CLI.Reflection
{
    public class AttributeHelper : IAttributeHelper
    {
        private readonly Assembly assembly;
        public AttributeHelper()
        {
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
        }
        public AttributeHelper(Assembly assembly)
        {
            this.assembly = assembly;
        }
        private IEnumerable<PropertyInfo> GetAllAssemblyProperties()
        {
            var allTypes = assembly.GetTypes();
            foreach (var t in allTypes)
                foreach (var p in t.GetProperties())
                    yield return p;
        }
        public IEnumerable<AttributeInfo> GetAllAttributes<T>()
        {
            var allTypes = assembly.GetTypes();
            foreach (var t in allTypes)
                foreach (var p in t.GetProperties())
                {
                    var customAttribute = p.GetCustomAttribute(typeof(T), false);
                    if (customAttribute != null)
                    {
                        yield return new AttributeInfo() { Attribute = customAttribute, PropertyName = p.Name, PropertyType = p.PropertyType };
                    }
                }
        }
    }

}
