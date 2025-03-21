using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class UserGroupAssignsService : BaseService, IUserGroupAssignsService
    {
        IUnitOfWork _unitOfWork;
        public UserGroupAssignsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<UserGroupAssigns> GetAll()
        {
            try
            {
                var userGroupAssigns = _repositoryFactory.UserGroupAssigns.Table.ToList();

                return userGroupAssigns;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserGroupAssigns>> GetAllAsync()
        {
            try
            {

                var userGroupAssigns = await _repositoryFactory.UserGroupAssigns.Table.ToListAsync();
                return userGroupAssigns;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public UserGroupAssigns GetUserGroupAssignsById(int userGroupAssignID)
        {
            try
            {
                var userGroupAssigns = _repositoryFactory.UserGroupAssigns
                    .FirstOrDefault(x => x.UserGroupAssignID == userGroupAssignID);

                return userGroupAssigns;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserGroupAssigns> GetUserGroupAssignsByIdAsync(int userGroupAssignID)
        {
            try
            {
                var userGroupAssigns = await _repositoryFactory.UserGroupAssigns
                    .FirstOrDefaultAsync(x => x.UserGroupAssignID == userGroupAssignID);

                return userGroupAssigns;
            }
            catch
            {
                throw;
            }
        }

        public List<UserGroupAssigns> Append(List<UserGroupAssigns> userGroupAssignsList)
        {
            using (var transaction = _unitOfWork.StartTransaction())
            {
                try
                {

                    List<UserGroupAssigns> _newObjectList = new List<UserGroupAssigns>();

                    ///delete all record with user group id
                    userGroupAssignsList.Select(x => x.UserID).Distinct().ToList().ForEach(x => DeleteByUserID(x));

                    userGroupAssignsList.Where(x => x.UserGroupID > 0).ToList().ForEach(x =>
                    {
                        _newObjectList.Add(new UserGroupAssigns
                        {
                            UserGroupAssignID = x.UserGroupAssignID,
                            UserGroupID = x.UserGroupID,
                            UserID = x.UserID,
                        });
                    });

                    _newObjectList.ForEach(x => _repositoryFactory.UserGroupAssigns.Add(x));

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


        public bool Update(UserGroupAssigns userGroupAssigns)
        {
            try
            {

                _repositoryFactory.UserGroupAssigns.UpdateBy(x => x.UserGroupAssignID == userGroupAssigns.UserGroupAssignID,
                    new UserGroupAssigns
                    {
                        UserGroupAssignID = userGroupAssigns.UserGroupAssignID,
                        UserID = userGroupAssigns.UserID,
                        UserGroupID = userGroupAssigns.UserGroupID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int userGroupAssignID)
        {
            try
            {
                var userGroupAssigns = _repositoryFactory.UserGroupAssigns
                    .FirstOrDefault(x => x.UserGroupAssignID == userGroupAssignID);

                if (userGroupAssigns == null)
                    throw new System.Exception("UserGroupAssigns Notfound.");

                _repositoryFactory.UserGroupAssigns.Delete(userGroupAssigns);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long DeleteByUserID(int userID)
        {
            try
            {

                var userGroupAssigns = _repositoryFactory.UserGroupAssigns
                    .Where(x => x.UserID == userID).ToList();

                if (userGroupAssigns == null)
                    throw new System.Exception("UserGroupAssigns Notfound.");

                userGroupAssigns.ForEach(x => _repositoryFactory.UserGroupAssigns.Delete(x));


                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<UserGroupAssigns>> GetAllByUserIdAsync(int id)
        {
            try
            {
                var userGroupAssigns = _repositoryFactory.UserGroupAssigns.Where(x => x.UserID == id).ToList();

                return userGroupAssigns;
            }
            catch
            {
                throw;
            }
        }


    }
}
