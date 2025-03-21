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
    public class RawMaterialsDeliveredToProductionDetailController : Controller
    {

        #region Prop

        private readonly IRawMaterialsDeliveredToProductionDetailService _rawMaterialsDeliveredToProductionDetailService;

        #endregion

        #region Ctor

        public RawMaterialsDeliveredToProductionDetailController(IRawMaterialsDeliveredToProductionDetailService rawMaterialsDeliveredToProductionDetailService)
        {
            _rawMaterialsDeliveredToProductionDetailService = rawMaterialsDeliveredToProductionDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialsDeliveredToProductionDetail()
        {
            try
            {

                List<Core.Models.RawMaterialsDeliveredToProductionDetail> rawMaterialsDeliveredToProductionDetail = await _rawMaterialsDeliveredToProductionDetailService.GetAllAsync();

                var res = rawMaterialsDeliveredToProductionDetail == null
                    ? null
                    : rawMaterialsDeliveredToProductionDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialsDeliveredToProductionDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDeliveredToProductionDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDeliveredToProductionDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialsDeliveredToProductionDetailByID(int id)
        {
            try
            {

                Core.Models.RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail = await _rawMaterialsDeliveredToProductionDetailService.GetRawMaterialsDeliveredToProductionDetailByIdAsync(id);

                var res = rawMaterialsDeliveredToProductionDetail == null
                    ? null
                    : (new List<Core.Models.RawMaterialsDeliveredToProductionDetail> { rawMaterialsDeliveredToProductionDetail }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialsDeliveredToProductionDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDeliveredToProductionDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDeliveredToProductionDetailDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail)
        {
            try
            {

                int result = _rawMaterialsDeliveredToProductionDetailService.Append(rawMaterialsDeliveredToProductionDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialsDeliveredToProductionDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RawMaterialsDeliveredToProductionDetail rawMaterialsDeliveredToProductionDetail)
        {
            try
            {

                bool result = _rawMaterialsDeliveredToProductionDetailService.Update(rawMaterialsDeliveredToProductionDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialsDeliveredToProductionDetail update failed");
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
                long result = _rawMaterialsDeliveredToProductionDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialsDeliveredToProductionDetail delete failed");
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
