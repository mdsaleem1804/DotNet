﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketTestApi.ViewModel
{
    public class CompanyViewModel
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public DateTime InsuranceEndDate { get; set; }
    }
}
