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
    public class DataDosingDetailController : Controller
    {

        #region Prop

        private readonly IDataDosingDetailService _dataDosingDetailService;

        #endregion

        #region Ctor

        public DataDosingDetailController(IDataDosingDetailService dataDosingDetailService)
        {
            _dataDosingDetailService = dataDosingDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDataDosingDetail()
        {
            try
            {

                List<Core.Models.DataDosingDetail> dataDosingDetail = await _dataDosingDetailService.GetAllAsync();

                //var res = dataDosingDetail == null
                //? null 
                //: dataDosingDetail.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<DataDosingDetail>,List<DataDosingDetailDTO>> (dataDosingDetail);

                var res = ExtAutoMapper.JsonMap<List<DataDosingDetail>, List<DataDosingDetailDTO>>(dataDosingDetail);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataDosingDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataDosingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataDosingDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetDataDosingDetailByID(int id)
        {
            try
            {

                Core.Models.DataDosingDetail dataDosingDetail = await _dataDosingDetailService.GetDataDosingDetailByIdAsync(id);

                //var res = dataDosingDetail == null
                //    ? null 
                //    : (new List<Core.Models.DataDosingDetail> { dataDosingDetail }).ConvertToListDto();

                //var res = dataDosingDetail == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<DataDosingDetail>, List<DataDosingDetailDTO>>(new List<DataDosingDetail> { dataDosingDetail });

                var res = new List<DataDosingDetailDTO> { ExtAutoMapper.JsonMap<DataDosingDetail, DataDosingDetailDTO>(dataDosingDetail) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get dataDosingDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<DataDosingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataDosingDetailDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] DataDosingDetail dataDosingDetail)
        {
            try
            {

                int result = _dataDosingDetailService.Append(dataDosingDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataDosingDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DataDosingDetail dataDosingDetail)
        {
            try
            {

                bool result = _dataDosingDetailService.Update(dataDosingDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataDosingDetail update failed");
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
                long result = _dataDosingDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DataDosingDetail delete failed");
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

                List<Core.Models.DataDosingDetail> dataDosingDetail = await _dataDosingDetailService.GetListByDataProductionIdAsync(id);

                //var res = dataDosingDetail == null
                //? null 
                //: dataDosingDetail.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<DataDosingDetail>, List<DataDosingDetailDTO>>(dataDosingDetail);
                var res = ExtAutoMapper.JsonMap<List<DataDosingDetail>, List<DataDosingDetailDTO>>(dataDosingDetail);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DataDosingDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<DataDosingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DataDosingDetailDTO>>(e));
            }

        }


    }
}




