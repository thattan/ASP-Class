﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FordVSChevy.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string PartNum { get; set; }
        public string PartDesc { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string ImageName { get; set; }

    }
}
