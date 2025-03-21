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
    public class RawMaterialLotNumberController : Controller
    {

        #region Prop

        private readonly IRawMaterialLotNumbersService _rawMaterialLotNumbersService;

        #endregion

        #region Ctor

        public RawMaterialLotNumberController(IRawMaterialLotNumbersService rawMaterialLotNumbersService)
        {
            _rawMaterialLotNumbersService = rawMaterialLotNumbersService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialLotNumbers()
        {
            try
            {

                List<Core.Models.RawMaterialLotNumbers> rawMaterialLotNumbers = await _rawMaterialLotNumbersService.GetAllAsync();

                var res = rawMaterialLotNumbers == null
                    ? null
                    : rawMaterialLotNumbers.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialLotNumbers List failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotNumbersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotNumbersDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRawMaterialLotNumbersByID(int id)
        {
            try
            {

                Core.Models.RawMaterialLotNumbers rawMaterialLotNumbers = await _rawMaterialLotNumbersService.GetRawMaterialLotNumbersByIdAsync(id);

                var res = rawMaterialLotNumbers == null
                    ? null
                    : (new List<Core.Models.RawMaterialLotNumbers> { rawMaterialLotNumbers }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get rawMaterialLotNumbers failed");
                return Ok(ResponseFactory.OKCreator(new List<RawMaterialLotNumbersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotNumbersDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{lotNo}")]
        public async Task<IActionResult> GetInstanceByLotNo(string lotNo)
        {
            try
            {

                var result = _rawMaterialLotNumbersService.GetInstanceByLotNoAsync(lotNo);

                var res = new List<RawMaterialLotNumbers> { await result };

                return Ok(ResponseFactory.OKCreator<List<RawMaterialLotNumbers>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RawMaterialLotNumbers failed");
                return Ok(ResponseFactory.OKCreator<List<RawMaterialLotNumbers>>(new List<RawMaterialLotNumbers>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<RawMaterialLotNumbers>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RawMaterialLotNumbers rawMaterialLotNumber)
        {
            try
            {

                int result = _rawMaterialLotNumbersService.Append(rawMaterialLotNumber);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialLotNumbers append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RawMaterialLotNumbers rawMaterialLotNumber)
        {
            try
            {

                bool result = _rawMaterialLotNumbersService.Update(rawMaterialLotNumber);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialLotNumbers update failed");
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
                long result = _rawMaterialLotNumbersService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RawMaterialLotNumbers delete failed");
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
