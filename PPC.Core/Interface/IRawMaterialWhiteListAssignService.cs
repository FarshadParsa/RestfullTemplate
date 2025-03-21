using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRawMaterialWhiteListAssignService
    {

        /// <summary>
        /// Query RawMaterialWhiteListAssign
        /// </summary>
        /// <param name="rawMaterialWhiteListAssignID"></param>
        /// <returns></returns>
        RawMaterialWhiteListAssign GetRawMaterialWhiteListAssignById(int rawMaterialWhiteListAssignID);

        /// <summary>
        /// Get  RawMaterialWhiteListAssign  based on id
        /// </summary>
        /// <param name="rawMaterialWhiteListAssignID"></param>
        /// <returns></returns>
        Task<RawMaterialWhiteListAssign> GetRawMaterialWhiteListAssignByIdAsync(int rawMaterialWhiteListAssignID);

        /// <summary>
        /// Get all RawMaterialWhiteListAssign
        /// </summary>
        /// <returns></returns>
        List<RawMaterialWhiteListAssign> GetAll();

        /// <summary>
        /// Get all RawMaterialWhiteListAssign Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialWhiteListAssign>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialWhiteListAssign"></param>
        /// <returns></returns>
        int Append(RawMaterialWhiteListAssign rawMaterialWhiteListAssign);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialWhiteListAssign"></param>
        /// <returns></returns>
        bool Update(RawMaterialWhiteListAssign rawMaterialWhiteListAssign);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialWhiteListAssignID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialWhiteListAssignID);

        Task<List<RawMaterialWhiteListAssign>> GetListByWhitelistIdAsync(int? id);
        Task<List<RawMaterialWhiteListAssign>> GetListByRawMaterialIdAsync(int id);


    }
}
