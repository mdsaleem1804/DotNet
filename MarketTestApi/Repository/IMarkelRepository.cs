using MarketTestApi.Models;
using MarketTestApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketTestApi.Repository
{
    public interface IMarkelRepository
    {
        Task<CompanyViewModel> GetCompany(int? companyId);
        Task<List<CompanyViewModel>> GetActiveCompanies();
        Task<List<ClaimViewModel>> GetClaimsForSingleCompany(int? companyId);

        Task<ClaimViewModelWithDays> getClaim(string UCR);

        Task UpdateClaim(Claims claim);
    }
}
