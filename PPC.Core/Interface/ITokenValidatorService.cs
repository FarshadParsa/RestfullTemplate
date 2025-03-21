using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITokenValidatorService
    {
        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task ValidateAsync(TokenValidatedContext context);
    }
}
