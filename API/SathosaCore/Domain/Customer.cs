using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class Customer
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("MOBILE_NUMBER")]
        public string mobileNumber { get; set; }

        [DBField("NIC")]
        public string nic { get; set; }

        [DBField("PASSPORT")]
        public string passport { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("QR_CODE")]
        public string qrCode { get; set; }

        [DBField("DEALER-ID")]
        public int dealerId { get; set; }

        [DBField("HOME_TOWN")]
        public string homeTown { get; set; }

        [DBField("AVERAGE_RUNING_RATE")]
        public double averageRuningRate { get; set; }

    }

    public class CustomerCreation
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("MOBILE_NUMBER")]
        public string mobileNumber { get; set; }

        [DBField("NIC")]
        public string nic { get; set; }

        [DBField("PASSPORT")]
        public string passport { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("QR_CODE")]
        public string qrCode { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        [DBField("HOME_TOWN")]
        public string homeTown { get; set; }

        [DBField("AVERAGE_RUNING_RATE")]
        public double averageRuningRate { get; set; }

        [DBField("EMAIL")]
        public string email { get; set; }

        [DBField("PASSWORD")]
        public string password { get; set; }

        [DBField("COMPANY-ID")]
        public int companyId { get; set; }

        public UserLogin userLogin { get; set; }
        public CustomerLogin customerLogin { get; set; }
    }
}
