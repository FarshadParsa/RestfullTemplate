using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataPatilService
    {

        /// <summary>
        /// Query DataPatil
        /// </summary>
        /// <param name="dataPatilID"></param>
        /// <returns></returns>
        DataPatil GetDataPatilById(int dataPatilID);

        /// <summary>
        /// Get  DataPatil  based on id
        /// </summary>
        /// <param name="dataPatilID"></param>
        /// <returns></returns>
        Task<DataPatil> GetDataPatilByIdAsync(int dataPatilID);

        /// <summary>
        /// Get all DataPatil
        /// </summary>
        /// <returns></returns>
        List<DataPatil> GetAll();

        /// <summary>
        /// Get all DataPatil Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataPatil>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataPatil"></param>
        /// <returns></returns>
        int Append(DataPatil dataPatil);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataPatil"></param>
        /// <returns></returns>
        bool Update(DataPatil dataPatil);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataPatilID"></param>
        /// <returns></returns>
        long Delete(int dataPatilID);


    }
}
