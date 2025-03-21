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
    public class ProductionPlanBOMDetailController : Controller
    {

        #region Prop

        private readonly IProductionPlanBOMDetailService _productionPlanBOMDetailService;

        #endregion

        #region Ctor

        public ProductionPlanBOMDetailController(IProductionPlanBOMDetailService productionPlanBOMDetailService)
        {
            _productionPlanBOMDetailService = productionPlanBOMDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanBOMDetail()
        {
            try
            {

                List<Core.Models.ProductionPlanBOMDetail> productionPlanBOMDetail = await _productionPlanBOMDetailService.GetAllAsync();

                var res = productionPlanBOMDetail == null
                    ? null
                    : productionPlanBOMDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanBOMDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanBOMDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanBOMDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanBOMDetailByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanBOMDetail productionPlanBOMDetail = await _productionPlanBOMDetailService.GetProductionPlanBOMDetailByIdAsync(id);

                var res = productionPlanBOMDetail == null
                    ? null
                    : (new List<Core.Models.ProductionPlanBOMDetail> { productionPlanBOMDetail }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanBOMDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanBOMDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanBOMDetailDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanBOMDetail productionPlanBOMDetail)
        {
            try
            {

                int result = _productionPlanBOMDetailService.Append(productionPlanBOMDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanBOMDetail productionPlanBOMDetail)
        {
            try
            {

                bool result = _productionPlanBOMDetailService.Update(productionPlanBOMDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetail update failed");
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
                long result = _productionPlanBOMDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetail delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetListByProductionPlanId(int id)
        {
            try
            {

                List<Core.Models.ProductionPlanBOMDetail> productionPlanBOMDetail = await _productionPlanBOMDetailService.GetListByProductionPlanIdAsync(id);

                var res = productionPlanBOMDetail == null
                    ? null
                    : productionPlanBOMDetail.ConvertToListDto();


                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanBOMDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanBOMDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanBOMDetailDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> BOMRevise([FromBody] List<ProductionPlanBOMDetail> productionPlanBOMDetailList)
        {
            try
            {

                bool result = _productionPlanBOMDetailService.BOMRevise(productionPlanBOMDetailList);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetail BOMRevise failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

    }
}
