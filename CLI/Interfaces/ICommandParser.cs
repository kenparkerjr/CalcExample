using System.Collections.Generic;

namespace CLI
{
    public interface ICommandParser
    {
        IDictionary<string, string> Parse(string[] args);
    }
}