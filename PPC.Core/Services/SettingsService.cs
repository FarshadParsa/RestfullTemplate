using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PPC.Common.Auth;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
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

        public bool Append(SettingUpdateViewModel settingUpdateViewModel)
        {
            using (var transaction = _unitOfWork.StartTransaction())
            {

                try
                {
                    SettingGenerals oldSettingGeneral = _repositoryFactory.SettingGenerals.Table.FirstOrDefault(x => x.Version == GetActiveVersion().LastVersion);

                    _repositoryFactory.Settings.Add(
                        new Settings
                        {
                            //SettingID = settings.SettingID,
                            LastVersion = settingUpdateViewModel.LastVersion,
                            LastVersionWarninType = settingUpdateViewModel.LastVersionWarninType,
                            UserID = settingUpdateViewModel.UserID,
                            StationID = settingUpdateViewModel.StationID,
                            IsActive = settingUpdateViewModel.IsActive,
                        });

                    _repositoryFactory.SettingUpdates.Add(
                        new SettingUpdates
                        {
                            Version = settingUpdateViewModel.Version,
                            ServerMap = settingUpdateViewModel.ServerMap,
                            FilesName = settingUpdateViewModel.FilesName,
                            Date = settingUpdateViewModel.Date,
                            Describe = settingUpdateViewModel.Describe,
                        });

                    _repositoryFactory.SettingGenerals.Add(
                        new SettingGenerals
                        {
                            Version = settingUpdateViewModel.Version,
                            FactoryNameEn = oldSettingGeneral.FactoryNameEn,
                            FactoryNameFa = oldSettingGeneral.FactoryNameFa,
                            CalendarCultureInfo = oldSettingGeneral.CalendarCultureInfo,
                            CurrencyDecimalSeparator = oldSettingGeneral.CurrencyDecimalSeparator,
                            ReportCustomerDraftFormCode = oldSettingGeneral.ReportCustomerDraftFormCode,
                            LogOpeningForm = oldSettingGeneral.LogOpeningForm,
                            LogClosingForm = oldSettingGeneral.LogClosingForm,
                            LogButtonsClick = oldSettingGeneral.LogButtonsClick,
                            FactoryCode = oldSettingGeneral.FactoryCode,
                        });

                    var statuse = _unitOfWork.Commit() > 0;

                    transaction.Commit();

                    return statuse;
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }

        }

        public bool Update(SettingUpdateViewModel settingUpdateViewModel)
        {

            using (var transaction = _unitOfWork.StartTransaction())
            {

                try
                {
                    var version = settingUpdateViewModel.Version;
                    SettingUpdates settingUpdate = _repositoryFactory.SettingUpdates.Table.First(x => x.Version == version);

                    //_repositoryFactory.Settings
                    //    .Where(x => x.LastVersion == version && (x.UserID != null || x.StationID != null))
                    //    .ToList().ForEach(x => _repositoryFactory.Settings.Delete(x));

                    _repositoryFactory.Settings.DeleteBy(x => x.LastVersion == version && (x.UserID != null || x.StationID != null));

                    _repositoryFactory.Settings.UpdateBy(x => x.SettingID == settingUpdateViewModel.SettingID,
                        new Settings
                        {
                            SettingID = settingUpdateViewModel.SettingID,
                            LastVersion = settingUpdateViewModel.LastVersion,
                            LastVersionWarninType = settingUpdateViewModel.LastVersionWarninType,
                            UserID = null,
                            StationID = null,
                            IsActive = settingUpdateViewModel.IsActive,
                        });

                    _repositoryFactory.SettingUpdates.UpdateBy(x => x.UpdateID == settingUpdate.UpdateID,
                        new SettingUpdates
                        {
                            UpdateID= settingUpdateViewModel.UpdateID,
                            Version = settingUpdateViewModel.Version,
                            ServerMap = settingUpdateViewModel.ServerMap,
                            FilesName = settingUpdateViewModel.FilesName,
                            Date = settingUpdateViewModel.Date,
                            Describe = settingUpdateViewModel.Describe,
                        });

                    settingUpdateViewModel.Users.ForEach(u =>
                    _repositoryFactory.Settings.Add(
                        new Settings
                        {
                            LastVersion = settingUpdateViewModel.LastVersion,
                            LastVersionWarninType = u.LastVersionWarninType,
                            UserID = u.UserID,
                            StationID = null,
                            IsActive = u.IsActive,
                        }));


                    settingUpdateViewModel.Stations.ForEach(s =>
                    _repositoryFactory.Settings.Add(
                        new Settings
                        {
                            LastVersion = settingUpdateViewModel.LastVersion,
                            LastVersionWarninType = s.LastVersionWarninType,
                            UserID = null,
                            StationID = s.StationID,
                            IsActive = s.IsActive,
                        }));

                    var statuse = _unitOfWork.Commit() > 0;

                    transaction.Commit();

                    return statuse;
                }
                catch (System.Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }


            //try
            //{

            //    _repositoryFactory.Settings.UpdateBy(x => x.SettingID == settings.SettingID,
            //        new Settings
            //        {
            //            SettingID = settings.SettingID,
            //            LastVersion = settings.LastVersion,
            //            LastVersionWarninType = settings.LastVersionWarninType,
            //            UserID = settings.UserID,
            //            StationID = settings.StationID,
            //            IsActive = settings.IsActive,


            //        });
            //    var statuse = _unitOfWork.Commit() > 0;
            //    return statuse;
            //}
            //catch (System.Exception ex)
            //{
            //    throw ex;
        }


        //public long Delete(int settingID)
        //{
        //    try
        //    {
        //        var settings = _repositoryFactory.Settings
        //            .FirstOrDefault(x => x.SettingID == settingID);

        //        if (settings == null)
        //            throw new System.Exception("Settings Notfound.");

        //        _repositoryFactory.Settings.Delete(settings);
        //        var statuse = _unitOfWork.Commit();

        //        return statuse;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

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
                var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive && x.Station == null && x.User == null);
                //var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive == true );

                return settings;
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
                var settings = _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefault(x => x.IsActive && x.Station == null && x.User == null);
                //var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive == true );

                return settings;
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
                var settings = await _repositoryFactory.Settings.Table.OrderByDescending(x => x.SettingID).FirstOrDefaultAsync(x => x.IsActive && x.UserID == userID && x.Station == null);


                return settings;
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

        public async Task<List<SettingUpdateViewModel>> GetAllVersionInfo()
        {
            try
            {
                var db = _repositoryFactory;
                var settings = await (from setting in db.Settings.Table
                                      join settingUpdate in db.SettingUpdates.Table on setting.LastVersion equals settingUpdate.Version
                                      where setting.User == null && setting.Station == null
                                      select new SettingUpdateViewModel
                                      {
                                          SettingID = setting.SettingID,
                                          LastVersion = setting.LastVersion,
                                          LastVersionWarninType = setting.LastVersionWarninType,
                                          //UserID = setting.UserID,
                                          User = null,
                                          //StationID = setting.StationID,
                                          Station = null,
                                          IsActive = setting.IsActive,
                                          UpdateID = settingUpdate.UpdateID,
                                          Version = settingUpdate.Version,
                                          ServerMap = settingUpdate.ServerMap,
                                          FilesName = settingUpdate.FilesName,
                                          Date = settingUpdate.Date,
                                          Describe = settingUpdate.Describe,

                                      }).Distinct().ToListAsync();



                return settings;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public List<SettingUserViewModel> GetSettingUsers(string version)
        {
            try
            {
                return SettingUpdateViewModelDL.getVersionUsers(version);

                ////var db = _repositoryFactory;
                ////var settingUser = await (from users in db.Users.Table
                ////                         join settings in db.Settings.Table on users.UserID equals settings.UserID into userJoind
                ////                         from user in userJoind.DefaultIfEmpty()
                ////                      select new SettingUpdateViewModel
                ////                      {
                ////                          SettingID = user.SettingID,
                ////                          LastVersion = user.LastVersion,
                ////                          LastVersionWarninType = user.LastVersionWarninType,
                ////                          UserID = user.UserID,
                ////                          User = user.User,
                ////                          IsActive = user.IsActive,
                ////                          ////Users = (_repositoryFactory.Users.Table.Where(x => x.UserID == setting.UserID).ToList()),
                ////                          ////Users = (_repositoryFactory.Users.Table.Where(x => x.IsActive).ToList()),
                ////                          ////Users = _repositoryFactory.Users.Table.ToList(),
                ////                          //User = settings.User,
                ////                          //StationID = settings.StationID,
                ////                          //Station = null,
                ////                          UpdateID =0,// settingUpdate.UpdateID,
                ////                          ServerMap ="",// settingUpdate.ServerMap,
                ////                          FilesName ="",// settingUpdate.FilesName,
                ////                          Date = "",//settingUpdate.Date,
                ////                          Describe = "",// settingUpdate.Describe,
                ////                          Version ="",// settingUpdate.Version,

                ////                      }).ToListAsync();


                //var db = _repositoryFactory;
                //var settings = await (from setting in db.Settings.Table
                //                      join settingUpdate in db.SettingUpdates.Table on setting.LastVersion equals settingUpdate.Version
                //                      //join user in db.Users.Table on setting.UserID equals user.UserID
                //                      where setting.LastVersion == version &&   setting.Station == null //user.IsActive && 
                //                      select new SettingUpdateViewModel
                //                      {
                //                          SettingID = setting.SettingID,
                //                          LastVersion = setting.LastVersion,
                //                          LastVersionWarninType = setting.LastVersionWarninType,
                //                          UserID = setting.UserID,
                //                          //Users = user,
                //                          //Users = (_repositoryFactory.Users.Table.Where(x => x.UserID == setting.UserID).ToList()),
                //                          Users = (_repositoryFactory.Users.Table.Where(x => x.IsActive).ToList()),
                //                          //Users = _repositoryFactory.Users.Table.ToList(),
                //                          StationID = setting.StationID,
                //                          Station = null,
                //                          IsActive = setting.IsActive,
                //                          UpdateID = settingUpdate.UpdateID,
                //                          Version = settingUpdate.Version,
                //                          ServerMap = settingUpdate.ServerMap,
                //                          FilesName = settingUpdate.FilesName,
                //                          Date = settingUpdate.Date,
                //                          Describe = settingUpdate.Describe,

                //                      }).ToListAsync();


                ////return settingUser;
                //return settings;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public List<SettingStationViewModel> GetSettingStations(string version)
        {
            try
            {
                return SettingUpdateViewModelDL.getVersionStations(version);

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


    }
}
