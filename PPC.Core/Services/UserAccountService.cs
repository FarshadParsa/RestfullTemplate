using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using PPC.Core.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PPC.Base;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PPC.Core.Services
{
    [ServiceMapTo(typeof(IUserAccountService))]
    public class UserAccountService : BaseService, IUserAccountService
    {
        #region Properties

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISecurityService _securityService;
        #endregion

        #region Ctor
        public UserAccountService(
            IUnitOfWork unitOfWork,
            RepositoryFactory repositoryFactory,
            ISecurityService securityService,
            IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _repositoryFactory = repositoryFactory;


            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }

        #endregion

        #region Public Method
        public SysUserAccount AccountVerify(string userName, string password)
        {
            // string encodePwd = SHA1.GetHashedString(password);
            var encodePwd = _securityService.GetSha256Hash(password);
            var user = _repositoryFactory.SysUserAccounts.FirstOrDefault(x => x.Username == userName && x.Password == encodePwd && x.IsActive);
            if (user == null || !(user.IsActive))
            {
                return null;
            }
            //Update login time
            user.LastLoginTime = DateTime.Now;
            _repositoryFactory.SysUserAccounts.Update(user, "LastLoginTime");
            _unitOfWork.Commit();
            return user;
        }

        public Task<SysUserAccount> FindUserAsync(string username, string password)
        {
            var passwordHash = _securityService.GetSha256Hash(password);
            var _user = _repositoryFactory.SysUserAccounts.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
            return _user;
        }

        public SysUserAccount GetUserById(int userId)
        {
            return _repositoryFactory.SysUserAccounts.FirstOrDefault(x => x.ID == userId);
        }

        //public ValueTask<SysUserAccount> FindUserAsync(int userId)
        //{
        //    return _repositoryFactory.SysUserAccounts.FirstOrDefaultAsync(x => x.ID == userId);
        //}

        public async Task<SysUserAccount> GetUserByIdAsync(int userId)
        {
            return await _repositoryFactory.SysUserAccounts.FirstOrDefaultAsync(x => x.ID == userId);
        }

        public async Task UpdateUserLastActivityDateAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);

            if (user.LastLoginTime != null)
            {
                var updateLastActivityDate = TimeSpan.FromMinutes(2);
                var currentUtc = DateTime.Now;
                var timeElapsed = currentUtc.Subtract(user.LastLoginTime.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoginTime = DateTime.Now;
            _unitOfWork.Commit();
        }

        public int GetCurrentUserId()
        {
            var claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            var userId = userDataClaim?.Value;
            return string.IsNullOrWhiteSpace(userId) ? 0 : int.Parse(userId);
        }

        public Task<SysUserAccount> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();
            return GetUserByIdAsync(userId);
        }
        public async Task<string> GetSerialNumberAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            return user.SerialNumber;
        } 
        #endregion
    }
}
