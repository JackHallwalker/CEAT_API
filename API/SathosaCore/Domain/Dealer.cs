using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class Dealer
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("DISTRICT_ID")]
        public int districtId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("COMPANY_ID")]
        public int companyId { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string contactNumber { get; set; }

        [DBField("LONGITUDE")]
        public double longitude { get; set; }

        [DBField("LANGITUDE")]
        public double langitude { get; set; }

        [DBField("REF_CODE")]
        public string refCode { get; set; }

        [DBField("IS_ACTIVE")]
        public int isActive { get; set; }

        [DBField("CREATED_DATE")]
        public DateTime date { get; set; }

        [DBField("CREATED_BY")]
        public string createdBy { get; set; }

        [DBField("TOWN")]
        public string town { get; set; }

        [DBField("TOTAL_REWARDS")]
        public int totalRewards { get; set; }

        [DBField("QR_CODE")]
        public string qrCode { get; set; }

        [DBField("EMAIL")]
        public string email { get; set; }


        public District district { get; set; }
        public Company company { get; set; }
        public List<Fitters> fitters { get; set; }
    }

    public class DealerCreation
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("DISTRICT_ID")]
        public int districtId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("COMPANY_ID")]
        public int companyId { get; set; }

        [DBField("ADDRESS")]
        public string address { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string contactNumber { get; set; }

        [DBField("LONGITUDE")]
        public double longitude { get; set; }

        [DBField("LANGITUDE")]
        public double langitude { get; set; }

        [DBField("REF_CODE")]
        public string refCode { get; set; }

        [DBField("IS_ACTIVE")]
        public int isActive { get; set; }

        [DBField("CREATED_DATE")]
        public DateTime date { get; set; }

        [DBField("CREATED_BY")]
        public string createdBy { get; set; }

        [DBField("TOWN")]
        public string town { get; set; }

        [DBField("TOTAL_REWARDS")]
        public int totalRewards { get; set; }

        [DBField("QR_CODE")]
        public string qrCode { get; set; }

        [DBField("EMAIL")]
        public string email { get; set; }

        [DBField("PASSWORD")]
        public string password { get; set; }

        public UserLogin userLogin { get; set; }
        public DealerLogin dealerLogin { get; set; }
    }
}
