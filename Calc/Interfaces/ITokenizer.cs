using System.Collections.Generic;

namespace Calc
{
    public interface ITokenizer
    {
        IEnumerable<long> Parse(string s);
    }
}