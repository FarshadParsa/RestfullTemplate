using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanBasicIndexService
    {

        /// <summary>
        /// Query TestPlanBasicIndex
        /// </summary>
        /// <param name="testPlanBasicIndexID"></param>
        /// <returns></returns>
        TestPlanBasicIndex GetTestPlanBasicIndexById(short testPlanBasicIndexID);

        /// <summary>
        /// Get  TestPlanBasicIndex  based on id
        /// </summary>
        /// <param name="testPlanBasicIndexID"></param>
        /// <returns></returns>
        Task<TestPlanBasicIndex> GetTestPlanBasicIndexByIdAsync(short testPlanBasicIndexID);

        /// <summary>
        /// Get all TestPlanBasicIndex
        /// </summary>
        /// <returns></returns>
        List<TestPlanBasicIndex> GetAll();

        /// <summary>
        /// Get all TestPlanBasicIndex Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanBasicIndex>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanBasicIndex"></param>
        /// <returns></returns>
        short Append(TestPlanBasicIndex testPlanBasicIndex);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanBasicIndex"></param>
        /// <returns></returns>
        bool Update(TestPlanBasicIndex testPlanBasicIndex);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanBasicIndexID"></param>
        /// <returns></returns>
        long Delete(short testPlanBasicIndexID);

    }
}
