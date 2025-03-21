using PPC.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanIndexesService
    {

        /// <summary>
        /// Query TestPlanIndex
        /// </summary>
        /// <param name="testPlanIndexID"></param>
        /// <returns></returns>
        TestPlanIndexes GetTestPlanIndexesById(int testPlanIndexID);

        /// <summary>
        /// Get  TestPlanIndex  based on id
        /// </summary>
        /// <param name="testPlanIndexID"></param>
        /// <returns></returns>
        Task<TestPlanIndexes> GetTestPlanIndexesByIdAsync(int testPlanIndexID);

        /// <summary>
        /// Get all TestPlanIndex
        /// </summary>
        /// <returns></returns>
        List<TestPlanIndexes> GetAll();

        /// <summary>
        /// Get all TestPlanIndex Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanIndexes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanIndexes"></param>
        /// <returns></returns>
        bool Append(TestPlanIndexes testPlanIndexes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanIndexes"></param>
        /// <returns></returns>
        bool Update(TestPlanIndexes testPlanIndexes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanIndexID"></param>
        /// <returns></returns>
        long Delete(int testPlanIndexID);

        /// <summary>
        /// Existing TestPlanIndexesAsync
        /// </summary>
        /// <param name="name">testPlanIndex name</param>
        /// <returns></returns>
        Task<bool> ExistTestPlanIndexesAsync(string name);


    }
}
