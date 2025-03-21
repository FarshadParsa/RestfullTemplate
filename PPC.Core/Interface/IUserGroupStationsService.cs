using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IUserGroupStationsService
    {

        /// <summary>
        /// Query UserGroupStation
        /// </summary>
        /// <param name="userGroupStationID"></param>
        /// <returns></returns>
        UserGroupStations GetUserGroupStationsById(int userGroupStationID);

        /// <summary>
        /// Get  UserGroupStation  based on id
        /// </summary>
        /// <param name="userGroupStationID"></param>
        /// <returns></returns>
        Task<UserGroupStations> GetUserGroupStationsByIdAsync(int userGroupStationID);

        /// <summary>
        /// Get all UserGroupStation
        /// </summary>
        /// <returns></returns>
        List<UserGroupStations> GetAll();

        /// <summary>
        /// Get all UserGroupStation Async
        /// </summary>
        /// <returns></returns>
        Task<List<UserGroupStations>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="userGroupStations"></param>
        /// <returns></returns>
        List<UserGroupStations> Append(List<UserGroupStations> userGroupStationsList);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="userGroupStations"></param>
        /// <returns></returns>
        bool Update(UserGroupStations userGroupStations);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="userGroupStationID"></param>
        /// <returns></returns>
        long Delete(int userGroupStationID);

        long DeleteByUserGroupId(int userGroupID);

        /// <summary>
        /// Get all UserGroupStation Async
        /// </summary>
        /// <returns></returns>
        Task<List<UserGroupStations>> GetAllByUserGroupIdAsync(int id);



    }
}
