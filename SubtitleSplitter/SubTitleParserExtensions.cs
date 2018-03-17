using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubtitleSplitter
{
   public static class SubTitleParserExtensions
    {      
        public static string RemoveExtraSpaces(this string input)
        {
            return new Regex(" {2,}").Replace(input, " ");
        }
        public static bool IsEndOfString(this string input,int index) {
            return input.Length-1==index;
        }
        public static bool IsLastIndexSeparator(this string input,int index) {
            return (input[index] == ' ' || input[index] == ',' || input[index] == '.');
        }
        public static bool IsNextCharSpace(this string input, int index)
        {
            return (++index<input.Length? input[index] == ' ':false);
        }
    }
}
