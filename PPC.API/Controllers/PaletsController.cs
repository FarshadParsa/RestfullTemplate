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
using System;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class PaletsController : Controller
    {

        #region Prop

        private readonly IPaletsService _paletsService;

        #endregion

        #region Ctor

        public PaletsController(IPaletsService paletsService)
        {
            _paletsService = paletsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPalets()
        {
            try
            {

                List<Core.Models.Palets> palets = await _paletsService.GetAllAsync();

                //var res = palets == null
                //? null 
                //: palets.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<Palets>,List<PaletsDTO>> (palets);

                var res = ExtAutoMapper.JsonMap<List<Palets>, List<PaletsDTO>>(palets);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Palets List failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPaletsByID(int id)
        {
            try
            {

                Core.Models.Palets palets = await _paletsService.GetPaletsByIdAsync(id);

                //var res = palets == null
                //    ? null 
                //    : (new List<Core.Models.Palets> { palets }).ConvertToListDto();

                //var res = palets == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<Palets>, List<PaletsDTO>>(new List<Palets> { palets });

                var res = new List<PaletsDTO> { ExtAutoMapper.JsonMap<Palets, PaletsDTO>(palets) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get palets failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletsDTO>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] Palets palets)
        {
            try
            {

                int result = _paletsService.Append(palets);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Palets append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Palets palets)
        {
            try
            {

                //var q = ModelState.IsValid;

                bool result = _paletsService.Update(palets);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Palets update failed");
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
                long result = _paletsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Palets delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInstanceByPaletNo(string id)
        {
            try
            {

                Core.Models.Palets palets = await _paletsService.GetInstanceByPaletNoAsync(id);

                //var res = palets == null
                //    ? null 
                //    : (new List<Core.Models.Palets> { palets }).ConvertToListDto();

                //var res = palets == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<Palets>, List<PaletsDTO>>(new List<Palets> { palets });

                var res = new List<PaletsDTO> { ExtAutoMapper.JsonMap<Palets, PaletsDTO>(palets) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get palets failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletsDTO>>(e));
            }

        }

        [HttpGet]
        public IActionResult GetMaxPaletNoAsync()
        {

            try
            {

                var result = _paletsService.GetMaxPaletNo();

                var res = new List<string> { result };

                return Ok(ResponseFactory.OKCreator<List<string>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Palets append failed");
                return Ok(ResponseFactory.OKCreator<List<string>>(new List<string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> ValidateCanInsert([FromBody] List<int> invProductIdList)
        {
            try
            {

                List<string> invProducts = await _paletsService.ValidateCanInsertProductsAsync(invProductIdList);

                ////var res = palets == null
                ////    ? null 
                ////    : (new List<Core.Models.Palets> { palets }).ConvertToListDto();

                ////var res = palets == null
                ////     ? null 
                ////       : ExtAutoMapper.Mapper.Map<List<Palets>, List<PaletsDTO>>(new List<Palets> { palets });

                ////var res = new List<InvProductsDTO> { ExtAutoMapper.JsonMap<InvProducts, InvProductsDTO>(invProducts) };

                //Dictionary<InvProductsDTO, string> result = new Dictionary<InvProductsDTO, string>();
                //foreach (var inv in invProducts)
                //{
                //    var res = ExtAutoMapper.JsonMap<InvProducts, InvProductsDTO>(inv.Key);
                //    result.Add(res,inv.Value);
                //}

                ////var res = ExtAutoMapper.JsonMap<InvProducts, InvProductsDTO>(invProducts) ;

                //var srtJson = JSON.ToJson(invProducts).Result;

                var result = invProducts == null || invProducts.Count == 0
                    ? null
                    //:new List<string> { JSON.ToJson(invProducts).Result };
                    //: invProducts.Select(x => $"{x.Key}-{x.Value}").ToList();
                    : invProducts;

                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(invProducts);


                //Dictionary<InvProducts, string> invProducts2 = new Dictionary<InvProducts, string>();
                //invProducts2.Add(new InvProducts { InvProductID = 1, InvProductCode = "Product 1" }, "Description 1");
                //invProducts2.Add(new InvProducts { InvProductID = 2, InvProductCode = "Product 2" }, "Description 2");

                //string json2 = Newtonsoft.Json.JsonConvert.SerializeObject(invProducts2);

                return Ok(ResponseFactory.OKCreator(result, result != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get palets failed");
                return Ok(ResponseFactory.OKCreator(new Dictionary<string, string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<Dictionary<string, string>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetArchiveList(int startDate, int endDate)
        {
            try
            {
                string dateFrom = Utility.FormatPersianDate(startDate);
                string dateTo = Utility.FormatPersianDate(endDate);

                List<Core.Models.Palets> palets = await _paletsService.GetArchiveList(dateFrom, dateTo);

                //var res = palets == null
                //? null 
                //: palets.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<Palets>,List<PaletsDTO>> (palets);

                var res = ExtAutoMapper.JsonMap<List<Palets>, List<PaletsDTO>>(palets);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Palets List failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetPaletLabelInfo(int id)
        {
            try
            {

                Core.Models.Palets palets = await _paletsService.GetPaletLabelInfoAsync(id);

                var res = new List<PaletsDTO> { ExtAutoMapper.JsonMap<Palets, PaletsDTO>(palets) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get palets failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletsDTO>>(e));
            }

        }


    }
}
