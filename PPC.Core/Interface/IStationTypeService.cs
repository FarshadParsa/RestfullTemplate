using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IStationTypeService
    {

        /// <summary>
        /// Query stationTypeType 
        /// </summary>
        /// <param name="stationTypeId"></param>
        /// <returns></returns>
        StationType GetStationTypeById(int stationTypeId);

        StationType[] GetStationType();

        /// <summary>
        /// Find StationType Async
        /// </summary>
        /// <param name="stationTypeName"></param>
        /// <returns></returns>
        Task<StationType> FindStationTypeAsync(string stationTypename);

        /// <summary>
        /// Get StationType  based on id
        /// </summary>
        /// <param name="stationTypeId"></param>
        /// <returns></returns>
        Task<StationType> GetStationTypeByIdAsync(int stationTypeId);

        /// <summary>
        /// Get Current StationType 
        /// </summary>
        /// <param name="stationTypeId"></param>
        /// <returns></returns>
        Task<StationType> GetCurrentStationTypeAsync();

        Task<StationType[]> GetStationTypeAsync();

        bool Append(StationType stationType);
        bool Update(StationType stationType);
        long Delete(int stationTypeId);




    }
}
