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
    public class DeliveryRawMaterialToProductionController : Controller
    {

        #region Prop

        private readonly IDeliveryRawMaterialToProductionService _deliveryRawMaterialToProductionService;

        #endregion

        #region Ctor

        public DeliveryRawMaterialToProductionController(IDeliveryRawMaterialToProductionService deliveryRawMaterialToProductionService)
        {
            _deliveryRawMaterialToProductionService = deliveryRawMaterialToProductionService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDeliveryRawMaterialToProduction()
        {
            try
            {

                List<Core.Models.DeliveryRawMaterialToProduction> deliveryRawMaterialToProduction = await _deliveryRawMaterialToProductionService.GetAllAsync();


                //var res = deliveryRawMaterialToProduction == null
                //    ? null
                //    : deliveryRawMaterialToProduction.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<DeliveryRawMaterialToProduction>, List<DeliveryRawMaterialToProductionDTO>>(deliveryRawMaterialToProduction);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProduction List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveryRawMaterialToProductionByID(int id)
        {
            try
            {

                Core.Models.DeliveryRawMaterialToProduction deliveryRawMaterialToProduction = await _deliveryRawMaterialToProductionService.GetDeliveryRawMaterialToProductionByIdAsync(id);

                //var res = deliveryRawMaterialToProduction == null
                //    ? null
                //    : (new List<Core.Models.DeliveryRawMaterialToProduction> { deliveryRawMaterialToProduction }).ConvertToListDto();

                var res = new List<DeliveryRawMaterialToProductionDTO>() { ExtAutoMapper.JsonMap<DeliveryRawMaterialToProduction, DeliveryRawMaterialToProductionDTO>(deliveryRawMaterialToProduction) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get deliveryRawMaterialToProduction failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DeliveryRawMaterialToProduction deliveryRawMaterialToProduction)
        {
            try
            {

                int result = _deliveryRawMaterialToProductionService.Append(deliveryRawMaterialToProduction);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProduction append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DeliveryRawMaterialToProduction deliveryRawMaterialToProduction)
        {
            try
            {

                //var R = Request;
                //var isss = ModelState.IsValid;

                bool result = _deliveryRawMaterialToProductionService.Update(deliveryRawMaterialToProduction);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProduction update failed");
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
                long result = _deliveryRawMaterialToProductionService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProduction delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public IActionResult GetMaxRequestNo()
        {
            try
            {
                int? result = _deliveryRawMaterialToProductionService.GetMaxRequestNo();

                var res = new List<int?> { result };

                return Ok(ResponseFactory.OKCreator<List<int?>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"GetMaxRequestNo failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialToProductionDeliveryList()
        {
            try
            {

                List<Core.Models.DeliveryRawMaterialToProduction> deliveryRawMaterialToProduction = await _deliveryRawMaterialToProductionService.GetRawMaterialToProductionDeliveryListAsync();

                //var res = deliveryRawMaterialToProduction == null
                //    ? null
                //    : deliveryRawMaterialToProduction.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<DeliveryRawMaterialToProduction>, List<DeliveryRawMaterialToProductionDTO>>(deliveryRawMaterialToProduction);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProduction List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{status}/{dateFrom?}/{dateTo?}")]
        public async Task<IActionResult> GetListByStatus(byte status, string dateFrom, string dateTo)
        {
            try
            {

                List<Core.Models.DeliveryRawMaterialToProduction> deliveryRawMaterialToProduction = await _deliveryRawMaterialToProductionService.GetRawMaterialToProductionDeliveryListAsync();

                //var res = deliveryRawMaterialToProduction == null
                //    ? null
                //    : deliveryRawMaterialToProduction.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<DeliveryRawMaterialToProduction>, List<DeliveryRawMaterialToProductionDTO>>(deliveryRawMaterialToProduction);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProduction List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionDTO>>(e));
            }

        }


    }
}
