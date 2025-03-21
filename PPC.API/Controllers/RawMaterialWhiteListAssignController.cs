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
    public class RawMaterialWhiteListAssignController : Controller
    {

        #region Prop

        private readonly IRawMaterialWhiteListAssignService _rawMaterialWhiteListAssignService;

        #endregion

        #region Ctor

        public RawMaterialWhiteListAssignController(IRawMaterialWhiteListAssignService rawMaterialWhiteListAssignService)
        {
            _rawMaterialWhiteListAssignService = rawMaterialWhiteListAssignService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialWhiteListAssign()
        {
            try
            {

                List<Core.Models.RawMaterialWhiteListAssign> rawMaterialWhiteListAssign = await _rawMaterialWhiteListAssignService.GetAllAsync();

                var res = rawMaterialWhiteListAssign == null
                    ? null
                    : rawMaterialWhiteListAssign.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialWhiteListAssign List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialWhiteListAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialWhiteListAssignDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialWhiteListAssignByID(int id)
        {
            try
            {

                Core.Models.RawMaterialWhiteListAssign rawMaterialWhiteListAssign = await _rawMaterialWhiteListAssignService.GetRawMaterialWhiteListAssignByIdAsync(id);

                var res = rawMaterialWhiteListAssign == null
                    ? null
                    : (new List<Core.Models.RawMaterialWhiteListAssign> { rawMaterialWhiteListAssign }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialWhiteListAssign failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialWhiteListAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialWhiteListAssignDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RawMaterialWhiteListAssign rawMaterialWhiteListAssign)
        {
            try
            {

                int result = _rawMaterialWhiteListAssignService.Append(rawMaterialWhiteListAssign);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialWhiteListAssign append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RawMaterialWhiteListAssign rawMaterialWhiteListAssign)
        {
            try
            {

                bool result = _rawMaterialWhiteListAssignService.Update(rawMaterialWhiteListAssign);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialWhiteListAssign update failed");
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
                long result = _rawMaterialWhiteListAssignService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialWhiteListAssign delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetSelectorListByWhitelistId(int? id)
        {
            try
            {

                List<Core.Models.RawMaterialWhiteListAssign> rawMaterialWhiteListAssign = await _rawMaterialWhiteListAssignService.GetListByWhitelistIdAsync(id);

                var res = rawMaterialWhiteListAssign == null
                    ? null
                    : rawMaterialWhiteListAssign.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialWhiteListAssign List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialWhiteListAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialWhiteListAssignDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetListByRawMaterialId(int id)
        {
            try
            {

                List<Core.Models.RawMaterialWhiteListAssign> rawMaterialWhiteListAssign = await _rawMaterialWhiteListAssignService.GetListByRawMaterialIdAsync(id);

                var res = rawMaterialWhiteListAssign == null
                    ? null
                    : rawMaterialWhiteListAssign.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialWhiteListAssign List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialWhiteListAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialWhiteListAssignDTO>>(e));
            }

        }



    }
}
