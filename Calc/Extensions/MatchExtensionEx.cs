using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace Calc
{
    public static class MatchExtensionEx
    {
        public static String[] ToStringArray(this MatchCollection matchCollection)
        {
             return  matchCollection.Select(m => m.Groups[0].Value)
                                                    .ToArray();
        }
    }
}
