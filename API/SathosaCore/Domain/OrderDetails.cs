using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class OrderDetails
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("PRODUCT_LINE_ITEM_ID")]
        public int product_line_item_id { get; set; }

        [DBField("PRODUCT_MASTER_ID")]
        public int productMasterId { get; set; }

        [DBField("CUSTOMER_ORDERS_ID")]
        public int customerOrdersId { get; set; }

        [DBField("QUANTITY")]
        public int quantity { get; set; }

        [DBField("WARRANTY_START")]
        public DateTime warrantyStart { get; set; }

        [DBField("WARRANTY_END")]
        public DateTime warrantyEnd { get; set; }

        [DBField("IS_REPLACED")]
        public int isReplaced { get; set; }

        [DBField("DEALER_NAME")]
        public string dealerName { get; set; }

        [DBField("STORE_NAME")]
        public string storeName { get; set; }

        public ProductRating productRating { get; set; }
        public Dealer dealer { get; set; }
        public ProductMaster productMasters { get; set; }
        public ProductLineItem productLineItem { get; set; }
        public CustomerOrder customerOrder { get; set; }
    }

    public class OrderDetailsWithCount
    {
        //[DBField("ID")]
        //public int id { get; set; }

        //[DBField("PRODUCT_MASTER_ID")]
        //public int productMasterId { get; set; }

        //[DBField("CUSTOMER_ORDERS_ID")]
        //public int customerOrdersId { get; set; }

        //[DBField("QUANTITY")]
        //public int quantity { get; set; }


        //[DBField("NAME")]
        //public string name { get; set; }

        //[DBField("STORE_NAME")]
        //public string storeName { get; set; }

        //[DBField("CONTACT_NUMBER")]
        //public string contactNumber { get; set; }

        [DBField("COUNT")]
        public int count { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        public Dealer dealer { get; set; }

    }

    public class OrderDetailsForSales
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("PRODUCT_MASTER_ID")]
        public int productMasterId { get; set; }

        [DBField("PRODUCT_LINE_ITEM_ID")]
        public int product_line_item_id { get; set; }

        [DBField("CUSTOMER_ORDERS_ID")]
        public int customerOrdersId { get; set; }

        [DBField("QUANTITY")]
        public int quantity { get; set; }

        [DBField("WARRANTY_START")]
        public DateTime warrantyStart { get; set; }

        [DBField("WARRANTY_END")]
        public DateTime warrantyEnd { get; set; }

        [DBField("IS_REPLACED")]
        public int isReplaced { get; set; }

        [DBField("DEALER_NAME")]
        public string dealerName { get; set; }

        [DBField("STORE_NAME")]
        public string storeName { get; set; }

        public ProductMaster productMasters { get; set; }
    }
}
