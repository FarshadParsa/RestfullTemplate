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
using PPC.Base.Utility;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
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
        public async Task<IActionResult> GetRawMaterials()
        {
            try
            {

                List<Core.Models.RawMaterials> rawMaterials = await _rawMaterialsService.GetAllAsync();

                var res = rawMaterials == null
                    ? null
                    : rawMaterials.ConvertToListDto();
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
        public async Task<IActionResult> GetRawMaterialsByID(int id)
        {
            try
            {

                Core.Models.RawMaterials rawMaterials = await _rawMaterialsService.GetRawMaterialsByIdAsync(id);

                var res = rawMaterials == null
                    ? null
                    : (new List<Core.Models.RawMaterials> { rawMaterials }).ConvertToListDto();
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

        [HttpGet("[Controller]/[Action]/{name}")]
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
        public async Task<IActionResult> Append([FromBody] RawMaterials rawMaterial)
        {
            try
            {

                int result = _rawMaterialsService.Append(rawMaterial);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterials append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RawMaterials rawMaterial)
        {
            try
            {

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
        public IActionResult Delete(int id)
        {
            try
            {
                long result = _rawMaterialsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterials delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetListForDropDown()
        {
            try
            {

                List<Core.Models.RawMaterials> rawMaterials = await _rawMaterialsService.GetAllForDropDownAsync();

                var res = rawMaterials == null
                    ? null
                    : rawMaterials.ConvertToListDto();
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
        public async Task<IActionResult> GetRawMaterialsByRawMaterialSampleId(int id)
        {
            try
            {

                Core.Models.RawMaterials rawMaterials = await _rawMaterialsService.GetInstanceByRawMaterialSampleId(id);

                var res = rawMaterials == null
                    ? null
                    : (new List<Core.Models.RawMaterials> { rawMaterials }).ConvertToListDto();
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

        //[HttpGet]
        //public async Task<IActionResult> RawMateriaIsParent(int id)
        //{
        //    try
        //    {

        //        bool rawMaterials = await _rawMaterialsService.CheckRawMateriaIsParent(id);

        //        var res = new List<bool> { rawMaterials };
        //        return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get rawMaterials failed");
        //        return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }

        //}


        [HttpGet]
        public async Task<IActionResult> GetListForBOM()
        {
            try
            {

                List<Core.Models.RawMaterials> rawMaterials = await _rawMaterialsService.GetListForBOMAsync();

                var res = rawMaterials == null
                    ? null
                    : rawMaterials.ConvertToListDto();
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
        public async Task<IActionResult> GetListByRawMatrtialId(int id)
        {
            try
            {

                List<Core.Models.RawMaterials> rawMaterials = await _rawMaterialsService.GetListByRawMatrtialIdAsync(id);

                var res = rawMaterials == null
                    ? null
                    : rawMaterials.ConvertToListDto();
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


        [HttpGet("[Controller]/[Action]/{Id}/{state}")]
        public async Task<IActionResult> ChangeSampleConfirmation(int id, bool state)
        {
            try
            {

                bool result = _rawMaterialsService.ChangeSampleConfirmation(id, state);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Change Sample Confirmation failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialsDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetListByIdList([FromBody] List<int> idList)
        {
            try
            {
                List<Core.Models.RawMaterials> rawMaterials = await _rawMaterialsService.GetListByIdListAsync(idList);

                //var res = rawMaterials == null
                //    ? null
                //    : rawMaterials.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<RawMaterials>, List<RawMaterialsDTO>>(rawMaterials);
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


    }
}
