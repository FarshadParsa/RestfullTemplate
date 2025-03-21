using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IInvProductionRawMaterialsService
    {

        /// <summary>
        /// Query InvProductionRawMaterial
        /// </summary>
        /// <param name="invProductionRawMaterialID"></param>
        /// <returns></returns>
        InvProductionRawMaterials GetInvProductionRawMaterialsById(int invProductionRawMaterialID);

        /// <summary>
        /// Get  InvProductionRawMaterial  based on id
        /// </summary>
        /// <param name="invProductionRawMaterialID"></param>
        /// <returns></returns>
        Task<InvProductionRawMaterials> GetInvProductionRawMaterialsByIdAsync(int invProductionRawMaterialID);

        /// <summary>
        /// Get all InvProductionRawMaterial
        /// </summary>
        /// <returns></returns>
        List<InvProductionRawMaterials> GetAll();

        /// <summary>
        /// Get all InvProductionRawMaterial Async
        /// </summary>
        /// <returns></returns>
        Task<List<InvProductionRawMaterials>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="invProductionRawMaterials"></param>
        /// <returns></returns>
        int Append(InvProductionRawMaterials invProductionRawMaterials);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="invProductionRawMaterials"></param>
        /// <returns></returns>
        bool Update(InvProductionRawMaterials invProductionRawMaterials);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="invProductionRawMaterialID"></param>
        /// <returns></returns>
        long Delete(int invProductionRawMaterialID);



    }
}
