using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Extensions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PPC.Base;
using PPC.Core.Services;

namespace PPC.API.Controllers
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class RawMaterialController : Controller
    {

        #region Prop

        private readonly IRawMaterialsService _rawMaterialsService;

        #endregion

        #region Ctor

        public RawMaterialController(IRawMaterialsService rawMaterialsService)
        {
            _rawMaterialsService = rawMaterialsService;
        }

        #endregion

        [HttpGet]
        [Route("RawMaterials/GetRawMaterials")]
        public async Task<IActionResult> GetRawMaterials()
        {
            try
            {

                List<Core.Models.RawMaterials> rawMaterials = await _rawMaterialsService.GetAllAsync();

                var res = rawMaterials.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterials List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("RawMaterials/GetRawMaterialsById/{rawMaterialID}")]
        public async Task<IActionResult> GetRawMaterialsByID(int rawMaterialID)
        {
            try
            {

                Core.Models.RawMaterials rawMaterials = await _rawMaterialsService.GetRawMaterialsByIdAsync(rawMaterialID);

                var res = (new List<Core.Models.RawMaterials> { rawMaterials }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterials failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("RawMaterials/ExistRawMaterials/{name}")]
        public async Task<IActionResult> ExistRawMaterials(string name)
        {
            try
            {

                var result = _rawMaterialsService.ExistRawMaterialsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterials failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("RawMaterials/Append")]
        public IActionResult Append([FromBody] RawMaterialsDTO rawMaterials)
        {
            try
            {
                RawMaterials rawMaterial = new RawMaterials();
                var mapper = Functions.CreateMapper<RawMaterialsDTO, RawMaterials>();
                rawMaterial = mapper(rawMaterials);

                bool result = _rawMaterialsService.Append(rawMaterial);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterials append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("RawMaterials/Update")]
        public IActionResult Update([FromBody] RawMaterialsDTO rawMaterials)
        {
            try
            {
                RawMaterials rawMaterial = new RawMaterials();
                var mapper = Functions.CreateMapper<RawMaterialsDTO, RawMaterials>();
                rawMaterial = mapper(rawMaterials);

                bool result = _rawMaterialsService.Update(rawMaterial);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterials update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("RawMaterials/Delete/{rawMaterialID}")]
        public IActionResult Delete(int rawMaterialID)
        {
            try
            {
                long result = _rawMaterialsService.Delete(rawMaterialID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterials update failed");
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
/*
namespace PPC.API.Controllers
{



    [Authorize]
    public class RawMaterialController : Controller
    {
        //[Route("api/[controller]")]
        [EnableCors("CorsPolicy")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }



        #region Prop
        private readonly IRawMaterialService _rawMaterialService;


        #endregion

        #region Ctor

        public RawMaterialController(IRawMaterialService rawMaterialService)
        {
            _rawMaterialService = rawMaterialService;
        }

        #endregion


        [HttpGet]
        [Authorize]
        [Route("GetRawMaterialLists")]
        public async Task<IActionResult> GetRawMaterialLists()
        {

            try
            {

                List<PPC.Core.Models.RawMaterials> rawMaterial = await _rawMaterialService.GetAllAsync();

                var res = rawMaterial.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<RawMaterialsDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterial List failed");
                return Ok(ResponseFactory.OKCreator<List<RawMaterialsDTO>>(new List<RawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDTO>>(e));
            }

        }



 



    }
}

*/