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
    public class ExcelExportSettingController : Controller
    {

        #region Prop

        private readonly IExcelExportSettingService _excelExportSettingService;

        #endregion

        #region Ctor

        public ExcelExportSettingController(IExcelExportSettingService excelExportSettingService)
        {
            _excelExportSettingService = excelExportSettingService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetExcelExportSetting()
        {
            try
            {

                List<Core.Models.ExcelExportSetting> excelExportSetting = await _excelExportSettingService.GetAllAsync();

                //var res = excelExportSetting == null
                //    ? null
                //    : excelExportSetting.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<ExcelExportSetting>, List<ExcelExportSettingDTO>>(excelExportSetting);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ExcelExportSetting List failed");
                return Ok(ResponseFactory.OKCreator(new List<ExcelExportSettingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ExcelExportSettingDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetExcelExportSettingByID(int id)
        {
            try
            {

                Core.Models.ExcelExportSetting excelExportSetting = await _excelExportSettingService.GetExcelExportSettingByIdAsync(id);

                //var res = excelExportSetting == null
                //    ? null
                //    : (new List<Core.Models.ExcelExportSetting> { excelExportSetting }).ConvertToListDto();
                var res = new List<ExcelExportSettingDTO> { ExtAutoMapper.JsonMap<ExcelExportSetting, ExcelExportSettingDTO>(excelExportSetting) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get excelExportSetting failed");
                return Ok(ResponseFactory.OKCreator(new List<ExcelExportSettingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ExcelExportSettingDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ExcelExportSetting excelExportSetting)
        {
            try
            {

                int result = _excelExportSettingService.Append(excelExportSetting);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ExcelExportSetting append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ExcelExportSetting excelExportSetting)
        {
            try
            {

                bool result = _excelExportSettingService.Update(excelExportSetting);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ExcelExportSetting update failed");
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
                long result = _excelExportSettingService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ExcelExportSetting delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{formName}/{userId}")]
        public async Task<IActionResult> GetExcelExportSettingByUserId(string formName, int userId)
        {
            try
            {

                Core.Models.ExcelExportSetting excelExportSetting = await _excelExportSettingService.GetExcelExportSettingByUserIdAsync(formName, userId);

                //var res = excelExportSetting == null
                //    ? null
                //    : (new List<Core.Models.ExcelExportSetting> { excelExportSetting }).ConvertToListDto();

                var res = new List<ExcelExportSettingDTO> { ExtAutoMapper.JsonMap<ExcelExportSetting, ExcelExportSettingDTO>(excelExportSetting) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get excelExportSetting failed");
                return Ok(ResponseFactory.OKCreator(new List<ExcelExportSettingDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ExcelExportSettingDTO>>(e));
            }

        }


    }
}
