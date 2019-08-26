using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class Tokenizer 
    {
 
        public Tokenizer()
        {
        }

        public IEnumerable<long> Parse(string s)
        {
            var parseOptions = ParseOptions.Default;
            return Parse(s);
        }
        public IEnumerable<long> Parse(string s, IParseOptions parseOptions)
        {
            throw new NotImplementedException();
        }
  
    }
}
