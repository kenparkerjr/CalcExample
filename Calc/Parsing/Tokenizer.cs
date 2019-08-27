using Calc.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Calc
{
    public class Tokenizer 
    {
        public IHeader Header { get; private set; }
        public Tokenizer()
        {
            Header = new Header();
        }

        public IEnumerable<long> Parse(string s)
        {
            var parseOptions = ParseOptions.Default;
            return Parse(s, parseOptions);
        }
        public IEnumerable<long> Parse(string s, IParseOptions parseOptions)
        {
            var delimiters = Header.Parse(s);
            string valueString = s.Substring(Header.GetHeaderLength(s));
            var tokens = valueString.Split(delimiters.Concat<string>(new string[] { ",", "\n" }).ToArray(), StringSplitOptions.None);
            foreach(string t in tokens)
            {
                if (long.TryParse(t, out long n))
                    yield return n;
                else
                    yield return 0;
            }
        }
  
    }
}
