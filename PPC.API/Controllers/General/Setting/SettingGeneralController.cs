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
    public class SettingGeneralController : Controller
    {

        #region Prop

        private readonly ISettingGeneralsService _settingGeneralsService;

        #endregion

        #region Ctor

        public SettingGeneralController(ISettingGeneralsService settingGeneralsService)
        {
            _settingGeneralsService = settingGeneralsService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetSettingGenerals()
        {
            try
            {

                List<Core.Models.SettingGenerals> settingGenerals = await _settingGeneralsService.GetAllAsync();

                var res = settingGenerals.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get SettingGenerals List failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingGeneralsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingGeneralsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetSettingGeneralsByID(int id)
        {
            try
            {

                Core.Models.SettingGenerals settingGenerals = await _settingGeneralsService.GetSettingGeneralsByIdAsync(id);

                var res = (new List<Core.Models.SettingGenerals> { settingGenerals }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get settingGenerals failed");
                return Ok(ResponseFactory.OKCreator(new List<SettingGeneralsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SettingGeneralsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistSettingGenerals/{name}")]
        public async Task<IActionResult> ExistSettingGenerals(string name)
        {
            try
            {

                var result = _settingGeneralsService.ExistSettingGeneralsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get SettingGenerals failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] SettingGeneralsDTO settingGenerals)
        {
            try
            {
                SettingGenerals settingGeneral = new SettingGenerals();
                try
                {
                    var mapper = Functions.CreateMapper<SettingGeneralsDTO, SettingGenerals>();
                    settingGeneral = mapper(settingGenerals);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }


                bool result = _settingGeneralsService.Append(settingGeneral);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SettingGenerals append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] SettingGeneralsDTO settingGenerals)
        {
            try
            {
                SettingGenerals settingGeneral = new SettingGenerals();
                try
                {
                    var mapper = Functions.CreateMapper<SettingGeneralsDTO, SettingGenerals>();
                    settingGeneral = mapper(settingGenerals);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }

                bool result = _settingGeneralsService.Update(settingGeneral);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SettingGenerals update failed");
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
                long result = _settingGeneralsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SettingGenerals update failed");
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
