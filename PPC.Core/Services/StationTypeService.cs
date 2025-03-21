using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Services
{
    public class StationTypeService : BaseService, IStationTypeService
    {

        IUnitOfWork _unitOfWork;
        public StationTypeService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public bool Append(StationType stationType)
        {
            try
            {
                _repositoryFactory.StationType.Add(
                    new StationType
                    {
                        StationTypeID = stationType.StationTypeID,
                        StationTypeName = stationType.StationTypeName,
                        StationTypeLatinName= stationType.StationTypeLatinName,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(StationType stationType)
        {
            try
            {

                _repositoryFactory.StationType.UpdateBy(x => x.StationTypeID == stationType.StationTypeID,
                    new StationType
                    {
                        StationTypeID = stationType.StationTypeID,
                        StationTypeName = stationType.StationTypeName,
                        StationTypeLatinName = stationType.StationTypeLatinName,
                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int stationTypeId)
        {
            try
            {
                var stationType = _repositoryFactory.StationType
                    .FirstOrDefault(x => x.StationTypeID == stationTypeId);

                if (stationType == null)
                    throw new System.Exception("StationType Not found.");

                _repositoryFactory.StationType.Delete(stationType);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public StationType GetStationTypeById(int stationTypeId)
        {
            try
            {
                var stationType = _repositoryFactory.StationType
                    .FirstOrDefault(x => x.StationTypeID == stationTypeId);

                return stationType;
            }
            catch
            {
                throw;
            }
        }

        public StationType GetStationTypeByName(string stationTypeName)
        {
            try
            {
                var stationType = _repositoryFactory.StationType
                    .FirstOrDefault(x => x.StationTypeName.Equals(stationTypeName,StringComparison.InvariantCultureIgnoreCase));

                return stationType;
            }
            catch
            {
                throw;
            }
        }

        public StationType[] GetStationTypes()
        {
            try
            {
                var stationType = _repositoryFactory.StationType.Table.ToArray();

                return stationType;
            }
            catch
            {
                throw;
            }
        }

        public async Task<StationType[]> GetStationTypesAsync()
        {
            try
            {
                var stationType = _repositoryFactory.StationType.Table.ToArray();

                return stationType;
            }
            catch
            {
                throw;
            }
        }

        public Task<StationType> FindStationTypeAsync(string stationTypename)
        {
            throw new NotImplementedException();
        }

        public Task<StationType> GetCurrentStationTypeAsync()
        {
            throw new NotImplementedException();
        }

        public StationType[] GetStationType()
        {
            throw new NotImplementedException();
        }

        public Task<StationType[]> GetStationTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StationType> GetStationTypeByIdAsync(int stationTypeId)
        {
            throw new NotImplementedException();
        }

    }
}
