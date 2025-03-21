using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IProductionPlanReworksService
    {

        /// <summary>
        /// Query ProductionPlanRework
        /// </summary>
        /// <param name="productionPlanReworkID"></param>
        /// <returns></returns>
        ProductionPlanReworks GetProductionPlanReworksById(int productionPlanReworkID);

        /// <summary>
        /// Get  ProductionPlanRework  based on id
        /// </summary>
        /// <param name="productionPlanReworkID"></param>
        /// <returns></returns>
        Task<ProductionPlanReworks> GetProductionPlanReworksByIdAsync(int productionPlanReworkID);

        /// <summary>
        /// Get all ProductionPlanRework
        /// </summary>
        /// <returns></returns>
        List<ProductionPlanReworks> GetAll();

        /// <summary>
        /// Get all ProductionPlanRework Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlanReworks>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlanReworks"></param>
        /// <returns></returns>
        int Append(ProductionPlanReworks productionPlanReworks);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlanReworks"></param>
        /// <returns></returns>
        bool Update(ProductionPlanReworks productionPlanReworks);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanReworkID"></param>
        /// <returns></returns>
        long Delete(int productionPlanReworkID);

        /// <summary>
        /// بازگشت آخرین مرتبه اقدام اصلاحی
        /// </summary>
        /// <param name="productionPlanPatilID"></param>
        /// <returns></returns>
        byte GetMaxLevelNoByPatilId(int productionPlanPatilID);

        Task<List<ProductionPlanReworks>> GetInstanceByProductionPlanPatilIDAsync(int productionPlanPatilId);

        /// <summary>
        /// خذف منطقی
        /// </summary>
        /// <param name="productionPlanReworkID"></param>
        /// <returns></returns>
        bool DeleteLogic(int productionPlanReworkID, int userId);


    }
}
