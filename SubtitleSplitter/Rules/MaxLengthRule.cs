using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleSplitter.Rules
{
    public class MaxLengthRule : ISubTitleSplitter
    {       
       public int CalculateLineSplitterIndex(string input, int currentIndex, int maxLength)
        {
            return maxLength < (input.Length - currentIndex) ? maxLength : (input.Length - currentIndex);// -1;
        }
    }
}
