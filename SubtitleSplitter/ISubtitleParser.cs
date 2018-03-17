using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleSplitter
{
   public interface ISubtitleParser
    {
        List<string> Parse(string input);
       
    }
}
