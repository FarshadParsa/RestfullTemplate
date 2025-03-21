using Microsoft.AspNetCore.Mvc;

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

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class SettingUpdateController : Controller
    {

        #region Prop

        private readonly ISettingUpdatesService _settingUpdatesService;

        #endregion

        #region Ctor

        public SettingUpdateController(ISettingUpdatesService settingUpdatesService)
        {
            _settingUpdatesService = settingUpdatesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetSettingUpdates()
        {
            try
            {

                List<Core.Models.SettingUpdates> settingUpdates = await _settingUpdatesService.GetAllAsync();

                var res = settingUpdates.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get SettingUpdates List failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingUpdatesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingUpdatesDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetSettingUpdatesByID(int id)
        {
            try
            {

                Core.Models.SettingUpdates settingUpdates = await _settingUpdatesService.GetSettingUpdatesByIdAsync(id);

                var res = (new List<Core.Models.SettingUpdates> { settingUpdates }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settingUpdates failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingUpdatesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingUpdatesDTO>>(e));
            }

        }

        [HttpPost]

        public IActionResult Append([FromBody] SettingUpdatesDTO settingUpdates)
        {
            try
            {
                SettingUpdates settingUpdate = new SettingUpdates();
                try
                {
                    var mapper = Functions.CreateMapper<SettingUpdatesDTO, SettingUpdates>();
                    settingUpdate = mapper(settingUpdates);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }


                bool result = _settingUpdatesService.Append(settingUpdate);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SettingUpdates append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] SettingUpdatesDTO settingUpdates)
        {
            try
            {
                SettingUpdates settingUpdate = new SettingUpdates();
                try
                {
                    var mapper = Functions.CreateMapper<SettingUpdatesDTO, SettingUpdates>();
                    settingUpdate = mapper(settingUpdates);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }

                bool result = _settingUpdatesService.Update(settingUpdate);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SettingUpdates update failed");
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
                long result = _settingUpdatesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SettingUpdates update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[controller]/[Action]/{version}")]
        public async Task<IActionResult> GetSettingUpdatesByVersion(string version)
        {
            try
            {
                Core.Models.SettingUpdates settingUpdates = await _settingUpdatesService.GetSettingUpdatesByVersionAsync(version);

                var res = (new List<Core.Models.SettingUpdates> { settingUpdates }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settingUpdates failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingUpdatesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingUpdatesDTO>>(e));
            }

        }



    }
}
