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
    public class BOMDetailController : Controller
    {

        #region Prop

        private readonly IBOMDetailService _bOMDetailService;

        #endregion

        #region Ctor

        public BOMDetailController(IBOMDetailService bOMDetailService)
        {
            _bOMDetailService = bOMDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetBOMDetail()
        {
            try
            {

                List<Core.Models.BOMDetail> bOMDetail = await _bOMDetailService.GetAllAsync();

                var res = bOMDetail == null
                    ? null
                    : bOMDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOMDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBOMDetailByID(int id)
        {
            try
            {

                Core.Models.BOMDetail bOMDetail = await _bOMDetailService.GetBOMDetailByIdAsync(id);

                var res = bOMDetail == null
                    ? null
                    : (new List<Core.Models.BOMDetail> { bOMDetail }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get bOMDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDetailDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] BOMDetail bOMDetail)
        {
            try
            {

                int result = _bOMDetailService.Append(bOMDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOMDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] BOMDetail bOMDetail)
        {
            try
            {

                bool result = _bOMDetailService.Update(bOMDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOMDetail update failed");
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
                long result = _bOMDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOMDetail delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListByBOMId(int id)
        {
            try
            {

                List<Core.Models.BOMDetail> bOMDetail = await _bOMDetailService.GetListByBOMIdAsync(id);

                var res = bOMDetail == null
                    ? null
                    : bOMDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOMDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDetailDTO>>(e));
            }

        }



    }
}
