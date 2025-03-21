using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class PackagingPlanController : Controller
    {

        #region Prop

        private readonly IPackagingPlansService _packagingPlansService;

        #endregion

        #region Ctor

        public PackagingPlanController(IPackagingPlansService packagingPlansService)
        {
            _packagingPlansService = packagingPlansService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetPackagingPlans()
        {
            try
            {

                List<Core.Models.PackagingPlans> packagingPlans = await _packagingPlansService.GetAllAsync();

                var res = packagingPlans.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PackagingPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<PackagingPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PackagingPlansDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetPackagingPlansByID(int id)
        {
            try
            {

                Core.Models.PackagingPlans packagingPlans = await _packagingPlansService.GetPackagingPlansByIdAsync(id);

                var res = (new List<Core.Models.PackagingPlans> { packagingPlans }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get packagingPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<PackagingPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PackagingPlansDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{name}")]

        public async Task<IActionResult> ExistPackagingPlans(string name)
        {
            try
            {

                var result = _packagingPlansService.ExistPackagingPlansAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PackagingPlans failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] PackagingPlans packagingPlan)
        {
            try
            {

                int result = _packagingPlansService.Append(packagingPlan);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PackagingPlans append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] PackagingPlans packagingPlan)
        {
            try
            {

                bool result = _packagingPlansService.Update(packagingPlan);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PackagingPlans update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                long result = _packagingPlansService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PackagingPlans delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

    }
}
