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
using AC_PPC.Response.DTOs;
using Microsoft.Extensions.Configuration.Json;
using PPC.Base.Utility;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class DeliveryRawMaterialToProductionDetailController : Controller
    {

        #region Prop

        private readonly IDeliveryRawMaterialToProductionDetailService _deliveryRawMaterialToProductionDetailService;

        #endregion

        #region Ctor

        public DeliveryRawMaterialToProductionDetailController(IDeliveryRawMaterialToProductionDetailService deliveryRawMaterialToProductionDetailService)
        {
            _deliveryRawMaterialToProductionDetailService = deliveryRawMaterialToProductionDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDeliveryRawMaterialToProductionDetail()
        {
            try
            {

                List<Core.Models.DeliveryRawMaterialToProductionDetail> deliveryRawMaterialToProductionDetail = await _deliveryRawMaterialToProductionDetailService.GetAllAsync();

                var res = deliveryRawMaterialToProductionDetail == null
                    ? null
                    : deliveryRawMaterialToProductionDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProductionDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveryRawMaterialToProductionDetailByID(int id)
        {
            try
            {

                Core.Models.DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail = await _deliveryRawMaterialToProductionDetailService.GetDeliveryRawMaterialToProductionDetailByIdAsync(id);

                var res = deliveryRawMaterialToProductionDetail == null
                    ? null
                    : (new List<Core.Models.DeliveryRawMaterialToProductionDetail> { deliveryRawMaterialToProductionDetail }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get deliveryRawMaterialToProductionDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDetailDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail)
        {
            try
            {

                int result = _deliveryRawMaterialToProductionDetailService.Append(deliveryRawMaterialToProductionDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProductionDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail)
        {
            try
            {

                bool result = _deliveryRawMaterialToProductionDetailService.Update(deliveryRawMaterialToProductionDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProductionDetail update failed");
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
                long result = _deliveryRawMaterialToProductionDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProductionDetail delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetRawMaterialToProductionDeliveryList()
        {
            try
            {


                List<Core.Models.DeliveryRawMaterialToProductionDetail> deliveryRawMaterialToProduction = await _deliveryRawMaterialToProductionDetailService.GetAllToProductionDeliveryAsync();
                //var resAuto = ExtAutoMapper.Mapper.Map<List<DeliveryRawMaterialToProductionDetail>, List<DeliveryRawMaterialToProductionDetailDTO>>(deliveryRawMaterialToProduction);
                //return Ok(ResponseFactory.OKCreator(resAuto, resAuto.Count()));

                //////////var zzzzz = deliveryRawMaterialToProduction.TempMapper();

                ////////var t = new List<Temp>();

                ////////t.Add(new Temp()
                ////////{
                ////////    ID = 1,
                ////////    Name = "Ali"
                ////////});

                ////////t.Add(new Temp()
                ////////{
                ////////    ID = 2,
                ////////    Name = "Reza"
                ////////});

                ////////var t1 = new Temp()
                ////////{
                ////////    ID = 3,
                ////////    Name = "Farshad"
                ////////};
                ////////var t2 = new TempDTO();

                ////////////AutoMapperProfile.TempMapper<DeliveryRawMaterialToProductionDetail, DeliveryRawMaterialToProductionDetailDTO>(deliveryRawMaterialToProduction);
                //////////AutoMapperProfile.TempMapper<List<Temp>, List<TempDTO>>(t);
                ////////AutoMapperProfile.TempMapper<Temp, TempDTO>(t1);

                ////var resAuto = ExtAutoMapper.Mapper.Map<DeliveryRawMaterialToProductionDetail, DeliveryRawMaterialToProductionDetailDTO>(deliveryRawMaterialToProduction.FirstOrDefault());

                ////foreach (var item in resAuto.DeliveryRawMaterialToProduction.DeliveryRawMaterialToProductionPatilList)
                ////{
                ////    if (item == null)
                ////        continue;

                ////    if (item.DeliveryRawMaterialToProductionID == resAuto.DeliveryRawMaterialToProductionID)
                ////        item.DeliveryRawMaterialToProduction = null;
                ////}
                ////foreach (var item in resAuto.DeliveryRawMaterialToProduction.DeliveryRawMaterialToProductionDetailList)
                ////{
                ////    if (item == null)
                ////        continue;

                ////    if (item.DeliveryRawMaterialToProductionID == resAuto.DeliveryRawMaterialToProductionID)
                ////        item.DeliveryRawMaterialToProduction.DeliveryRawMaterialToProductionDetailList = null;
                ////}

                ////return Ok(ResponseFactory.OKCreator(resAuto, 0 ));


                ////var resAuto = ExtAutoMapper.Mapper.Map<List<DeliveryRawMaterialToProductionDetail>, List<DeliveryRawMaterialToProductionDetailDTO>>(deliveryRawMaterialToProduction);


                //var qq = new List<DeliveryRawMaterialToProductionDetailDTO>();
                //qq.AddRange(resAuto);
                //return Ok(ResponseFactory.OKCreator(qq, resAuto.Count()));

                var resAuto = ExtAutoMapper.MapToJsonList<List<DeliveryRawMaterialToProductionDetail>, List<DeliveryRawMaterialToProductionDetailDTO>>(deliveryRawMaterialToProduction);
                return Ok(ResponseFactory.OKCreator(resAuto, resAuto.Count()));


            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProductionDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDetailDTO>>(e));
            }

        }



        /// <summary>
        /// GetRawMaterialToProductionDeliveryListByDeliveryRawMaterialToProductionId
        /// </summary>
        /// <param name="id">DeliveryRawMaterialToProductionId</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRawMaterialToProductionDeliveryListByDRMPId(int id)
        {
            try
            {

                List<Core.Models.DeliveryRawMaterialToProductionDetail> deliveryRawMaterialToProductionDetail = await _deliveryRawMaterialToProductionDetailService.GetRawMaterialToProductionDeliveryListByDRMPId(id);

                var res = deliveryRawMaterialToProductionDetail == null
                    ? null
                    : deliveryRawMaterialToProductionDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProductionDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDetailDTO>>(e));
            }

        }



    }
}
