﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTK.Bank.Api.Models
{
    public class Movement
    {
        public DateTime Time { get; set; }
        public int X { get; set;}
        public int Y { get; set; }
        public string Type { get; set; }

    }
}