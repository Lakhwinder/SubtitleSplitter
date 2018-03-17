using SubtitleSplitter.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace SubtitleSplitter
{
    public class SubtitleParser: ISubtitleParser
    {
        private readonly int ruleException = 5;
        List<ISubTitleSplitter> splitterRules = new List<ISubTitleSplitter>();
        public SubtitleParser() {
            splitterRules.Add(new MaxLengthRule());
            splitterRules.Add(new LineSeparatorRule(ruleException) );
           
        }
        public List<string> Parse(string input)
        {
            List<string> dataList = new List<string>();
            int maxLength;
            input = input.RemoveExtraSpaces();
            for (int startIndex = 0; startIndex < input.Length;) {
                maxLength = 25;
                foreach (var rule in splitterRules)
                {
                    maxLength = Math.Min(rule.CalculateLineSplitterIndex(input, startIndex, maxLength), maxLength);                  
                }
                if (maxLength > 0)
                {
                    dataList.Add(input.Substring(startIndex, maxLength));
                    startIndex += maxLength;
                }
                else
                    return dataList;
            }
            return dataList;
        }
        //public string[] SubTitleParser(string input) {
        //    input = new Regex(" {2,}").Replace(input, " ");//done
        //    List<string> dataList = new List<string>();
        //    //  var data = input.Split(' ');
        //    int i = 0;
        //    string subString = string.Empty;
        //    do
        //    {
        //        int stringLength = 25 <= (input.Length - i) ? 25 : (input.Length - i);
        //        subString = input.Substring(i, stringLength);
        //        if (subString[subString.Length - 1] == ' ' || subString[subString.Length - 1] == ',' || subString[subString.Length - 1] == '.')
        //        {
        //            dataList.Add(subString);
        //            i += 25;
        //        }
        //        else
        //        {
        //            int lineBreak = getLineBreak(subString);
        //            // if (subString.LastIndexOf(' ') > 0)
        //            if (lineBreak > 0)
        //                dataList.Add(subString.Substring(0, lineBreak));
        //            else
        //                dataList.Add(subString);
        //            i += lineBreak;//subString.LastIndexOf(' ');
        //        }
        //        //Console.WriteLine(subString);
        //        //   subString =string.Empty;
        //    } while (i < input.Length && subString.LastIndexOf(' ') > 0);
        //    return dataList.ToArray();

        //}
        //private int getLineBreak(string subString)
        //{
        //    int spaceIndex = subString.LastIndexOf(' ');
        //    int sentBreak = Math.Max(subString.LastIndexOf(','), subString.LastIndexOf('.'));
        //    if (sentBreak > -1)
        //        return spaceIndex - sentBreak > 5 ? spaceIndex : sentBreak + 1;
        //    else
        //        return spaceIndex;
        //}
    }
}
