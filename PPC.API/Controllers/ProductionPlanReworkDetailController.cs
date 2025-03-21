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
    public class ProductionPlanReworkDetailController : Controller
    {

        #region Prop

        private readonly IProductionPlanReworkDetailsService _productionPlanReworkDetailsService;

        #endregion

        #region Ctor

        public ProductionPlanReworkDetailController(IProductionPlanReworkDetailsService productionPlanReworkDetailsService)
        {
            _productionPlanReworkDetailsService = productionPlanReworkDetailsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanReworkDetails()
        {
            try
            {

                List<Core.Models.ProductionPlanReworkDetails> productionPlanReworkDetails = await _productionPlanReworkDetailsService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<ProductionPlanReworkDetails>, List<ProductionPlanReworkDetailsDTO>>(productionPlanReworkDetails);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanReworkDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanReworkDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanReworkDetailsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanReworkDetailsByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanReworkDetails productionPlanReworkDetails = await _productionPlanReworkDetailsService.GetProductionPlanReworkDetailsByIdAsync(id);


                var res = new List<ProductionPlanReworkDetailsDTO> { ExtAutoMapper.JsonMap<ProductionPlanReworkDetails, ProductionPlanReworkDetailsDTO>(productionPlanReworkDetails) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanReworkDetails failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanReworkDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanReworkDetailsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanReworkDetails productionPlanReworkDetail)
        {
            try
            {

                int result = _productionPlanReworkDetailsService.Append(productionPlanReworkDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworkDetails append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanReworkDetails productionPlanReworkDetail)
        {
            try
            {

                bool result = _productionPlanReworkDetailsService.Update(productionPlanReworkDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworkDetails update failed");
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
                long result = _productionPlanReworkDetailsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworkDetails delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetDetailsListByProductionPlanReworkId(int id)
        {
            try
            {

                List<Core.Models.ProductionPlanReworkDetails> productionPlanReworkDetails = await _productionPlanReworkDetailsService.GetDetailsListByProductionPlanReworkIdAsync(id);


                var res = ExtAutoMapper.JsonMap<List<ProductionPlanReworkDetails>, List<ProductionPlanReworkDetailsDTO>>(productionPlanReworkDetails);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanReworkDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanReworkDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanReworkDetailsDTO>>(e));
            }

        }


    }
}
