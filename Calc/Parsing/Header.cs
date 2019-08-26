using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Parsing
{
    public class Header
    {
        public Header()
        {
            HeaderStart = "//";
            HeaderEnd = "\n";
        }
        public string HeaderStart { get; private set; }
        public string HeaderEnd { get; private set; }
        /// <summary>
        /// Extracts the delimiter header without the beginning and ending symbols
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ExtractHeader(string s)
        {
            if (s.TrimStart().StartsWith(HeaderStart))
            {
                int idx = s.IndexOf(HeaderEnd)-2;
                if (idx == -1) throw new Exception("Header missing end line");

                return s.Substring(HeaderStart.Length, idx);
            }
            else
                return String.Empty;
        }
        /// <summary>
        /// Excepts a string containing delimiters
        /// </summary>
        /// <param name="">Should contain a string with delimiters formatted as ///[delimiter]([delimiter])*{EOL} or
        /// //{single-char-delimiter}{EOL}</param>
        public string[] Parse(string headerString)
        {
            string s = ExtractHeader(headerString);
            if (s.Contains("[") == false && !String.IsNullOrEmpty(s))
                return new string[] { s[0].ToString() };
            else
            {
                throw new NotImplementedException("Multi-Char Strings Not Impliminted");
            }
        }
    }
}
