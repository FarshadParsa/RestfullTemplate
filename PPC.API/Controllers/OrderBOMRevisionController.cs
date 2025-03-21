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
using AC_PPC.Common;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class OrderBOMRevisionController : Controller
    {

        #region Prop

        private readonly IOrderBOMRevisionsService _orderBOMRevisionsService;

        #endregion

        #region Ctor

        public OrderBOMRevisionController(IOrderBOMRevisionsService orderBOMRevisionsService)
        {
            _orderBOMRevisionsService = orderBOMRevisionsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetOrderBOMRevisions()
        {
            try
            {

                List<Core.Models.OrderBOMRevisions> orderBOMRevisions = await _orderBOMRevisionsService.GetAllAsync();

                //var res = orderBOMRevisions == null
                //? null 
                //: orderBOMRevisions.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<OrderBOMRevisions>,List<OrderBOMRevisionsDTO>> (orderBOMRevisions);

                var res = ExtAutoMapper.JsonMap<List<OrderBOMRevisions>, List<OrderBOMRevisionsDTO>>(orderBOMRevisions);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderBOMRevisions List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderBOMRevisionsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderBOMRevisionsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetOrderBOMRevisionsByID(int id)
        {
            try
            {

                Core.Models.OrderBOMRevisions orderBOMRevisions = await _orderBOMRevisionsService.GetOrderBOMRevisionsByIdAsync(id);

                //var res = orderBOMRevisions == null
                //    ? null 
                //    : (new List<Core.Models.OrderBOMRevisions> { orderBOMRevisions }).ConvertToListDto();

                //var res = orderBOMRevisions == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<OrderBOMRevisions>, List<OrderBOMRevisionsDTO>>(new List<OrderBOMRevisions> { orderBOMRevisions });

                var res = new List<OrderBOMRevisionsDTO> { ExtAutoMapper.JsonMap<OrderBOMRevisions, OrderBOMRevisionsDTO>(orderBOMRevisions) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get orderBOMRevisions failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderBOMRevisionsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderBOMRevisionsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] OrderBOMRevisions orderBOMRevision)
        {
            try
            {

                int result = _orderBOMRevisionsService.Append(orderBOMRevision);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderBOMRevisions append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] OrderBOMRevisions orderBOMRevision)
        {
            try
            {

                bool result = _orderBOMRevisionsService.Update(orderBOMRevision);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderBOMRevisions update failed");
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
                long result = _orderBOMRevisionsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"OrderBOMRevisions delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetArchive(int startDate, int endDate)
        {
            try
            {


                List<Core.Models.OrderBOMRevisions> orderBOMRevisions = await _orderBOMRevisionsService.GetArchiveAsync(
                    Utility.ConvertDateNumToStr(startDate),Utility.ConvertDateNumToStr(endDate));

                var res = ExtAutoMapper.JsonMap<List<OrderBOMRevisions>, List<OrderBOMRevisionsDTO>>(orderBOMRevisions);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get OrderBOMRevisions List failed");
                return Ok(ResponseFactory.OKCreator(new List<OrderBOMRevisionsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<OrderBOMRevisionsDTO>>(e));
            }

        }



    }
}
