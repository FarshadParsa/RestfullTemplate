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
    public class DataGrindingDetailController : Controller
    {

        #region Prop

        private readonly IDataGrindingDetailService _dataGrindingDetailService;

        #endregion

        #region Ctor

        public DataGrindingDetailController(IDataGrindingDetailService dataGrindingDetailService)
        {
            _dataGrindingDetailService = dataGrindingDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataGrindingDetail()
        {
            try
            {

                List<Core.Models.DataGrindingDetail> dataGrindingDetail = await _dataGrindingDetailService.GetAllAsync();

                //var res = dataGrindingDetail == null
                //? null 
                //: dataGrindingDetail.ConvertToListDto();

                var res = ExtAutoMapper.Mapper.Map<List<DataGrindingDetail>, List<DataGrindingDetailDTO>>(dataGrindingDetail);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataGrindingDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataGrindingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataGrindingDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataGrindingDetailByID(int id)
        {
            try
            {

                Core.Models.DataGrindingDetail dataGrindingDetail = await _dataGrindingDetailService.GetDataGrindingDetailByIdAsync(id);

                //var res = dataGrindingDetail == null
                //    ? null 
                //    : (new List<Core.Models.DataGrindingDetail> { dataGrindingDetail }).ConvertToListDto();

                var res = dataGrindingDetail == null
                    ? null
                    : ExtAutoMapper.Mapper.Map<List<DataGrindingDetail>, List<DataGrindingDetailDTO>>(new List<DataGrindingDetail> { dataGrindingDetail });

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataGrindingDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<DataGrindingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataGrindingDetailDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataGrindingDetail dataGrindingDetail)
        {
            try
            {

                int result = _dataGrindingDetailService.Append(dataGrindingDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataGrindingDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataGrindingDetail dataGrindingDetail)
        {
            try
            {

                bool result = _dataGrindingDetailService.Update(dataGrindingDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataGrindingDetail update failed");
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
                long result = _dataGrindingDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataGrindingDetail delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListByDataProductionId(int id)
        {
            try
            {

                List<Core.Models.DataGrindingDetail> dataGrindingDetail = await _dataGrindingDetailService.GetListByDataProductionIdAsync(id);

                //var res = dataGrindingDetail == null
                //? null 
                //: dataGrindingDetail.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<DataGrindingDetail>, List<DataGrindingDetailDTO>>(dataGrindingDetail);
                var res = ExtAutoMapper.JsonMap<List<DataGrindingDetail>, List<DataGrindingDetailDTO>>(dataGrindingDetail);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataGrindingDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataGrindingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataGrindingDetailDTO>>(e));
            }

        }



    }
}
