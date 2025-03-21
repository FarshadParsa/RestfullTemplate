using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace PPC.Core.Interface
{
    public interface IInvRawMaterialsService
    {

        /// <summary>
        /// Query InvRawMaterial
        /// </summary>
        /// <param name="invRawMaterialID"></param>
        /// <returns></returns>
        InvRawMaterials GetInvRawMaterialsById(int invRawMaterialID);

        /// <summary>
        /// Get  InvRawMaterial  based on id
        /// </summary>
        /// <param name="invRawMaterialID"></param>
        /// <returns></returns>
        Task<InvRawMaterials> GetInvRawMaterialsByIdAsync(int invRawMaterialID);

        //Task<InvRawMaterials> GetInvRawMaterialsByIdAsync(int invRawMaterialID, string includeProperties = "");
        Task<InvRawMaterials> GetInvRawMaterialsByIdAsync(int invRawMaterialID, params Expression<Func<InvRawMaterials, object>>[] includes);

        /// <summary>
        /// Get all InvRawMaterial
        /// </summary>
        /// <returns></returns>
        List<InvRawMaterials> GetAll();

        /// <summary>
        /// Get all InvRawMaterial Async
        /// </summary>
        /// <returns></returns>
        Task<List<InvRawMaterials>> GetListAsync(params Expression<Func<InvRawMaterials, object>>[] includes);


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="invRawMaterials"></param>
        /// <returns></returns>
        int Append(InvRawMaterials invRawMaterials);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="invRawMaterials"></param>
        /// <returns></returns>
        Task<bool> Update(InvRawMaterials invRawMaterials);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="invRawMaterialID"></param>
        /// <returns></returns>
        long Delete(int invRawMaterialID);

        /// <summary>
        /// Existing InvRawMaterialsAsync
        /// </summary>
        /// <param name="name">invRawMaterial name</param>
        /// <returns></returns>
        Task<InvRawMaterials> GetInvRawMaterialByFinancialRequestNoAsync(string financialRequestNo);

        Task<InvRawMaterials> GetInvRawMaterialWithLotsByIdAsync(int invRawMaterialID);

        //Task<InvRawMaterials> GetInstanceByPartOfLotNoAsync(string lotNo);

        //Task<List<InvRawMaterials>> GetListByGeneralLotNoAsync(string generalLotNo);

        //Task<List<string>> GetLotnumbersByRawMaterialIdAsync(int rawMaterialId);


        /// <summary>
        /// Get list of InvRawMaterial Async by date
        /// </summary>
        /// <returns></returns>
        Task<List<InvRawMaterials>> GetListByDateAsync(
            string startDate,
            string endDate,
            params Expression<Func<InvRawMaterials, object>>[] includes);


    }
}
