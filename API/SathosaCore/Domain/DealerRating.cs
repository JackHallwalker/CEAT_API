using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class DealerRating
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("CUSTOMER_ORDERS_ID")]
        public int customerOrderId { get; set; }

        [DBField("COMMENT_2")]
        public string comment { get; set; }

        [DBField("STAR_COUNT")]
        public int starCount { get; set; }

        [DBField("DEALER_ID")]
        public int dealer_id { get; set; }

    }
}
