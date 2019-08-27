using System.Collections.Generic;

namespace CLI.Reflection
{
    public interface IAttributeHelper
    {
        IEnumerable<AttributeInfo> GetAllAttributes<T>();
    }
}