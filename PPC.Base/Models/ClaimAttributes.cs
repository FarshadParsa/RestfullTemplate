using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Base.Models
{
    public static class ClaimAttributes
    {
        /// <summary>
        /// UserId
        /// </summary>
        public const string UserId = "id";

        /// <summary>
        /// IdentityServerUserId
        /// </summary>
        public const string IdentityServerUserId = "sub";

        /// <summary>
        /// SerialNumber
        /// </summary>
        public const string SerialNumber = "sub";

        /// <summary>
        /// UserName
        /// </summary>
        public const string UserName = "na";

        /// <summary>
        /// UserNickName
        /// </summary>
        public const string UserNickName = "nn";

        /// <summary>
        /// RefreshExpires
        /// </summary>
        public const string RefreshExpires = "re";

    }
}
