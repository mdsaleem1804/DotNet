using System.Threading.Tasks;
using MarketTestApi.Models;
using MarketTestApi.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace MarketTestApi.Repository
{
    public class MarkelRepository : IMarkelRepository
    {
        TestMarkelContext db;

        public MarkelRepository(TestMarkelContext _db)
        {
            db = _db;
        }

        public Task<CompanyViewModel> GetCompany(int? companyId)
        {
            if (db != null)
            {
                return (from c in db.Company
                        where c.Id == companyId
                        select new CompanyViewModel
                        {
                            Name = c.Name,
                            Address1 = c.Address1,
                            Address2 = c.Address2,
                            Address3 = c.Address3,
                            Active = c.Active,
                            Country = c.Country,
                            InsuranceEndDate = c.InsuranceEndDate,
                            PostCode = c.PostCode
                        }).FirstOrDefaultAsync();
            }
            return null;
        }


        public async Task<List<CompanyViewModel>> GetActiveCompanies()
        {
            if (db != null)
            {
                return await (from c in db.Company
                              where c.Active == true
                              select new CompanyViewModel
                              {
                                  Name = c.Name,
                                  Active = c.Active,
                              }).ToListAsync();
            }

            return null;
        }

        public Task<List<ClaimViewModel>> GetClaimsForSingleCompany(int? companyId)
        {
            if (db != null)
            {
                return (from cl in db.Claims
                        from c in db.Company
                        where c.Id == cl.CompanyId
                        && c.Id == companyId
                        select new ClaimViewModel
                        {
                            CompanyId = c.Id,
                            CompanyName = c.Name,
                            AssuredName = cl.AssuredName,
                            ClaimDate = cl.ClaimDate,
                            Ucr = cl.Ucr,
                            Closed = cl.Closed,
                            IncurredClass = cl.IncurredClass,
                            LossDate = cl.LossDate
                        }).ToListAsync();
            }
            return null;
        }

        public Task<ClaimViewModelWithDays> getClaim(string UCR)
        {

            if (db != null)
            {
                return (from cl in db.Claims
                        where cl.Ucr == UCR
                        select new ClaimViewModelWithDays
                        {

                            AssuredName = cl.AssuredName,
                            ClaimDate = cl.ClaimDate,
                            Ucr = cl.Ucr,
                            Days = Convert.ToString((DateTime.Now - cl.ClaimDate).Ticks)
                        }).FirstOrDefaultAsync();

            }
            return null;
        }


        public async Task UpdateClaim(Claims claim)
        {
            if (db != null)
            {

                db.Claims.Update(claim);

          
                await db.SaveChangesAsync();
            }
        }
    }
}
