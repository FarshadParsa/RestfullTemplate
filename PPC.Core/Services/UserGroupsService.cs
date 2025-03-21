using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class UserGroupsService : BaseService, IUserGroupsService
    {
        IUnitOfWork _unitOfWork;
        public UserGroupsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<UserGroups> GetAll()
        {
            try
            {
                var userGroups = _repositoryFactory.UserGroups.Table.ToList();

                return userGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserGroups>> GetAllAsync()
        {
            try
            {

                var userGroups = await _repositoryFactory.UserGroups.Table.ToListAsync();
                return userGroups;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public UserGroups GetUserGroupsById(int userGroupID)
        {
            try
            {
                var userGroups = _repositoryFactory.UserGroups
                    .FirstOrDefault(x => x.UserGroupID == userGroupID);

                return userGroups;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserGroups> GetUserGroupsByIdAsync(int userGroupID)
        {
            try
            {
                var userGroups = await _repositoryFactory.UserGroups
                    .FirstOrDefaultAsync(x => x.UserGroupID == userGroupID);

                return userGroups;
            }
            catch
            {
                throw;
            }
        }

        public int Append(UserGroups userGroups)
        {
            try
            {
                var _newObject = new UserGroups
                {
                    UserGroupID = userGroups.UserGroupID,
                    UserGroupName = userGroups.UserGroupName,
                    Describe = userGroups.Describe,


                };

                _repositoryFactory.UserGroups.Add(_newObject);

                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return _newObject.UserGroupID;
                else
                    return int.MinValue;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public bool Update(UserGroups userGroups)
        {
            try
            {

                _repositoryFactory.UserGroups.UpdateBy(x => x.UserGroupID == userGroups.UserGroupID,
                    new UserGroups
                    {
                        UserGroupID = userGroups.UserGroupID,
                        UserGroupName = userGroups.UserGroupName,
                        Describe = userGroups.Describe,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int userGroupID)
        {
            try
            {
                var userGroups = _repositoryFactory.UserGroups
                    .FirstOrDefault(x => x.UserGroupID == userGroupID);

                if (userGroups == null)
                    throw new System.Exception("UserGroups Notfound.");

                _repositoryFactory.UserGroups.Delete(userGroups);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistUserGroupsAsync(string name)
        {
            try
            {

                return await _repositoryFactory.UserGroups.FirstOrDefaultAsync(x => x.UserGroupName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }


    }
}
