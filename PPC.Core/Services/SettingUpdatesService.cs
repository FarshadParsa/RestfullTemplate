using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class SettingUpdatesService : BaseService, ISettingUpdatesService
    {
        IUnitOfWork _unitOfWork;
        public SettingUpdatesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<SettingUpdates> GetAll()
        {
            try
            {
                var settingUpdates = _repositoryFactory.SettingUpdates.Table.ToList();

                return settingUpdates;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<SettingUpdates>> GetAllAsync()
        {
            try
            {

                var settingUpdates = await _repositoryFactory.SettingUpdates.Table.ToListAsync();
                return settingUpdates;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public SettingUpdates GetSettingUpdatesById(int updateID)
        {
            try
            {
                var settingUpdates = _repositoryFactory.SettingUpdates
                    .FirstOrDefault(x => x.UpdateID == updateID);

                return settingUpdates;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SettingUpdates> GetSettingUpdatesByIdAsync(int updateID)
        {
            try
            {
                var settingUpdates = await _repositoryFactory.SettingUpdates
                    .FirstOrDefaultAsync(x => x.UpdateID == updateID);

                return settingUpdates;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(SettingUpdates settingUpdates)
        {
            try
            {
                _repositoryFactory.SettingUpdates.Add(
                    new SettingUpdates
                    {
                        UpdateID = settingUpdates.UpdateID,
                        Version = settingUpdates.Version,
                        ServerMap = settingUpdates.ServerMap,
                        FilesName = settingUpdates.FilesName,
                        Date = settingUpdates.Date,
                        Describe = settingUpdates.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(SettingUpdates settingUpdates)
        {
            try
            {

                _repositoryFactory.SettingUpdates.UpdateBy(x => x.UpdateID == settingUpdates.UpdateID,
                    new SettingUpdates
                    {
                        UpdateID = settingUpdates.UpdateID,
                        Version = settingUpdates.Version,
                        ServerMap = settingUpdates.ServerMap,
                        FilesName = settingUpdates.FilesName,
                        Date = settingUpdates.Date,
                        Describe = settingUpdates.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int updateID)
        {
            try
            {
                var settingUpdates = _repositoryFactory.SettingUpdates
                    .FirstOrDefault(x => x.UpdateID == updateID);

                if (settingUpdates == null)
                    throw new System.Exception("SettingUpdates Notfound.");

                _repositoryFactory.SettingUpdates.Delete(settingUpdates);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SettingUpdates> GetSettingUpdatesByVersionAsync(string version)
        {
            try
            {
                var settingUpdates = await _repositoryFactory.SettingUpdates
                    .FirstOrDefaultAsync(x => x.Version == version);

                return settingUpdates;
            }
            catch
            {
                throw;
            }
        }


    }
}
