using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace OneClickZip.Includes.Utilities
{
    public class StringOperation
    {

        // If you want to implement both "*" and "?"
        public static String WildCardToRegular(String value)
        {
            //string text = "x is not the same as X and yz not the same as YZ";
            //bool contains = LikeOperator.LikeString(text, "*X*YZ*", Microsoft.VisualBasic.CompareMethod.Binary);
            //https://www.nuget.org/packages/DotNet.Glob/
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }

        // If you want to implement "*" only
        public static String WildCardToRegular1(String value)
        {
            return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
        }
    }
}
