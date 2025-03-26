using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base.Models.Exceptions;
using WebApi.Core.Interface;
using WebApi.Core.Log;
using WebApi.Core.Services;
using WebApi.Response.DTOs;
using WebApi.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApi.API.Controllers
{

    [Authorize]
    public class GeneralController : Controller
    {

        [EnableCors("CorsPolicy")]
        public IActionResult Index()
        {
            
            return View();
        }

        #region Ctor

        public GeneralController()
        {

        }

        #endregion


        [HttpGet]
        [Route("GetDate")]
        public async Task<IActionResult> GetDate()
        {

            try
            {

                var res = new List<string> { WebApi.Common.General.CurrentDateString };

                return Ok(ResponseFactory.OKCreator<List<string>>(res, 1));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get date failed");
                return Ok(ResponseFactory.OKCreator<List<string>>(new List<string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
            }

        }

        [HttpGet]
        [Route("GetTime")]
        public async Task<IActionResult> GetTime()
        {

            try
            {

                var res = new List<string> { WebApi.Common.General.CurrentTimeString};

                return Ok(ResponseFactory.OKCreator<List<string>>(res, 1));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get date failed");
                return Ok(ResponseFactory.OKCreator<List<string>>(new List<string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
            }

        }

        [HttpGet]
        [Route("GetTimeWithSecond")]
        public async Task<IActionResult> GetTimeWithSecond()
        {

            try
            {

                var res = new List<string> { WebApi.Common.General.CurrentTimeWithSecondString };

                return Ok(ResponseFactory.OKCreator<List<string>>(res, 1));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get date failed");
                return Ok(ResponseFactory.OKCreator<List<string>>(new List<string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
            }

        }




    }
}
