using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IBOMComplementaryService
    {

        /// <summary>
        /// Query BOMComplementary
        /// </summary>
        /// <param name="bOMComplementaryID"></param>
        /// <returns></returns>
        BOMComplementary GetBOMComplementaryById(int bOMComplementaryID);

        /// <summary>
        /// Get  BOMComplementary  based on id
        /// </summary>
        /// <param name="bOMComplementaryID"></param>
        /// <returns></returns>
        Task<BOMComplementary> GetBOMComplementaryByIdAsync(int bOMComplementaryID);

        /// <summary>
        /// Get all BOMComplementary
        /// </summary>
        /// <returns></returns>
        List<BOMComplementary> GetAll();

        /// <summary>
        /// Get all BOMComplementary Async
        /// </summary>
        /// <returns></returns>
        Task<List<BOMComplementary>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="bOMComplementary"></param>
        /// <returns></returns>
        int Append(BOMComplementary bOMComplementary);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="bOMComplementary"></param>
        /// <returns></returns>
        bool Update(BOMComplementary bOMComplementary);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="bOMComplementaryID"></param>
        /// <returns></returns>
        long Delete(int bOMComplementaryID);

        Task<List<BOMComplementary>> GetListByRMWhiteListIdAsync(int rmWhiteListId);

        Task<List<BOMComplementary>> GetListByBOMDetailId(int bomDetailId);

        Task<List<BOMComplementary>> GetListByBOMId(int bomId);


    }
}
