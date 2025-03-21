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
    public class DeliveryRawMaterialToProductionPatilsController : Controller
    {

        #region Prop

        private readonly IDeliveryRawMaterialToProductionPatilsService _deliveryRawMaterialToProductionPatilsService;

        #endregion

        #region Ctor

        public DeliveryRawMaterialToProductionPatilsController(IDeliveryRawMaterialToProductionPatilsService deliveryRawMaterialToProductionPatilsService)
        {
            _deliveryRawMaterialToProductionPatilsService = deliveryRawMaterialToProductionPatilsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDeliveryRawMaterialToProductionPatils()
        {
            try
            {

                List<Core.Models.DeliveryRawMaterialToProductionPatils> deliveryRawMaterialToProductionPatils = await _deliveryRawMaterialToProductionPatilsService.GetAllAsync();

                var res = deliveryRawMaterialToProductionPatils == null
                    ? null
                    : deliveryRawMaterialToProductionPatils.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DeliveryRawMaterialToProductionPatils List failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionPatilsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDeliveryRawMaterialToProductionPatilsByID(int id)
        {
            try
            {

                Core.Models.DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils = await _deliveryRawMaterialToProductionPatilsService.GetDeliveryRawMaterialToProductionPatilsByIdAsync(id);

                var res = deliveryRawMaterialToProductionPatils == null
                    ? null
                    : (new List<Core.Models.DeliveryRawMaterialToProductionPatils> { deliveryRawMaterialToProductionPatils }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get deliveryRawMaterialToProductionPatils failed");
                return Ok(ResponseFactory.OKCreator(new List<DeliveryRawMaterialToProductionPatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DeliveryRawMaterialToProductionPatilsDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils)
        {
            try
            {

                int result = _deliveryRawMaterialToProductionPatilsService.Append(deliveryRawMaterialToProductionPatils);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProductionPatils append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils)
        {
            try
            {

                bool result = _deliveryRawMaterialToProductionPatilsService.Update(deliveryRawMaterialToProductionPatils);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProductionPatils update failed");
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
                long result = _deliveryRawMaterialToProductionPatilsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DeliveryRawMaterialToProductionPatils delete failed");
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
