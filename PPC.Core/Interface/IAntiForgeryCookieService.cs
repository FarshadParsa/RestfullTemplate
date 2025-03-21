using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PPC.Core.Interface
{
    public interface IAntiForgeryCookieService
    {
        /// <summary>
        /// Regenerate AntiForgery Cookies
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        void RegenerateAntiForgeryCookies(IEnumerable<Claim> claims);

        /// <summary>
        /// Delete AntiForgery Cookies
        /// </summary>
        /// <returns></returns>
        void DeleteAntiForgeryCookies();
    }
}
