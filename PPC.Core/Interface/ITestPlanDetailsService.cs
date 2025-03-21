using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanDetailsService
    {

        /// <summary>
        /// Query TestPlanDetail
        /// </summary>
        /// <param name="testPlanDetailID"></param>
        /// <returns></returns>
        TestPlanDetails GetTestPlanDetailsById(int testPlanDetailID);

        /// <summary>
        /// Get  TestPlanDetail  based on id
        /// </summary>
        /// <param name="testPlanDetailID"></param>
        /// <returns></returns>
        Task<TestPlanDetails> GetTestPlanDetailsByIdAsync(int testPlanDetailID);

        /// <summary>
        /// Get all TestPlanDetail
        /// </summary>
        /// <returns></returns>
        List<TestPlanDetails> GetAll();

        /// <summary>
        /// Get all TestPlanDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanDetails>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanDetails"></param>
        /// <returns></returns>
        bool Append(TestPlanDetails testPlanDetails);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanDetails"></param>
        /// <returns></returns>
        bool Update(TestPlanDetails testPlanDetails);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanDetailID"></param>
        /// <returns></returns>
        long Delete(int testPlanDetailID);

        Task<List<TestPlanDetails>> GetAllByTestPlanIdAsync(int testPlanId);


    }
}
