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
    public class DataProductionController : Controller
    {

        #region Prop

        private readonly IDataProductionService _dataProductionService;

        #endregion

        #region Ctor

        public DataProductionController(IDataProductionService dataProductionService)
        {
            _dataProductionService = dataProductionService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataProduction()
        {
            try
            {

                List<Core.Models.DataProduction> dataProduction = await _dataProductionService.GetAllAsync();

                //var res = dataProduction == null
                //? null 
                //: dataProduction.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<DataProduction>,List<DataProductionDTO>> (dataProduction);

                var res = ExtAutoMapper.JsonMap<List<DataProduction>, List<DataProductionDTO>>(dataProduction);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataProduction List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataProductionDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataProductionByID(int id)
        {
            try
            {

                Core.Models.DataProduction dataProduction = await _dataProductionService.GetDataProductionByIdAsync(id);

                //var res = dataProduction == null
                //    ? null 
                //    : (new List<Core.Models.DataProduction> { dataProduction }).ConvertToListDto();

                //var res = dataProduction == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<DataProduction>, List<DataProductionDTO>>(new List<DataProduction> { dataProduction });

                var res = new List<DataProductionDTO> { ExtAutoMapper.JsonMap<DataProduction, DataProductionDTO>(dataProduction) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataProduction failed");
                return Ok(ResponseFactory.OKCreator(new List<DataProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataProductionDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataProduction dataProduction)
        {
            try
            {

                int result = _dataProductionService.Append(dataProduction);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataProduction append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataProduction dataProduction)
        {
            try
            {

                var r = Request;
                var s = ModelState;

                bool result = _dataProductionService.Update(dataProduction);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataProduction update failed");
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
                long result = _dataProductionService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataProduction delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByProductionPlanPatilId(int id)
        {
            try
            {

                Core.Models.DataProduction dataProduction = await _dataProductionService.GetByProductionPlanPatilIdAsync(id);

                //var res = dataProduction == null
                //    ? null 
                //    : (new List<Core.Models.DataProduction> { dataProduction }).ConvertToListDto();

                //var res = dataProduction == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<DataProduction>, List<DataProductionDTO>>(new List<DataProduction> { dataProduction });

                var res = new List<DataProductionDTO> { ExtAutoMapper.JsonMap<DataProduction, DataProductionDTO>(dataProduction) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataProduction failed");
                return Ok(ResponseFactory.OKCreator(new List<DataProductionDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataProductionDTO>>(e));
            }

        }


    }
}
