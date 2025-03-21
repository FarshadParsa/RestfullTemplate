using AtlasCellData.ADO;
using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IStationsService
    {


        /// <summary>
        /// Query stations 
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        Stations GetStationById(int stationId);

        /// <summary>
        /// Get Station  based on id
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        Task<Stations> GetStationByIdAsync(int stationId);

        /// <summary>
        /// Get Stations
        /// </summary>
        /// <returns></returns>
        List<Stations> GetStations(bool? isActive=null);

        /// <summary>
        /// Get Stations Async
        /// </summary>
        /// <returns></returns>
        Task<List<Stations>> GetStationsAsync(bool? isActive = null);

        /// <summary>				
        /// Query Stations				
        /// </summary>				
        /// <param name="stationID"></param>				
        /// <returns></returns>				
        Stations GetStationsById(int stationID);

        /// <summary>				
        /// Get  Stations  based on id				
        /// </summary>				
        /// <param name="stationID"></param>				
        /// <returns></returns>				
        Task<Stations> GetStationsByIdAsync(int stationID);

        /// <summary>				
        /// Get all Stations				
        /// </summary>				
        /// <returns></returns>				
        List<Stations> GetAll();

        /// <summary>				
        /// Get all Stations Async				
        /// </summary>				
        /// <returns></returns>				
        Task<List<Stations>> GetAllAsync();


        /// <summary>				
        /// Append a record				
        /// </summary>				
        /// <param name="stationses"></param>				
        /// <returns></returns>				
        int Append(Stations stationses);

        /// <summary>				
        /// Update a record				
        /// </summary>				
        /// <param name="stationses"></param>				
        /// <returns></returns>				
        bool Update(Stations stationses);

        /// <summary>				
        /// Delete a record				
        /// </summary>				
        /// <param name="stationID"></param>				
        /// <returns></returns>				
        long Delete(int stationID);

        /// <summary>				
        /// Existing StationsAsync				
        /// </summary>				
        /// <param name="name">stations name</param>				
        /// <returns></returns>				
        Task<bool> ExistStationsAsync(string name);


    }
}
