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
    public class UserGroupController : Controller
    {

        #region Prop

        private readonly IUserGroupsService _userGroupsService;

        #endregion

        #region Ctor

        public UserGroupController(IUserGroupsService userGroupsService)
        {
            _userGroupsService = userGroupsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetUserGroups()
        {
            try
            {

                List<Core.Models.UserGroups> userGroups = await _userGroupsService.GetAllAsync();

                var res = userGroups.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get UserGroups List failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetUserGroupsByID(int id)
        {
            try
            {

                Core.Models.UserGroups userGroups = await _userGroupsService.GetUserGroupsByIdAsync(id);

                var res = (new List<Core.Models.UserGroups> { userGroups }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get userGroups failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{name}")]

        public async Task<IActionResult> ExistUserGroups(string name)
        {
            try
            {

                var result = _userGroupsService.ExistUserGroupsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get UserGroups failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] UserGroups userGroup)
        {
            try
            {

                int result =  _userGroupsService.Append(userGroup);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroups append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserGroups userGroup)
        {
            try
            {

                bool result = _userGroupsService.Update(userGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroups update failed");
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
                long result = _userGroupsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroups delete failed");
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
