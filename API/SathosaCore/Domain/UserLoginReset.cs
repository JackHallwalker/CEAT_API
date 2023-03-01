using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeCourtCore.Domain
{
    public partial class UserLoginReset
    {
        [DBField("id")]
        public int id { get; set; }

        [DBField("email")]
        public string email { get; set; }

        [DBField("verification_code")]

        public string verificationCode { get; set; }
    }
}
