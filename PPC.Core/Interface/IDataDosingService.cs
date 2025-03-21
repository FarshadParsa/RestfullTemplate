using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataDosingService
    {

        /// <summary>
        /// Query DataDosing
        /// </summary>
        /// <param name="dataDosingID"></param>
        /// <returns></returns>
        DataDosing GetDataDosingById(int dataDosingID);

        /// <summary>
        /// Get  DataDosing  based on id
        /// </summary>
        /// <param name="dataDosingID"></param>
        /// <returns></returns>
        Task<DataDosing> GetDataDosingByIdAsync(int dataDosingID);

        /// <summary>
        /// Get all DataDosing
        /// </summary>
        /// <returns></returns>
        List<DataDosing> GetAll();

        /// <summary>
        /// Get all DataDosing Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataDosing>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataDosing"></param>
        /// <returns></returns>
        int Append(DataDosing dataDosing);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataDosing"></param>
        /// <returns></returns>
        bool Update(DataDosing dataDosing);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataDosingID"></param>
        /// <returns></returns>
        long Delete(int dataDosingID);



    }
}
