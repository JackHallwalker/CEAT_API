using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public partial class CustomerVehicle
    {
        [DBField("id")]
        public int id { get; set; }

        [DBField("customer_id")]
        public int customerId { get; set; }

        [DBField("vehicle_number")]
        public string vehicleNumber { get; set; }

        [DBField("vehicle_name")]
        public string vehicleName { get; set; }

        [DBField("is_active")]
        public int isActive { get; set; }
    }
}
