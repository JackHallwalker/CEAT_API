using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class CustomerComplaint
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        [DBField("COMPLAINT_CATEGORY_ID")]
        public int complaintCategoryId { get; set; }

        [DBField("CUSTOMER_ID")]
        public int customerId { get; set; }

        [DBField("COMPLAINT_TYPE_ID")]
        public int complaintTypeId { get; set; }

        [DBField("DESCRIPTION")]
        public string description { get; set; }

        [DBField("IS_RESOLVED")]
        public int isResolved { get; set; }

        [DBField("COMPLAINT_DATE")]
        public DateTime complaintDate { get; set; }

        [DBField("RESOLVED_DATE")]
        public DateTime resolvedDate { get; set; }

        [DBField("ASSAIGN_TO")]
        public int assaign_to { get; set; }

        [DBField("REMARK_BY_ASSAIGNEE")]
        public string remark_by_assaignee { get; set; }

        public ComplaintOrder complaintOrder { get; set; }
        public List<ComplaintOrder> complaintOrders { get; set; }
        public Dealer dealer { get; set; }
        public ComplaintCategory complaintCategory { get; set; }
        public  ComplaintType complaint { get; set; }
        public Customer customer { get; set; }
        
    }

    public class CustomerComplaintDetails
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        [DBField("COMPLAINT_CATEGORY_ID")]
        public int complaintCategoryId { get; set; }

        [DBField("CUSTOMER_ID")]
        public int customerId { get; set; }

        [DBField("COMPLAINT_TYPE_ID")]
        public int complaintTypeId { get; set; }

        [DBField("DESCRIPTION")]
        public string description { get; set; }

        [DBField("IS_RESOLVED")]
        public int isResolved { get; set; }

        [DBField("COMPLAINT_DATE")]
        public DateTime complaintDate { get; set; }

        [DBField("RESOLVED_DATE")]
        public DateTime resolvedDate { get; set; }

        [DBField("ASSAIGN_TO")]
        public int assaign_to { get; set; }

        [DBField("REMARK_BY_ASSAIGNEE")]
        public string remark_by_assaignee { get; set; }

        //public ComplaintOrder complaintOrder { get; set; }
        public List<ComplaintOrder> complaintOrders { get; set; }
        public Dealer dealer { get; set; }
        public Customer customer { get; set; }
        public ComplaintCategory complaintCategory { get; set; }
        //public ComplaintType complaint { get; set; }
        //public ProductMaster product { get; set; }

    }

}
