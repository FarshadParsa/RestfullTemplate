using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IExcelExportSettingService
    {

        /// <summary>
        /// Query ExcelExportSetting
        /// </summary>
        /// <param name="excelExportSettingID"></param>
        /// <returns></returns>
        ExcelExportSetting GetExcelExportSettingById(int excelExportSettingID);

        /// <summary>
        /// Get  ExcelExportSetting  based on id
        /// </summary>
        /// <param name="excelExportSettingID"></param>
        /// <returns></returns>
        Task<ExcelExportSetting> GetExcelExportSettingByIdAsync(int excelExportSettingID);

        /// <summary>
        /// Get all ExcelExportSetting
        /// </summary>
        /// <returns></returns>
        List<ExcelExportSetting> GetAll();

        /// <summary>
        /// Get all ExcelExportSetting Async
        /// </summary>
        /// <returns></returns>
        Task<List<ExcelExportSetting>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="excelExportSetting"></param>
        /// <returns></returns>
        int Append(ExcelExportSetting excelExportSetting);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="excelExportSetting"></param>
        /// <returns></returns>
        bool Update(ExcelExportSetting excelExportSetting);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="excelExportSettingID"></param>
        /// <returns></returns>
        long Delete(int excelExportSettingID);


        /// <summary>
        /// Get  ExcelExportSetting  based on formname and userid
        /// </summary>
        /// <param name="formName">formName</param>
        /// <param name="userId">userId</param>
        /// <returns></returns>
        Task<ExcelExportSetting> GetExcelExportSettingByUserIdAsync(string formName, int userId);


    }
}
