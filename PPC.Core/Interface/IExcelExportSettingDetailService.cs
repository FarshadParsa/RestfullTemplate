using WebApi.Core.Models;
using WebApi.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{
    public interface IExcelExportSettingDetailService
    {

        /// <summary>
        /// Query ExcelExportSettingDetail
        /// </summary>
        /// <param name="excelExportSettingDetailID"></param>
        /// <returns></returns>
        ExcelExportSettingDetail GetExcelExportSettingDetailById(int excelExportSettingDetailID);

        /// <summary>
        /// Get  ExcelExportSettingDetail  based on id
        /// </summary>
        /// <param name="excelExportSettingDetailID"></param>
        /// <returns></returns>
        Task<ExcelExportSettingDetail> GetExcelExportSettingDetailByIdAsync(int excelExportSettingDetailID);

        /// <summary>
        /// Get all ExcelExportSettingDetail
        /// </summary>
        /// <returns></returns>
        List<ExcelExportSettingDetail> GetAll();

        /// <summary>
        /// Get all ExcelExportSettingDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<ExcelExportSettingDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="excelExportSettingDetail"></param>
        /// <returns></returns>
        long Append(ExcelExportSettingDetail excelExportSettingDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="excelExportSettingDetail"></param>
        /// <returns></returns>
        bool Update(ExcelExportSettingDetail excelExportSettingDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="excelExportSettingDetailID"></param>
        /// <returns></returns>
        long Delete(int excelExportSettingDetailID);

        /// <summary>
        /// Get all ExcelExportSettingDetail By SettingId Async
        /// </summary>
        /// <returns></returns>
        Task<List<ExcelExportSettingDetail>> GetAllBySettingIdAsync(int settingId);



    }
}
