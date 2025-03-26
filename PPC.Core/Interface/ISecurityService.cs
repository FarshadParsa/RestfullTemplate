using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Interface
{
    public interface ISecurityService
    {
        /// <summary>
        /// Get Sha256Hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string GetSha256Hash(string input);

        /// <summary>
        /// Create Cryptographically SecureGuid
        /// </summary>
        /// <returns></returns>
        Guid CreateCryptographicallySecureGuid();
    }
}
