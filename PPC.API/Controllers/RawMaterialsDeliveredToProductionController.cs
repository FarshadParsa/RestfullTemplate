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
    public class RawMaterialsDeliveredToProductionController : Controller
    {

        #region Prop

        private readonly IRawMaterialsDeliveredToProductionService _rawMaterialsDeliveredToProductionService;

        #endregion

        #region Ctor

        public RawMaterialsDeliveredToProductionController(IRawMaterialsDeliveredToProductionService rawMaterialsDeliveredToProductionService)
        {
            _rawMaterialsDeliveredToProductionService = rawMaterialsDeliveredToProductionService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialsDeliveredToProduction()
        {
            try
            {

                List<Core.Models.RawMaterialsDeliveredToProduction> rawMaterialsDeliveredToProduction = await _rawMaterialsDeliveredToProductionService.GetAllAsync();

                //var res = rawMaterialsDeliveredToProduction == null
                //    ? null
                //    : rawMaterialsDeliveredToProduction.ConvertToListDto();
                //return Ok(ResponseFactory.OKCreator(res, res.Count()));
                

                var res = ExtAutoMapper.MapToJsonList< List<RawMaterialsDeliveredToProduction> , List<RawMaterialsDeliveredToProductionDTO> >(rawMaterialsDeliveredToProduction);
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialsDeliveredToProduction List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDeliveredToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDeliveredToProductionDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialsDeliveredToProductionByID(int id)
        {
            try
            {

                Core.Models.RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction = await _rawMaterialsDeliveredToProductionService.GetRawMaterialsDeliveredToProductionByIdAsync(id);

                var res = rawMaterialsDeliveredToProduction == null
                    ? null
                    : (new List<Core.Models.RawMaterialsDeliveredToProduction> { rawMaterialsDeliveredToProduction }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialsDeliveredToProduction failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDeliveredToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDeliveredToProductionDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction)
        {
            try
            {

                int result = _rawMaterialsDeliveredToProductionService.Append(rawMaterialsDeliveredToProduction);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialsDeliveredToProduction append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RawMaterialsDeliveredToProduction rawMaterialsDeliveredToProduction)
        {
            try
            {

                var R = Request;
                var isss = ModelState.IsValid;

                bool result = _rawMaterialsDeliveredToProductionService.Update(rawMaterialsDeliveredToProduction);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialsDeliveredToProduction update failed");
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
                long result = _rawMaterialsDeliveredToProductionService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialsDeliveredToProduction delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{status}/{dateFrom?}/{dateTo?}")]
        public async Task<IActionResult> GetListByStatus(byte status, string dateFrom, string dateTo)
        {
            try
            {

                List<Core.Models.RawMaterialsDeliveredToProduction> rawMaterialsDeliveredToProduction = await _rawMaterialsDeliveredToProductionService.GetAllAsync();

                //var res = rawMaterialsDeliveredToProduction == null
                //    ? null
                //    : rawMaterialsDeliveredToProduction.ConvertToListDto();
                //return Ok(ResponseFactory.OKCreator(res, res.Count()));


                var res = ExtAutoMapper.MapToJsonList<List<RawMaterialsDeliveredToProduction>, List<RawMaterialsDeliveredToProductionDTO>>(rawMaterialsDeliveredToProduction);
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialsDeliveredToProduction List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDeliveredToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDeliveredToProductionDTO>>(e));
            }

        }


    }
}
