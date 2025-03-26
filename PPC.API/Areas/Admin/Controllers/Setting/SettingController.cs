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

namespace PPC.API.Controllers.General.Setting
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class SettingController : Controller
    {

        #region Prop

        private readonly ISettingsService _settingsService;

        #endregion

        #region Ctor

        public SettingController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            try
            {

                List<Settings> settings = await _settingsService.GetAllAsync();

                var res = settings.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Settings List failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetSettingsByID(int id)
        {
            try
            {

                Settings settings = await _settingsService.GetSettingsByIdAsync(id);

                var res = new List<Settings> { settings }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settings failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingsDTO>>(e));
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                long result = _settingsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Settings update failed");
                return Ok(ResponseFactory.OKCreator(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetActiveVersion()
        {
            try
            {

                Settings settings = await _settingsService.GetActiveVersionAsync();

                var res = new List<Settings> { settings }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settings failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetActiveVersionByUserId(int id)
        {
            try
            {

                Settings settings = await _settingsService.GetActiveVersionByUserIdAsync(id);

                var res = new List<Settings> { settings }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settings failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetActiveVersionStationId(int id)
        {
            try
            {

                Settings settings = await _settingsService.GetActiveVersionByStationIdAsync(id);

                var res = new List<Settings> { settings }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settings failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingsDTO>>(e));
            }

        }


    }
}

