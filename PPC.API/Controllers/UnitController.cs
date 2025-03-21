using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Extensions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Core.Services;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using PPC.Base;

namespace PPC.API.Controllers
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class UnitController : Controller
    {

        #region Prop

        private readonly IUnitsService _unitsService;

        #endregion

        #region Ctor

        public UnitController(IUnitsService unitsService)
        {
            _unitsService = unitsService;
        }

        #endregion

        [HttpGet]
        [Route("BaseInfo/Units/GetUnits")]
        public async Task<IActionResult> GetUnits()
        {
            try
            {

                List<Core.Models.Units> units = await _unitsService.GetAllAsync();

                var res = units.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Units List failed");
                return Ok(ResponseFactory.OKCreator(new List<UnitsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UnitsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Units/GetUnitById/{unitID}")]
        public async Task<IActionResult> GetUnitByID(int unitID)
        {
            try
            {

                Core.Models.Units units = await _unitsService.GetUnitsByIdAsync(unitID);

                var res = (new List<Core.Models.Units> { units }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Units failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UnitsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Units/ExistUnits/{name}")]
        public async Task<IActionResult> ExistUnits(string name)
        {
            try
            {

                var result = _unitsService.ExistUnitsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Units failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Units/Append")]
        public IActionResult Append([FromBody] UnitsDTO units)
        {
            try
            {
                Units unit = new Units();
                var mapper = Functions.CreateMapper<UnitsDTO, Units>();
                unit = mapper(units);

                bool result = _unitsService.Append(unit);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Units append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Units/Update")]
        public IActionResult Update([FromBody] UnitsDTO units)
        {
            try
            {
                Units unit = new Units();
                var mapper = Functions.CreateMapper<UnitsDTO, Units>();
                unit = mapper(units);

                bool result = _unitsService.Update(unit);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Units update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Units/Delete/{unitID}")]
        public IActionResult Delete(int unitID)
        {
            try
            {
                long result = _unitsService.Delete(unitID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Units delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Units/GetUnitByName/{unitName}")]
        public async Task<IActionResult> GetUnitByName(string unitName)
        {
            try
            {

                Core.Models.Units units = await _unitsService.GetUnitByNameAsync(unitName);

                var res = (new List<Core.Models.Units> { units }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Units failed");
                return Ok(ResponseFactory.OKCreator(new List<StationsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UnitsDTO>>(e));
            }

        }



    }
}
