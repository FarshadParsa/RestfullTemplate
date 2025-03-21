using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PPC.Core.Common.Security
{
    public class SHA1
    {
        /// <summary>
        /// GetHashedString
        /// </summary>
        /// <param name="_PW"></param>
        /// <returns></returns>
        public static string GetHashedString(string _PW)
        {
            string _HashedPW = "";
            SHA512 sha = new SHA512CryptoServiceProvider();
            byte[] result;
            StringBuilder strBuilder = new StringBuilder();


            sha.ComputeHash(Encoding.ASCII.GetBytes(_PW));
            result = sha.Hash;

            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            _HashedPW = strBuilder.ToString();
            return _HashedPW;
        }

    }

}
