using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class AdminLogin
    {
        [DBField("USER_LOGIN_ID")]
        public int userLoginId { get; set; }

        [DBField("ADMIN_ID")]
        public int adminId { get; set; }

        public Admin admin { get; set; }
        public UserLogin userLogin { get; set; }

    }
}
