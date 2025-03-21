using PPC.Core.Models;
using PPC.Core.Interface;
using AtlasCellData.ADO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ILoginLogsService
    {

        /// <summary>
        /// Query LoginLog
        /// </summary>
        /// <param name="loginLogID"></param>
        /// <returns></returns>
        LoginLogs GetLoginLogsById(int loginLogID);

        /// <summary>
        /// Get  LoginLog  based on id
        /// </summary>
        /// <param name="loginLogID"></param>
        /// <returns></returns>
        Task<LoginLogs> GetLoginLogsByIdAsync(int loginLogID);

        /// <summary>
        /// Get all LoginLog
        /// </summary>
        /// <returns></returns>
        List<LoginLogs> GetAll();

        /// <summary>
        /// Get all LoginLog Async
        /// </summary>
        /// <returns></returns>
        Task<List<LoginLogs>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="loginLogs"></param>
        /// <returns></returns>
        bool Append(LoginLogs loginLogs);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="loginLogs"></param>
        /// <returns></returns>
        bool Update(LoginLogs loginLogs);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="loginLogID"></param>
        /// <returns></returns>
        long Delete(int loginLogID);


    }
}
