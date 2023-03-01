using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class TireTips
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("TITLE")]
        public string title { get; set; }

        [DBField("BODY")]
        public string body { get; set; }

        [DBField("URL")]
        public string url { get; set; }
    }
}
