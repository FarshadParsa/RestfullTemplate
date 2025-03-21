using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Services;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PPC.API.Controllers
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

                var res = new List<string> { PPC.Common.General.CurrentDateString };

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

                var res = new List<string> { PPC.Common.General.CurrentTimeString};

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

                var res = new List<string> { PPC.Common.General.CurrentTimeWithSecondString };

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
