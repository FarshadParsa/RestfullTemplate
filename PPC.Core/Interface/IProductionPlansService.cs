using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace PPC.Core.Interface
{
    public interface IProductionPlansService
    {

        /// <summary>
        /// Query ProductionPlan
        /// </summary>
        /// <param name="productionPlanID"></param>
        /// <returns></returns>
        ProductionPlans GetProductionPlansById(int productionPlanID);

        /// <summary>
        /// Get  ProductionPlan  based on id
        /// </summary>
        /// <param name="productionPlanID"></param>
        /// <returns></returns>
        Task<ProductionPlans> GetProductionPlansByIdAsync(int productionPlanID);

        /// <summary>
        /// Get all ProductionPlan
        /// </summary>
        /// <returns></returns>
        List<ProductionPlans> GetAll();

        /// <summary>
        /// Get all ProductionPlan Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlans>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productionPlans"></param>
        /// <returns></returns>
        int Append(ProductionPlans productionPlans);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productionPlans"></param>
        /// <returns></returns>
        bool Update(ProductionPlans productionPlans);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productionPlanID"></param>
        /// <returns></returns>
        long Delete(int productionPlanID);

        Task<ProductionPlans> GetMaxProductionPlanByDateAsync(string date);

        Task<List<ProductionPlans>> GetBatchNumbersListByOrderDetailIdAsync(int orderDetailId);

        Task<List<ProductionPlans>> GetListForDropdown();

        /// <summary>
        /// Get list of inprocess ProductionPlans
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlans>> GetInprocessListAsync(string startDate, string endDate);

        (DataTable productionDT, DataTable bomDT, DataTable packagingDT, DataTable patilesDT) GetProductionReport(int productionPlanId);

        Task<bool> ValidateCanFinishPlanAsync(int productionPlanId);

        Task<bool> FinishPlanAsync(int productionPlanId);


        /// <summary>
        /// دریافت لیست آخرین فرمولاسیون مصرف شده یک برنامه تولید
        /// </summary>
        /// <returns></returns>
        Task<ProductionPlans> GetLatestUsgedBOMAsync(int productionPlanId);


        /// <summary>
        /// Get Instance by ProductionPlanPatilId
        /// </summary>
        /// <param name="productionPlanID"></param>
        /// <returns></returns>
        Task<ProductionPlans> GetInstanceByProductionPlanPatilId(int productionPlanPatilID);

        /// <summary>
        /// Get list of inprocess ProductionPlans
        /// </summary>
        /// <returns></returns>
        Task<List<ProductionPlans>> GetAllAsync(string startDate, string endDate);


    }
}
