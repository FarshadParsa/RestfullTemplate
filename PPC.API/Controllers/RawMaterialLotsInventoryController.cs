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
using Newtonsoft.Json.Linq;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class RawMaterialLotsInventoryController : Controller
    {

        #region Prop

        private readonly IRawMaterialLotsInventoryService _rawMaterialLotsInventoryService;

        #endregion

        #region Ctor

        public RawMaterialLotsInventoryController(IRawMaterialLotsInventoryService rawMaterialLotsInventoryService)
        {
            _rawMaterialLotsInventoryService = rawMaterialLotsInventoryService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialLotsInventory()
        {
            try
            {

                List<Core.Models.RawMaterialLotsInventory> rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<RawMaterialLotsInventory>, List<RawMaterialLotsInventoryDTO>>(rawMaterialLotsInventory);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialLotsInventory List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetListByRawMaterialID(int id)
        {
            try
            {

                List<RawMaterialLotsInventory> rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetListByRawMaterialIDAsync(id);


                var res = ExtAutoMapper.JsonMap<List<RawMaterialLotsInventory>, List<RawMaterialLotsInventoryDTO>>(rawMaterialLotsInventory);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotsInventory failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }

        /// <summary>
        /// دریافت لیست موجودی مواد اولیه
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetInWarehouseList()
        {
            try
            {

                List<RawMaterialLotsInventory> rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetInWarehouseListAsync();


                var res = ExtAutoMapper.JsonMap<List<RawMaterialLotsInventory>, List<RawMaterialLotsInventoryDTO>>(rawMaterialLotsInventory);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotsInventory failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }

        /// <summary>
        /// دریافت لیست موجودی مواد اولیه  بوسیله شناسه ماده اولیه
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetInWarehouseListByRawMaterialID(int id)
        {
            try
            {

                List<RawMaterialLotsInventory> rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetInWarehouseListByRawMaterialIDAsync(id);


                var res = ExtAutoMapper.JsonMap<List<RawMaterialLotsInventory>, List<RawMaterialLotsInventoryDTO>>(rawMaterialLotsInventory);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotsInventory failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }

        /// <summary>
        /// دریافت لیست موجودی مواد اولیه بوسیله مجموعه ای از شناسه های مواد اولیه
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetInWarehouseListByRawMaterialIDs([FromBody] List<int> rawMaterialIdList)
        {
            try
            {

                List<RawMaterialLotsInventory> rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetInWarehouseListByRawMaterialIDsAsync(rawMaterialIdList);


                var res = ExtAutoMapper.JsonMap<List<RawMaterialLotsInventory>, List<RawMaterialLotsInventoryDTO>>(rawMaterialLotsInventory);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotsInventory failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }

        /// <summary>
        /// دریافت لیست مواد اولیه بر اساس نزدیک ترین تاریخ انقضا بوسیله مجموعه ای از شناسه های مواد اولیه
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetOldestRawMaterialListByRawMaterialIDs([FromBody] List<int> rawMaterialIdList)
        {
            try
            {

                List<RawMaterialLotsInventory> rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetOldestRawMaterialListByRawMaterialIDsAsync(rawMaterialIdList);


                var res = ExtAutoMapper.JsonMap<List<RawMaterialLotsInventory>, List<RawMaterialLotsInventoryDTO>>(rawMaterialLotsInventory);

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotsInventory failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }



        [HttpGet]
        public async Task<IActionResult> GetInstanceByLotNo(string id)
        {
            try
            {

                Core.Models.RawMaterialLotsInventory rawMaterialLotsInventory = await _rawMaterialLotsInventoryService.GetInstanceByLotNoAsync(id);


                var res = new List<RawMaterialLotsInventoryDTO> { ExtAutoMapper.JsonMap<RawMaterialLotsInventory, RawMaterialLotsInventoryDTO>(rawMaterialLotsInventory) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotsInventory failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotsInventoryDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotsInventoryDTO>>(e));
            }

        }



    }
}
