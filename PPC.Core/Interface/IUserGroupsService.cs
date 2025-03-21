using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IUserGroupsService
    {

        /// <summary>
        /// Query UserGroup
        /// </summary>
        /// <param name="userGroupID"></param>
        /// <returns></returns>
        UserGroups GetUserGroupsById(int userGroupID);

        /// <summary>
        /// Get  UserGroup  based on id
        /// </summary>
        /// <param name="userGroupID"></param>
        /// <returns></returns>
        Task<UserGroups> GetUserGroupsByIdAsync(int userGroupID);

        /// <summary>
        /// Get all UserGroup
        /// </summary>
        /// <returns></returns>
        List<UserGroups> GetAll();

        /// <summary>
        /// Get all UserGroup Async
        /// </summary>
        /// <returns></returns>
        Task<List<UserGroups>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="userGroups"></param>
        /// <returns></returns>
        int Append(UserGroups userGroups);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="userGroups"></param>
        /// <returns></returns>
        bool Update(UserGroups userGroups);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="userGroupID"></param>
        /// <returns></returns>
        long Delete(int userGroupID);

        /// <summary>
        /// Existing UserGroupsAsync
        /// </summary>
        /// <param name="name">userGroup name</param>
        /// <returns></returns>
        Task<bool> ExistUserGroupsAsync(string name);


    }
}
