using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Common
{
    public class JwtConfigOptions
    {
        public string Key { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public int ATExpires { set; get; }
        public int RTExpires { set; get; }
        public bool AllowMultipleLoginsFromTheSameUser { set; get; }
        public bool AllowSignoutAllUserActiveClients { set; get; }
    }
}
