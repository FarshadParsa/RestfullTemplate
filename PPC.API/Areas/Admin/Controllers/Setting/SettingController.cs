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

        //[HttpPost]
        //public IActionResult Append([FromBody] SettingsDTO settings)
        //{
        //    try
        //    {
        //        Settings setting = new Settings();
        //        try
        //        {
        //            var mapper = Functions.CreateMapper<SettingsDTO, Settings>();
        //            setting = mapper(settings);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
        //        }


        //        bool result = _settingsService.Append(setting);

        //        var res = new List<bool> { result };

        //        return Ok(ResponseFactory.OKCreator(res, res.Count()));
        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Settings append failed");
        //        return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ... ", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }
        //}


        [HttpPost]
        public IActionResult Append([FromBody] SettingUpdateViewModelDTO settingViewModel)
        {
            try
            {
                SettingUpdateViewModel settingUpdateViewModel = new SettingUpdateViewModel();
                try
                {
                    var mapper = Functions.CreateMapper<SettingUpdateViewModelDTO, SettingUpdateViewModel>();
                    settingUpdateViewModel = mapper(settingViewModel);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }


                bool result = _settingsService.Append(settingUpdateViewModel);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Settings append failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        //[HttpPost]
        //public IActionResult Update([FromBody] SettingsDTO settings)
        //{
        //    try
        //    {
        //        Settings setting = new Settings();
        //        try
        //        {
        //            var mapper = Functions.CreateMapper<SettingsDTO, Settings>();
        //            setting = mapper(settings);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
        //        }

        //        bool result = _settingsService.Update(setting);

        //        var res = new List<bool> { result };

        //        return Ok(ResponseFactory.OKCreator(res, res.Count()));
        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Settings update failed");
        //        return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ... ", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }
        //}

        [HttpPost]
        //public IActionResult Update([FromBody] SettingUpdateViewModelDTO settingViewModel)
        public IActionResult Update([FromBody] SettingUpdateViewModel settingUpdate)
        {
            try
            {
                //SettingUpdateViewModel settingUpdate = new SettingUpdateViewModel();
                //try
                //{
                //    var mapper = Functions.CreateMapper<SettingUpdateViewModelDTO, SettingUpdateViewModel>();
                //    settingUpdate = mapper(settingViewModel);
                //}
                //catch (System.Exception ex)
                //{
                //    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                //}

                bool result = _settingsService.Update(settingUpdate);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Settings update failed");
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

        [HttpGet]
        public async Task<IActionResult> GetAllVersionInfo()
        {
            try
            {

                List<SettingUpdateViewModel> settings = await _settingsService.GetAllVersionInfo();

                var res = settings.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Settings List failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingUpdateViewModelDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingUpdateViewModelDTO>>(e));
            }

        }

        [HttpGet("[controller]/[Action]/{version?}")]
        public async Task<IActionResult> GetSettingUsers(string version)
        {
            try
            {



                List<SettingUserViewModel> settings = _settingsService.GetSettingUsers(version);

                var res = settings.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settings failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingUserViewModelDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingUserViewModelDTO>>(e));
            }

        }

        [HttpGet("[controller]/[Action]/{version?}")]
        public async Task<IActionResult> GetSettingStations(string version)
        {
            try
            {



                List<SettingStationViewModel> settings = _settingsService.GetSettingStations(version);

                var res = settings.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settings failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingStationViewModelDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingStationViewModelDTO>>(e));
            }

        }


    }
}

