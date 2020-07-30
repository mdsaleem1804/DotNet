using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketTestApi.Models;
using MarketTestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkelController : ControllerBase
    {
        IMarkelRepository markelRepository;
        public MarkelController(IMarkelRepository _markelRepository)
        {
            markelRepository = _markelRepository;
        }
        [HttpGet]
        [Route("GetCompany")]
        public async Task<IActionResult> GetCompany(int? companyId)
        {
            if (companyId == null)
            {
                return BadRequest();
            }

            try
            {
                var company = await markelRepository.GetCompany(companyId);

                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetActiveCompanies")]
        public async Task<IActionResult> GetActiveCompanies()
        {
            try
            {
                var companies = await markelRepository.GetActiveCompanies();
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetClaimsForSingleCompany")]
        public async Task<IActionResult> GetClaimsForSingleCompany(int? companyId)
        {
            if (companyId == null)
            {
                return BadRequest();
            }
            try
            {
                var companies = await markelRepository.GetClaimsForSingleCompany(companyId);
                if (companies == null)
                {
                    return NotFound();
                }

                return Ok(companies);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetClaim")]
        public async Task<IActionResult> GetClaim(string UCR)
        {
            if (UCR == null)
            {
                return BadRequest();
            }

            try
            {
                var company = await markelRepository.getClaim(UCR);

                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateClaim")]
        public async Task<IActionResult> UpdateClaim([FromBody]Claims model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await markelRepository.UpdateClaim(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}