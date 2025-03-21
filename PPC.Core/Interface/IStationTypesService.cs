using PPC.Core.Models;
using PPC.Core.Interface;
using AtlasCellData.ADO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IStationTypesService
    {

        /// <summary>
        /// Query StationType
        /// </summary>
        /// <param name="stationTypeID"></param>
        /// <returns></returns>
        StationTypes GetStationTypesById(int stationTypeID);

        /// <summary>
        /// Get  StationType  based on id
        /// </summary>
        /// <param name="stationTypeID"></param>
        /// <returns></returns>
        Task<StationTypes> GetStationTypesByIdAsync(int stationTypeID);

        /// <summary>
        /// Get all StationType
        /// </summary>
        /// <returns></returns>
        List<StationTypes> GetAll();

        /// <summary>
        /// Get all StationType Async
        /// </summary>
        /// <returns></returns>
        Task<List<StationTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="stationTypes"></param>
        /// <returns></returns>
        StationTypes Append(StationTypes stationTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="stationTypes"></param>
        /// <returns></returns>
        bool Update(StationTypes stationTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="stationTypeID"></param>
        /// <returns></returns>
        long Delete(int stationTypeID);

        /// <summary>
        /// Existing StationTypesAsync
        /// </summary>
        /// <param name="name">stationType name</param>
        /// <returns></returns>
        Task<bool> ExistStationTypesAsync(string name);


    }
}
