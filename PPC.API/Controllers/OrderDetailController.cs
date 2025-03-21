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
using PPC.Base.Utility;
using PPC.Core.Services;
using System.Text.Json;
using System;
using static NuGet.Packaging.PackagingConstants;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class OrderDetailController : Controller
    {

        #region Prop

        private readonly IOrderDetailsService _orderDetailsService;

        #endregion

        #region Ctor

        public OrderDetailController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            try
            {

                List<Core.Models.OrderDetails> orderDetails = await _orderDetailsService.GetAllAsync();

                //var res = orderDetails.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<OrderDetails>, List<OrderDetailsDTO>>(orderDetails);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetOrderDetailsByID(int id)
        {
            try
            {

                Core.Models.OrderDetails orderDetails = await _orderDetailsService.GetOrderDetailsByIdAsync(id);

                //var res = (new List<Core.Models.OrderDetails> { orderDetails }).ConvertToListDto();
                var res = new List<OrderDetailsDTO>() { ExtAutoMapper.JsonMap<OrderDetails, OrderDetailsDTO>(orderDetails) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get orderDetails failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> ExistOrderDetails(int id)
        {
            try
            {

                var result = _orderDetailsService.ExistOrderDetailsAsync(id);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] OrderDetails orderDetail)
        {
            try
            {

                int result = _orderDetailsService.Append(orderDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderDetails append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] OrderDetails orderDetail)
        {
            try
            {

                bool result = _orderDetailsService.Update(orderDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderDetails update failed");
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
                long result = _orderDetailsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderDetails delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int id)
        {
            try
            {

                List<Core.Models.OrderDetails> orderDetails = await _orderDetailsService.GetAllByOrderIdAsync(id);

                //var res = orderDetails.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<OrderDetails>, List<OrderDetailsDTO>>(orderDetails);
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDropdownList()
        {
            try
            {

                List<Core.Models.OrderDetails> orderDetails = await _orderDetailsService.GetDropdownList();

                //var res = orderDetails.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<OrderDetails>, List<OrderDetailsDTO>>(orderDetails);
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetPlannedList([FromBody] JsonElement parameters)
        {
            try
            {

                #region obtain JObject elements

                var jObject = await JSON.ToObject<JObject>(parameters.ToString());

                string dateFrom = jObject["dateFrom"].ToString();
                string dateTo = jObject["dateTo"].ToString();
                List<byte> orderStatus = await JSON.JArrayToList<byte>((JArray)jObject["orderStatus"]);

                #endregion


                List<OrderDetails> orderDetails = await _orderDetailsService.GetPlannedListAsync(dateFrom, dateTo, orderStatus);

                //var res = orderDetails.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<OrderDetails>, List<OrderDetailsDTO>>(orderDetails);
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetListToAssignBOM(int startDate, int endDate)
        {
            try
            {

                List<OrderDetails> orderDetails = await _orderDetailsService.GetListToAssignBOMAsync(Utility.FormatPersianDate(startDate), Utility.FormatPersianDate(endDate));

                //var res = orderDetails.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<OrderDetails>, List<OrderDetailsDTO>>(orderDetails);
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetForSearchByProductId(int id)
        {
            try
            {
                List<Core.Models.OrderDetails> orders = await _orderDetailsService.GetForSearchByProductId(id);

                var res = ExtAutoMapper.JsonMap<List<OrderDetails>, List<OrderDetailsDTO>>(orders);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderDetailsDTO>>(e));
            }

        }




    }
}
