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
    public class InvRawMaterialLotsController : Controller
    {

        #region Prop

        private readonly IInvRawMaterialLotsService _invRawMaterialLotsService;

        #endregion

        #region Ctor

        public InvRawMaterialLotsController(IInvRawMaterialLotsService invRawMaterialLotsService)
        {
            _invRawMaterialLotsService = invRawMaterialLotsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetInvRawMaterialLots()
        {
            try
            {

                List<Core.Models.InvRawMaterialLots> invRawMaterialLots = await _invRawMaterialLotsService.GetAllAsync();

                //var res = invRawMaterialLots == null
                //    ? null
                //    : invRawMaterialLots.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<InvRawMaterialLots>, List<InvRawMaterialLotsDTO>>(invRawMaterialLots);


                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvRawMaterialLots List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvRawMaterialLotsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialLotsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetInvRawMaterialLotsByID(int id)
        {
            try
            {

                Core.Models.InvRawMaterialLots invRawMaterialLots = await _invRawMaterialLotsService.GetInvRawMaterialLotsByIdAsync(id);

                //var res = invRawMaterialLots == null
                //    ? null
                //    : (new List<Core.Models.InvRawMaterialLots> { invRawMaterialLots }).ConvertToListDto();

                var res = new List<InvRawMaterialLotsDTO> { ExtAutoMapper.JsonMap<InvRawMaterialLots, InvRawMaterialLotsDTO>(invRawMaterialLots) };


                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invRawMaterialLots failed");
                return Ok(ResponseFactory.OKCreator(new List<InvRawMaterialLotsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialLotsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{lotNo}")]
        public async Task<IActionResult> ExistInvRawMaterialLots(string lotNo)
        {
            try
            {

                var result = _invRawMaterialLotsService.GetInvRawMaterialLotsAsync(lotNo);

                var res = new List<InvRawMaterialLots> { await result };

                return Ok(ResponseFactory.OKCreator<List<InvRawMaterialLots>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvRawMaterialLots failed");
                return Ok(ResponseFactory.OKCreator<List<InvRawMaterialLots>>(new List<InvRawMaterialLots>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvRawMaterialLots>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] InvRawMaterialLots invRawMaterialLots)
        {
            try
            {

                int result = _invRawMaterialLotsService.Append(invRawMaterialLots);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvRawMaterialLots append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] InvRawMaterialLots invRawMaterialLots)
        {
            try
            {

                bool result = _invRawMaterialLotsService.Update(invRawMaterialLots);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvRawMaterialLots update failed");
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
                long result = _invRawMaterialLotsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvRawMaterialLots delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{partlotNo}")]
        public async Task<IActionResult> GetLastLotNoByPartOfLotNo(string partlotNo)
        {
            try
            {

                var result = _invRawMaterialLotsService.GetLatestByPartOfLotNoAsync(partlotNo);

                var res = new List<string> { await result };

                return Ok(ResponseFactory.OKCreator<List<string>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvRawMaterialLots failed");
                return Ok(ResponseFactory.OKCreator<List<string>>(new List<string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
            }
        }


    }
}
