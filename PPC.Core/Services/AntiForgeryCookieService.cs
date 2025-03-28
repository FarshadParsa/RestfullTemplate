﻿using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using WebApi.Core.Common;
using WebApi.Core.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebApi.Core.Services
{
    public class AntiForgeryCookieService : IAntiForgeryCookieService
    {
        #region Properties
        private const string XsrfTokenKey = "XSRF-TOKEN";

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAntiforgery _antiforgery;
        private readonly IOptions<AntiforgeryOptions> _antiforgeryOptions;
        #endregion

        #region ctor
        public AntiForgeryCookieService(
            IHttpContextAccessor contextAccessor,
            IAntiforgery antiforgery,
            IOptions<AntiforgeryOptions> antiforgeryOptions)
        {
            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(contextAccessor));

            _antiforgery = antiforgery;
            _antiforgery.CheckArgumentIsNull(nameof(antiforgery));

            _antiforgeryOptions = antiforgeryOptions;
            _antiforgeryOptions.CheckArgumentIsNull(nameof(antiforgeryOptions));
        }
        #endregion

        #region Public method
        public void RegenerateAntiForgeryCookies(IEnumerable<Claim> claims)
        {
            var httpContext = _contextAccessor.HttpContext;
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme));
            var tokens = _antiforgery.GetAndStoreTokens(httpContext);
            httpContext.Response.Cookies.Append(
                  key: XsrfTokenKey,
                  value: tokens.RequestToken,
                  options: new CookieOptions
                  {
                      HttpOnly = false // Now JavaScript is able to read the cookie
                  });
        }

        public void DeleteAntiForgeryCookies()
        {
            var cookies = _contextAccessor.HttpContext.Response.Cookies;
            cookies.Delete(_antiforgeryOptions.Value.Cookie.Name);
            cookies.Delete(XsrfTokenKey);
        } 
        #endregion
    }
}
