using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using WebApi.Common.Auth;
using WebApi.Core.Interface;
using WebApi.Common.Attributes;

using WebApi.Core.Models;

using WebApi.Core.Repository;

namespace WebApi.Core.Services
{
    [ServiceMapTo(typeof(ISettingsService), ServiceLifetime.Scoped)]
    public class SettingsService : BaseService, ISettingsService
    {
        IUnitOfWork _unitOfWork;
        public SettingsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Settings> GetAll()
        {
            try
            {
                var settings = _repositoryFactory.Settings.Table.ToList();

                return settings;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Settings>> GetAllAsync()
        {
            try
            {

                var settings = await _repositoryFactory.Settings.Table.ToListAsync();
                return settings;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Settings GetSettingsById(int settingID)
        {
            try
            {
                var settings = _repositoryFactory.Settings
                    .FirstOrDefault(x => x.SettingID == settingID);

                return settings;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Settings> GetSettingsByIdAsync(int settingID)
        {
            try
            {
                var settings = await _repositoryFactory.Settings
                    .FirstOrDefaultAsync(x => x.SettingID == settingID);

                return settings;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(Settings settings)
        {
            try
            {
                _repositoryFactory.Settings.Add(
                    new Settings
                    {
                        SettingID = settings.SettingID,
                        LastVersion = settings.LastVersion,
                        LastVersionWarninType = settings.LastVersionWarninType,
                        UserID = settings.UserID,
                        StationID = settings.StationID,
                        IsActive = settings.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Settings settings)
        {
            try
            {

                _repositoryFactory.Settings.UpdateBy(x => x.SettingID == settings.SettingID,
                    new Settings
                    {
                        SettingID = settings.SettingID,
                        LastVersion = settings.LastVersion,
                        LastVersionWarninType = settings.LastVersionWarninType,
                        UserID = settings.UserID,
                        StationID = settings.StationID,
                        IsActive = settings.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int settingID)
        {
            using (var transaction = _unitOfWork.StartTransaction())
            {
                try
                {
                    var settings = _repositoryFactory.Settings
                        .FirstOrDefault(x => x.SettingID == settingID);

                    var settingUpdates = _repositoryFactory.SettingUpdates
                        .FirstOrDefault(x => x.Version == settings.LastVersion);

                    var settinGenerals = _repositoryFactory.SettingGenerals
                        .FirstOrDefault(x => x.Version == settings.LastVersion);

                    if (settings == null)
                        throw new System.Exception("Settings Notfound.");

                    _repositoryFactory.Settings.Delete(settings);

                    if (settingUpdates != null)
                        _repositoryFactory.SettingUpdates.Delete(settingUpdates);

                    if (settinGenerals != null)
                        _repositoryFactory.SettingGenerals.Delete(settinGenerals);

                    var statuse = _unitOfWork.Commit();

                    transaction.Commit();
                    return statuse;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<Settings> GetActiveVersionAsync()
        {
            try
            {
                //var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive && x.Station == null && x.User == null);
                ////var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive == true );

                //return settings;

                return null;

            }
            catch
            {
                throw;
            }
        }

        public Settings GetActiveVersion()
        {
            try
            {
                //var settings = _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefault(x => x.IsActive && x.Station == null && x.User == null);
                ////var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive == true );

                //return settings;

                return null;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Settings> GetActiveVersionByUserIdAsync(int userID)
        {
            try
            {
                //var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive && x.UserID == userID && x.Station == null);


                //return settings;

                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Settings> GetActiveVersionByStationIdAsync(int stationID)
        {
            try
            {
                var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive && x.StationID == stationID && x.User == null);

                return settings;
            }
            catch
            {
                throw;
            }
        }

    }
}
