using SubtitleSplitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SubTitleWebApi.Controllers
{
    public class SubtitleController : ApiController
    {
        //GET: api/Subtitle
        public List<string> GetSubtitle(string input)
        {
            SubtitleParser subtitleParser = new SubtitleParser();
           return subtitleParser.Parse(input);
           
        }
     
    }
}
