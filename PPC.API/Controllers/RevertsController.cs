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
using PPC.Base.Utility;
using System.Linq.Expressions;
using System;
namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class RevertsController : Controller
    {

        #region Prop

        private readonly IRevertsService _revertsService;

        #endregion

        #region Ctor

        public RevertsController(IRevertsService revertsService)
        {
            _revertsService = revertsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetReverts()
        {
            try
            {

                List<Core.Models.Reverts> reverts = await _revertsService.GetListAsync();


                var res = ExtAutoMapper.JsonMap<List<Reverts>, List<RevertsDTO>>(reverts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Reverts List failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRevertsByID(int id)
        {
            try
            {

                Core.Models.Reverts reverts = await _revertsService.GetRevertsByIdAsync(id);


                var res = new List<RevertsDTO> { ExtAutoMapper.JsonMap<Reverts, RevertsDTO>(reverts) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get reverts failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] Reverts reverts)
        {
            try
            {

                int result = _revertsService.Append(reverts);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Reverts append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Reverts reverts)
        {
            try
            {

                bool result = _revertsService.Update(reverts);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Reverts update failed");
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
                long result = _revertsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Reverts delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetListByDate(int startDate, int endDate)
        {
            try
            {
                string dateFrom = Utility.FormatPersianDate(startDate);
                string dateTo = Utility.FormatPersianDate(endDate);

                var includes = new List<Expression<Func<Reverts, object>>>
                {
                    x => x.Customer,
                    x => x.RevertPaletsList.Select(p=>p.Palet).Select(c=>c.Customer)
                }.ToArray();

                List<Core.Models.Reverts> reverts = await _revertsService.GetListByDate(
                    dateFrom, 
                    dateTo,
                    includes);


                var res = ExtAutoMapper.JsonMap<List<Reverts>, List<RevertsDTO>>(reverts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Reverts List failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertsDTO>>(e));
            }

        }


    }
}
