using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleSplitter.Rules
{
    
    public class LineSeparatorRule : ISubTitleSplitter
    {
        private int _ruleException;
        public LineSeparatorRule(int ruleException) {

            _ruleException = ruleException;
        }
        public int CalculateLineSplitterIndex(string input, int currentIndex, int maxLength)
        {
            if (input.IsLastIndexSeparator((currentIndex+ maxLength)-1) || input.IsNextCharSpace((currentIndex + maxLength)-1))
                return maxLength;
            else {                
                string subString = input.Substring(currentIndex, maxLength);
                if (input.Length == currentIndex + maxLength) {
                    return maxLength;
                }
                int spaceIndex = subString.LastIndexOf(' ');
                int sentBreak = Math.Max(subString.LastIndexOf(','), subString.LastIndexOf('.'));
                if (sentBreak > -1)
                    return spaceIndex - sentBreak > _ruleException ? spaceIndex : sentBreak + 1;
                else
                    return spaceIndex;
               // return nextLineBreak - currentIndex;
            }           

        }
    }
}
