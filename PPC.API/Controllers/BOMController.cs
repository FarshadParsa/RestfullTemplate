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
using PPC.Core.Services;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class BOMController : Controller
    {

        #region Prop

        private readonly IBOMService _bOMService;
        private readonly IRawMaterialsService _rawMaterialsService;

        #endregion

        #region Ctor

        public BOMController(IBOMService bOMService, IRawMaterialsService rawMaterialsService)
        {
            _bOMService = bOMService;
            _rawMaterialsService = rawMaterialsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetBOM()
        {
            try
            {

                List<Core.Models.BOM> bOM = await _bOMService.GetAllAsync();

                var res = bOM == null
                    ? null
                    : bOM.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOM List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBOMByID(int id)
        {
            try
            {

                Core.Models.BOM bOM = await _bOMService.GetBOMByIdAsync(id);

                var res = bOM == null
                    ? null
                    : (new List<Core.Models.BOM> { bOM }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get bOM failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{code}")]
        public async Task<IActionResult> ExistBOM(string code)
        {
            try
            {

                var result = _bOMService.GetByBOMCodeAsync(code);

                var res = new List<BOM> { await result };

                return Ok(ResponseFactory.OKCreator<List<BOM>>(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOM failed");
                return Ok(ResponseFactory.OKCreator<List<BOM>>(new List<BOM>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOM>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] BOM bOM)
        {
            try
            {

                int result = _bOMService.Append(bOM);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOM append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] BOM bOM)
        {
            try
            {

                bool result = _bOMService.Update(bOM);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOM update failed");
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
                long result = _bOMService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"BOM delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDraft(int id)
        {
            try
            {

                Core.Models.BOM bOM = _bOMService.GetBOMById(id);

                if (bOM == null || !bOM.IsDraft)
                    throw new System.Exception("فقط ردیف های پیش نویس(موقت) قابل تایید می باشند");

                bool result = _bOMService.ConfirmDraft(id);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Confirmation failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByProductId(int id)
        {
            try
            {

                List<Core.Models.BOM> bOM = await _bOMService.GetListByProductIdAsync(id);

                var res = bOM == null
                    ? null
                    : bOM.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOM List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetLatestVersionById(int id)
        {
            try
            {

                Core.Models.BOM bOM = await _bOMService.GetLatestVersionByIdAsync(id);

                var res = bOM == null
                    ? null
                    : (new List<Core.Models.BOM> { bOM }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get bOM failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBOMWithComplementaryById(int id)
        {
            try
            {

                Core.Models.BOM bOM = await _bOMService.GetBOMWithComplementaryByIdAsync(id);

                var res = bOM == null
                    ? null
                    : new List<BOM> { bOM }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOM List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByRawMaterialId(int id)
        {
            try
            {

                var boms = await _bOMService.GetListByRawMaterialIdAsync(id);

                //var res = bOM == null
                //    ? null
                //    : new List<BOM> { bOM }.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<BOM>, List<BOMDTO>>(boms);
                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get BOM List failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetMaxBOMcodeByProductId(int id)
        {
            try
            {

                Core.Models.BOM bOM = _bOMService.GetMaxBOMcodeByProductId(id);

                var res = bOM == null
                    ? null
                    : (new List<Core.Models.BOM> { bOM }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get bOM failed");
                return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
            }

        }

        //[HttpPost]
        //public async Task<IActionResult> CalculateBOM([FromBody] BOM bom)
        //{
        //    try
        //    {

        //        //List<RawMaterials> rawMaterialList = await _rawMaterialsService.GetListByIdListAsync(bom.BOMDetailList.Select(x=>x.RawMaterialID).ToList());


        //        string res = null;
        //        return Ok(ResponseFactory.OKCreator(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get BOM List failed");
        //        return Ok(ResponseFactory.OKCreator(new List<BOMDTO>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<BOMDTO>>(e));
        //    }

        //}


    }

}
