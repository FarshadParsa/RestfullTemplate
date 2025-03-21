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
    public class DataGrindingController : Controller
    {

        #region Prop

        private readonly IDataGrindingService _dataGrindingService;

        #endregion

        #region Ctor

        public DataGrindingController(IDataGrindingService dataGrindingService)
        {
            _dataGrindingService = dataGrindingService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataGrinding()
        {
            try
            {

                List<Core.Models.DataGrinding> dataGrinding = await _dataGrindingService.GetAllAsync();

                //var res = dataGrinding == null
                //? null 
                //: dataGrinding.ConvertToListDto();

                var res = ExtAutoMapper.Mapper.Map<List<DataGrinding>, List<DataGrindingDTO>>(dataGrinding);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataGrinding List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataGrindingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataGrindingDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataGrindingByID(int id)
        {
            try
            {

                Core.Models.DataGrinding dataGrinding = await _dataGrindingService.GetDataGrindingByIdAsync(id);

                //var res = dataGrinding == null
                //    ? null 
                //    : (new List<Core.Models.DataGrinding> { dataGrinding }).ConvertToListDto();

                var res = dataGrinding == null
                    ? null
                    : ExtAutoMapper.Mapper.Map<List<DataGrinding>, List<DataGrindingDTO>>(new List<DataGrinding> { dataGrinding });

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataGrinding failed");
                return Ok(ResponseFactory.OKCreator(new List<DataGrindingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataGrindingDTO>>(e));
            }

        }




        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataGrinding dataGrinding)
        {
            try
            {

                int result = _dataGrindingService.Append(dataGrinding);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataGrinding append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataGrinding dataGrinding)
        {
            try
            {

                bool result = _dataGrindingService.Update(dataGrinding);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataGrinding update failed");
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
                long result = _dataGrindingService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataGrinding delete failed");
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
