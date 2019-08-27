using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace Calc.Parsing
{
    public class Header : IHeader
    {
        public Header() : this("//", "\n", null)
        {

            RegularExpression = (s, pattern) => Regex.Matches(s, pattern).ToStringArray();

        }
        public Header(string headerStart, string headerEnd, Func<string, string, string[]> regularEpressionFunction)
        {
            HeaderStart = headerStart;
            HeaderEnd = headerEnd;

            if (String.IsNullOrEmpty(HeaderStart) || String.IsNullOrEmpty(headerEnd))
                throw new ArgumentOutOfRangeException("HeaderStart and HeaderEnd Can't be empty or whitespace.");

            RegularExpression = regularEpressionFunction;
        }
        public Func<string, string, string[]> RegularExpression { get; private set; }
        public string HeaderStart { get; private set; }
        public string HeaderEnd { get; private set; }
        /// <summary>
        /// Extracts the delimiter header
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ExtractHeader(string s)
        {
           
            if (s.TrimStart().StartsWith(HeaderStart))
                return s.Substring(0, GetHeaderLength(s));
            else
                return String.Empty;
        }
        public int GetHeaderLength(string s)
        {
            if (s.TrimStart().StartsWith(HeaderStart))
            {
                int idx = s.IndexOf(HeaderEnd) + 1;
                if (idx == -1) throw new Exceptions.InvalidHeaderException();
                return idx;
            }
            return 0;
        }
        /// <summary>
        /// Excepts a string containing delimiters
        /// </summary>
        /// <param name="">Should contain a string with delimiters formatted as ///[{delimiter}]({[delimiter]})*{EOL} or
        /// //{single-char-delimiter}{EOL}</param>
        public string[] Parse(string headerString)
        {
            string s = ExtractHeader(headerString);
            if (String.IsNullOrEmpty(s))
                return new string[] { };
            else if (s.Contains("[") == false)
                return new string[] { s.Substring(HeaderStart.Length, 1) }; //Single Character
            else
                return RegularExpression(headerString, @"(?<=\[).+?(?=\])");
        }
    }
}
