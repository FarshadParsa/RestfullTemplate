using WebApi.Core.Models;
using WebApi.Core.Models.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{
    public interface ITokenFactoryService
    {
        /// <summary>
        /// Create Jwt Tokens Async
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<JwtTokensData> CreateJwtTokensAsync(SysUserAccount user);


        /// <summary>
        /// Get Refresh Token Serial
        /// </summary>
        /// <param name="refreshTokenValue"></param>
        /// <returns></returns>
        string GetRefreshTokenSerial(string refreshTokenValue);
    }
}
