using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class StationTypesService : BaseService, IStationTypesService
    {
        IUnitOfWork _unitOfWork;
        public StationTypesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<StationTypes> GetAll()
        {
            try
            {
                var stationTypes = _repositoryFactory.StationTypes.Table.ToList();

                return stationTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<StationTypes>> GetAllAsync()
        {
            try
            {

                var stationTypes = await _repositoryFactory.StationTypes.Table.ToListAsync();
                return stationTypes;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public StationTypes GetStationTypesById(int stationTypeID)
        {
            try
            {
                var stationTypes = _repositoryFactory.StationTypes
                    .FirstOrDefault(x => x.StationTypeID == stationTypeID);

                return stationTypes;
            }
            catch
            {
                throw;
            }
        }

        public async Task<StationTypes> GetStationTypesByIdAsync(int stationTypeID)
        {
            try
            {
                var stationTypes = await _repositoryFactory.StationTypes
                    .FirstOrDefaultAsync(x => x.StationTypeID == stationTypeID);

                return stationTypes;
            }
            catch
            {
                throw;
            }
        }

        public StationTypes Append(StationTypes stationTypes)
        {
            try
            {
                var _newObject = new StationTypes
                {
                    StationTypeID = stationTypes.StationTypeID,
                    StationTypeName = stationTypes.StationTypeName,
                    StationTypeLatinName = stationTypes.StationTypeLatinName,
                    IsActive = stationTypes.IsActive,
                    InsDate = stationTypes.InsDate,
                    InsTime = stationTypes.InsTime,
                    InsUserID = stationTypes.InsUserID,
                    EditDate = stationTypes.EditDate,
                    EditTime = stationTypes.EditTime,
                    EditUserID = stationTypes.EditUserID,


                };

                _repositoryFactory.StationTypes.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject;
                else
                    return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(StationTypes stationTypes)
        {
            try
            {

                _repositoryFactory.StationTypes.UpdateBy(x => x.StationTypeID == stationTypes.StationTypeID,
                    new StationTypes
                    {
                        StationTypeID = stationTypes.StationTypeID,
                        StationTypeName = stationTypes.StationTypeName,
                        StationTypeLatinName = stationTypes.StationTypeLatinName,
                        IsActive = stationTypes.IsActive,
                        InsDate = stationTypes.InsDate,
                        InsTime = stationTypes.InsTime,
                        InsUserID = stationTypes.InsUserID,
                        EditDate = stationTypes.EditDate,
                        EditTime = stationTypes.EditTime,
                        EditUserID = stationTypes.EditUserID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int stationTypeID)
        {
            try
            {
                var stationTypes = _repositoryFactory.StationTypes
                    .FirstOrDefault(x => x.StationTypeID == stationTypeID);

                if (stationTypes == null)
                    throw new System.Exception("StationTypes Notfound.");

                _repositoryFactory.StationTypes.Delete(stationTypes);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistStationTypesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.StationTypes.FirstOrDefaultAsync(x => x.StationTypeName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
