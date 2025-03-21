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
    public class DataPremixController : Controller
    {

        #region Prop

        private readonly IDataPremixService _dataPremixService;

        #endregion

        #region Ctor

        public DataPremixController(IDataPremixService dataPremixService)
        {
            _dataPremixService = dataPremixService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataPremix()
        {
            try
            {

                List<Core.Models.DataPremix> dataPremix = await _dataPremixService.GetAllAsync();

                //var res = dataPremix == null
                //? null 
                //: dataPremix.ConvertToListDto();

                var res = ExtAutoMapper.Mapper.Map<List<DataPremix>, List<DataPremixDTO>>(dataPremix);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataPremix List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataPremixDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataPremixDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataPremixByID(int id)
        {
            try
            {

                Core.Models.DataPremix dataPremix = await _dataPremixService.GetDataPremixByIdAsync(id);

                //var res = dataPremix == null
                //    ? null 
                //    : (new List<Core.Models.DataPremix> { dataPremix }).ConvertToListDto();

                var res = dataPremix == null
                    ? null
                    : ExtAutoMapper.Mapper.Map<List<DataPremix>, List<DataPremixDTO>>(new List<DataPremix> { dataPremix });

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataPremix failed");
                return Ok(ResponseFactory.OKCreator(new List<DataPremixDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataPremixDTO>>(e));
            }

        }



        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataPremix dataPremix)
        {
            try
            {

                int result = _dataPremixService.Append(dataPremix);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataPremix append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataPremix dataPremix)
        {
            try
            {

                bool result = _dataPremixService.Update(dataPremix);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataPremix update failed");
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
                long result = _dataPremixService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataPremix delete failed");
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
