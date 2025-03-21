using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IOrderBOMRevisionsService
    {

        /// <summary>
        /// Query OrderBOMRevision
        /// </summary>
        /// <param name="orderBOMRevisionID"></param>
        /// <returns></returns>
        OrderBOMRevisions GetOrderBOMRevisionsById(int orderBOMRevisionID);

        /// <summary>
        /// Get  OrderBOMRevision  based on id
        /// </summary>
        /// <param name="orderBOMRevisionID"></param>
        /// <returns></returns>
        Task<OrderBOMRevisions> GetOrderBOMRevisionsByIdAsync(int orderBOMRevisionID);

        /// <summary>
        /// Get all OrderBOMRevision
        /// </summary>
        /// <returns></returns>
        List<OrderBOMRevisions> GetAll();

        /// <summary>
        /// Get all OrderBOMRevision Async
        /// </summary>
        /// <returns></returns>
        Task<List<OrderBOMRevisions>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="orderBOMRevisions"></param>
        /// <returns></returns>
        int Append(OrderBOMRevisions orderBOMRevisions);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="orderBOMRevisions"></param>
        /// <returns></returns>
        bool Update(OrderBOMRevisions orderBOMRevisions);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="orderBOMRevisionID"></param>
        /// <returns></returns>
        long Delete(int orderBOMRevisionID);

        Task<List<OrderBOMRevisions>> GetArchiveAsync(string startDate, string endDate);


    }
}
