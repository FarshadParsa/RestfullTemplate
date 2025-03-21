using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;

namespace PPC.Core.Services
{
    public class ExcelExportSettingService : BaseService, IExcelExportSettingService
    {
        IUnitOfWork _unitOfWork;
        public ExcelExportSettingService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<ExcelExportSetting> GetAll()
        {
            try
            {
                var excelExportSetting = _repositoryFactory.ExcelExportSetting.Table.ToList();

                return excelExportSetting;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ExcelExportSetting>> GetAllAsync()
        {
            try
            {

                var excelExportSetting = await _repositoryFactory.ExcelExportSetting.Table.ToListAsync();
                return excelExportSetting;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public ExcelExportSetting GetExcelExportSettingById(int excelExportSettingID)
        {
            try
            {
                var excelExportSetting = _repositoryFactory.ExcelExportSetting
                    .FirstOrDefault(x => x.ExcelExportSettingID == excelExportSettingID);

                return excelExportSetting;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ExcelExportSetting> GetExcelExportSettingByIdAsync(int excelExportSettingID)
        {
            try
            {
                var excelExportSetting = await _repositoryFactory.ExcelExportSetting
                    .FirstOrDefaultAsync(x => x.ExcelExportSettingID == excelExportSettingID);

                return excelExportSetting;
            }
            catch
            {
                throw;
            }
        }

        public int Append(ExcelExportSetting excelExportSetting)
        {
            using (var t = _unitOfWork.StartTransaction())
            {

                try
                {
                    var _newObject = new ExcelExportSetting
                    {
                        //ExcelExportSettingID = excelExportSetting.ExcelExportSettingID,
                        FormButtonName = excelExportSetting.FormButtonName,
                        FileName = excelExportSetting.FileName,
                        Path = excelExportSetting.Path,
                        ConcatDateTimeToFileName = excelExportSetting.ConcatDateTimeToFileName,
                        UserID = excelExportSetting.UserID,


                    };

                    _repositoryFactory.ExcelExportSetting.Add(_newObject);
                    var statuse = _unitOfWork.Commit() > 0;

                    excelExportSetting.ExcelExportSettingDetailList.ForEach(x =>
                    {
                        _repositoryFactory.ExcelExportSettingDetail.Add(new ExcelExportSettingDetail
                        {
                            ExcelExportSettingID = _newObject.ExcelExportSettingID,
                            Priority = x.Priority,
                            FieldName = x.FieldName,
                            DisplayName = x.DisplayName,
                            Visible = x.Visible,
                        });

                    });


                    //_repositoryFactory.ExcelExportSetting.Add(_newObject);

                    statuse &= _unitOfWork.Commit() > 0;

                    t.Commit();
                    if (statuse)
                        return _newObject.ExcelExportSettingID;
                    else
                        return int.MinValue;
                }
                catch (System.Exception)
                {
                    t.Rollback();
                    throw;
                }
            }
        }


        public bool Update(ExcelExportSetting excelExportSetting)
        {
            try
            {


                _repositoryFactory.ExcelExportSetting.UpdateBy(x => x.ExcelExportSettingID == excelExportSetting.ExcelExportSettingID,
                    new ExcelExportSetting
                    {
                        ExcelExportSettingID = excelExportSetting.ExcelExportSettingID,
                        FormButtonName = excelExportSetting.FormButtonName,
                        FileName = excelExportSetting.FileName,
                        Path = excelExportSetting.Path,
                        ConcatDateTimeToFileName = excelExportSetting.ConcatDateTimeToFileName,
                        UserID = excelExportSetting.UserID,


                    });

                //ExcelExportSettingDetailDL.deleteRecords("ExcelExportSettingID=" + ExcelExportSetting.ExcelExportSettingID.ToString());

                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int excelExportSettingID)
        {
            try
            {
                var excelExportSetting = _repositoryFactory.ExcelExportSetting
                    .FirstOrDefault(x => x.ExcelExportSettingID == excelExportSettingID);

                if (excelExportSetting == null)
                    throw new System.Exception("ExcelExportSetting Notfound.");

                _repositoryFactory.ExcelExportSetting.Delete(excelExportSetting);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ExcelExportSetting> GetExcelExportSettingByUserIdAsync(string formName, int userId)
        {
            try
            {
                var excelExportSetting = await _repositoryFactory.ExcelExportSetting
                    .FirstOrDefaultAsync(x => x.UserID == userId || x.FormButtonName == formName);

                return excelExportSetting;
            }
            catch
            {
                throw;
            }
        }



    }
}
