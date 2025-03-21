using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using PPC.Base.Models.Exceptions;
using PPC.Base;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Linq;
using PPC.Core.Extensions;

namespace PPC.API.Controllers
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class RawMaterialGroupController : Controller
    {

        #region Prop

        private readonly IRawMaterialGroupsService _rawMaterialGroupsService;

        #endregion

        #region Ctor

        public RawMaterialGroupController(IRawMaterialGroupsService rawMaterialGroupsService)
        {
            _rawMaterialGroupsService = rawMaterialGroupsService;
        }

        #endregion

        [HttpGet]
        [Route("RawMaterialGroups/GetRawMaterialGroups")]
        public async Task<IActionResult> GetRawMaterialGroups()
        {
            try
            {

                List<Core.Models.RawMaterialGroups> rawMaterialGroups = await _rawMaterialGroupsService.GetAllAsync();

                var res = rawMaterialGroups.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialGroups List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialGroupsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("RawMaterialGroups/GetRawMaterialGroupsById/{rawMaterialGroupID}")]
        public async Task<IActionResult> GetRawMaterialGroupsByID(int rawMaterialGroupID)
        {
            try
            {

                Core.Models.RawMaterialGroups rawMaterialGroups = await _rawMaterialGroupsService.GetRawMaterialGroupsByIdAsync(rawMaterialGroupID);

                var res = (new List<Core.Models.RawMaterialGroups> { rawMaterialGroups }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialGroups failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialGroupsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("RawMaterialGroups/ExistRawMaterialGroups/{name}")]
        public async Task<IActionResult> ExistRawMaterialGroups(string name)
        {
            try
            {

                var result = _rawMaterialGroupsService.ExistRawMaterialGroupsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialGroups failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("RawMaterialGroups/Append")]
        public IActionResult Append([FromBody] RawMaterialGroupsDTO rawMaterialGroups)
        {
            try
            {
                RawMaterialGroups rawMaterialGroup = new RawMaterialGroups();
                var mapper = Functions.CreateMapper<RawMaterialGroupsDTO, RawMaterialGroups>();
                rawMaterialGroup = mapper(rawMaterialGroups);

                bool result = _rawMaterialGroupsService.Append(rawMaterialGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialGroups append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("RawMaterialGroups/Update")]
        public IActionResult Update([FromBody] RawMaterialGroupsDTO rawMaterialGroups)
        {
            try
            {
                RawMaterialGroups rawMaterialGroup = new RawMaterialGroups();
                var mapper = Functions.CreateMapper<RawMaterialGroupsDTO, RawMaterialGroups>();
                rawMaterialGroup = mapper(rawMaterialGroups);

                bool result = _rawMaterialGroupsService.Update(rawMaterialGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialGroups update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("RawMaterialGroups/Delete/{rawMaterialGroupID}")]
        public IActionResult Delete(int rawMaterialGroupID)
        {
            try
            {
                long result = _rawMaterialGroupsService.Delete(rawMaterialGroupID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialGroups update failed");
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