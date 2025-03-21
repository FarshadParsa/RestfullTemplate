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
    public class OrderDetailPackagingController : Controller
    {

        #region Prop

        private readonly IOrderDetailPackagingsService _orderDetailPackagingsService;

        #endregion

        #region Ctor

        public OrderDetailPackagingController(IOrderDetailPackagingsService orderDetailPackagingsService)
        {
            _orderDetailPackagingsService = orderDetailPackagingsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailPackagings()
        {
            try
            {

                List<Core.Models.OrderDetailPackagings> orderDetailPackagings = await _orderDetailPackagingsService.GetAllAsync();

                var res = orderDetailPackagings == null
                    ? null
                    : orderDetailPackagings.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetailPackagings List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailPackagingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailPackagingsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailPackagingsByID(int id)
        {
            try
            {

                Core.Models.OrderDetailPackagings orderDetailPackagings = await _orderDetailPackagingsService.GetOrderDetailPackagingsByIdAsync(id);

                var res = orderDetailPackagings == null
                    ? null
                    : (new List<Core.Models.OrderDetailPackagings> { orderDetailPackagings }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get orderDetailPackagings failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailPackagingsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailPackagingsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] OrderDetailPackagings orderDetailPackaging)
        {
            try
            {

                int result = _orderDetailPackagingsService.Append(orderDetailPackaging);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderDetailPackagings append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] OrderDetailPackagings orderDetailPackaging)
        {
            try
            {

                bool result = _orderDetailPackagingsService.Update(orderDetailPackaging);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderDetailPackagings update failed");
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
                long result = _orderDetailPackagingsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderDetailPackagings delete failed");
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
