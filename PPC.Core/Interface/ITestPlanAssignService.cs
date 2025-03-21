using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanAssignService
    {

        /// <summary>
        /// Query TestPlanAssign
        /// </summary>
        /// <param name="testPlanAssignID"></param>
        /// <returns></returns>
        TestPlanAssign GetTestPlanAssignById(int testPlanAssignID);

        /// <summary>
        /// Get  TestPlanAssign  based on id
        /// </summary>
        /// <param name="testPlanAssignID"></param>
        /// <returns></returns>
        Task<TestPlanAssign> GetTestPlanAssignByIdAsync(int testPlanAssignID);

        /// <summary>
        /// Get all TestPlanAssign
        /// </summary>
        /// <returns></returns>
        List<TestPlanAssign> GetAll();

        /// <summary>
        /// Get all TestPlanAssign Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanAssign>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanAssign"></param>
        /// <returns></returns>
        int Append(TestPlanAssign testPlanAssign);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanAssign"></param>
        /// <returns></returns>
        bool Update(TestPlanAssign testPlanAssign);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanAssignID"></param>
        /// <returns></returns>
        long Delete(int testPlanAssignID);

        /// <summary>
        /// Existing TestPlanAssignAsync
        /// </summary>
        /// <param code="TestPlanAssign code">testPlanAssign name</param>
        /// <returns></returns>
        Task<TestPlanAssign> ExistTestPlanAssignAsync(string code);

        //Task<List<TestPlanAssignViewModel>> GetAllForDropDownAsync();

        Task<TestPlanAssign> GetLatestTestPlanAssignByTestPlanCodeAsync(string testPlanCode);

        Task<TestPlanAssign> GetLatestTestPlanAssignByTestPlanIdAsync(int testPlanId);


    }
}
