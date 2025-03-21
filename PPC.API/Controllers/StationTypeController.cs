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
    public class StationTypeController : Controller
    {

        #region Prop

        private readonly IStationTypesService _stationTypesService;

        #endregion

        #region Ctor

        public StationTypeController(IStationTypesService stationTypesService)
        {
            _stationTypesService = stationTypesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetStationTypes()
        {
            try
            {

                List<Core.Models.StationTypes> stationTypes = await _stationTypesService.GetAllAsync();

                var res = stationTypes.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get StationTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<StationTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationTypesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetStationTypesByID(int id)
        {
            try
            {

                Core.Models.StationTypes stationTypes = await _stationTypesService.GetStationTypesByIdAsync(id);

                var res = (new List<Core.Models.StationTypes> { stationTypes }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get stationTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<StationTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationTypesDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{name}")]

        public async Task<IActionResult> ExistStationTypes(string name)
        {
            try
            {

                var result = _stationTypesService.ExistStationTypesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get StationTypes failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] StationTypes stationType)
        {
            try
            {

                StationTypes result = _stationTypesService.Append(stationType);

                var res = new List<StationTypes> { result };

                return Ok(ResponseFactory.OKCreator<List<StationTypes>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"StationTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<StationTypes>>(new List<StationTypes>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationTypes>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] StationTypes stationType)
        {
            try
            {

                bool result = _stationTypesService.Update(stationType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"StationTypes update failed");
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
                long result = _stationTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"StationTypes delete failed");
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
