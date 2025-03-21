using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IUserGroupAssignsService
    {

        /// <summary>
        /// Query UserGroupAssign
        /// </summary>
        /// <param name="userGroupAssignID"></param>
        /// <returns></returns>
        UserGroupAssigns GetUserGroupAssignsById(int userGroupAssignID);

        /// <summary>
        /// Get  UserGroupAssign  based on id
        /// </summary>
        /// <param name="userGroupAssignID"></param>
        /// <returns></returns>
        Task<UserGroupAssigns> GetUserGroupAssignsByIdAsync(int userGroupAssignID);

        /// <summary>
        /// Get all UserGroupAssign
        /// </summary>
        /// <returns></returns>
        List<UserGroupAssigns> GetAll();

        /// <summary>
        /// Get all UserGroupAssign Async
        /// </summary>
        /// <returns></returns>
        Task<List<UserGroupAssigns>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="userGroupAssigns"></param>
        /// <returns></returns>
        List<UserGroupAssigns> Append(List<UserGroupAssigns> userGroupAssigns);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="userGroupAssigns"></param>
        /// <returns></returns>
        bool Update(UserGroupAssigns userGroupAssigns);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="userGroupAssignID"></param>
        /// <returns></returns>
        long Delete(int userGroupAssignID);

        long DeleteByUserID(int userID);

        Task<List<UserGroupAssigns>> GetAllByUserIdAsync(int id);


    }
}
