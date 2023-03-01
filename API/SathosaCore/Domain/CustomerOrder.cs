using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class CustomerOrder
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        [DBField("CUSTOMER_ID")]
        public int customerId { get; set; }

        [DBField("ORDER_DATE")]
        public DateTime orderDate { get; set; } = DateTime.Now;

        public List<OrderDetails> orderDetails { get; set; }
        public List<OrderFitter> orderFitters { get; set; }
        public Dealer dealer { get; set; }
        //public DealerRating dealerRating { get; set; }



        public Customer customer { get; set; }
        public CustomerComplaint customerComplaint { get; set; }
        //public List<ProductMaster> productMasters { get; set; }

    }

    public class CustomerOrderDetails
    {
        [DBField("QUANTITY")]
        public int quantity { get; set; }

        //[DBField("PRODUCT_MASTER_ID")]
        //public int product_master_id { get; set; }

        [DBField("PRODUCT_LINE_ITEM_ID")]
        public int product_line_item_id { get; set; }

        [DBField("DEALER_ID")]
        public int dealer_id { get; set; }

        public ProductMaster productMasters { get; set; }
        public ProductLineItem productLineItem { get; set; }
        public Dealer dealer { get; set; }
    }

    public class CustomerOrderSalesCount
    {
        [DBField("QUANTITY")]
        public int quantity { get; set; }
       
        //public int monthlySale { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }


        public Dealer dealer { get; set; }
    }

    public class CustomerOrderSalesCountToday
    {
        [DBField("QUANTITY")]
        public int quantity { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }


        public Dealer dealer { get; set; }
    }
}
