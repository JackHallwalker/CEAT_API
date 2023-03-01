using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class ProductLineItem
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("QR_CODE")]
        public string qrCode { get; set; }

        [DBField("PRODUCT_MASTER_ID")] 
        public int productMasterId { get; set; }

        public ProductMaster productMaster { get; set; }
    }

    public class ProductLineItemWithDetails
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("QR_CODE")]
        public string qrCode { get; set; }

        [DBField("PRODUCT_MASTER_ID")]
        public int productMasterId { get; set; }

        [DBField("CUSTOMER_ORDERS_ID")]
        public int customer_orders_id { get; set; }

        [DBField("ORDER_DETAILS_ID")]
        public int order_details_id { get; set; }

        [DBField("CUSTOMER_ID")]
        public int customer_Id { get; set; }

        [DBField("DEALER_ID")]
        public int dealer_Id { get; set; }

        public ProductMaster productMaster { get; set; }
        public Customer customer { get; set; }
        public Dealer dealer { get; set; }
        public CustomerOrder customerOrder { get; set; }
        public OrderDetails orderDetail { get; set; }
    }
}
