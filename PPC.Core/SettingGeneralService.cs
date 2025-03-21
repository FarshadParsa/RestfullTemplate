using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Core.Services;
using static System.Collections.Specialized.BitVector32;

using Microsoft.EntityFrameworkCore;
namespace PPC.Core
{
    public class SettingGeneralService : BaseService, ISettingGeneralService
    {
        IUnitOfWork _unitOfWork;
        public SettingGeneralService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<SettingGeneral> GetAll()
        {
            try
            {
                var settingGeneral = _repositoryFactory.SettingGeneral.Table.ToList();

                return settingGeneral;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<SettingGeneral>> GetAllAsync()
        {
            try
            {

                var settingGeneral = await _repositoryFactory.SettingGeneral.Table.ToListAsync();
                return settingGeneral;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public SettingGeneral GetSettingGeneralById(string systemVersion)
        {
            try
            {
                var settingGeneral = _repositoryFactory.SettingGeneral
                    .FirstOrDefault(x => x.SystemVersion == systemVersion);

                return settingGeneral;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SettingGeneral> GetSettingGeneralByIdAsync(string systemVersion)
        {
            try
            {
                var settingGeneral = await _repositoryFactory.SettingGeneral
                    .FirstOrDefaultAsync(x => x.SystemVersion == systemVersion);

                return settingGeneral;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(SettingGeneral settingGeneral)
        {
            try
            {
                _repositoryFactory.SettingGeneral.Add(
                    new SettingGeneral
                    {
                        SystemVersion = settingGeneral.SystemVersion,
                        FactoryNameEn = settingGeneral.FactoryNameEn,
                        FactoryNameFa = settingGeneral.FactoryNameFa,
                        CalendarCultureInfo = settingGeneral.CalendarCultureInfo,
                        CurrencyDecimalSeparator = settingGeneral.CurrencyDecimalSeparator,
                        ReportCustomerDraftFormCode = settingGeneral.ReportCustomerDraftFormCode,
                        GraphicAuthorizedTimesGetDossier = settingGeneral.GraphicAuthorizedTimesGetDossier,
                        MaxSizeOfJobImage = settingGeneral.MaxSizeOfJobImage,
                        LogOpeningForm = settingGeneral.LogOpeningForm,
                        LogClosingForm = settingGeneral.LogClosingForm,
                        LogButtonsClick = settingGeneral.LogButtonsClick,
                        SettingGeneralID = settingGeneral.SettingGeneralID,
                        OrderRequestToExcelSetting = settingGeneral.OrderRequestToExcelSetting,
                        temp = settingGeneral.temp,
                        FactoryCode = settingGeneral.FactoryCode,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(SettingGeneral settingGeneral)
        {
            try
            {

                _repositoryFactory.SettingGeneral.UpdateBy(x => x.SystemVersion == settingGeneral.SystemVersion,
                    new SettingGeneral
                    {
                        SystemVersion = settingGeneral.SystemVersion,
                        FactoryNameEn = settingGeneral.FactoryNameEn,
                        FactoryNameFa = settingGeneral.FactoryNameFa,
                        CalendarCultureInfo = settingGeneral.CalendarCultureInfo,
                        CurrencyDecimalSeparator = settingGeneral.CurrencyDecimalSeparator,
                        ReportCustomerDraftFormCode = settingGeneral.ReportCustomerDraftFormCode,
                        GraphicAuthorizedTimesGetDossier = settingGeneral.GraphicAuthorizedTimesGetDossier,
                        MaxSizeOfJobImage = settingGeneral.MaxSizeOfJobImage,
                        LogOpeningForm = settingGeneral.LogOpeningForm,
                        LogClosingForm = settingGeneral.LogClosingForm,
                        LogButtonsClick = settingGeneral.LogButtonsClick,
                        SettingGeneralID = settingGeneral.SettingGeneralID,
                        OrderRequestToExcelSetting = settingGeneral.OrderRequestToExcelSetting,
                        temp = settingGeneral.temp,
                        FactoryCode = settingGeneral.FactoryCode,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(string systemVersion)
        {
            try
            {
                var settingGeneral = _repositoryFactory.SettingGeneral
                    .FirstOrDefault(x => x.SystemVersion == systemVersion);

                if (settingGeneral == null)
                    throw new System.Exception("SettingGeneral Notfound.");

                _repositoryFactory.SettingGeneral.Delete(settingGeneral);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

    }
}
