using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class SliderImage
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("USER_TYPE_ID")]
        public int user_type_id { get; set; }

        [DBField("DESCRIPTION")]
        public string description { get; set; }

        [DBField("TITLE")]
        public string title { get; set; }

        [DBField("EFFECTIVE_DATE")]
        public DateTime effective_date { get; set; }

        public string image_url { get; set; }

        public UserType userType { get; set; }
    }
}
