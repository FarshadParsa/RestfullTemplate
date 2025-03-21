using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataGrindingService
    {

        /// <summary>
        /// Query DataGrinding
        /// </summary>
        /// <param name="dataGrindingID"></param>
        /// <returns></returns>
        DataGrinding GetDataGrindingById(int dataGrindingID);

        /// <summary>
        /// Get  DataGrinding  based on id
        /// </summary>
        /// <param name="dataGrindingID"></param>
        /// <returns></returns>
        Task<DataGrinding> GetDataGrindingByIdAsync(int dataGrindingID);

        /// <summary>
        /// Get all DataGrinding
        /// </summary>
        /// <returns></returns>
        List<DataGrinding> GetAll();

        /// <summary>
        /// Get all DataGrinding Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataGrinding>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataGrinding"></param>
        /// <returns></returns>
        int Append(DataGrinding dataGrinding);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataGrinding"></param>
        /// <returns></returns>
        bool Update(DataGrinding dataGrinding);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataGrindingID"></param>
        /// <returns></returns>
        long Delete(int dataGrindingID);


    }
}
