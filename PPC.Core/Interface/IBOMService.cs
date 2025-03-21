using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IBOMService
    {

        /// <summary>
        /// Query BOM
        /// </summary>
        /// <param name="bOMID"></param>
        /// <returns></returns>
        BOM GetBOMById(int bOMID);

        /// <summary>
        /// Get  BOM  based on id
        /// </summary>
        /// <param name="bOMID"></param>
        /// <returns></returns>
        Task<BOM> GetBOMByIdAsync(int bOMID);

        /// <summary>
        /// Get all BOM
        /// </summary>
        /// <returns></returns>
        List<BOM> GetAll();

        /// <summary>
        /// Get all BOM Async
        /// </summary>
        /// <returns></returns>
        Task<List<BOM>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="bOM"></param>
        /// <returns></returns>
        int Append(BOM bOM);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="bOM"></param>
        /// <returns></returns>
        bool Update(BOM bOM);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="bOMID"></param>
        /// <returns></returns>
        long Delete(int bOMID);

        /// <summary>
        /// Existing BOMAsync
        /// </summary>
        /// <param name="name">bOM name</param>
        /// <returns></returns>
        Task<BOM> GetByBOMCodeAsync(string bomCode);

        bool ConfirmDraft(int bomId);

        Task<List<BOM>> GetListByProductIdAsync(int id);

        Task<BOM> GetLatestVersionByIdAsync(int bOMID);
        Task<BOM> GetBOMWithComplementaryByIdAsync(int bOMID);

        Task<List<BOM>> GetListByRawMaterialIdAsync(int rawMaterialId);

        BOM GetMaxBOMcodeByProductId(int productId);


    }
}
