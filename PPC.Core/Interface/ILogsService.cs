using WebApi.Core.Models;
using WebApi.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApi.Core.Interface
{
    public interface ILogsService
    {

        /// <summary>
        /// Query Log
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        Logs GetLogsById(int logID);

        /// <summary>
        /// Get  Log  based on id
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        Task<Logs> GetLogsByIdAsync(int logID);

        /// <summary>
        /// Get all Log
        /// </summary>
        /// <returns></returns>
        List<Logs> GetAll();

        /// <summary>
        /// Get all Log Async
        /// </summary>
        /// <returns></returns>
        Task<List<Logs>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        Task<Logs> Append(Logs logs);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        bool Update(Logs logs);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        long Delete(int logID);


        /// <summary>
        /// Insert Log with server DateTime
        /// </summary>
        /// <param name="userId">UserID</param>
        /// <param name="stationId">StationID</param>
        /// <param name="action">Action</param>
        /// <param name="details">Detail</param>
        /// <param name="loginLogId">LoginLogID</param>
        /// <returns></returns>
        Logs Insert(Int32 userId, string action, string details, int loginLogId);


        Task<List<Logs>> GetLogsByDateTime(string dateFrom, string timeFrom, string dateTo, string timeTo);


    }
}
