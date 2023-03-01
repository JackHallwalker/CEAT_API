using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class Company
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("EMAIL")]
        public string email { get; set; }

        [DBField("FAX")]
        public string fax { get; set; }

        //public List<Dealer> dealers { get; set; }
    }
}
