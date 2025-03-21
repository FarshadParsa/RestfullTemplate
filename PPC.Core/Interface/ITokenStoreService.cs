using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITokenStoreService
    {
        /// <summary>
        /// Add User Token Async
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        Task AddUserTokenAsync(SysUserToken userToken);

        /// <summary>
        /// Add User Token Async
        /// </summary>
        /// <param name="user"></param>
        /// <param name="refreshTokenSerial"></param>
        /// <param name="accessToken"></param>
        /// <param name="refreshTokenSourceSerial"></param>
        /// <returns></returns>
        Task AddUserTokenAsync(SysUserAccount user, string refreshTokenSerial, string accessToken, string refreshTokenSourceSerial);

        /// <summary>
        /// Is Valid Token Async
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsValidTokenAsync(string accessToken, int userId);

        /// <summary>
        /// Delete Expired Tokens Async
        /// </summary>
        /// <returns></returns>
        Task DeleteExpiredTokensAsync();

        /// <summary>
        /// Find Token Async
        /// </summary>
        /// <param name="refreshTokenValue"></param>
        /// <returns></returns>
        Task<SysUserToken> FindTokenAsync(string refreshTokenValue);

        /// <summary>
        /// VDelete Token Async
        /// </summary>
        /// <param name="refreshTokenValue"></param>
        /// <returns></returns>
        Task DeleteTokenAsync(string refreshTokenValue);

        /// <summary>
        /// Delete Tokens With Same Refresh TokenSourceAsync
        /// </summary>
        /// <param name="refreshTokenIdHashSource"></param>
        /// <returns></returns>
        Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource);

        /// <summary>
        /// Invalidate User Tokens Async
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task InvalidateUserTokensAsync(int userId);

        /// <summary>
        /// Revoke User Bearer Tokens Async
        /// </summary>
        /// <param name="userIdValue"></param>
        /// <param name="refreshTokenValue"></param>
        /// <returns></returns>
        Task RevokeUserBearerTokensAsync(string userIdValue, string refreshTokenValue);

    }
}
