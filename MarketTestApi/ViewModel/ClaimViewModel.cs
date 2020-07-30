using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketTestApi.ViewModel
{
    public class ClaimViewModel
    {
        public string Ucr { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal IncurredClass { get; set; }
        public bool Closed { get; set; }
    }
}
