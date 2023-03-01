using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class Admin
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("USER_TYPE_ID")]
        public int userTypeId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("IS_ACTIVE")]
        public int isActive { get; set; }



    }

    public class AdminCreate
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("USER_TYPE-ID")]
        public int userTypeId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("EMAIL")]
        public string email { get; set; }

        [DBField("PASSWORD")]
        public string password { get; set; }

        [DBField("IS_ACTIVE")]
        public int isActive { get; set; }


        public UserLogin userLogin { get; set; }
        public AdminLogin adminLogin { get; set; }
    }
}
