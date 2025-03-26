using WebApi.Core.Interface;
using WebApi.Core.Models;
using WebApi.Core.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Common.Attributes;


namespace WebApi.Core.Services
{
    [ServiceMapTo(typeof(IRoleService))]
    public class RoleService : BaseService, IRoleService
    {

        #region ctor

        public RoleService(
            IUnitOfWork unitOfWork,
            RepositoryFactory repositoryFactory)
        {
            _unitOfWork = unitOfWork;
            _repositoryFactory = repositoryFactory;

        }
        #endregion

        #region Public Method

        public Task<List<SysRole>> FindUserRolesAsync(int userId)
        {
            var _roles = _repositoryFactory.SysRoles.Table;
            var userRolesQuery = from role in _roles
                                 from userRoles in role.UserRoles
                                 where userRoles.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).ToListAsync();
        }

        public Task<List<SysUserAccount>> FindUsersInRoleAsync(string roleName)
        {
            var _roles = _repositoryFactory.SysRoles.Table;
            var roleUserIdsQuery = from role in _roles
                                   where role.Name == roleName
                                   from user in role.UserRoles
                                   select user.UserId;
            return _repositoryFactory.SysUserAccounts.Where(user => roleUserIdsQuery.Contains(user.ID))
                         .ToListAsync();
        }

        public async Task<bool> IsUserInRoleAsync(int userId, string roleName)
        {
            var _roles = _repositoryFactory.SysRoles.Table;

            var userRolesQuery = from role in _roles
                                 where role.Name == roleName
                                 from user in role.UserRoles
                                 where user.UserId == userId
                                 select role;
            var userRole = await userRolesQuery.FirstOrDefaultAsync();
            return userRole != null;
        } 
        #endregion
    }
}
