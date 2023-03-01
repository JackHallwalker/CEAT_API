using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class ProductMaster
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("DESCRIPTION")]
        public string description { get; set; }

        [DBField("WARRANTY_DESCRIPTION")] 
        public string warrantyDescription { get; set; }

        [DBField("WARRANTY_DURATION_NUM_OF_MONTH")]
        public int warrantyDurationNumOfMonth { get; set; }

    }
}
