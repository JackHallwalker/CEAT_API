using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class CustomerLogin
    {
        [DBField("USER_LOGIN_ID")]
        public int userLoginId { get; set; }

        [DBField("CUSTOMER_ID")]
        public int customerId { get; set; }

        public Customer customer { get; set; }
        public UserLogin userLogin { get; set; }

    }
}
