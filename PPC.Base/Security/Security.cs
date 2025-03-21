using PPC.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace PPC.Security
{
    public class Security
    {
        public Security() { }


        private string Name = "BL";
        public UserDL Users;
        public Byte? DomainIDSelected { get; set; }
        public string Password { get; set; }


        public StationsDL Stations;

        public bool ValidateLogin(out HandledException ex)
        {
            ex = new HandledException();
            UserDL _user = new UserDL();
            _user.UserName = Users.UserName;
            if (!_user.getInfo("UserName"))
            {
                ex = new HandledException("شناسه کاربری وجود ندارد.", "خطا", "با مدیر سیستم تماس بگیرید.");
                return false;
            }

            if (_user.UserID.Equals(0))//administrator
                _user.LoginType = (byte)PrintingCommon.General.LoginType.Both;

            ActiveDirectory activeDirectory;

            switch (_user.LoginType)
            {
                case 1://Standalone
                    if (_user.Password != SHA1.getHashString(Password))
                    {
                        ex = new HandledException("گذرواژه اشتباه می باشد.", "خطا");
                        return false;
                    }
                    break;
                case 2://ActiveDirectory

                    activeDirectory = new ActiveDirectory(DomainDL.GetDomainAddress(DomainIDSelected), Users.UserName, this.Password, System.DirectoryServices.AuthenticationTypes.Secure);
                    if (!activeDirectory.Login())
                    {
                        ex = new HandledException("شناسه و یا گذرواژه اشتباه می باشد.", "خطا");
                        return false;
                    }
                    break;
                case 3://Both
                    if (this.DomainIDSelected.IsNull())//Standalone
                    {
                        if (_user.Password != SHA1.getHashString(Password))
                        {
                            ex = new HandledException("گذرواژه اشتباه می باشد.", "خطا");
                            return false;
                        }
                    }
                    else
                    {

                        activeDirectory = new ActiveDirectory(DomainDL.GetDomainAddress(DomainIDSelected), Users.UserName, this.Password, System.DirectoryServices.AuthenticationTypes.Secure);
                        if (!activeDirectory.Login())
                        {
                            ex = new HandledException("شناسه و یا گذرواژه اشتباه می باشد.", "خطا");
                            return false;
                        }


                    }

                    break;
                default:
                    ex = new HandledException("دامین به درستی انتخاب نشده است", "خطا");
                    return false;
            }

            //if ((Byte)General.LoginType.Standalone == _user.LoginType && _user.Password != Users.Password)
            //{
            //    MessagesText.GetMessageText(this.Name, this.Name, "گذرواژه اشتباه می باشد.", "خطا", "");
            //    ex = new HandledException(MessagesText.MessageBody.MessageText, MessagesText.MessageBody.MessageTitle);
            //    return false;
            //}


            //if (Users.UserID != 0)//administrator
            if (!Users.IsSysAdmin)//administrator
            {
                if (!_user.CanLogin)
                {
                    ex = new HandledException("شما نمی توانید وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    return false;
                }
                if (_user.IsEntered)
                {
                    //ex = new HandledException("شما قبلا وارد سیستم شده اید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    //return false;
                }
                if (!Users.IsActive)
                {
                    ex = new HandledException("نام کاربری شما غیر فعال شده است. با مدیر سیستم تماس بگیرید.", "خطا");
                    return false;
                }
                //// check if user can login on station
                if (!UserDL.hasUserAccessToStation(Users.UserID, Stations.StationID))
                {
                    ex = new HandledException("شما نمی توانید در این ایستگاه وارد سیستم شوید.", "خطا", "با مدیر سیستم تماس بگیرید.");
                    return false;
                }
            }
            ///
            return true;
        }
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
                Users.IsEntered = true;
                Users.transaction = tr;
                Users.update_OLD();
                LoginLogsDL log = new LoginLogsDL();
                int MaxID = 0;
                try
                {
                    MaxID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "LoginLogsID", "", tr);
                }
                catch (Exception ex) { }
                MaxID++;
                log.transaction = tr;
                log.LoginLogsID = MaxID;
                log.LoginDate = PrintingCommon.General.CurrentDateOfServer;
                log.LoginTime = PrintingCommon.General.CurrentTimeOfServer;
                log.LogoutDate = "____/__/__";
                log.LogoutTime = "__:__";
                log.StationID = Stations.StationID;
                log.User_UserID = Users;
                log.Version = "";
                log.append_SQL();
                tr.Commit();
                return true;

            }
            catch (Exception ex)
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
                Users.transaction = tr;
                Users.getInfo();
                Users.IsEntered = false;
                Users.update_OLD();

                //string where = string.Format("UserID={0} and StationID={1}", Users.UserID.ToString(), Stations.StationID.ToString());
                //int logID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "LoginLogID", where, tr);
                string where = string.Format("UserID={0} and StationID={1}", Users.UserID.ToString(), Stations.StationID.ToString());
                int rowID = (int)LoginLogsDL.aggregate(AggregateType.MAX, "RowID", where, tr);

                LoginLogsDL[] logID = LoginLogsDL.getInstances("RowID=" + rowID);
                if (logID.Length != 0)
                {
                    LoginLogsDL log = new LoginLogsDL(logID[0].LoginLogsID);
                    log.getInfo();
                    log.LogoutDate = PrintingCommon.General.CurrentDateOfServer;
                    log.LogoutTime = PrintingCommon.General.CurrentTimeOfServer;
                    log.transaction = tr;
                    log.update_SQL();
                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
        }
    }
}
