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
            DefaultDelimiters = new string[] { ",", "\n" };
        }

        public string[] DefaultDelimiters { get; private set;}

        public IEnumerable<long> Parse(string s)
        {
            var delimiters = Header.Parse(s);
            string valueString = s.Substring(Header.GetHeaderLength(s));
            string[] seperator = delimiters.Concat<string>(DefaultDelimiters).ToArray();
            var tokens = valueString.Split(seperator, StringSplitOptions.None);
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
