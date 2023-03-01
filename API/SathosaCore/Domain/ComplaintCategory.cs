using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class ComplaintCategory
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("COMPLAINT_TYPE_ID")]
        public int complaintTypeID { get; set; }
    }
}
