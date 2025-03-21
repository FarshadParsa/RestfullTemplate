using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataPremixService
    {

        /// <summary>
        /// Query DataPremix
        /// </summary>
        /// <param name="dataPremixID"></param>
        /// <returns></returns>
        DataPremix GetDataPremixById(int dataPremixID);

        /// <summary>
        /// Get  DataPremix  based on id
        /// </summary>
        /// <param name="dataPremixID"></param>
        /// <returns></returns>
        Task<DataPremix> GetDataPremixByIdAsync(int dataPremixID);

        /// <summary>
        /// Get all DataPremix
        /// </summary>
        /// <returns></returns>
        List<DataPremix> GetAll();

        /// <summary>
        /// Get all DataPremix Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataPremix>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataPremix"></param>
        /// <returns></returns>
        int Append(DataPremix dataPremix);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataPremix"></param>
        /// <returns></returns>
        bool Update(DataPremix dataPremix);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataPremixID"></param>
        /// <returns></returns>
        long Delete(int dataPremixID);


    }
}
