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
using PPC.Core.Services;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class RMWhiteListsController : Controller
    {

        #region Prop

        private readonly IRMWhiteListsService _rMWhiteListsService;

        #endregion

        #region Ctor

        public RMWhiteListsController(IRMWhiteListsService rMWhiteListsService)
        {
            _rMWhiteListsService = rMWhiteListsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRMWhiteLists()
        {
            try
            {

                List<Core.Models.RMWhiteLists> rMWhiteLists = await _rMWhiteListsService.GetAllAsync();

                var res = rMWhiteLists == null
                    ? null
                    : rMWhiteLists.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RMWhiteLists List failed");
                return Ok(ResponseFactory.OKCreator(new List<RMWhiteListsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RMWhiteListsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRMWhiteListsByID(int id)
        {
            try
            {

                Core.Models.RMWhiteLists rMWhiteLists = await _rMWhiteListsService.GetRMWhiteListsByIdAsync(id);

                var res = rMWhiteLists == null
                    ? null
                    : (new List<Core.Models.RMWhiteLists> { rMWhiteLists }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rMWhiteLists failed");
                return Ok(ResponseFactory.OKCreator(new List<RMWhiteListsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RMWhiteListsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {

                var rmWhiteLists = await _rMWhiteListsService.GetByCodeAsync(code);

                var res = rmWhiteLists == null
                    ? null
                    : (new List<Core.Models.RMWhiteLists> { rmWhiteLists }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RMWhiteLists failed");
                return Ok(ResponseFactory.OKCreator<List<RMWhiteLists>>(new List<RMWhiteLists>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<RMWhiteLists>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RMWhiteLists rMWhiteLists)
        {
            try
            {

                int result = _rMWhiteListsService.Append(rMWhiteLists);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RMWhiteLists append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RMWhiteLists rMWhiteLists)
        {
            try
            {

                bool result = _rMWhiteListsService.Update(rMWhiteLists);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RMWhiteLists update failed");
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
                long result = _rMWhiteListsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RMWhiteLists delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListForDropDown()
        {
            try
            {

                List<Core.Models.RMWhiteLists> rmWhiteList = await _rMWhiteListsService.GetAllForDropDownAsync();

                var res = rmWhiteList == null
                    ? null
                    : rmWhiteList.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RMWhiteList List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDTO>>(e));
            }

        }




    }
}

