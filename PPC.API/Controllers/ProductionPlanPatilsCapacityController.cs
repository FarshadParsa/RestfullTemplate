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
    public class ProductionPlanPatilsCapacityController : Controller
    {

        #region Prop

        private readonly IProductionPlanPatilsCapacityService _productionPlanPatilsCapacityService;

        #endregion

        #region Ctor

        public ProductionPlanPatilsCapacityController(IProductionPlanPatilsCapacityService productionPlanPatilsCapacityService)
        {
            _productionPlanPatilsCapacityService = productionPlanPatilsCapacityService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanPatilsCapacity()
        {
            try
            {

                List<Core.Models.ProductionPlanPatilsCapacity> productionPlanPatilsCapacity = await _productionPlanPatilsCapacityService.GetAllAsync();

                var res = productionPlanPatilsCapacity == null
                    ? null
                    : productionPlanPatilsCapacity.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanPatilsCapacity List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsCapacityDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsCapacityDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanPatilsCapacityByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanPatilsCapacity productionPlanPatilsCapacity = await _productionPlanPatilsCapacityService.GetProductionPlanPatilsCapacityByIdAsync(id);

                var res = productionPlanPatilsCapacity == null
                    ? null
                    : (new List<Core.Models.ProductionPlanPatilsCapacity> { productionPlanPatilsCapacity }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanPatilsCapacity failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsCapacityDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsCapacityDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanPatilsCapacity productionPlanPatilsCapacity)
        {
            try
            {

                int result = _productionPlanPatilsCapacityService.Append(productionPlanPatilsCapacity);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPatilsCapacity append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanPatilsCapacity productionPlanPatilsCapacity)
        {
            try
            {

                bool result = _productionPlanPatilsCapacityService.Update(productionPlanPatilsCapacity);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPatilsCapacity update failed");
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
                long result = _productionPlanPatilsCapacityService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPatilsCapacity delete failed");
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
