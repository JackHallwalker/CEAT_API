using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class OrderFitter
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("CUSTOMER_ORDERS_ID")]
        public int customerOrdersId { get; set; }

        [DBField("FITTERS_ID")]
        public int fitterId { get; set; }

        public Fitters fitters{get; set;}
    }
}
