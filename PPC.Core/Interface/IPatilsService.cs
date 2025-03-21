using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IPatilsService
    {

        /// <summary>
        /// Query Patils
        /// </summary>
        /// <param name="patilID"></param>
        /// <returns></returns>
        Patils GetPatilsById(int patilID);

        /// <summary>
        /// Get  Patils  based on id
        /// </summary>
        /// <param name="patilID"></param>
        /// <returns></returns>
        Task<Patils> GetPatilsByIdAsync(int patilID);

        /// <summary>
        /// Get all Patils
        /// </summary>
        /// <returns></returns>
        List<Patils> GetAll();

        /// <summary>
        /// Get all Patils Async
        /// </summary>
        /// <returns></returns>
        Task<List<Patils>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="patils"></param>
        /// <returns></returns>
        int Append(Patils patils);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="patils"></param>
        /// <returns></returns>
        bool Update(Patils patils);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="patilID"></param>
        /// <returns></returns>
        long Delete(int patilID);



    }
}
