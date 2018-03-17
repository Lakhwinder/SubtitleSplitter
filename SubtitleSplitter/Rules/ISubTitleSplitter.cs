using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleSplitter.Rules
{
    interface ISubTitleSplitter
    {
        int CalculateLineSplitterIndex(string input,int currentIndex,int length);
    }
}
