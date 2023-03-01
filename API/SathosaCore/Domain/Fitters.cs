﻿using CeatCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Domain
{
    public class Fitters
    {
        [DBField("ID")]
        public int id { get; set; }

        [DBField("DEALER_ID")]
        public int dealerId { get; set; }

        [DBField("NAME")]
        public string name { get; set; }

        [DBField("IS_ACTIVE")]
        public int isActive { get; set; }

        public Dealer dealer { get; set; }
       

    }
}
