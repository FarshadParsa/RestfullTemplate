using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base;
using WebApi.Base.Models.Exceptions;
using WebApi.Common.Auth;
using WebApi.Core.Common;
using WebApi.Core.Extensions;
using WebApi.Core.Interface;
using WebApi.Core.Log;
using WebApi.Response.DTOs;
using WebApi.Response.Result;
using WebApi.Base.Extensions;

namespace WebApi.API.Controllers
{
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class UserAccountController : Controller
    {
        #region Properties
        private readonly IUserAccountService _usersService;
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IAntiForgeryCookieService _antiforgery;
        private readonly ITokenFactoryService _tokenFactoryService;
        private readonly IUser _user;
        #endregion

        #region ctor


        public UserAccountController(
            IUserAccountService usersService,
            ITokenStoreService tokenStoreService,
            ITokenFactoryService tokenFactoryService,
             IAntiForgeryCookieService antiforgery,
            IUser user)
        {
            _user = user;

            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentIsNull(nameof(tokenStoreService));


            _antiforgery = antiforgery;
            _antiforgery.CheckArgumentIsNull(nameof(antiforgery));

            _tokenFactoryService = tokenFactoryService;
            _tokenFactoryService.CheckArgumentIsNull(nameof(tokenFactoryService));
        } 
        #endregion

        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] AuthRequest loginUser)
        {
            try
            {

                if (loginUser == null)
                {
                    throw new NotFoundApiException();
                }

                var user = await _usersService.FindUserAsync(loginUser.Username, loginUser.Password);

                if (user == null)
                    throw new NotFoundApiException();

                if (user.IsActive != true)
                {
                    return Unauthorized();
                }


                var result = await _tokenFactoryService.CreateJwtTokensAsync(user);
                await _tokenStoreService.AddUserTokenAsync(user, result.RefreshTokenSerial, result.AccessToken, null);

                _antiforgery.RegenerateAntiForgeryCookies(result.Claims);

                 var res = result.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator<List<TokenDto>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Requested Token with User '{loginUser.Username}' and password '{loginUser.Password}' was not found");
                return Ok(ResponseFactory.OKCreator<List<TokenDto>>(new List<TokenDto>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Requested Token", e);
                throw new BadRequestApiException();
            }


        }


        [HttpGet("[action]")]
        public bool IsLogged()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet("[action]")]
        public IActionResult HowAmI()
        {
            try
            {
                var user =  _usersService.GetUserById(_user.Id.ToIntZero());
                if (user == null)
                    throw new NotFoundApiException();

                var res = user.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator<List<SysUserDto>>(res, res.Count()));


            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"HowAmI was not found");
                return Ok(ResponseFactory.OKCreator<List<SysUserDto>>(new List<SysUserDto>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Requested HowAmI", e);
                throw new BadRequestApiException();
            }
        }

        /*
         * RefreshToken
         *
         *
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody] Token model)
        {
            try
            {
                var refreshTokenValue = model.RefreshToken;
                if (string.IsNullOrWhiteSpace(refreshTokenValue))
                {
                    return BadRequest("refreshToken is not set.");
                }

                var token = await _tokenStoreService.FindTokenAsync(refreshTokenValue);
                if (token == null)
                {
                    return Unauthorized();
                }

                var result = await _tokenFactoryService.CreateJwtTokensAsync(token.User);
                await _tokenStoreService.AddUserTokenAsync(token.User, result.RefreshTokenSerial, result.AccessToken, _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue));
                _antiforgery.RegenerateAntiForgeryCookies(result.Claims);


                var res = result.ConvertToListDto();
                return Ok(ResponseFactory.Creator<List<TokenDto>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Requested RefreshToken was not found");
                return Ok(ResponseFactory.Creator<List<TokenDto>>(new List<TokenDto>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Requested Token", e);
                throw new BadRequestApiException();
            }
        }


         */

        //[AllowAnonymous]
        //[HttpGet("[action]")]
        //public async Task<bool> Logout(string refreshToken)
        //{
        //    var claimsIdentity = this.User.Identity as ClaimsIdentity;
        //    var userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;

        //    // The Jwt implementation does not support "revoke OAuth token" (logout) by design.
        //    // Delete the user's tokens from the database (revoke its bearer token)
        //    await _tokenStoreService.RevokeUserBearerTokensAsync(userIdValue, refreshToken);

        //    _antiforgery.DeleteAntiForgeryCookies();

        //    return true;
        //}
    }
}
