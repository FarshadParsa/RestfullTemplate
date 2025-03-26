using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core.Interface;

using WebApi.Core.Models;

using WebApi.Core.Repository;

namespace WebApi.Core.Services
{
    public class ExcelExportSettingDetailService : BaseService, IExcelExportSettingDetailService
    {
        IUnitOfWork _unitOfWork;
        public ExcelExportSettingDetailService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ExcelExportSettingDetail> GetAll()
        {
            try
            {
                var excelExportSettingDetail = _repositoryFactory.ExcelExportSettingDetail.Table.ToList();

                return excelExportSettingDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ExcelExportSettingDetail>> GetAllAsync()
        {
            try
            {

                var excelExportSettingDetail = await _repositoryFactory.ExcelExportSettingDetail.Table.ToListAsync();
                return excelExportSettingDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ExcelExportSettingDetail GetExcelExportSettingDetailById(int excelExportSettingDetailID)
        {
            try
            {
                var excelExportSettingDetail = _repositoryFactory.ExcelExportSettingDetail
                    .FirstOrDefault(x => x.ExcelExportSettingDetailID == excelExportSettingDetailID);

                return excelExportSettingDetail;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ExcelExportSettingDetail> GetExcelExportSettingDetailByIdAsync(int excelExportSettingDetailID)
        {
            try
            {
                var excelExportSettingDetail = await _repositoryFactory.ExcelExportSettingDetail
                    .FirstOrDefaultAsync(x => x.ExcelExportSettingDetailID == excelExportSettingDetailID);

                return excelExportSettingDetail;
            }
            catch
            {
                throw;
            }
        }

        public long Append(ExcelExportSettingDetail excelExportSettingDetail)
        {
            try
            {
                var _newObject = new ExcelExportSettingDetail
                {
                    ExcelExportSettingDetailID = excelExportSettingDetail.ExcelExportSettingDetailID,
                    Priority = excelExportSettingDetail.Priority,
                    ExcelExportSettingID = excelExportSettingDetail.ExcelExportSettingID,
                    FieldName = excelExportSettingDetail.FieldName,
                    DisplayName = excelExportSettingDetail.DisplayName,
                    Visible = excelExportSettingDetail.Visible,


                };

                _repositoryFactory.ExcelExportSettingDetail.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.ExcelExportSettingDetailID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(ExcelExportSettingDetail excelExportSettingDetail)
        {
            try
            {

                _repositoryFactory.ExcelExportSettingDetail.UpdateBy(x => x.ExcelExportSettingDetailID == excelExportSettingDetail.ExcelExportSettingDetailID,
                    new ExcelExportSettingDetail
                    {
                        ExcelExportSettingDetailID = excelExportSettingDetail.ExcelExportSettingDetailID,
                        Priority = excelExportSettingDetail.Priority,
                        ExcelExportSettingID = excelExportSettingDetail.ExcelExportSettingID,
                        FieldName = excelExportSettingDetail.FieldName,
                        DisplayName = excelExportSettingDetail.DisplayName,
                        Visible = excelExportSettingDetail.Visible,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int excelExportSettingDetailID)
        {
            try
            {
                var excelExportSettingDetail = _repositoryFactory.ExcelExportSettingDetail
                    .FirstOrDefault(x => x.ExcelExportSettingDetailID == excelExportSettingDetailID);

                if (excelExportSettingDetail == null)
                    throw new System.Exception("ExcelExportSettingDetail Notfound.");

                _repositoryFactory.ExcelExportSettingDetail.Delete(excelExportSettingDetail);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ExcelExportSettingDetail>> GetAllBySettingIdAsync(int settingId)
        {
            try
            {
                var excelExportSettingDetail = await _repositoryFactory.ExcelExportSettingDetail
                    .Where(x=>x.ExcelExportSettingID== settingId)
                    .ToListAsync();
                return excelExportSettingDetail;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
