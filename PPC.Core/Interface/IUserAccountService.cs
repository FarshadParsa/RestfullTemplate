using WebApi.Core.Models;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{

    public interface IUserAccountService
    {
        /// <summary>
        /// Account verify
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>      
        SysUserAccount AccountVerify(string userName, string password);

        /// <summary>
        /// Query users 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        SysUserAccount GetUserById(int userId);

        /// <summary>
        /// Find User Async
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<SysUserAccount> FindUserAsync(string username, string password);

        /// <summary>
        /// Get User  based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SysUserAccount> GetUserByIdAsync(int userId);

        /// <summary>
        /// Update User LastActivityDate  based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task UpdateUserLastActivityDateAsync(int userId);

        int GetCurrentUserId();

        /// <summary>
        /// Get Current User 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<SysUserAccount> GetCurrentUserAsync();

        /// <summary>
        /// Get SerialNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<string> GetSerialNumberAsync(int userId);
    }
}
