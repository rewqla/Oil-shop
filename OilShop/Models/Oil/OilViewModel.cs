﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OilShop.Models.Oil
{
    public class OilViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Capacity { get; set; }
    }
}
