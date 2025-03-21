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
    public class DataPatilController : Controller
    {

        #region Prop

        private readonly IDataPatilService _dataPatilService;

        #endregion

        #region Ctor

        public DataPatilController(IDataPatilService dataPatilService)
        {
            _dataPatilService = dataPatilService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataPatil()
        {
            try
            {

                List<Core.Models.DataPatil> dataPatil = await _dataPatilService.GetAllAsync();

                //var res = dataPatil == null
                //? null 
                //: dataPatil.ConvertToListDto();

                var res = ExtAutoMapper.Mapper.Map<List<DataPatil>, List<DataPatilDTO>>(dataPatil);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataPatil List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataPatilDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataPatilDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataPatilByID(int id)
        {
            try
            {

                Core.Models.DataPatil dataPatil = await _dataPatilService.GetDataPatilByIdAsync(id);

                //var res = dataPatil == null
                //    ? null 
                //    : (new List<Core.Models.DataPatil> { dataPatil }).ConvertToListDto();

                var res = dataPatil == null
                    ? null
                    : ExtAutoMapper.Mapper.Map<List<DataPatil>, List<DataPatilDTO>>(new List<DataPatil> { dataPatil });

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataPatil failed");
                return Ok(ResponseFactory.OKCreator(new List<DataPatilDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataPatilDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataPatil dataPatil)
        {
            try
            {

                int result = _dataPatilService.Append(dataPatil);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataPatil append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataPatil dataPatil)
        {
            try
            {

                bool result = _dataPatilService.Update(dataPatil);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataPatil update failed");
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
                long result = _dataPatilService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataPatil delete failed");
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
