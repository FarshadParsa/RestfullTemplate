using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtlasCellData.ADO;
using WebApi.Base;
using WebApi.Common.Auth;
using WebApi.Core.Models;
using WebApi.Exception;

namespace WebApi.Core.Common.Security
{
    public class UserSecurity
    {
        public UserSecurity()
        {
        }
        private UserDL user;
        private StationsDL station;

        public Users ValidateLogin(string userName, string userPassword, string stationID, out System.Exception ex)
        {
            bool result = true;
            ex = new System.Exception();
            user = new UserDL();
            user.UserName = userName;

            if (!user.getInfo("UserName"))
            {
                ex = new System.Exception("اطلاعات وارد شده اشتباه است.");
                //return false;
                result = false;
            }

            if(!ValidatePassword(userName, userPassword, out ex))
            //if (user.Password != SHA1.GetHashedString(user.UserID+ user.UserName+userPassword))
            {
                ex = new System.Exception("اطلاعات وارد شده اشتباه است.");
                //return false;
                result = false;
            }

            //station = new StationsDL(Convert.ToInt32(stationID));
            //station.getInfo();

            //if (Users.UserID != 0)//administrator
            if (result && !user.IsSysAdmin)//administrator
            {
                if (!user.CanLogin)
                {
                    ex = new System.Exception("شما نمی توانید وارد سیستم شوید.");
                    //return false;
                    result = false;
                }
                if (user.IsEntered)
                {
                    //ex = new HandledException("شما قبلا وارد سیستم شده اید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    //return false;
                }
                if (!user.IsActive)
                {
                    ex = new System.Exception("نام کاربری شما غیر فعال شده است. با مدیر سیستم تماس بگیرید.");
                    //return false;
                    result = false;
                }
                //// check if user can login on station
                
                if (!UserDL.hasUserAccessToStation(user.UserID, stationID))
                {
                    ex = new System.Exception("شما نمی توانید در این ایستگاه وارد سیستم شوید.");
                    //return false;
                    result = false;
                }

            }

            if(result)
            {


                List<Users> _user = new List<Users>();
                var mapper =  Functions.CreateMapper<UserDL, Users>();
                _user.Add(mapper(user));
                return _user[0];
            }
            else
            {
                return null;
                //throw ex;
            }
            ///
            //return true;
        }

        public bool ValidatePassword(string userName, string userPassword, out System.Exception ex)
        {
            bool result = true;
            ex = new System.Exception();
            user = new UserDL
            {
                UserName = userName
            };

            if (!user.getInfo("UserName"))
            {
                ex = new System.Exception("اطلاعات وارد شده اشتباه است.");
                result = false;
            }

            if (user.Password != SHA1.GetHashedString(user.UserID + user.UserName + userPassword))
            {
                ex = new System.Exception("اطلاعات وارد شده اشتباه است.");
                result = false;
            }

            return result;
        }

        //public bool ValidateLogin(out HandledException ex)
        //{
        //    ex = new HandledException();
        //    UserDL _user = new UserDL();
        //    _user.UserName = Users.UserName;
        //    if (!_user.getInfo("UserName"))
        //    {
        //        ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //        return false;
        //    }



        //    if (_user.Password != SHA1.GetHashedString(_user.UserID + _user.UserName + Password))
        //    {
        //        ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا");
        //        return false;
        //    }


        //    //if (Users.UserID != 0)//administrator
        //    if (!Users.IsSysAdmin)//administrator
        //    {
        //        if (!_user.CanLogin)
        //        {
        //            ex = new HandledException("شما نمی توانید وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //            return false;
        //        }
        //        if (_user.IsEntered)
        //        {
        //            //ex = new HandledException("شما قبلا وارد سیستم شده اید.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //            //return false;
        //        }
        //        if (!Users.IsActive)
        //        {
        //            ex = new HandledException("نام کاربری شما غیر فعال شده است. با مدیر سیستم تماس بگیرید.", "خطا");
        //            return false;
        //        }
        //        //// check if user can login on station
        //        if (!UserDL.hasUserAccessToStation(Users.UserID, Stations.StationID))
        //        {
        //            ex = new HandledException("شما نمی توانید در این ایستگاه وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //            return false;
        //        }
        //    }
        //    ///
        //    return true;
        //}


