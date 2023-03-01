using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class DealerLogin
    {
        [DBField("USER_LOGIN_ID")]
        public int userLoginId { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        public Dealer dealer { get; set; }
        public UserLogin userLogin { get; set; }

    }
}
