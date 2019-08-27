using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using CLI.Reflection;

namespace CalcCLI
{
    public class ArgumentReader : IArgumentReader
    {
        private readonly IEnumerable<CLIArgument> argumentAttributes;
        private readonly IAttributeHelper attributeHelper;
        public ArgumentReader()
        {

            this.attributeHelper = new AttributeHelper(Assembly.GetCallingAssembly());
            this.argumentAttributes = GetAllArguments();
        }
        public ArgumentReader(IAttributeHelper attributeHelper)
        {
            this.attributeHelper = attributeHelper;
            this.argumentAttributes = GetAllArguments();
        }
        
        public IEnumerable<CLIArgument> GetAllArguments()
        {
            var lst = new List<CLIArgument>();
            var allAttributes = attributeHelper.GetAllAttributes<CLIArgument>();
            foreach(var attr in allAttributes)
            {
                var arg = (CLIArgument)attr.Attribute;
                arg.PropertyName = attr.PropertyName;
                arg.PropertyType = attr.PropertyType;
                yield return arg;
            }
           
        }
        public T Read<T>(IDictionary<string, string> rawCommands) where T : new()
        {
            T result = new T();

            foreach (var arg in this.argumentAttributes)
            {
                var propertyType = arg.PropertyType;
                var propertyInfo = result.GetType().GetProperty(arg.PropertyName);

                if (rawCommands.ContainsKey(arg.Command.ToLower()) == false)
                    continue;
                string stringValue = rawCommands[arg.Command.ToLower()];

                if (propertyType == typeof(string))
                    propertyInfo.SetValue(result, stringValue);
                else if (propertyType == typeof(bool))
                {
                    bool boolValue = stringValue.ToUpper() == "Y" ? true : false;
                    propertyInfo.SetValue(result, boolValue);
                }
                else if (propertyType == typeof(int))
                {
                    if (int.TryParse(stringValue, out int intValue))
                        propertyInfo.SetValue(result, intValue);
                    else
                        ;//DO NOTHING IGNORE invalid values
                }
                else
                    throw new NotSupportedException();
            }
            return result;
        }

     
    }
}
