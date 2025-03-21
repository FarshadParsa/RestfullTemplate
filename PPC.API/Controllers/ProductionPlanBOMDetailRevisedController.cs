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
    public class ProductionPlanBOMDetailRevisedController : Controller
    {

        #region Prop

        private readonly IProductionPlanBOMDetailRevisedService _productionPlanBOMDetailRevisedService;

        #endregion

        #region Ctor

        public ProductionPlanBOMDetailRevisedController(IProductionPlanBOMDetailRevisedService productionPlanBOMDetailRevisedService)
        {
            _productionPlanBOMDetailRevisedService = productionPlanBOMDetailRevisedService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanBOMDetailRevised()
        {
            try
            {

                List<Core.Models.ProductionPlanBOMDetailRevised> productionPlanBOMDetailRevised = await _productionPlanBOMDetailRevisedService.GetAllAsync();

                var res = productionPlanBOMDetailRevised == null
                    ? null
                    : productionPlanBOMDetailRevised.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanBOMDetailRevised List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanBOMDetailRevisedDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanBOMDetailRevisedDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanBOMDetailRevisedByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised = await _productionPlanBOMDetailRevisedService.GetProductionPlanBOMDetailRevisedByIdAsync(id);

                var res = productionPlanBOMDetailRevised == null
                    ? null
                    : (new List<Core.Models.ProductionPlanBOMDetailRevised> { productionPlanBOMDetailRevised }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanBOMDetailRevised failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanBOMDetailRevisedDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanBOMDetailRevisedDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised)
        {
            try
            {

                int result = _productionPlanBOMDetailRevisedService.Append(productionPlanBOMDetailRevised);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetailRevised append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanBOMDetailRevised productionPlanBOMDetailRevised)
        {
            try
            {

                bool result = _productionPlanBOMDetailRevisedService.Update(productionPlanBOMDetailRevised);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetailRevised update failed");
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
                long result = _productionPlanBOMDetailRevisedService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanBOMDetailRevised delete failed");
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
