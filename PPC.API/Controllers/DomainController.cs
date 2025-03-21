using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PPC.Response.DTOs;
using PPC.Core.Extensions;
using System.Linq;

namespace PPC.API.Controllers
{
    public class DomainController : Controller
    {

        #region Prop

        private readonly IDomainService _domainsService;


        #endregion


        #region Ctor

        public DomainController(IDomainService domainsService)
        {
            _domainsService = domainsService;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("GetActiveDomain")]
        public async Task<IActionResult> GetActiveDomain()
        {

            try
            {

                List<PPC.Core.Models.Domain> domains = _domainsService.GetDomain(true);

                var res = domains.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<DomainDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Domain List failed");
                return Ok(ResponseFactory.OKCreator<List<DomainDTO>>(new List<DomainDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DomainDTO>>(e));
            }

        }


        [HttpGet]
        [Route("GetInactiveDomain")]
        public async Task<IActionResult> GetInactiveDomain()
        {

            try
            {

                List<PPC.Core.Models.Domain> domains = _domainsService.GetDomain(false);

                var res = domains.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<DomainDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Domain List failed");
                return Ok(ResponseFactory.OKCreator<List<DomainDTO>>(new List<DomainDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DomainDTO>>(e));
            }

        }

        [HttpGet]
        [Route("GetAllDomain")]
        public async Task<IActionResult> GetAllDomain()
        {

            try
            {

                List<PPC.Core.Models.Domain> domains = _domainsService.GetDomain();

                var res = domains.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<DomainDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Domain List failed");
                return Ok(ResponseFactory.OKCreator<List<DomainDTO>>(new List<DomainDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DomainDTO>>(e));
            }

        }


    }
}
