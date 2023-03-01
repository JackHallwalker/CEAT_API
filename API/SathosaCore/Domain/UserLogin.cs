using CeatCore.Domain;
using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class UserLogin
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("USER_TYPE_ID")]
        public int userTypeId { get; set; }

        [DBField("COMPANY_ID")]
        public int companyId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("PASSWORD")]
        public string password { get; set; }

        [DBField("USER_ID")]
        public int userId { get; set; }

        public Company company { get; set; } = new Company();
        public UserType userType { get; set; } = new UserType();

        public List<CustomerLogin> customerLogin { get; set; }
        public CustomerCreation customer { get; set; }
        public List<DealerLogin> dealerLogin { get; set; }
        public DealerCreation dealer { get; set; }
    }

    public class UserLoginData
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("USER_TYPE_ID")]
        public int userTypeId { get; set; }

        [DBField("COMPANY_ID")]
        public int companyId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("USER_ID")]
        public int userId { get; set; }

        [DBField("PASSWORD")]
        public string password { get; set; }


        public List<CustomerLogin> customerLogin { get; set; }
        public Customer customer { get; set; }
        public List<DealerLogin> dealerLogin { get; set; }
        public Dealer dealer { get; set; }
    }
}
