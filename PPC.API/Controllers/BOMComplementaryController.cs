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
using System.Security.Principal;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class BOMComplementaryController : Controller
    {

        #region Prop

        private readonly IBOMComplementaryService _bOMComplementaryService;

        #endregion

        #region Ctor

        public BOMComplementaryController(IBOMComplementaryService bOMComplementaryService)
        {
            _bOMComplementaryService = bOMComplementaryService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetBOMComplementary()
        {
            try
            {

                List<Core.Models.BOMComplementary> bOMComplementary = await _bOMComplementaryService.GetAllAsync();

                var res = bOMComplementary == null
                    ? null
                    : bOMComplementary.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOMComplementary List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMComplementaryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMComplementaryDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBOMComplementaryByID(int id)
        {
            try
            {

                Core.Models.BOMComplementary bOMComplementary = await _bOMComplementaryService.GetBOMComplementaryByIdAsync(id);

                var res = bOMComplementary == null
                    ? null
                    : (new List<Core.Models.BOMComplementary> { bOMComplementary }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get bOMComplementary failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMComplementaryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMComplementaryDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] BOMComplementary bOMComplementary)
        {
            try
            {

                int result = _bOMComplementaryService.Append(bOMComplementary);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOMComplementary append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] BOMComplementary bOMComplementary)
        {
            try
            {

                bool result = _bOMComplementaryService.Update(bOMComplementary);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOMComplementary update failed");
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
                long result = _bOMComplementaryService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOMComplementary delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListByRMWhiteListId(int id)
        {
            try
            {

                List<Core.Models.BOMComplementary> bOMComplementary = await _bOMComplementaryService.GetListByRMWhiteListIdAsync(id);

                var res = bOMComplementary == null
                    ? null
                    : bOMComplementary.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOMComplementary List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMComplementaryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMComplementaryDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByBOMDetailId(int id)
        {
            try
            {

                List<Core.Models.BOMComplementary> bOMComplementary = await _bOMComplementaryService.GetListByBOMDetailId(id);

                //var res = bOMComplementary == null
                //    ? null
                //    : bOMComplementary.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<BOMComplementary>, List<BOMComplementaryDTO>>(bOMComplementary);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOMComplementary List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMComplementaryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMComplementaryDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetListByBOMId(int id)
        {
            try
            {

                List<Core.Models.BOMComplementary> bOMComplementary = await _bOMComplementaryService.GetListByBOMId(id);

                var res = bOMComplementary == null
                    ? null
                    : bOMComplementary.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOMComplementary List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMComplementaryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMComplementaryDTO>>(e));
            }

        }

    }
}
