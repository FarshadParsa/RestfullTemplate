using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Response.DTOs;
using PPC.Response.Result;
using PPC.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using PPC.Base;
using Newtonsoft.Json.Linq;

namespace PPC.API.Controllers
{

    [Route("api/PPC/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class UsersController : Controller
    {

        #region Prop
        private readonly IUsersService _usersService;


        #endregion

        #region Ctor
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        #endregion


      
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UsersDTO loginUser)
        {
            try
            {

                var user = _usersService.UserVerify(loginUser?.UserName, loginUser?.Password);

                if (user == null)
                    throw new Exception("اطلاعات وارد شده صحیح نمی باشد.");

                if (user.IsActive != true || !Convert.ToBoolean(user.CanLogin))
                {
                    return Unauthorized();
                }

                var res = user.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));


            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Login User '{loginUser.UserName}' failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (Exception e)
            {
                LogManager.Error("Error Login", e);
                //throw e;// new BadRequestApiException();
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));

            }

        }

        //public async Task<IActionResult> Login([FromBody] JObject data)
        //{
        //    try
        //    {
        //        //UsersDto user = data["User"].ToObject<UsersDto>();

        //        var user = new UsersDto(); // _usersService.UserVerify(data?.Username, data?.Password);

        //        if (user == null)
        //            throw new Exception("اطلاعات وارد شده صحیح نمی باشد.");

        //        if (user.IsActive != true || !user.CanLogin)
        //        {
        //            return Unauthorized();
        //        }

        //        //var res = user.ConvertToListDto();

        //        //return Ok(ResponseFactory.OKCreator<List<UsersDto>>(res, res.Count()));
        //        return Ok(ResponseFactory.OKCreator<List<UsersDto>>());

        //    }
        //    catch (HttpResponseException)
        //    {
        //        //LogManager.Warn($"Login User '{((AuthRequest)loginUser["User"]).Username}' failed");
        //        return Ok(ResponseFactory.OKCreator<List<UsersDto>>(new List<UsersDto>(), 0));
        //    }
        //    catch (Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        //throw e;// new BadRequestApiException();
        //        return Ok(ResponseFactory.NotOKCreator<List<UsersDto>>(e));

        //    }

        //}

        [HttpGet]
        [Route("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var user = _usersService.GetUserById(Id);

            if (user == null)
                throw new NotFoundApiException();

            var res = user.ConvertToListDto();

            return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

        }

      
        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        public bool UpdateUser([FromBody] UsersDTO userDto)
        {
            try
            {
                Core.Models.Users user = _usersService.GetUserById(userDto.UserID);
                user.Username = userDto.UserName;
                user.FullName = userDto.FullName;
                user.MessageSignature = userDto.MessageSignature;
                user.CanLogin = (bool?)userDto.CanLogin;
                user.IsActive = userDto.IsActive;
                user.Description = userDto.Description;
                if (userDto.Password.Length > 0)
                    user.Password = PPC.Core.Common.SHA1.GetHashedString(userDto.Password);

                var status = _usersService.Update(user);


                return status;


            }
            catch (Exception ex)
            {
                LogManager.Error("Update failed.", ex);
                //throw new BadRequestApiException();
                return false;
            }

        }

        [IgnoreAntiforgeryToken]
        [HttpPost("[action]")]
        public bool InsertUser([FromBody] UsersDTO userDto)
        {
            try
            {
                Core.Models.Users user = new Core.Models.Users();
                user.Username = userDto.UserName;
                user.FullName = userDto.FullName;
                user.MessageSignature = userDto.MessageSignature;
                user.CanLogin = (bool?)userDto.CanLogin;
                user.IsActive = userDto.IsActive;
                user.Description = userDto.Description;
                user.Password = PPC.Core.Common.SHA1.GetHashedString(userDto.Password);

                var status = _usersService.Append(user);


                return status;


            }
            catch (Exception ex)
            {
                LogManager.Error("Update failed.", ex);
                //throw new BadRequestApiException();
                return false;
            }

        }

        [HttpGet]
        [Route("DeleteUserByID/{Id}")]
        public async Task<long> DeleteUserByID(int Id)
        {
            var user = _usersService.DeleteUser(Id);

            return user;
        }





    }
}
