using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PPC.Base.Models.Exceptions;
using PPC.Base;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PPC.API.Controllers
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class DenyAccessController : Controller
    {

        #region Prop

        private readonly IDenyAccessesService _denyAccessesService;

        #endregion

        #region Ctor

        public DenyAccessController(IDenyAccessesService denyAccessesService)
        {
            _denyAccessesService = denyAccessesService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDenyAccesses()
        {
            try
            {

                List<Core.Models.DenyAccesses> denyAccesses = await _denyAccessesService.GetAllAsync();

                var res = denyAccesses.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DenyAccesses List failed");
                return Ok(ResponseFactory.OKCreator(new List<DenyAccessesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DenyAccessesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetDenyAccessesByID(int id)
        {
            try
            {

                Core.Models.DenyAccesses denyAccesses = await _denyAccessesService.GetDenyAccessesByIdAsync(id);

                var res = (new List<Core.Models.DenyAccesses> { denyAccesses }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get denyAccesses failed");
                return Ok(ResponseFactory.OKCreator(new List<DenyAccessesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DenyAccessesDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{name}")]

        public async Task<IActionResult> ExistDenyAccesses(string name)
        {
            try
            {

                var result = _denyAccessesService.ExistDenyAccessesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DenyAccesses failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public IActionResult Append([FromBody] DenyAccesses denyAccess)
        {
            try
            {

                bool result = _denyAccessesService.Append(denyAccess);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DenyAccesses append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DenyAccesses denyAccess)
        {
            try
            {

                bool result = _denyAccessesService.Update(denyAccess);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DenyAccesses update failed");
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
                long result = _denyAccessesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DenyAccesses delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{userId}")]
        public async Task<IActionResult> GetDenyAccessesListByUserID(int userId)
        {
            try
            {

                List<Core.Models.DenyAccesses> denyAccesses = await _denyAccessesService.GetAllByUserIdAsync(userId);

                var res = denyAccesses.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DenyAccesses List failed");
                return Ok(ResponseFactory.OKCreator(new List<DenyAccessesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DenyAccessesDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{stationId}")]
        public async Task<IActionResult> GetDenyAccessesListByStationID(int stationId)
        {
            try
            {
                List<Core.Models.DenyAccesses> denyAccesses = await _denyAccessesService.GetAllByStationIdAsync(stationId);

                var res = denyAccesses.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DenyAccesses List failed");
                return Ok(ResponseFactory.OKCreator(new List<DenyAccessesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DenyAccessesDTO>>(e));
            }

        }


        [HttpGet("[Controller]/[Action]/{userId}")]
        public IActionResult DeleteByUserId(int userId)
        {
            try
            {
                long result = _denyAccessesService.DeleteByUserIfExists(userId);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DenyAccesses delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{stationId}")]
        public IActionResult DeleteByStationId(int stationId)
        {
            try
            {
                long result = _denyAccessesService.DeleteByStationIfExists(stationId);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DenyAccesses delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{userId}/{stationId}")]
        public async Task<IActionResult> GetDenyAccessesStateListByID(int? userId, int? stationId)
        {
            try
            {
                //List<Core.Models.DenyAccesses> denyAccessesUsers = null;
                //List<Core.Models.DenyAccesses> denyAccessesStation = null;
                List<Core.Models.DenyAccesses> denyAccessesLists = null;

                //if (userId != null)
                //{
                //    denyAccessesUsers = await _denyAccessesService.GetAllByUserIdAsync(Convert.ToInt32(userId));
                //    var res = denyAccessesUsers.ConvertToListDto();
                //    return Ok(ResponseFactory.OKCreator(res, res.Count()));

                //}
                //else if (stationId != null)
                //{
                //    denyAccessesStation = await _denyAccessesService.GetAllBystationIdAsync(Convert.ToInt32(stationId));
                //    var res = denyAccessesStation.ConvertToListDto();
                //    return Ok(ResponseFactory.OKCreator(res, res.Count()));
                //}

                denyAccessesLists = await _denyAccessesService.GetAllByUserIdAsync(Convert.ToInt32(userId));
                if (denyAccessesLists?.Count == 0)
                    denyAccessesLists = await _denyAccessesService.GetAllByStationIdAsync(Convert.ToInt32(stationId));
                var res = denyAccessesLists.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));


            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DenyAccesses List failed");
                return Ok(ResponseFactory.OKCreator(new List<DenyAccessesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DenyAccessesDTO>>(e));
            }

        }


    }
}
