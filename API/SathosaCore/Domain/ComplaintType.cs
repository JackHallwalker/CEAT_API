using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class ComplaintType
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("NAME")]
        public string name { get; set; }
    }
}
