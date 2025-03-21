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
    public class DataDosingController : Controller
    {

        #region Prop

        private readonly IDataDosingService _dataDosingService;

        #endregion

        #region Ctor

        public DataDosingController(IDataDosingService dataDosingService)
        {
            _dataDosingService = dataDosingService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataDosing()
        {
            try
            {

                List<Core.Models.DataDosing> dataDosing = await _dataDosingService.GetAllAsync();

                //var res = dataDosing == null
                //? null 
                //: dataDosing.ConvertToListDto();

                var res = ExtAutoMapper.Mapper.Map<List<DataDosing>, List<DataDosingDTO>>(dataDosing);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataDosing List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataDosingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataDosingDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataDosingByID(int id)
        {
            try
            {

                Core.Models.DataDosing dataDosing = await _dataDosingService.GetDataDosingByIdAsync(id);

                //var res = dataDosing == null
                //    ? null 
                //    : (new List<Core.Models.DataDosing> { dataDosing }).ConvertToListDto();

                var res = dataDosing == null
                    ? null
                    : ExtAutoMapper.Mapper.Map<List<DataDosing>, List<DataDosingDTO>>(new List<DataDosing> { dataDosing });

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataDosing failed");
                return Ok(ResponseFactory.OKCreator(new List<DataDosingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataDosingDTO>>(e));
            }

        }

        

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataDosing dataDosing)
        {
            try
            {

                int result = _dataDosingService.Append(dataDosing);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataDosing append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataDosing dataDosing)
        {
            try
            {

                bool result = _dataDosingService.Update(dataDosing);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataDosing update failed");
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
                long result = _dataDosingService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataDosing delete failed");
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
