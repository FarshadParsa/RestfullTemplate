using WebApi.Core.Models;
using WebApi.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{
    public interface IDenyAccessesService
    {

        /// <summary>
        /// Query DenyAccess
        /// </summary>
        /// <param name="denyAccessID"></param>
        /// <returns></returns>
        DenyAccesses GetDenyAccessesById(int denyAccessID);

        /// <summary>
        /// Get  DenyAccess  based on id
        /// </summary>
        /// <param name="denyAccessID"></param>
        /// <returns></returns>
        Task<DenyAccesses> GetDenyAccessesByIdAsync(int denyAccessID);

        /// <summary>
        /// Get all DenyAccess
        /// </summary>
        /// <returns></returns>
        List<DenyAccesses> GetAll();

        /// <summary>
        /// Get all DenyAccess Async
        /// </summary>
        /// <returns></returns>
        Task<List<DenyAccesses>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="denyAccesses"></param>
        /// <returns></returns>
        bool Append(DenyAccesses denyAccesses);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="denyAccesses"></param>
        /// <returns></returns>
        bool Update(DenyAccesses denyAccesses);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="denyAccessID"></param>
        /// <returns></returns>
        long Delete(int denyAccessID);

        /// <summary>
        /// Existing DenyAccessesAsync
        /// </summary>
        /// <param name="name">denyAccess name</param>
        /// <returns></returns>
        Task<bool> ExistDenyAccessesAsync(string name);

        /// <summary>
        /// Get all DenyAccess by userId Async
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        Task<List<DenyAccesses>> GetAllByUserIdAsync(int userId);

        /// <summary>
        /// Get all DenyAccess by stationId Async
        /// </summary>
        /// <param name="stationId">station id</param>
        /// <returns></returns>
        Task<List<DenyAccesses>> GetAllByStationIdAsync(int stationId);


        /// <summary>
        /// Delete a record by userId
        /// </summary>
        /// <param name="userId"> User id</param>
        /// <returns></returns>
        long DeleteByUserIfExists(int userId);


        /// <summary>
        /// Delete a record by stationId
        /// </summary>
        /// <param name="stationId"> Station id</param>
        /// <returns></returns>
        long DeleteByStationIfExists(int stationId);

    }
}
