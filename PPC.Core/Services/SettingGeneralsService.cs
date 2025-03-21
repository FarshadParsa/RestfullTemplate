using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class SettingGeneralsService : BaseService, ISettingGeneralsService
    {
        IUnitOfWork _unitOfWork;
        public SettingGeneralsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<SettingGenerals> GetAll()
        {
            try
            {
                var settingGenerals = _repositoryFactory.SettingGenerals.Table.ToList();

                return settingGenerals;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<SettingGenerals>> GetAllAsync()
        {
            try
            {

                var settingGenerals = await _repositoryFactory.SettingGenerals.Table.ToListAsync();
                return settingGenerals;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public SettingGenerals GetSettingGeneralsById(int settingGeneralID)
        {
            try
            {
                var settingGenerals = _repositoryFactory.SettingGenerals
                    .FirstOrDefault(x => x.SettingGeneralID == settingGeneralID);

                return settingGenerals;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SettingGenerals> GetSettingGeneralsByIdAsync(int settingGeneralID)
        {
            try
            {
                var settingGenerals = await _repositoryFactory.SettingGenerals
                    .FirstOrDefaultAsync(x => x.SettingGeneralID == settingGeneralID);

                return settingGenerals;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(SettingGenerals settingGenerals)
        {
            try
            {
                _repositoryFactory.SettingGenerals.Add(
                    new SettingGenerals
                    {
                        SettingGeneralID = settingGenerals.SettingGeneralID,
                        Version = settingGenerals.Version,
                        FactoryNameEn = settingGenerals.FactoryNameEn,
                        FactoryNameFa = settingGenerals.FactoryNameFa,
                        CalendarCultureInfo = settingGenerals.CalendarCultureInfo,
                        CurrencyDecimalSeparator = settingGenerals.CurrencyDecimalSeparator,
                        ReportCustomerDraftFormCode = settingGenerals.ReportCustomerDraftFormCode,
                        LogOpeningForm = settingGenerals.LogOpeningForm,
                        LogClosingForm = settingGenerals.LogClosingForm,
                        LogButtonsClick = settingGenerals.LogButtonsClick,
                        FactoryCode = settingGenerals.FactoryCode,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(SettingGenerals settingGenerals)
        {
            try
            {

                _repositoryFactory.SettingGenerals.UpdateBy(x => x.SettingGeneralID == settingGenerals.SettingGeneralID,
                    new SettingGenerals
                    {
                        SettingGeneralID = settingGenerals.SettingGeneralID,
                        Version = settingGenerals.Version,
                        FactoryNameEn = settingGenerals.FactoryNameEn,
                        FactoryNameFa = settingGenerals.FactoryNameFa,
                        CalendarCultureInfo = settingGenerals.CalendarCultureInfo,
                        CurrencyDecimalSeparator = settingGenerals.CurrencyDecimalSeparator,
                        ReportCustomerDraftFormCode = settingGenerals.ReportCustomerDraftFormCode,
                        LogOpeningForm = settingGenerals.LogOpeningForm,
                        LogClosingForm = settingGenerals.LogClosingForm,
                        LogButtonsClick = settingGenerals.LogButtonsClick,
                        FactoryCode = settingGenerals.FactoryCode,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int settingGeneralID)
        {
            try
            {
                var settingGenerals = _repositoryFactory.SettingGenerals
                    .FirstOrDefault(x => x.SettingGeneralID == settingGeneralID);

                if (settingGenerals == null)
                    throw new System.Exception("SettingGenerals Notfound.");

                _repositoryFactory.SettingGenerals.Delete(settingGenerals);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistSettingGeneralsAsync(string vrsion)
        {
            try
            {

                return await _repositoryFactory.SettingGenerals.FirstOrDefaultAsync(x => x.Version == vrsion) != null;
            }
            catch
            {
                throw;
            }
        }


        public async Task<SettingGenerals> GetInstanceByVesionAsync(string vrsion)
        {
            try
            {

                return await _repositoryFactory.SettingGenerals.FirstOrDefaultAsync(x => x.Version == vrsion);
            }
            catch
            {
                throw;
            }
        }


    }
}
