using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.Core.Interface;

using WebApi.Core.Models;

using WebApi.Core.Repository;

namespace WebApi.Core.Services
{
    public class LogsService : BaseService, ILogsService
    {
        IUnitOfWork _unitOfWork;
        public LogsService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<Logs> GetAll()
        {
            try
            {
                var logs = _repositoryFactory.Logs.Table.ToList();

                return logs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Logs>> GetAllAsync()
        {
            try
            {

                var logs = await _repositoryFactory.Logs.Table.ToListAsync();
                return logs;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public Logs GetLogsById(int logID)
        {
            try
            {
                var logs = _repositoryFactory.Logs
                    .FirstOrDefault(x => x.LogID == logID);

                return logs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Logs> GetLogsByIdAsync(int logID)
        {
            try
            {
                var logs = await _repositoryFactory.Logs
                    .FirstOrDefaultAsync(x => x.LogID == logID);

                return logs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Logs> Append(Logs logs)
        {
            try
            {
                    var log =new Logs
                    {
                        //LogID = logs.LogID,
                        Date = General.CurrentDateString,
                        Time = General.CurrentTimeString,
                        UserID = logs.UserID,
                        Action = logs.Action,
                        Details = logs.Details,
                        LoginLogID = logs.LoginLogID,
                        ServerDateTime = DateTime.Now,


                    };
                _repositoryFactory.Logs.Add(log);
                
                var statuse = _unitOfWork.Commit() > 0;

                if (statuse)
                    return log;

                return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(Logs logs)
        {
            try
            {

                _repositoryFactory.Logs.UpdateBy(x => x.LogID == logs.LogID,
                    new Logs
                    {
                        LogID = logs.LogID,
                        Date = logs.Date,
                        Time = logs.Time,
                        UserID = logs.UserID,
                        Action = logs.Action,
                        Details = logs.Details,
                        LoginLogID = logs.LoginLogID,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(int logID)
        {
            try
            {
                var logs = _repositoryFactory.Logs
                    .FirstOrDefault(x => x.LogID == logID);

                if (logs == null)
                    throw new System.Exception("Logs Notfound.");

                _repositoryFactory.Logs.Delete(logs);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public Logs Insert(Int32 userId, string action, string details, int loginLogId)
        {
            try
            {
                var log = new Logs
                {
                    Date = General.CurrentDateString,
                    Time = General.CurrentTimeString,
                    UserID = userId,
                    Action = action,
                    Details = details,
                    LoginLogID = loginLogId,
                    ServerDateTime = DateTime.Now,
                };
                _repositoryFactory.Logs.Add(log);

                if (_unitOfWork.Commit() > 0)
                    return log;
                else
                    return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<List<Logs>> GetLogsByDateTime(string dateFrom, string timeFrom, string dateTo, string timeTo)
        {
            try
            {
                //var logs = await _repositoryFactory.Logs.Table.Include(x=>x.LoginLog).ThenInclude(x=>x.Station).Include(x=>x.User)
                //    .Where(x=>x.Date == dateFrom).ToListAsync();

                //return logs;

                return null;

            }
            catch
            {
                throw;
            }
        }

    }
}
