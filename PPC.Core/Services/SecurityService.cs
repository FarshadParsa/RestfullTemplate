﻿using WebApi.Core.Interface;
using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Core.Services
{
    public class SecurityService : ISecurityService
    {
        #region Properties
        private readonly RandomNumberGenerator _rand = RandomNumberGenerator.Create();
        #endregion

        #region Public Method

        public string GetSha256Hash(string input)
        {
            using var hashAlgorithm = new SHA256CryptoServiceProvider();
            var byteValue = Encoding.UTF8.GetBytes(input);
            var byteHash = hashAlgorithm.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }

        public Guid CreateCryptographicallySecureGuid()
        {
            var bytes = new byte[16];
            _rand.GetBytes(bytes);
            return new Guid(bytes);

        }
        #endregion
    }
}
