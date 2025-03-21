using PPC.Core.Models;
using PPC.Core.Models.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
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
