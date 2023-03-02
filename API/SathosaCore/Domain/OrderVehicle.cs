using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public partial class OrderVehicle
    {
        [DBField("id")]
        public int id { get; set; }

        [DBField("order_id")]
        public int orderId { get; set; }

        [DBField("vehicle_id")]
        public string vehicleId { get; set; }

    }
}
