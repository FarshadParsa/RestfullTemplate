using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class UserGroupStationsService : BaseService, IUserGroupStationsService
    {
        IUnitOfWork _unitOfWork;
        public UserGroupStationsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<UserGroupStations> GetAll()
        {
            try
            {
                var userGroupStations = _repositoryFactory.UserGroupStations.Table.ToList();

                return userGroupStations;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserGroupStations>> GetAllAsync()
        {
            try
            {

                var userGroupStations = await _repositoryFactory.UserGroupStations.Table.ToListAsync();
                return userGroupStations;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public UserGroupStations GetUserGroupStationsById(int userGroupStationID)
        {
            try
            {
                var userGroupStations = _repositoryFactory.UserGroupStations
                    .FirstOrDefault(x => x.UserGroupStationID == userGroupStationID);

                return userGroupStations;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserGroupStations> GetUserGroupStationsByIdAsync(int userGroupStationID)
        {
            try
            {
                var userGroupStations = await _repositoryFactory.UserGroupStations
                    .FirstOrDefaultAsync(x => x.UserGroupStationID == userGroupStationID);

                return userGroupStations;
            }
            catch
            {
                throw;
            }
        }

        public List<UserGroupStations> Append(List<UserGroupStations> userGroupStationsList)
        {
            using (var transaction = _unitOfWork.StartTransaction())
            {
                try
                {

                    List<UserGroupStations> _newObjectList = new List<UserGroupStations>();

                    ///delete all record with user group id
                    userGroupStationsList.Select(x => x.UserGroupID).Distinct().ToList().ForEach(x => DeleteByUserGroupId(x));
                    
                    userGroupStationsList.Where(x=>x.StationID>0).ToList().ForEach(x =>
                    {
                        _newObjectList.Add(new UserGroupStations
                        {
                            UserGroupStationID = x.UserGroupStationID,
                            UserGroupID = x.UserGroupID,
                            StationID = x.StationID,
                        });
                    });

                    _newObjectList.ForEach(x => _repositoryFactory.UserGroupStations.Add(x));

                    var statuse = _unitOfWork.Commit() > 0;

                    _unitOfWork.CommitTransaction();

                    if (statuse)
                        return _newObjectList;
                    else
                        return null;

                }
                catch (System.Exception)
                {
                    _unitOfWork.Rollback();
                    throw;
                }

            }
        }


        public bool Update(UserGroupStations userGroupStations)
        {
            try
            {

                _repositoryFactory.UserGroupStations.UpdateBy(x => x.UserGroupStationID == userGroupStations.UserGroupStationID,
                    new UserGroupStations
                    {
                        UserGroupStationID = userGroupStations.UserGroupStationID,
                        UserGroupID = userGroupStations.UserGroupID,
                        StationID = userGroupStations.StationID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int userGroupStationID)
        {
            try
            {
                var userGroupStations = _repositoryFactory.UserGroupStations
                    .FirstOrDefault(x => x.UserGroupStationID == userGroupStationID);

                if (userGroupStations == null)
                    throw new System.Exception("UserGroupStations Notfound.");

                _repositoryFactory.UserGroupStations.Delete(userGroupStations);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long DeleteByUserGroupId(int userGroupID)
        {
            try
            {
                var userGroupStations = _repositoryFactory.UserGroupStations
                    .Where(x => x.UserGroupID == userGroupID).ToList();

                if (userGroupStations == null)
                    throw new System.Exception("UserGroupStations Notfound.");

                userGroupStations.ForEach(x => _repositoryFactory.UserGroupStations.Delete(x));
                
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }



        public async Task<List<UserGroupStations>> GetAllByUserGroupIdAsync(int userGroupId)
        {
            try
            {

                var userGroupStations = await _repositoryFactory.UserGroupStations.Table.Where(x => x.UserGroupID == userGroupId).ToListAsync();
                return userGroupStations;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }




    }
}
