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
    public class ProductionPlanPatilsController : Controller
    {

        #region Prop

        private readonly IProductionPlanPatilsService _productionPlanPatilsService;

        #endregion

        #region Ctor

        public ProductionPlanPatilsController(IProductionPlanPatilsService productionPlanPatilsService)
        {
            _productionPlanPatilsService = productionPlanPatilsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanPatils()
        {
            try
            {

                List<Core.Models.ProductionPlanPatils> productionPlanPatils = await _productionPlanPatilsService.GetAllAsync();

                //var res = productionPlanPatils == null
                //    ? null
                //    : productionPlanPatils.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<ProductionPlanPatils>, List<ProductionPlanPatilsDTO>>(productionPlanPatils);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanPatils List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlanPatilsByID(int id)
        {
            try
            {

                Core.Models.ProductionPlanPatils productionPlanPatils = await _productionPlanPatilsService.GetProductionPlanPatilsByIdAsync(id);

                //var res = productionPlanPatils == null
                //    ? null
                //    : (new List<Core.Models.ProductionPlanPatils> { productionPlanPatils }).ConvertToListDto();

                var res = new List<ProductionPlanPatilsDTO> { ExtAutoMapper.JsonMap<ProductionPlanPatils, ProductionPlanPatilsDTO>(productionPlanPatils) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanPatils failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlanPatils productionPlanPatils)
        {
            try
            {

                int result = _productionPlanPatilsService.Append(productionPlanPatils);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPatils append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlanPatils productionPlanPatils)
        {
            try
            {

                bool result = _productionPlanPatilsService.Update(productionPlanPatils);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPatils update failed");
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
                long result = _productionPlanPatilsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlanPatils delete failed");
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

                List<Core.Models.ProductionPlanPatils> productionPlanPatils = await _productionPlanPatilsService.GetListByProductionPlanIdAsync(id);

                //var res = productionPlanPatils == null
                //    ? null
                //    : productionPlanPatils.ConvertToListDto();

                var res =  ExtAutoMapper.JsonMap<List<ProductionPlanPatils>, List< ProductionPlanPatilsDTO> >(productionPlanPatils) ;

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanPatils List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDropdownListByProductionPlanId(int id)
        {
            try
            {

                List<Core.Models.ProductionPlanPatils> productionPlanPatils = await _productionPlanPatilsService.GetDropdownListByProductionPlanIdAsync(id);

                //var res = productionPlanPatils == null
                //    ? null
                //    : productionPlanPatils.ConvertToListDto();
                
                var res = ExtAutoMapper.JsonMap<List<ProductionPlanPatils>, List<ProductionPlanPatilsDTO>>(productionPlanPatils);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlanPatils List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPatilsLatestUsgedBOM(int id)
        {
            try
            {

                Core.Models.ProductionPlanPatils productionPlanPatils = await _productionPlanPatilsService.GetPatilsLatestUsgedBOMAsync(id);

                //var res = productionPlanPatils == null
                //    ? null
                //    : (new List<Core.Models.ProductionPlanPatils> { productionPlanPatils }).ConvertToListDto();

                var res = new List<ProductionPlanPatilsDTO> { ExtAutoMapper.JsonMap<ProductionPlanPatils, ProductionPlanPatilsDTO>(productionPlanPatils) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlanPatils failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlanPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlanPatilsDTO>>(e));
            }

        }

    }
}

