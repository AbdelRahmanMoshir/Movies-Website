﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXercises.Models
{
    public class MembershipType
    {
        public byte ID { get; set; }
        public short SignUPFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public string Name { get; set; }
    }
}