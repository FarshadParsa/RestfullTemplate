using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IInvRawMaterialLotsService
    {

        /// <summary>
        /// Query InvRawMaterialLots
        /// </summary>
        /// <param name="invRawMaterialLotID"></param>
        /// <returns></returns>
        InvRawMaterialLots GetInvRawMaterialLotsById(int invRawMaterialLotID);

        /// <summary>
        /// Get  InvRawMaterialLots  based on id
        /// </summary>
        /// <param name="invRawMaterialLotID"></param>
        /// <returns></returns>
        Task<InvRawMaterialLots> GetInvRawMaterialLotsByIdAsync(int invRawMaterialLotID);

        /// <summary>
        /// Get all InvRawMaterialLots
        /// </summary>
        /// <returns></returns>
        List<InvRawMaterialLots> GetAll();

        /// <summary>
        /// Get all InvRawMaterialLots Async
        /// </summary>
        /// <returns></returns>
        Task<List<InvRawMaterialLots>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="invRawMaterialLots"></param>
        /// <returns></returns>
        int Append(InvRawMaterialLots invRawMaterialLots);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="invRawMaterialLots"></param>
        /// <returns></returns>
        bool Update(InvRawMaterialLots invRawMaterialLots);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="invRawMaterialLotID"></param>
        /// <returns></returns>
        long Delete(int invRawMaterialLotID);

        /// <summary>
        /// Existing InvRawMaterialLotsAsync
        /// </summary>
        /// <param name="name">invRawMaterialLots name</param>
        /// <returns></returns>
        Task<InvRawMaterialLots> GetInvRawMaterialLotsAsync(string lotNo);

        Task<string> GetLatestByPartOfLotNoAsync(string lotNo);



    }
}
