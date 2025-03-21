using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IBOMDetailService
    {

        /// <summary>
        /// Query BOMDetail
        /// </summary>
        /// <param name="bOMDetailID"></param>
        /// <returns></returns>
        BOMDetail GetBOMDetailById(int bOMDetailID);

        /// <summary>
        /// Get  BOMDetail  based on id
        /// </summary>
        /// <param name="bOMDetailID"></param>
        /// <returns></returns>
        Task<BOMDetail> GetBOMDetailByIdAsync(int bOMDetailID);

        /// <summary>
        /// Get all BOMDetail
        /// </summary>
        /// <returns></returns>
        List<BOMDetail> GetAll();

        /// <summary>
        /// Get all BOMDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<BOMDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="bOMDetail"></param>
        /// <returns></returns>
        int Append(BOMDetail bOMDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="bOMDetail"></param>
        /// <returns></returns>
        bool Update(BOMDetail bOMDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="bOMDetailID"></param>
        /// <returns></returns>
        long Delete(int bOMDetailID);

        Task<List<BOMDetail>> GetListByBOMIdAsync(int id);
        

    }
}
