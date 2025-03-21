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
    public class ProductionPlanPackagingController : Controller
    {

        #region Prop

        private readonly IProductionPlanPackagingService _productionPlanPackagingService;

        #endregion

        #region Ctor

        public ProductionPlanPackagingController(IProductionPlanPackagingService productionPlanPackagingService)
        {
            _productionPlanPackagingService = productionPlanPackagingService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanPackaging()
        {
            try
            {

                List<Core.Models.ProductionPlanPackaging> productionPlanPackaging = await _productionPlanPackagingService.GetAllAsync();

                var res = productionPlanPackaging == null
                    ? null
                    : productionPlanPackaging.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanPackaging List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPackagingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPackagingDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanPackagingByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanPackaging productionPlanPackaging = await _productionPlanPackagingService.GetProductionPlanPackagingByIdAsync(id);

                var res = productionPlanPackaging == null
                    ? null
                    : (new List<Core.Models.ProductionPlanPackaging> { productionPlanPackaging }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanPackaging failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPackagingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPackagingDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanPackaging productionPlanPackaging)
        {
            try
            {

                int result = _productionPlanPackagingService.Append(productionPlanPackaging);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPackaging append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanPackaging productionPlanPackaging)
        {
            try
            {

                bool result = _productionPlanPackagingService.Update(productionPlanPackaging);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPackaging update failed");
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
                long result = _productionPlanPackagingService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPackaging delete failed");
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
