using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class DealerCustomer
    {
        [DBField("CUSTOMER_ID")]
        public int cuatomerId { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        [DBField("REWARD_POINT")]
        public int rewardPoint { get; set; }


    }
}
