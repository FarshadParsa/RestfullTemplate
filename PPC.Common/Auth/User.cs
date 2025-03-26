using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WebApi.Base.Extensions;
using WebApi.Base.Models;

namespace WebApi.Common.Auth
{
    /// <summary>
    /// User
    /// </summary>
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id
        {
            get
            {
                var id = _accessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
                if (id != null && id.Value.IsNotNull())
                {
                    return id.Value;
                }
                return "0";
            }
        }

        /// <summary>
        /// NickName
        /// </summary>
        public string NickName
        {
            get
            {
                var name = _accessor?.HttpContext?.User?.FindFirst(ClaimAttributes.UserNickName);

                if (NickName != null && NickName.IsNotNull())
                {
                    return name.Value;
                }

                return "";
            }
        }

        /// <summary>
        /// Username
        /// </summary>
        public string Username
        {
            get
            {
                var name = _accessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name);

                if (Username != null && Username.IsNotNull())
                {
                    return name.Value;
                }

                return "";
            }
        }

        /// <summary>
        /// SerialNumber
        /// </summary>
        public virtual string SerialNumber
        {
            get
            {
                var tenantId = _accessor?.HttpContext?.User?.FindFirst(ClaimTypes.SerialNumber);
                if (tenantId != null && tenantId.Value.IsNotNull())
                {
                    return SerialNumber;
                }
                return "0";
            }
        }
    }
}
