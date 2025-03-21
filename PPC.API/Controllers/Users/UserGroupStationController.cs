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
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class UserGroupStationController : Controller
    {

        #region Prop

        private readonly IUserGroupStationsService _userGroupStationsService;

        #endregion

        #region Ctor

        public UserGroupStationController(IUserGroupStationsService userGroupStationsService)
        {
            _userGroupStationsService = userGroupStationsService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetUserGroupStations()
        {
            try
            {

                List<Core.Models.UserGroupStations> userGroupStations = await _userGroupStationsService.GetAllAsync();

                var res = userGroupStations.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get UserGroupStations List failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupStationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupStationsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetUserGroupStationsByID(int id)
        {
            try
            {

                Core.Models.UserGroupStations userGroupStations = await _userGroupStationsService.GetUserGroupStationsByIdAsync(id);

                var res = (new List<Core.Models.UserGroupStations> { userGroupStations }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get userGroupStations failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupStationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupStationsDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] List<UserGroupStations> userGroupStation)
        {
            try
            {

                List <UserGroupStations> result = _userGroupStationsService.Append(userGroupStation);

                var res = new List<List<UserGroupStations>> { result };

                return Ok(ResponseFactory.OKCreator<List<List<UserGroupStations>>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroupStations append failed");
                return Ok(ResponseFactory.OKCreator<List<UserGroupStations>>(new List<UserGroupStations>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupStations>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserGroupStations userGroupStation)
        {
            try
            {

                bool result = _userGroupStationsService.Update(userGroupStation);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroupStations update failed");
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
                long result = _userGroupStationsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroupStations delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        //[HttpGet("[Controller]/[Action]/{id}")]
        public async Task<IActionResult> GetUserGroupStationsByUserGroupId(int id)
        {
            try
            {

                List<Core.Models.UserGroupStations> userGroupStations = await _userGroupStationsService.GetAllByUserGroupIdAsync(id);

                var res = userGroupStations.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get UserGroupStations List failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupStationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupStationsDTO>>(e));
            }

        }

    }
}
