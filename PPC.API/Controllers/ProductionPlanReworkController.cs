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
    public class ProductionPlanReworkController : Controller
    {

        #region Prop

        private readonly IProductionPlanReworksService _productionPlanReworksService;

        #endregion

        #region Ctor

        public ProductionPlanReworkController(IProductionPlanReworksService productionPlanReworksService)
        {
            _productionPlanReworksService = productionPlanReworksService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanReworks()
        {
            try
            {

                List<Core.Models.ProductionPlanReworks> productionPlanReworks = await _productionPlanReworksService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<ProductionPlanReworks>, List<ProductionPlanReworksDTO>>(productionPlanReworks);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanReworks List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanReworksDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanReworksDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanReworksByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanReworks productionPlanReworks = await _productionPlanReworksService.GetProductionPlanReworksByIdAsync(id);


                var res = new List<ProductionPlanReworksDTO> { ExtAutoMapper.JsonMap<ProductionPlanReworks, ProductionPlanReworksDTO>(productionPlanReworks) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanReworks failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanReworksDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanReworksDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanReworks productionPlanRework)
        {
            try
            {

                int result = _productionPlanReworksService.Append(productionPlanRework);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworks append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanReworks productionPlanRework)
        {
            try
            {

                bool result = _productionPlanReworksService.Update(productionPlanRework);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworks update failed");
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
                long result = _productionPlanReworksService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworks delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxLevelNo(int id)
        {
            try
            {

                byte levelNo = _productionPlanReworksService.GetMaxLevelNoByPatilId(id);


                var res = new List<byte> { levelNo };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanReworks failed");
                return Ok(ResponseFactory.OKCreator(new List<byte>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<byte>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanReworksByProductionPlanId(int id)
        {
            try
            {

                List<Core.Models.ProductionPlanReworks> productionPlanReworks = await _productionPlanReworksService.GetInstanceByProductionPlanPatilIDAsync(id);


                var res = ExtAutoMapper.JsonMap<List<ProductionPlanReworks>, List<ProductionPlanReworksDTO>>(productionPlanReworks);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanReworks failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanReworksDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanReworksDTO>>(e));
            }

        }


        [HttpGet("[Controller]/[Action]/{productionPlanReworkID}/{userId}")]
        public IActionResult DeleteLogic(int productionPlanReworkID, int userId)
        {
            try
            {
                bool result = _productionPlanReworksService.DeleteLogic(productionPlanReworkID, userId);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanReworks delete failed");
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
