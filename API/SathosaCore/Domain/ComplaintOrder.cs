using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class ComplaintOrder
    {

        [DBField("ORDER_DETAILS_ID")]
        public int orderDetailsId { get; set; }

        [DBField("PRODUCT_MASTER_ID")]
        public int productMasterId { get; set; }

        [DBField("CUSTOMER_COMPLAINT_ID")]
        public int customerComplaintId { get; set; }

        [DBField("REMARK")]
        public string remark { get; set; }

        [DBField("PRODUCT_LINE_ITEM_ID")]
        public int product_line_item_id { get; set; }

        public OrderDetails orderDetails { get; set; }
        public ProductMaster productMaster { get; set; }
        public ProductLineItem productLineItem { get; set; }
        public CustomerComplaint customerComplaint { get; set; }
    }
}
