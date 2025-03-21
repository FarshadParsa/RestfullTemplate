using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanBOMDetailService
    {

        /// <summary>
        /// Query ProductionPlanBOMDetail
        /// </summary>
        /// <param name="productionPlanBOMDetailID"></param>
        /// <returns></returns>
        ProductionPlanBOMDetail GetProductionPlanBOMDetailById(int productionPlanBOMDetailID);

        /// <summary>
        /// Get  ProductionPlanBOMDetail  based on id
        /// </summary>
        /// <param name="productionPlanBOMDetailID"></param>
        /// <returns></returns>
        Task<ProductionPlanBOMDetail> GetProductionPlanBOMDetailByIdAsync(int productionPlanBOMDetailID);

        /// <summary>
        /// Get all ProductionPlanBOMDetail
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanBOMDetail> GetAll();

        /// <summary>
        /// Get all ProductionPlanBOMDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanBOMDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanBOMDetail"></param>
        /// <returns></returns>
        int Append(ProductionPlanBOMDetail productionPlanBOMDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanBOMDetail"></param>
        /// <returns></returns>
        bool Update(ProductionPlanBOMDetail productionPlanBOMDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanBOMDetailID"></param>
        /// <returns></returns>
        long Delete(int productionPlanBOMDetailID);

        Task<List<ProductionPlanBOMDetail>> GetListByProductionPlanIdAsync(int productionPlanId);

        /// <summary>
        /// change of BOM
        /// </summary>
        /// <param name="productionPlanBOMList"></param>
        /// <returns></returns>
        bool BOMRevise(List<ProductionPlanBOMDetail> productionPlanBOMList);


    }
}
