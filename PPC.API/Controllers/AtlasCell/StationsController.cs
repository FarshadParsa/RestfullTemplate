using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPC.Core.Extensions;
namespace PPC.API.Controllers
{
    [Route("api/AtlasCell/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class StationsController : Controller
    {

        #region Prop
        private readonly IStationsService _stationsService;


        #endregion

        #region Ctor

        public StationsController(IStationsService stationsService)
        {
            _stationsService = stationsService;
        }

        #endregion


        [HttpGet]
        [Route("GetStationLists")]
        public async Task<IActionResult> GetStationLists()
        {

            try
            {

                List<PPC.Core.Models.Stations> stations = _stationsService.GetAll();
                
                var res = stations.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<StationsDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get station List failed");
                return Ok(ResponseFactory.OKCreator<List<StationsDTO>>(new List<StationsDTO>(), 0));
            }
            catch (Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e.Message));
            }

        }



    }
}
