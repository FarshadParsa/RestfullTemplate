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
    public class UserGroupAssignController : Controller
    {

        #region Prop

        private readonly IUserGroupAssignsService _userGroupAssignsService;

        #endregion

        #region Ctor

        public UserGroupAssignController(IUserGroupAssignsService userGroupAssignsService)
        {
            _userGroupAssignsService = userGroupAssignsService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetUserGroupAssigns()
        {
            try
            {

                List<Core.Models.UserGroupAssigns> userGroupAssigns = await _userGroupAssignsService.GetAllAsync();

                var res = userGroupAssigns.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get UserGroupAssigns List failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupAssignsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupAssignsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetUserGroupAssignsByID(int id)
        {
            try
            {

                Core.Models.UserGroupAssigns userGroupAssigns = await _userGroupAssignsService.GetUserGroupAssignsByIdAsync(id);

                var res = (new List<Core.Models.UserGroupAssigns> { userGroupAssigns }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get userGroupAssigns failed");
                return Ok(ResponseFactory.OKCreator(new List<UserGroupAssignsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupAssignsDTO>>(e));
            }

        }

      

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] List<UserGroupAssigns> userGroupAssign)
        {
            try
            {

                List<UserGroupAssigns> result = _userGroupAssignsService.Append(userGroupAssign);

                var res = new List<List<UserGroupAssigns>> { result };

                return Ok(ResponseFactory.OKCreator<List<List<UserGroupAssigns>>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroupAssigns append failed");
                return Ok(ResponseFactory.OKCreator<List<UserGroupAssigns>>(new List<UserGroupAssigns>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<UserGroupAssigns>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserGroupAssigns userGroupAssign)
        {
            try
            {

                bool result = _userGroupAssignsService.Update(userGroupAssign);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroupAssigns update failed");
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
                long result = _userGroupAssignsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"UserGroupAssigns delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserGroupAssignsByUserId(int id)
        {
            try
            {

                List<Core.Models.UserGroupAssigns> userGroupAssigns = await _userGroupAssignsService.GetAllByUserIdAsync(id);

                var res = userGroupAssigns.ConvertToListDto();
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


    }
}
