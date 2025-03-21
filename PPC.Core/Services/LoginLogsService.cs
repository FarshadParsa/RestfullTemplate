using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;

using PPC.Core.Models;

using PPC.Core.Repository;

namespace PPC.Core.Services
{
    public class LoginLogsService : BaseService, ILoginLogsService
    {
        IUnitOfWork _unitOfWork;
        public LoginLogsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<LoginLogs> GetAll()
        {
            try
            {
                var loginLogs = _repositoryFactory.LoginLogs.Table.ToList();

                return loginLogs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<LoginLogs>> GetAllAsync()
        {
            try
            {

                var loginLogs = await _repositoryFactory.LoginLogs.Table.ToListAsync();
                return loginLogs;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public LoginLogs GetLoginLogsById(int loginLogID)
        {
            try
            {
                var loginLogs = _repositoryFactory.LoginLogs
                    .FirstOrDefault(x => x.LoginLogID == loginLogID);

                return loginLogs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<LoginLogs> GetLoginLogsByIdAsync(int loginLogID)
        {
            try
            {
                var loginLogs = await _repositoryFactory.LoginLogs
                    .FirstOrDefaultAsync(x => x.LoginLogID == loginLogID);

                return loginLogs;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(LoginLogs loginLogs)
        {
            try
            {
                _repositoryFactory.LoginLogs.Add(
                    new LoginLogs
                    {
                        LoginLogID = loginLogs.LoginLogID,
                        UserID = loginLogs.UserID,
                        StationID = loginLogs.StationID,
                        LoginDate = loginLogs.LoginDate,
                        LoginTime = loginLogs.LoginTime,
                        LogoutDate = loginLogs.LogoutDate,
                        LogoutTime = loginLogs.LogoutTime,
                        Version = loginLogs.Version,
                        IPAddresses = loginLogs.IPAddresses,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(LoginLogs loginLogs)
        {
            try
            {

                _repositoryFactory.LoginLogs.UpdateBy(x => x.LoginLogID == loginLogs.LoginLogID,
                    new LoginLogs
                    {
                        LoginLogID = loginLogs.LoginLogID,
                        UserID = loginLogs.UserID,
                        StationID = loginLogs.StationID,
                        LoginDate = loginLogs.LoginDate,
                        LoginTime = loginLogs.LoginTime,
                        LogoutDate = loginLogs.LogoutDate,
                        LogoutTime = loginLogs.LogoutTime,
                        Version = loginLogs.Version,
                        IPAddresses = loginLogs.IPAddresses,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int loginLogID)
        {
            try
            {
                var loginLogs = _repositoryFactory.LoginLogs
                    .FirstOrDefault(x => x.LoginLogID == loginLogID);

                if (loginLogs == null)
                    throw new System.Exception("LoginLogs Notfound.");

                _repositoryFactory.LoginLogs.Delete(loginLogs);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


    }
}
