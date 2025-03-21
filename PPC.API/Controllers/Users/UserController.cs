using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Response.Result;
using System.Collections.Generic;
using System;
using PPC.Response.DTOs;
using System.Threading.Tasks;
using PPC.Core.Extensions;
using System.Linq;
using System.Web;
using PPC.Core.Common.Security;
using PPC.Exception;
using PPC.Core.Models;
using AtlasCellData.ADO;
using PPC.Base;
using PPC.Common.Auth;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace PPC.API.Controllers
{
    [IgnoreAntiforgeryToken]
    public class UserController : Controller
    {

        #region Prop

        private readonly IUsersService _usersService;


        #endregion


        #region Ctor

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        #endregion

        //[HttpGet] 
        //[Route("ctc")]
        //  public string ctc(Users user)
        //{
        //    //DisplayNameAttribute
        //    SettingGeneral settingGeneral = new SettingGeneral();
        //    var q = settingGeneral.SystemVersion;
        //    return q;

        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetActiveUsers")]
        public async Task<IActionResult> GetActiveUsers()
        {

            try
            {

                List<PPC.Core.Models.Users> users = _usersService.GetUsers(true);

                var res = users.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users List failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }

        }


        [HttpGet]
        [Route("GetInactiveUsers")]
        public async Task<IActionResult> GetInactiveUsers()
        {

            try
            {

                List<PPC.Core.Models.Users> users = _usersService.GetUsers(false);

                var res = users.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users List failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {

            try
            {

                List<PPC.Core.Models.Users> users = _usersService.GetUsers();

                var res = users.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users List failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }

        }


        [HttpGet]
        [Route("login/ValidateLogin/{userName}/{password}/{stationID}")]
        public async Task<IActionResult> ValidateLogin(string userName, string password, string stationID)
        {

            try
            {
                //HandledException hex = new HandledException();
                System.Exception hex = new System.Exception();
                hex = null;
                UserSecurity userSecurity = new UserSecurity();
                Core.Models.Users users = userSecurity.ValidateLogin(userName, password, stationID, out hex);

                //List<PPC.Core.Models.Users> users = _usersService.();

                var res = users?.ConvertToListDto();
                if (res == null)
                    if (hex?.Message.Length > 0)
                        throw hex;
                    else
                        throw new System.Exception("اطلاعات کاربری وارد شده صحیح نمی باشد!");

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users List failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }


            return null;
        }


        [HttpGet]
        [Route("login/ChangePassword/{userName}/{password}/{newPassword}")]
        public async Task<IActionResult> ChangePassword(string userName, string password, string newPassword)
        {

            try
            {

                if (password.Trim().Length.Equals(0) || newPassword.Trim().Length.Equals(0))
                    throw new System.Exception("اطلاعات وارد شده صحیح نمی باشد.");

                if (password == newPassword)
                    throw new System.Exception("کلمه عبور قدیم و جدید نمیتواند یکسان باشد.");

                //HandledException hex = new HandledException();
                System.Exception hex = new System.Exception();
                UserSecurity userSecurity = new UserSecurity();
                if (!userSecurity.ValidatePassword(userName, password, out hex))
                    throw hex;

                var user = _usersService.GetUserByUsername(userName);
                if (user == null)
                    throw new System.Exception("اطلاعات وارد شده صحیح نمی باشد.");

                //var encodePwd = SHA1.GetHashedString(user.UserID + user.Username + password);

                //if (!_usersService.PasswordVerify(user, encodePwd))
                //    throw new System.Exception("اطلاعات کاربری وارد شده صحیح نمی باشد.");

                //var encodeNewPwd = SHA1.GetHashedString(user.UserID + user.Username + newPassword);

                var result = _usersService.ChangePassword(user, newPassword);
                if (result)
                {
                    var res = new List<string>() { "تغییر رمز عبور با موفقیت انجام شد" };
                    return Ok(ResponseFactory.OKCreator<List<string>>(res, res.Count()));
                }
                else
                {
                    throw new System.Exception("عملیات تغییر رمز عبور با شکست مواجه شد.");

                    var res = new List<string>() { "عملیات تغییر رمز عبور با شکست مواجه شد." };
                    return Ok(ResponseFactory.OKCreator<List<string>>(res, res.Count()));
                }

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"change password failed");
                return Ok(ResponseFactory.OKCreator<List<string>>(new List<string>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<string>>(e));
            }


            return null;
        }

        [HttpGet]
        //[Route("Users/ExistUser/{userName}")]
        [Route("[Controller]/[Action]/{userName}")]
        public async Task<IActionResult> ExistUser(string userName)
        {

            try
            {
                var result = _usersService.ExistUser(userName);

                //List<PPC.Core.Models.Users> users = _usersService.();

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }


            return null;
        }

        [HttpGet]
        [Route("[Controller]/[Action]/{userName}")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {

            try
            {
                var result =await _usersService.GetUserByUsernameAsync(userName);

                var res =  result.ConvertToListDto() ;

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }


            return null;
        }

        [HttpGet]
        [Route("[Controller]/[Action]/{userId}")]
        public async Task<IActionResult> GetUserByUserId(int userId)
        {

            try
            {

                PPC.Core.Models.Users result = await _usersService.GetUserByUserIdAsync(userId);

                var res =result.ConvertToListDto() ;// new List<Users> { await result };

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Users failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }


            return null;
        }

        //[HttpPost]
        //[Route("Users/Append")]
        //public async Task<IActionResult> Append()
        //{

        //    try
        //    {

        //        bool result = false;//  _usersService.Append(user);

        //        var res = new List<bool> { result };

        //        return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"User append failed");
        //        return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }

        //}

        //[HttpPost]
        //[Route("Users/Append")]
        //public IActionResult Append([FromBody] UsersDTO users)
        //{
        //    try
        //    {
        //        Users user = new Users();
        //        var mapper = Functions.CreateMapper<UsersDTO, Users>();
        //        user = mapper(users);

        //        bool result = _usersService.Append(user);

        //        var res = new List<bool> { result };

        //        return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"User append failed");
        //        return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ...", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }
        //}


        [HttpPost]
        //[Route("[Controller]/[Action]/")]
        public IActionResult Append([FromBody] Users user)
        {
            try
            {

                Users result = _usersService.Append(user);

                var res = result.ConvertToListDto();// new List<Users> { await result };

                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(res, res.Count()));

                //return Ok(ResponseFactory.OKCreator<List<Users>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"User append failed");
                return Ok(ResponseFactory.OKCreator<List<UsersDTO>>(new List<UsersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ...", e);
                return Ok(ResponseFactory.NotOKCreator<List<UsersDTO>>(e));
            }
        }


        [HttpPost]
        //[Route("Users/Update")]
        public IActionResult Update([FromBody] Users user)
        {
            try
            {
                //Users user = new Users();
                //var mapper = Functions.CreateMapper<UsersDTO, Users>();
                //user = mapper(users);


                bool result = _usersService.Update(user);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"User update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ...", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {

                long result = _usersService.DeleteUser(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"User delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ...", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        //[HttpPost("[Controller]/[Action]/{preLoginId}")]
        //public async Task<IActionResult> Login([FromBody] LoginLogs loginLogs, int preLoginId)
        //{
        //    try
        //    {

        //        long result = await _usersService.LoginAsync(loginLogs, preLoginId);

        //        var res = new List<long> { result };

        //        return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException e)
        //    {
        //        LogManager.Warn($"login log failed");
        //        return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ...", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
        //    }
        //}


        //[HttpGet("[Controller]/[Action]/{loginId}")]
        //public async Task<IActionResult> Logout(long loginId)
        //{
        //    try
        //    {

        //        bool result = await _usersService.LogoutAsync(loginId);

        //        var res = new List<bool> { result };

        //        return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException e)
        //    {
        //        LogManager.Warn($"login log failed");
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ...", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }
        //}


        [HttpGet("[Controller]/[Action]/{userId}/{stationId}")]
        public async Task<IActionResult> UserAccessToStation(int userId, int stationId)
        {
            try
            {

                bool result = await _usersService.HasUserAccessToStation(userId, stationId);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException e)
            {
                LogManager.Warn($"login log failed");
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ...", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpGet]
        public IActionResult SingnIn(int id)
        {
            try
            {
                long result = _usersService.UserSingnIn(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"User sign in failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ...", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public IActionResult SingnOut(int id)
        {
            try
            {
                long result = _usersService.UserSingnOut(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"User sign out failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ...", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }




    }
}
