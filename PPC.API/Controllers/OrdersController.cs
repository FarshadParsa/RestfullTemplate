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
using Newtonsoft.Json;
using System;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using PPC.Base.Utility;

namespace PPC.API.Controllers
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class OrdersController : Controller
    {

        #region Prop

        private readonly IOrdersService _ordersService;

        #endregion

        #region Ctor

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {

                List<Core.Models.Orders> orders = await _ordersService.GetAllAsync();

                //var res = orders.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<Orders>, List<OrdersDTO>>(orders);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Orders List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrdersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrdersDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetOrdersByID(int id)
        {
            try
            {

                Core.Models.Orders orders = await _ordersService.GetOrdersByIdAsync(id);

                //var res = (new List<Core.Models.Orders> { orders }).ConvertToListDto();
                var res = new List<OrdersDTO>() { ExtAutoMapper.JsonMap<Orders, OrdersDTO>(orders) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get orders failed");
                return Ok(ResponseFactory.OKCreator(new List<OrdersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrdersDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] Orders order)
        {
            try
            {

                int result = _ordersService.Append(order);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Orders append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Orders order)
        {
            try
            {

                bool result = _ordersService.Update(order);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Orders update failed");
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
                long result = _ordersService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Orders delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> OrderDeliveryHasStarted(int id)
        {
            try
            {

                var result = _ordersService.OrderDeliveryHasStarted(id);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get order delivery failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderPlanningHasStarted(int id)
        {
            try
            {

                var result = _ordersService.OrderPlanningHasStarted(id);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get order delivery failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetOrdersByRegisterDate([FromBody] object parameters)
        {
            try
            {
                string dateFrom, dateTo, isForiegn;

                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters.ToString());
                values.TryGetValue(nameof(dateFrom), out dateFrom);
                values.TryGetValue(nameof(dateTo), out dateTo);
                values.TryGetValue(nameof(isForiegn), out isForiegn);


                List<Core.Models.Orders> orders = await _ordersService.GetAllByRegisterDateAsync(dateFrom, dateTo, isForiegn==null?null:Convert.ToBoolean(isForiegn));

                //var res = orders.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<Orders>, List<OrdersDTO>>(orders);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Orders List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrdersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrdersDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{orderNo}")]
        public async Task<IActionResult> GetOrderByNo(string orderNo)
        {
            try
            {

                Core.Models.Orders orders = await _ordersService.GetOrdersByNoAsync(orderNo);

                //var res = (new List<Core.Models.Orders> { orders }).ConvertToListDto();
                var res = new List<OrdersDTO>() { ExtAutoMapper.JsonMap<Orders, OrdersDTO>(orders) };
                
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get orders failed");
                return Ok(ResponseFactory.OKCreator(new List<OrdersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrdersDTO>>(e));
            }

        }



        #region Planing

        [HttpPost]
        public async Task<IActionResult> GetPlanningOrdersByRegisterDate([FromBody] object parameters)
        {
            try
            {
                string dateFrom, dateTo, isForiegn;

                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters.ToString());
                values.TryGetValue(nameof(dateFrom), out dateFrom);
                values.TryGetValue(nameof(dateTo), out dateTo);
                values.TryGetValue(nameof(isForiegn), out isForiegn);


                List<Core.Models.Orders> orders = await _ordersService.GetAllPlanningByRegisterDateAsync(dateFrom, dateTo, isForiegn == null ? null : Convert.ToBoolean(isForiegn));

                //var res = orders.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<Orders>, List<OrdersDTO>>(orders);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Orders List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrdersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrdersDTO>>(e));
            }

        }

        #endregion

    }
}
