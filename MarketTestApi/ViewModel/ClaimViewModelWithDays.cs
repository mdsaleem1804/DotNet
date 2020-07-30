using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketTestApi.ViewModel
{
    public class ClaimViewModelWithDays
    {
        public string Ucr { get; set; }
        public string AssuredName { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Days { get; set; }
    }
}
