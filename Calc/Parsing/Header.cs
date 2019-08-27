using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace Calc.Parsing
{
    public class Header : IHeader
    {
        public Header() : this("//", "\n", null)
        {

            RegularExpression = (s, pattern) => Regex.Matches(s, pattern)
                                                    .Select(m => m.Groups[0].Value)
                                                    .ToArray();
        }
        public Header(string headerStart, string headerEnd, Func<string, string, string[]> regularEpressionFunction)
        {
            HeaderStart = headerStart;
            HeaderEnd = headerEnd;
            RegularExpression = regularEpressionFunction;
        }
        public Func<string, string, string[]> RegularExpression { get; private set; }
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
                return s.Substring(2).TrimEnd(HeaderEnd[0]);
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
        /// <param name="">Should contain a string with delimiters formatted as ///[delimiter]([delimiter])*{EOL} or
        /// //{single-char-delimiter}{EOL}</param>
        public string[] Parse(string headerString)
        {
            string s = ExtractHeader(headerString);
            if (String.IsNullOrEmpty(s))
                return new string[] { };
            else if (s.Contains("[") == false)
                return new string[] { s[0].ToString() };
            else
                return RegularExpression(headerString, @"(?<=\[).+?(?=\])");

        }
    }
}
