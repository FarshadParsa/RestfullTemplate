using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanCodeCharService
    {

        /// <summary>
        /// Query TestPlanCodeChar
        /// </summary>
        /// <param name="testPlanCodeCharID"></param>
        /// <returns></returns>
        TestPlanCodeChar GetTestPlanCodeCharById(short testPlanCodeCharID);

        /// <summary>
        /// Get  TestPlanCodeChar  based on id
        /// </summary>
        /// <param name="testPlanCodeCharID"></param>
        /// <returns></returns>
        Task<TestPlanCodeChar> GetTestPlanCodeCharByIdAsync(short testPlanCodeCharID);

        /// <summary>
        /// Get all TestPlanCodeChar
        /// </summary>
        /// <returns></returns>
        List<TestPlanCodeChar> GetAll();

        /// <summary>
        /// Get all TestPlanCodeChar Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanCodeChar>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanCodeChar"></param>
        /// <returns></returns>
        short Append(TestPlanCodeChar testPlanCodeChar);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanCodeChar"></param>
        /// <returns></returns>
        bool Update(TestPlanCodeChar testPlanCodeChar);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanCodeCharID"></param>
        /// <returns></returns>
        long Delete(short testPlanCodeCharID);

        /// <summary>
        /// Existing TestPlanCodeCharAsync
        /// </summary>
        /// <param name="name">testPlanCodeChar name</param>
        /// <returns></returns>
        Task<bool> ExistTestPlanCodeCharAsync(string code);


    }
}
