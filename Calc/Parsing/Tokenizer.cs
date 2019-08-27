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

        public Tokenizer() : this((input, delim) => input.Split(delim, StringSplitOptions.None).ToArray())
        {
            
        }

        public Tokenizer(Func<string, string[], string[]> splitFunction)
        {
            Header = new Header();
            DefaultDelimiters = new string[] { ",", "\n" };
            Split = splitFunction;
     
        }

        public string[] DefaultDelimiters { get; private set;}
        public Func<string, string[], string[]> Split { get; private set; }
        private string[] GetDelimiters(string s)
        {
            var delimiters = Header.Parse(s);
            return delimiters.Concat<string>(DefaultDelimiters).ToArray();
        }
        public IEnumerable<long> Parse(string s)
        {           
            string valueString = s.Substring(Header.GetHeaderLength(s));          
            var tokens = Split(valueString, GetDelimiters(s));
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
