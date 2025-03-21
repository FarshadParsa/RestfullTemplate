using AtlasCellData.ADO;
using Microsoft.EntityFrameworkCore;
using PPC.Common;
using PPC.Common.Auth;
using PPC.Core.Common.Security;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PPC.Core.Services
{
    public class UsersService : BaseService, IUsersService
    {
        IUnitOfWork _unitOfWork;
        public UsersService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;

        }


        public List<Users> GetUsers(bool? isActive = null)
        {
            try
            {
                //if (isActive == null)
                //    return _repositoryFactory.Users.Table.ToList();
                //else if (isActive == true)
                //    return _repositoryFactory.Users.Where(x => x.IsActive).ToList();
                //else
                //    return _repositoryFactory.Users.Where(x => !x.IsActive).ToList();

                var users = _repositoryFactory.Users.Where(x => x.IsActive).ToList();

                if (isActive == null)
                    users = _repositoryFactory.Users.Table.ToList();
                else if (isActive == false)
                    users = _repositoryFactory.Users.Where(x => !x.IsActive).ToList();

                users.ForEach(x => x.Password = string.Empty);

                return users;

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Users Append(Users user)
        {

            try
            {

                var users = new Users
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    Username = user.Username,
                    Password = user.Password,
                    Last = user.Last,
                    StationID = user.StationID,
                    AuthenticationType = user.AuthenticationType,
                    Description = user.Description,
                    DomainID = user.DomainID,
                    LoginType = user.LoginType,
                    CanLogin = (bool)user.CanLogin,
                    IsEntered = user.IsEntered,
                    IsActive = user.IsActive,
                    IsAdmin = user.IsAdmin,
                    IsSysAdmin = user.IsSysAdmin,
                    IsManager = user.IsManager,
                    IsSupervisor = user.IsSupervisor,
                    IsExpert = user.IsExpert,
                    IsOperator = user.IsOperator,
                    IsSpecialUser = user.IsSpecialUser,
                    GetUrgentRequest = user.GetUrgentRequest,
                    MessageSignature = user.MessageSignature,
                    InsDate = user.InsDate,
                    InsTime = user.InsTime,
                    InsUserID = user.InsUserID,
                    EditDate = user.EditDate,
                    EditTime = user.EditTime,
                    EditUserID = user.EditUserID,
                };
                _repositoryFactory.Users.Add(users);

                var statuse = _unitOfWork.Commit() > 0;

                var _userID = GetUserByUsername(user.Username);
                _userID.Password = user.Password;
                //var encodePwd = SHA1.GetHashedString(_userID + user.Username + user.Password);
                ChangePassword(_userID, user.Password);

                if (statuse)
                    return users;
                else
                    return null;
            }
            catch
            {
                throw;
            }

        }


        public bool Update(Users user)
        {
            try
            {
                var _user = GetUserByUserId(user.UserID);

                if (_user == null) return false;

                _user.UserID = user.UserID;
                _user.FullName = user.FullName;
                _user.Username = user.Username;
                _user.Password = user.Password.Trim() == _user.Password
                    ? user.Password
                    : SHA1.GetHashedString(user.UserID + user.Username + user.Password);
                _user.Last = user.Last;
                _user.StationID = user.StationID;
                _user.AuthenticationType = user.AuthenticationType;
                _user.Description = user.Description;
                _user.DomainID = user.DomainID;
                _user.LoginType = user.LoginType;
                _user.CanLogin = (bool)user.CanLogin;
                _user.IsEntered = user.IsEntered;
                _user.IsActive = user.IsActive;
                _user.IsAdmin = user.IsAdmin;
                _user.IsSysAdmin = user.IsSysAdmin;
                _user.IsManager = user.IsManager;
                _user.IsSupervisor = user.IsSupervisor;
                _user.IsExpert = user.IsExpert;
                _user.IsOperator = user.IsOperator;
                _user.IsSpecialUser = user.IsSpecialUser;
                _user.GetUrgentRequest = user.GetUrgentRequest;
                _user.MessageSignature = user.MessageSignature;
                _user.InsDate = user.InsDate;
                _user.InsTime = user.InsTime;
                _user.InsUserID = user.InsUserID;
                _user.EditDate = user.EditDate;
                _user.EditTime = user.EditTime;
                _user.EditUserID = user.EditUserID;
                
                _repositoryFactory.Users.Update(_user);

                //if (user.Password.Trim() == string.Empty)
                //{
                //    _repositoryFactory.Users.UpdateBy(x => x.UserID == user.UserID,
                //        new Users
                //        {
                //            UserID = user.UserID,
                //            FullName = user.FullName,
                //            Username = user.Username,
                //            Last = user.Last,
                //            StationID = user.StationID,
                //            AuthenticationType = user.AuthenticationType,
                //            Description = user.Description,
                //            DomainID = user.DomainID,
                //            LoginType = user.LoginType,
                //            CanLogin = (bool)user.CanLogin,
                //            IsEntered = user.IsEntered,
                //            IsActive = user.IsActive,
                //            IsAdmin = user.IsAdmin,
                //            IsSysAdmin = user.IsSysAdmin,
                //            IsManager = user.IsManager,
                //            IsSupervisor = user.IsSupervisor,
                //            IsExpert = user.IsExpert,
                //            IsOperator = user.IsOperator,
                //            IsSpecialUser = user.IsSpecialUser,
                //            GetUrgentRequest = user.GetUrgentRequest,
                //            MessageSignature = user.MessageSignature,
                //            InsDate = user.InsDate,
                //            InsTime = user.InsTime,
                //            InsUserID = user.InsUserID,
                //            EditDate = user.EditDate,
                //            EditTime = user.EditTime,
                //            EditUserID = user.EditUserID,
                //        });
                //}
                //else
                //{
                //    var encodePwd = SHA1.GetHashedString(user.UserID + user.Username + user.Password);

                //    _repositoryFactory.Users.UpdateBy(x => x.UserID == user.UserID,
                //        new Users
                //        {
                //            UserID = user.UserID,
                //            FullName = user.FullName,
                //            Username = user.Username,
                //            Password = encodePwd,//user.Password,
                //            Last = user.Last,
                //            StationID = user.StationID,
                //            AuthenticationType = user.AuthenticationType,
                //            Description = user.Description,
                //            DomainID = user.DomainID,
                //            LoginType = user.LoginType,
                //            CanLogin = (bool)user.CanLogin,
                //            IsEntered = user.IsEntered,
                //            IsActive = user.IsActive,
                //            IsAdmin = user.IsAdmin,
                //            IsSysAdmin = user.IsSysAdmin,
                //            IsManager = user.IsManager,
                //            IsSupervisor = user.IsSupervisor,
                //            IsExpert = user.IsExpert,
                //            IsOperator = user.IsOperator,
                //            IsSpecialUser = user.IsSpecialUser,
                //            GetUrgentRequest = user.GetUrgentRequest,
                //            MessageSignature = user.MessageSignature,
                //            InsDate = user.InsDate,
                //            InsTime = user.InsTime,
                //            InsUserID = user.InsUserID,
                //            EditDate = user.EditDate,
                //            EditTime = user.EditTime,
                //            EditUserID = user.EditUserID,
                //        });

                //}

                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long DeleteUser(int userId)
        {
            try
            {
                var user = _repositoryFactory.Users.FirstOrDefault(x => x.UserID == userId);

                if (user == null)
                    throw new System.Exception("User Not found.");

                _repositoryFactory.Users.Delete(user);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public Users GetUserByUserId(int userId)
        {
            try
            {
                var user = _repositoryFactory.Users.FirstOrDefault(x => x.UserID == userId);

                //if (user != null)
                //    user.Password = string.Empty;
                return user;
            }
            catch
            {
                throw;
            }
        }

        public Users GetUserByUsername(string username)
        {
            try
            {
                var user = _repositoryFactory.Users.FirstOrDefault(x => x.Username.ToUpper() == username.ToUpper());

                //if (user != null)
                //    user.Password = string.Empty;

                return user;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Users> GetUserByUsernameAsync(string username)
        {
            try
            {
                var user = await _repositoryFactory.Users.FirstOrDefaultAsync(x => x.Username.ToUpper() == username.ToUpper());

                //if (user != null)
                //    user.Password = string.Empty;

                return user;
            }
            catch
            {
                throw;
            }
        }



        public async Task<Users> FindUserAsync(string username)
        {
            try
            {
                var user = await _repositoryFactory.Users.FirstOrDefaultAsync(x => x.Username.ToUpper() == username.ToUpper());

                //if (user != null)
                //    user.Password = string.Empty;

                return user;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<Users> FindUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentUserId()
        {
            throw new NotImplementedException();
        }
        public async Task<Users> GetUserByUserIdAsync(int userId)
        {
            try
            {
                var user = await _repositoryFactory.Users.FirstOrDefaultAsync(x => x.UserID == userId);

                //if (user != null)
                //    user.Password = string.Empty;
                return user;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }


        #region Public Method
        public Users UserVerify(string userName, string password)
        {
            var user = _repositoryFactory.Users.FirstOrDefault(x => x.Username == userName);

            if (user == null)
                return null;

            var encodePwd = SHA1.GetHashedString(user.UserID + user.Username + password);


            if (user.Password == encodePwd && user.IsActive && Convert.ToBoolean(user.CanLogin))
            {
                return user;
            }

            return null;
        }

        public bool PasswordVerify(int userID, string password)
        {
            var encodePwd = SHA1.GetHashedString(password);
            var user = _repositoryFactory.Users.FirstOrDefault(x => x.UserID == userID &&
            x.Password == encodePwd);

            if (user == null)
            {
                return false;
            }
            return true;
        }
        public bool PasswordVerify(Users user, string password)
        {
            return PasswordVerify(user.UserID, password);
        }

        public bool ChangePassword(Users user, string newPassword)
        {
            try
            {

                var encodePwd = SHA1.GetHashedString(user.UserID + user.Username + newPassword);

                _repositoryFactory.Users.UpdateBy(x => x.UserID == user.UserID,
                    new Users
                    {
                        UserID = user.UserID,
                        FullName = user.FullName,
                        Username = user.Username,
                        Password = encodePwd,//user.Password,
                        Last = user.Last,
                        StationID = user.StationID,
                        AuthenticationType = user.AuthenticationType,
                        Description = user.Description,
                        DomainID = user.DomainID,
                        LoginType = user.LoginType,
                        CanLogin = (bool)user.CanLogin,
                        IsEntered = user.IsEntered,
                        IsActive = user.IsActive,
                        IsAdmin = user.IsAdmin,
                        IsSysAdmin = user.IsSysAdmin,
                        IsManager = user.IsManager,
                        IsSupervisor = user.IsSupervisor,
                        IsExpert = user.IsExpert,
                        IsOperator = user.IsOperator,
                        IsSpecialUser = user.IsSpecialUser,
                        GetUrgentRequest = user.GetUrgentRequest,
                        MessageSignature = user.MessageSignature,
                        InsDate = user.InsDate,
                        InsTime = user.InsTime,
                        InsUserID = user.InsUserID,
                        EditDate = user.EditDate,
                        EditTime = user.EditTime,
                        EditUserID = user.EditUserID,

                    });


                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ExistUser(string userName)
        {
            try
            {
                return await _repositoryFactory.Users.FirstOrDefaultAsync(x => x.Username.ToUpper() == userName.ToUpper()) != null;
            }
            catch
            {

                throw;
            }
        }



        public async Task<long> LoginAsync(LoginLogs loginLog, long? preLoginId)
        {

            //var user = GetUserByUserId(userId);
            var preLogin = preLoginId == null
                ? null
                : await _repositoryFactory.LoginLogs.FirstOrDefaultAsync(x => x.LoginLogID == (Convert.ToInt32(preLoginId)));

            //using (var transaction = _unitOfWork.StartTransaction())
            {
                try
                {
                    LoginLogs loginLogs = new LoginLogs
                    {
                        UserID = loginLog.UserID,
                        StationID = loginLog.StationID,
                        LoginDate = General.CurrentDateString,
                        LoginTime = General.CurrentTimeString,
                        IPAddresses = loginLog.IPAddresses,
                        LogoutDate = "____/__/__",
                        LogoutTime = "__:__",
                        MachineName = loginLog.MachineName,
                        SystemUserName = loginLog.SystemUserName,
                        Version = loginLog.Version,
                    };

                    _repositoryFactory.LoginLogs.Add(loginLogs);
                    if (preLogin != null)
                    {
                        _repositoryFactory.LoginLogs.UpdateBy(x => x.LoginLogID == preLoginId,
                        new LoginLogs
                        {
                            LoginLogID = preLogin.LoginLogID,
                            UserID = preLogin.UserID,
                            StationID = preLogin.StationID,
                            LoginDate = preLogin.LoginDate,
                            LoginTime = preLogin.LoginTime,
                            IPAddresses = preLogin.IPAddresses,
                            LogoutDate = General.CurrentDateString,
                            LogoutTime = General.CurrentTimeString,
                            MachineName = preLogin.MachineName,
                            SystemUserName = preLogin.SystemUserName,
                            Version = preLogin.Version,
                        });
                    }
                    //var preLog

                    var statuse = _unitOfWork.Commit() > 0;
                    if (statuse)
                        return loginLogs.LoginLogID;
                    //transaction.Commit();
                }
                catch
                {
                    //transaction.Rollback();
                    throw;
                }
            }

            return -5;
            //throw new NotImplementedException();
        }


        public async Task<bool> LogoutAsync(long loginId)
        {
            try
            {

                LoginLogs loginLog = await _repositoryFactory.LoginLogs.FirstOrDefaultAsync(x => x.LoginLogID == loginId);

                loginLog.LogoutDate = General.CurrentDateString;
                loginLog.LogoutTime = General.CurrentTimeString;

                var statuse = _unitOfWork.Commit() > 0;

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> HasUserAccessToStation(int userId, int stationId)
        {
            try
            {
                bool statuse = false;

                var db = _repositoryFactory;
                var q = await (from users in db.Users.Table
                               join userGroupAssigns in db.UserGroupAssigns.Table on users.UserID equals userGroupAssigns.UserID
                               join userGroups in db.UserGroups.Table on userGroupAssigns.UserGroupID equals userGroups.UserGroupID
                               join userGroupStations in db.UserGroupStations.Table on userGroups.UserGroupID equals userGroupStations.UserGroupID
                               join stations in db.Stations.Table on userGroupStations.StationID equals stations.StationID
                               where users.UserID == userId && stations.StationID == stationId
                               select users.UserID
                         ).CountAsync();


                statuse = q > 0;
                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long UserSingnIn(int userId)
        {
            try
            {
                var _user = GetUserByUserId(userId);
                _user.IsEntered = true;

                //_repositoryFactory.Users.UpdateBy(x => x.UserID == _user.UserID,
                //        new Users
                //        {
                //            UserID = _user.UserID,
                //            FullName = _user.FullName,
                //            Username = _user.Username,
                //            Password = _user.Password,
                //            Last = _user.Last,
                //            StationID = _user.StationID,
                //            AuthenticationType = _user.AuthenticationType,
                //            Description = _user.Description,
                //            DomainID = _user.DomainID,
                //            LoginType = _user.LoginType,
                //            CanLogin = (bool)_user.CanLogin,
                //            IsEntered = _user.IsEntered,
                //            IsActive = _user.IsActive,
                //            IsAdmin = _user.IsAdmin,
                //            IsSysAdmin = _user.IsSysAdmin,
                //            IsManager = _user.IsManager,
                //            IsSupervisor = _user.IsSupervisor,
                //            IsExpert = _user.IsExpert,
                //            IsOperator = _user.IsOperator,
                //            IsSpecialUser = _user.IsSpecialUser,
                //            GetUrgentRequest = _user.GetUrgentRequest,
                //            MessageSignature = _user.MessageSignature,
                //            InsDate = _user.InsDate,
                //            InsTime = _user.InsTime,
                //            InsUserID = _user.InsUserID,
                //            EditDate =  _user.EditDate,
                //            EditTime = _user.EditTime,
                //            EditUserID = _user.EditUserID,
                //        });

                _repositoryFactory.Users.Update(_user);
                var statuse = _unitOfWork.Commit();
                return statuse;
            }
            catch
            {
                throw;
            }
        }

        public long UserSingnOut(int userId)
        {
            try
            {
                var _user = GetUserByUserId(userId);
                _user.IsEntered = false;
                _repositoryFactory.Users.Update(_user);
                var statuse = _unitOfWork.Commit();
                return statuse;
            }
            catch
            {
                throw;
            }
        }


        #endregion
    }
}
