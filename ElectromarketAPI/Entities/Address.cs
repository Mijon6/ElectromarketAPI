﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectromarketAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set;}
        public string PostalCode { get; set; }
        public virtual Electromarket Electromarket { get; set; }

    }
}
