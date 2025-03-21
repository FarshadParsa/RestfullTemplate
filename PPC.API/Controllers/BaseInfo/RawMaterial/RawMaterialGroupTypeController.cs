using Microsoft.AspNetCore.Mvc;
using PPC.Core.Extensions;
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
    public class RawMaterialGroupTypeController : Controller
    {

        #region Prop

        private readonly IRawMaterialGroupTypesService _rawMaterialGroupTypesService;

        #endregion

        #region Ctor

        public RawMaterialGroupTypeController(IRawMaterialGroupTypesService rawMaterialGroupTypesService)
        {
            _rawMaterialGroupTypesService = rawMaterialGroupTypesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetRawMaterialGroupTypes()
        {
            try
            {

                List<Core.Models.RawMaterialGroupTypes> rawMaterialGroupTypes = await _rawMaterialGroupTypesService.GetAllAsync();

                var res = rawMaterialGroupTypes.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialGroupTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialGroupTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialGroupTypesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetRawMaterialGroupTypesByID(short id)
        {
            try
            {

                Core.Models.RawMaterialGroupTypes rawMaterialGroupTypes = await _rawMaterialGroupTypesService.GetRawMaterialGroupTypesByIdAsync(id);

                var res = (new List<Core.Models.RawMaterialGroupTypes> { rawMaterialGroupTypes }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialGroupTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialGroupTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialGroupTypesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistRawMaterialGroupTypes/{name}")]
        public async Task<IActionResult> ExistRawMaterialGroupTypes(string name)
        {
            try
            {

                var result = _rawMaterialGroupTypesService.ExistRawMaterialGroupTypesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialGroupTypes failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] RawMaterialGroupTypesDTO rawMaterialGroupTypes)
        {
            try
            {
                RawMaterialGroupTypes rawMaterialGroupType = new RawMaterialGroupTypes();
                var mapper = Functions.CreateMapper<RawMaterialGroupTypesDTO, RawMaterialGroupTypes>();
                rawMaterialGroupType = mapper(rawMaterialGroupTypes);

                bool result = _rawMaterialGroupTypesService.Append(rawMaterialGroupType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialGroupTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] RawMaterialGroupTypesDTO rawMaterialGroupTypes)
        {
            try
            {
                RawMaterialGroupTypes rawMaterialGroupType = new RawMaterialGroupTypes();
                var mapper = Functions.CreateMapper<RawMaterialGroupTypesDTO, RawMaterialGroupTypes>();
                rawMaterialGroupType = mapper(rawMaterialGroupTypes);

                bool result = _rawMaterialGroupTypesService.Update(rawMaterialGroupType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialGroupTypes update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]

        public IActionResult Delete(short id)
        {
            try
            {
                long result = _rawMaterialGroupTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialGroupTypes update failed");
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