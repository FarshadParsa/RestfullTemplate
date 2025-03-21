using PPC.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IUsersService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isActive">null)All user</param>
        /// <returns></returns>
        List<Users> GetUsers(bool? isActive = null);

        /// <summary>
        /// Account verify
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>      
        Users UserVerify(string username, string password);

        /// <summary>
        /// Query users 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Users GetUserByUserId(int userId);

        /// <summary>
        /// Get User  based on id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Users> GetUserByUserIdAsync(int userId);

        /// <summary>
        /// Query users 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Users GetUserByUsername(string username);

        /// <summary>
        /// Query users 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Users> GetUserByUsernameAsync(string username);

        /// <summary>
        /// Find User Async
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<Users> FindUserAsync(string username);

        /// <summary>
        /// Find User Async
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Users> FindUserAsync(string username, string password);

        int GetCurrentUserId();

        Users Append(Users user);
        bool Update(Users user);
        long DeleteUser(int userId);

        //bool PasswordVerify(Users user, string password);
        bool ChangePassword(Users user, string newPassword);

        Task<bool> ExistUser(string userName);

        Task<long> LoginAsync(LoginLogs loginLog, long? preLoginId);

        Task<bool> LogoutAsync(long loginId);

        Task<bool> HasUserAccessToStation(int userId, int stationId);

        long UserSingnIn(int userId);

        long UserSingnOut(int userId);


    }
}
