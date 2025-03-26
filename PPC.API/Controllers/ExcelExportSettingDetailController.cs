using WebApi.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using WebApi.Base.Models.Exceptions;
using WebApi.Core.Interface;
using WebApi.Core.Log;
using WebApi.Core.Models;
using WebApi.Response.DTOs;
using WebApi.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WebApi.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ExcelExportSettingDetailController : Controller
    {

        #region Prop

        private readonly IExcelExportSettingDetailService _excelExportSettingDetailService;

        #endregion

        #region Ctor

        public ExcelExportSettingDetailController(IExcelExportSettingDetailService excelExportSettingDetailService)
        {
            _excelExportSettingDetailService = excelExportSettingDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetExcelExportSettingDetail()
        {
            try
            {

                List<Core.Models.ExcelExportSettingDetail> excelExportSettingDetail = await _excelExportSettingDetailService.GetAllAsync();

                //var res = excelExportSettingDetail == null
                //    ? null
                //    : excelExportSettingDetail.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<ExcelExportSettingDetail>, List<ExcelExportSettingDetailDTO>>(excelExportSettingDetail);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ExcelExportSettingDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<ExcelExportSettingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ExcelExportSettingDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetExcelExportSettingDetailByID(int id)
        {
            try
            {

                Core.Models.ExcelExportSettingDetail excelExportSettingDetail = await _excelExportSettingDetailService.GetExcelExportSettingDetailByIdAsync(id);

                //var res = excelExportSettingDetail == null
                //    ? null
                //    : (new List<Core.Models.ExcelExportSettingDetail> { excelExportSettingDetail }).ConvertToListDto();

                var res = new List<ExcelExportSettingDetailDTO> { ExtAutoMapper.JsonMap<ExcelExportSettingDetail, ExcelExportSettingDetailDTO>(excelExportSettingDetail) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get excelExportSettingDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<ExcelExportSettingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ExcelExportSettingDetailDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ExcelExportSettingDetail excelExportSettingDetail)
        {
            try
            {

                long result = _excelExportSettingDetailService.Append(excelExportSettingDetail);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ExcelExportSettingDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ExcelExportSettingDetail excelExportSettingDetail)
        {
            try
            {

                bool result = _excelExportSettingDetailService.Update(excelExportSettingDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ExcelExportSettingDetail update failed");
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
                long result = _excelExportSettingDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ExcelExportSettingDetail delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetDetailByExcelExportSettingId(int id)
        {
            try
            {

                List<Core.Models.ExcelExportSettingDetail> excelExportSettingDetail = await _excelExportSettingDetailService.GetAllBySettingIdAsync(id);

                //var res = excelExportSettingDetail == null
                //    ? null
                //    : excelExportSettingDetail.ConvertToListDto();
                var res = ExtAutoMapper.JsonMap<List<ExcelExportSettingDetail>, List<ExcelExportSettingDetailDTO>>(excelExportSettingDetail);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ExcelExportSettingDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<ExcelExportSettingDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ExcelExportSettingDetailDTO>>(e));
            }

        }


    }
}
