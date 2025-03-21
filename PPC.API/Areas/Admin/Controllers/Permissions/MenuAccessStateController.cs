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

namespace PPC.API.Controllers.Admin
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class MenuAccessStateController : Controller
    {

        #region Prop

        private readonly IMenuAccessStatesService _menuAccessStatesService;

        #endregion

        #region Ctor

        public MenuAccessStateController(IMenuAccessStatesService menuAccessStatesService)
        {
            _menuAccessStatesService = menuAccessStatesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetMenuAccessStates()
        {
            try
            {

                List<MenuAccessStates> menuAccessStates = await _menuAccessStatesService.GetAllAsync();

                var res = menuAccessStates.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get MenuAccessStates List failed");
                return Ok(ResponseFactory.OKCreator(new List<MenuAccessStatesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<MenuAccessStatesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetMenuAccessStatesByID(int id)
        {
            try
            {

                MenuAccessStates menuAccessStates = await _menuAccessStatesService.GetMenuAccessStatesByIdAsync(id);

                var res = new List<MenuAccessStates> { menuAccessStates }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get menuAccessStates failed");
                return Ok(ResponseFactory.OKCreator(new List<MenuAccessStatesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<MenuAccessStatesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistMenuAccessStates/{name}")]
        public async Task<IActionResult> ExistMenuAccessStates(string name)
        {
            try
            {

                var result = _menuAccessStatesService.ExistMenuAccessStatesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get MenuAccessStates failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] MenuAccessStatesDTO menuAccessStates)
        {
            try
            {
                MenuAccessStates menuAccessState = new MenuAccessStates();
                try
                {
                    var mapper = Functions.CreateMapper<MenuAccessStatesDTO, MenuAccessStates>();
                    menuAccessState = mapper(menuAccessStates);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }


                bool result = _menuAccessStatesService.Append(menuAccessState);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"MenuAccessStates append failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] MenuAccessStatesDTO menuAccessStates)
        {
            try
            {
                MenuAccessStates menuAccessState = new MenuAccessStates();
                try
                {
                    var mapper = Functions.CreateMapper<MenuAccessStatesDTO, MenuAccessStates>();
                    menuAccessState = mapper(menuAccessStates);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }

                bool result = _menuAccessStatesService.Update(menuAccessState);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"MenuAccessStates update failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
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
                long result = _menuAccessStatesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"MenuAccessStates update failed");
                return Ok(ResponseFactory.OKCreator(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{groupId}")]
        public async Task<IActionResult> GetMenuAccessStatesByGroupId(byte groupId)
        {
            try
            {

                List<MenuAccessStates> menuAccessStates = await _menuAccessStatesService.GetMenuAccessStatesByGroupIdAsync(groupId);

                var res = menuAccessStates.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get menuAccessStates failed");
                return Ok(ResponseFactory.OKCreator(new List<MenuAccessStatesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<MenuAccessStatesDTO>>(e));
            }

        }

    }
}
