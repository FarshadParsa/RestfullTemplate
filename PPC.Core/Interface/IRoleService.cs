using WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{
    public interface IRoleService
    {
        /// <summary>
        /// Find User Roles Async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<SysRole>> FindUserRolesAsync(int userId);

        /// <summary>
        /// Is User InRole Async
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<bool> IsUserInRoleAsync(int userId, string roleName);

        /// <summary>
        /// Find Users InRole Async 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<List<SysUserAccount>> FindUsersInRoleAsync(string roleName);

    }
}