        public bool Login()
        {
            Transaction tr = new Transaction();
            tr.StartTransaction();
            try
            {
                //HandledException ex = new HandledException();
                //if (!ValidateLogin(out ex))
                //{
                //    throw ex;
                //    //return false;
                //}
                user.IsEntered = true;
                user.transaction = tr;
                user.update_OLD();
                LoginLogsDL log = new LoginLogsDL();
                int MaxID = 0;
                try
                {
                    MaxID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "LoginLogsID", "", tr);
                }
                catch (System.Exception ex) { }
                MaxID++;
                log.transaction = tr;
                log.LoginLogsID = MaxID;
                log.LoginDate = WebApi.Common.General.CurrentDateString;// PrintingCommon.General.CurrentDateOfServer;
                log.LoginTime = WebApi.Common.General.CurrentTimeString;
                log.LogoutDate = "____/__/__";
                log.LogoutTime = "__:__";
                log.StationID = station.StationID;
                log.User_UserID = user;
                log.Version = "";
                log.append_SQL();
                tr.Commit();
                return true;

            }
            catch (System.Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        public void Logout()
        {
            Transaction tr = new Transaction();
            tr.StartTransaction();
            try
            {
                user.transaction = tr;
                user.getInfo();
                user.IsEntered = false;
                user.update_OLD();

                string where = string.Format("UserID='{0}' and StationID='{1}'", user.UserID.ToString(), station.StationID.ToString());
                int rowID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "RowID", where, tr);

                LoginLogsDL[] logID = LoginLogsDL.getInstances("RowID=" + rowID);
                if (logID.Length != 0)
                {
                    LoginLogsDL log = new LoginLogsDL(logID[0].LoginLogsID);
                    log.getInfo();
                    log.LogoutDate = WebApi.Common.General.CurrentDateString;
                    log.LogoutTime = WebApi.Common.General.CurrentDateString;
                    log.transaction = tr;
                    log.update_SQL();
                }
                tr.Commit();
            }
            catch (System.Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }
    }
}


/*
namespace PPC.Core.Common.Security
{
    public class UserSecurity
    {
        public UserSecurity()
        {
        }
        private string Name = "BL";
        //public UserDL Users;
        //public Byte? DomainIDSelected { get; set; }
        //public string Password { get; set; }

        private UserDL user;
        private StationsDL station;


        //public StationsDL Stations;

        public Users ValidateLogin(string userName, string userPassword, string stationID, out HandledException ex)
        {
            bool result = true;
            //user.ConvertToDto
            ex = new HandledException();
            user = new UserDL();
            user.UserName = userName;

            if (!user.getInfo("UserName"))
            {
                ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا", "با مدیر سیستم تماس بگیرید.");
                //return false;
                result = false;
            }

            if(!ValidatePassword(userName, userPassword, out ex))
            //if (user.Password != SHA1.GetHashedString(user.UserID+ user.UserName+userPassword))
            {
                ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا");
                //return false;
                result = false;
            }

            //station = new StationsDL(Convert.ToInt32(stationID));
            //station.getInfo();

            //if (Users.UserID != 0)//administrator
            if (!user.IsSysAdmin)//administrator
            {
                if (!user.CanLogin)
                {
                    ex = new HandledException("شما نمی توانید وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    //return false;
                    result = false;
                }
                if (user.IsEntered)
                {
                    //ex = new HandledException("شما قبلا وارد سیستم شده اید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    //return false;
                }
                if (!user.IsActive)
                {
                    ex = new HandledException("نام کاربری شما غیر فعال شده است. با مدیر سیستم تماس بگیرید.", "خطا");
                    //return false;
                    result = false;
                }
                //// check if user can login on station
                if (!UserDL.hasUserAccessToStation(user.UserID, stationID))
                {
                    //ex = new HandledException("شما نمی توانید در این ایستگاه وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    ////return false;
                    //result = false;
                }

            }

            if(result)
            {


                List<Users> _user = new List<Users>();
                var mapper =  Functions.CreateMapper<UserDL, Users>();
                _user.Add(mapper(user));
                return _user[0];
            }
            else
            {
                return null;
                //throw ex;
            }
            ///
            //return true;
        }

        public bool ValidatePassword(string userName, string userPassword, out HandledException ex)
        {
            bool result = true;
            ex = new HandledException();
            user = new UserDL
            {
                UserName = userName
            };

            if (!user.getInfo("UserName"))
            {
                ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا", "با مدیر سیستم تماس بگیرید.");
                result = false;
            }

            if (user.Password != SHA1.GetHashedString(user.UserID + user.UserName + userPassword))
            {
                ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا");
                result = false;
            }

            return result;
        }

        //public bool ValidateLogin(out HandledException ex)
        //{
        //    ex = new HandledException();
        //    UserDL _user = new UserDL();
        //    _user.UserName = Users.UserName;
        //    if (!_user.getInfo("UserName"))
        //    {
        //        ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //        return false;
        //    }



        //    if (_user.Password != SHA1.GetHashedString(_user.UserID + _user.UserName + Password))
        //    {
        //        ex = new HandledException("اطلاعات وارد شده اشتباه است.", "خطا");
        //        return false;
        //    }


        //    //if (Users.UserID != 0)//administrator
        //    if (!Users.IsSysAdmin)//administrator
        //    {
        //        if (!_user.CanLogin)
        //        {
        //            ex = new HandledException("شما نمی توانید وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //            return false;
        //        }
        //        if (_user.IsEntered)
        //        {
        //            //ex = new HandledException("شما قبلا وارد سیستم شده اید.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //            //return false;
        //        }
        //        if (!Users.IsActive)
        //        {
        //            ex = new HandledException("نام کاربری شما غیر فعال شده است. با مدیر سیستم تماس بگیرید.", "خطا");
        //            return false;
        //        }
        //        //// check if user can login on station
        //        if (!UserDL.hasUserAccessToStation(Users.UserID, Stations.StationID))
        //        {
        //            ex = new HandledException("شما نمی توانید در این ایستگاه وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
        //            return false;
        //        }
        //    }
        //    ///
        //    return true;
        //}


        public bool Login()
        {
            Transaction tr = new Transaction();
            tr.StartTransaction();
            try
            {
                //HandledException ex = new HandledException();
                //if (!ValidateLogin(out ex))
                //{
                //    throw ex;
                //    //return false;
                //}
                user.IsEntered = true;
                user.transaction = tr;
                user.update_OLD();
                LoginLogsDL log = new LoginLogsDL();
                int MaxID = 0;
                try
                {
                    MaxID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "LoginLogsID", "", tr);
                }
                catch (System.Exception ex) { }
                MaxID++;
                log.transaction = tr;
                log.LoginLogsID = MaxID;
                log.LoginDate = PPC.Common.General.CurrentDateString;// PrintingCommon.General.CurrentDateOfServer;
                log.LoginTime = PPC.Common.General.CurrentTimeString;
                log.LogoutDate = "____/__/__";
                log.LogoutTime = "__:__";
                log.StationID = station.StationID;
                log.User_UserID = user;
                log.Version = "";
                log.append_SQL();
                tr.Commit();
                return true;

            }
            catch (System.Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }

        public void Logout()
        {
            Transaction tr = new Transaction();
            tr.StartTransaction();
            try
            {
                user.transaction = tr;
                user.getInfo();
                user.IsEntered = false;
                user.update_OLD();

                string where = string.Format("UserID='{0}' and StationID='{1}'", user.UserID.ToString(), station.StationID.ToString());
                int rowID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "RowID", where, tr);

                LoginLogsDL[] logID = LoginLogsDL.getInstances("RowID=" + rowID);
                if (logID.Length != 0)
                {
                    LoginLogsDL log = new LoginLogsDL(logID[0].LoginLogsID);
                    log.getInfo();
                    log.LogoutDate = PPC.Common.General.CurrentDateString;
                    log.LogoutTime = PPC.Common.General.CurrentDateString;
                    log.transaction = tr;
                    log.update_SQL();
                }
                tr.Commit();
            }
            catch (System.Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }
    }
} */