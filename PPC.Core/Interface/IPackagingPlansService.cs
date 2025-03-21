using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IPackagingPlansService
    {

        /// <summary>
        /// Query PackagingPlan
        /// </summary>
        /// <param name="packagingPlanID"></param>
        /// <returns></returns>
        PackagingPlans GetPackagingPlansById(int packagingPlanID);

        /// <summary>
        /// Get  PackagingPlan  based on id
        /// </summary>
        /// <param name="packagingPlanID"></param>
        /// <returns></returns>
        Task<PackagingPlans> GetPackagingPlansByIdAsync(int packagingPlanID);

        /// <summary>
        /// Get all PackagingPlan
        /// </summary>
        /// <returns></returns>
        List<PackagingPlans> GetAll();

        /// <summary>
        /// Get all PackagingPlan Async
        /// </summary>
        /// <returns></returns>
        Task<List<PackagingPlans>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="packagingPlans"></param>
        /// <returns></returns>
        int Append(PackagingPlans packagingPlans);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="packagingPlans"></param>
        /// <returns></returns>
        bool Update(PackagingPlans packagingPlans);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="packagingPlanID"></param>
        /// <returns></returns>
        long Delete(int packagingPlanID);

        /// <summary>
        /// Existing PackagingPlansAsync
        /// </summary>
        /// <param name="name">packagingPlan name</param>
        /// <returns></returns>
        Task<bool> ExistPackagingPlansAsync(string name);

    }
}
