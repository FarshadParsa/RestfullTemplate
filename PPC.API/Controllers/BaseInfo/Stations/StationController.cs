using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Log;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PPC.Core.Interface;
using PPC.Core.Extensions;
using System.Linq;
using PPC.Core.Common;
using Microsoft.AspNetCore.Authorization;
using PPC.Core.Models;

namespace PPC.API.Controllers.BaseInfo.Stations
{

    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class StationController : Controller
    {
        #region Prop
        private readonly IStationsService _stationsService;

        #endregion


        #region Ctor

        public StationController(IStationsService stationsService)
        {
            _stationsService = stationsService;
        }

        #endregion


        [HttpGet]
        [Route("BaseInfo/Stations/GetActiveStations")]
        public async Task<IActionResult> GetActiveStations()
        {
            try
            {

                List<Core.Models.Stations> station = await _stationsService.GetStationsAsync(true);

                var res = station.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Station List failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Stations/GetInactiveStations")]
        public async Task<IActionResult> GetInactiveStations()
        {
            try
            {

                List<Core.Models.Stations> station = await _stationsService.GetStationsAsync(false);

                var res = station.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Station List failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Stations/GetAllStations")]
        public async Task<IActionResult> GetAllStations()
        {
            try
            {

                List<Core.Models.Stations> station =  await _stationsService.GetStationsAsync();

                var res = station.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Station List failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e));
            }

        }


        [HttpGet]
        [Route("BaseInfo/Stations/GetStationByID/{staionID}")]
        public async Task<IActionResult> GetStationByID(int staionID)
        {
            try
            {

                Core.Models.Stations station = await _stationsService.GetStationByIdAsync(staionID);

                //var res = station.ConvertToDto();
                var res = (new List<Core.Models.Stations> { station }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Station  failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetStations()
        {
            try
            {

                List<Core.Models.Stations> station = await _stationsService.GetAllAsync();

                var res = station.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Stations List failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetStationsByID(int id)
        {
            try
            {

                Core.Models.Stations station = await _stationsService.GetStationsByIdAsync(id);

                var res = (new List<Core.Models.Stations> { station }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get station failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<StationsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{name}")]
        public async Task<IActionResult> ExistStations(string name)
        {
            try
            {

                var result = _stationsService.ExistStationsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Stations failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] Core.Models.Stations stations)
        {
            try
            {

                if(stations == null) {

                    throw new System.Exception("مقادیر اطلاعات وارد شده نامعتبر می باشد");
                }

                int result = _stationsService.Append(stations);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Stations append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Core.Models.Stations stations)
        {
            try
            {

                bool result = _stationsService.Update(stations);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Stations update failed");
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
                long result = _stationsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Stations delete failed");
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
