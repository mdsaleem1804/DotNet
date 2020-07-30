using System;
using System.Collections.Generic;

namespace MarketTestApi.Models
{
    public partial class Claims
    {
        public string Ucr { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal IncurredClass { get; set; }
        public bool Closed { get; set; }
    }
}
