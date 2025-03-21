using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRawMaterialConfirmationService
    {

        /// <summary>
        /// Query RawMaterialConfirmation
        /// </summary>
        /// <param name="rawMaterialConfirmationID"></param>
        /// <returns></returns>
        RawMaterialConfirmation GetRawMaterialConfirmationById(int rawMaterialConfirmationID);

        /// <summary>
        /// Get  RawMaterialConfirmation  based on id
        /// </summary>
        /// <param name="rawMaterialConfirmationID"></param>
        /// <returns></returns>
        Task<RawMaterialConfirmation> GetRawMaterialConfirmationByIdAsync(int rawMaterialConfirmationID);

        /// <summary>
        /// Get all RawMaterialConfirmation
        /// </summary>
        /// <returns></returns>
        List<RawMaterialConfirmation> GetAll();

        /// <summary>
        /// Get all RawMaterialConfirmation Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialConfirmation>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialConfirmation"></param>
        /// <returns></returns>
        int Append(RawMaterialConfirmation rawMaterialConfirmation);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialConfirmation"></param>
        /// <returns></returns>
        bool Update(RawMaterialConfirmation rawMaterialConfirmation);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialConfirmationID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialConfirmationID);


    }
}
