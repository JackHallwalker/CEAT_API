using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class ProductRating
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("ORDER_DETAILS_ID")]
        public int orderDetailsId { get; set; }

        [DBField("COMMENT_2")]
        public string comment { get; set; }

        [DBField("STAR_COUNT")]
        public int starCount { get; set; }

        [DBField("PRODUCT_MASTER_ID")]
        public int productMasterId { get; set; }

        [DBField("PRODUCT_LINE_ITEM_ID")]
        public int productLineItemId { get; set; }

        public ProductMaster productMaster { get; set; }
        public ProductLineItem productLineItem { get; set; }
    }
}
