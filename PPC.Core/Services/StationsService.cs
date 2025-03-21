using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AtlasCellData.ADO;

namespace PPC.Core.Services
{
    public class StationsService : BaseService, IStationsService
    {
        IUnitOfWork _unitOfWork;
        public StationsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        //public bool Append(Stations station)
        //{
        //    try
        //    {
        //        _repositoryFactory.Stations.Add(
        //            new Stations
        //            {
        //                StationID = station.StationID,
        //                StationName = station.StationName,
        //                StationLatinName = station.StationLatinName,
        //                //StationType = station.StationType,
        //                AllowableStopsInDay = station.AllowableStopsInDay,
        //                BarcodeSign = station.BarcodeSign,
        //                IsActive = station.IsActive,
        //            });
        //        var statuse = _unitOfWork.Commit() > 0;
        //        return statuse;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool Update(Stations station)
        //{
        //    try
        //    {

        //        _repositoryFactory.Stations.UpdateBy(x => x.StationID == station.StationID,
        //            new Stations
        //            {
        //                StationID = station.StationID,
        //                StationName = station.StationName,
        //                StationLatinName = station.StationLatinName,
        //                //StationType = station.StationType,
        //                AllowableStopsInDay = station.AllowableStopsInDay,
        //                BarcodeSign = station.BarcodeSign,
        //                IsActive = station.IsActive,
        //            });
        //        var statuse = _unitOfWork.Commit() > 0;
        //        return statuse;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public long Delete(int stationId)
        //{
        //    try
        //    {
        //        var station = _repositoryFactory.Stations
        //            .FirstOrDefault(x => x.StationID == stationId);

        //        if (station == null)
        //            throw new System.Exception("Station Not found.");

        //        _repositoryFactory.Stations.Delete(station);
        //        var statuse = _unitOfWork.Commit();

        //        return statuse;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public Stations GetStationById(int stationId)
        {
            try
            {
                var station = _repositoryFactory.Stations
                    .FirstOrDefault(x => x.StationID == stationId);

                return station;
            }
            catch
            {
                throw;
            }
        }

        public Stations GetStationByName(string stationName)
        {
            try
            {
                var station = _repositoryFactory.Stations
                    .FirstOrDefault(x => x.StationName.Equals(stationName, StringComparison.InvariantCultureIgnoreCase));

                return station;
            }
            catch
            {
                throw;
            }
        }


        public List<Stations> GetStations(bool? isActive = null)
        {
            try
            {
                var station = _repositoryFactory.Stations.Where(x=> x.IsActive).ToList();
                
                if(isActive== null)
                    station = _repositoryFactory.Stations.Table.ToList();
                else if(isActive==false)
                    station = _repositoryFactory.Stations.Where(x => !x.IsActive).ToList();

                return station;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Stations>> GetStationsAsync(bool? isActive = null)
        {
            try
            {

                //var s = _repositoryFactory.Stations
                //    .FirstOrDefault(x => x.StationName.Equals("Station C", StringComparison.InvariantCultureIgnoreCase));


                var station = await _repositoryFactory.Stations.Where(x => x.IsActive).ToListAsync();

                if (isActive == null)
                    station = await _repositoryFactory.Stations.Table.ToListAsync();
                else if (isActive == false)
                    station =await _repositoryFactory.Stations.Where(x => !x.IsActive).ToListAsync();

                return station;

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
       
        public Task<Stations> GetStationByIdAsync(int stationId)
        {
            try
            {
                //var station = _repositoryFactory.Stations.Where(x=>x.StationID == stationId).FirstOrDefaultAsync();// stationId);
                var station = _repositoryFactory.Stations.Table
                    .Include(x => x.StationType)
                    .FirstOrDefaultAsync(x => x.StationID == stationId);// stationId);


                return station;
            }
            catch
            {
                throw;
            }
        }

        public List<Stations> GetAll()
        {
            try
            {
                var stationses = _repositoryFactory.Stations.Table.ToList();

                return stationses;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Stations>> GetAllAsync()
        {
            try
            {

                //var stationses = await _repositoryFactory.Stations.Table.Include(x=>x.StationType).ToListAsync();
                var stationses = await _repositoryFactory.Stations.Table
                    .Include(x=>x.StationType)
                    .ToListAsync();
                return stationses;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Stations GetStationsById(int stationID)
        {
            try
            {
                var stationses = _repositoryFactory.Stations
                    .FirstOrDefault(x => x.StationID == stationID);

                return stationses;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Stations> GetStationsByIdAsync(int stationID)
        {
            try
            {
                var stationses = await _repositoryFactory.Stations
                    .FirstOrDefaultAsync(x => x.StationID == stationID);

                return stationses;
            }
            catch
            {
                throw;
            }
        }

        public int Append(Stations stationses)
        {
            try
            {
                var _newObject = new Stations
                {
                    StationID = stationses.StationID,
                    StationName = stationses.StationName,
                    StationLatinName = stationses.StationLatinName,
                    StationTypeID = stationses.StationTypeID,
                    FWWidth = stationses.FWWidth,
                    AllowableStopsInDay = stationses.AllowableStopsInDay,
                    MinNoOfEmptyBobins = stationses.MinNoOfEmptyBobins,
                    SpeedMMin = stationses.SpeedMMin,
                    BarcodeSign = stationses.BarcodeSign,
                    IsActive = stationses.IsActive,
                    InsUserID = stationses.InsUserID,
                    InsDate = stationses.InsDate,
                    InsTime = stationses.InsTime,
                    EditUserID = stationses.EditUserID,
                    EditDate = stationses.EditDate,
                    EditTime = stationses.EditTime,


                };

                _repositoryFactory.Stations.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.StationID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(Stations stationses)
        {
            try
            {

                _repositoryFactory.Stations.UpdateBy(x => x.StationID == stationses.StationID,
                    new Stations
                    {
                        StationID = stationses.StationID,
                        StationName = stationses.StationName,
                        StationLatinName = stationses.StationLatinName,
                        StationTypeID = stationses.StationTypeID,
                        FWWidth = stationses.FWWidth,
                        AllowableStopsInDay = stationses.AllowableStopsInDay,
                        MinNoOfEmptyBobins = stationses.MinNoOfEmptyBobins,
                        SpeedMMin = stationses.SpeedMMin,
                        BarcodeSign = stationses.BarcodeSign,
                        IsActive = stationses.IsActive,
                        InsUserID = stationses.InsUserID,
                        InsDate = stationses.InsDate,
                        InsTime = stationses.InsTime,
                        EditUserID = stationses.EditUserID,
                        EditDate = stationses.EditDate,
                        EditTime = stationses.EditTime,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int stationID)
        {
            try
            {
                var stationses = _repositoryFactory.Stations
                    .FirstOrDefault(x => x.StationID == stationID);

                if (stationses == null)
                    throw new System.Exception("Stations Notfound.");

                _repositoryFactory.Stations.Delete(stationses);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistStationsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.Stations.FirstOrDefaultAsync(x => x.StationName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
