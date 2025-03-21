using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanGroupTypeAssignsService
    {

        /// <summary>
        /// Query TestPlanGroupTypeAssign
        /// </summary>
        /// <param name="testPlanGroupTypeAssignID"></param>
        /// <returns></returns>
        TestPlanGroupTypeAssigns GetTestPlanGroupTypeAssignsById(short testPlanGroupTypeAssignID);

        /// <summary>
        /// Get  TestPlanGroupTypeAssign  based on id
        /// </summary>
        /// <param name="testPlanGroupTypeAssignID"></param>
        /// <returns></returns>
        Task<TestPlanGroupTypeAssigns> GetTestPlanGroupTypeAssignsByIdAsync(short testPlanGroupTypeAssignID);

        /// <summary>
        /// Get all TestPlanGroupTypeAssign
        /// </summary>
        /// <returns></returns>
        List<TestPlanGroupTypeAssigns> GetAll();

        /// <summary>
        /// Get all TestPlanGroupTypeAssign Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanGroupTypeAssigns>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanGroupTypeAssigns"></param>
        /// <returns></returns>
        bool Append(TestPlanGroupTypeAssigns testPlanGroupTypeAssigns);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanGroupTypeAssigns"></param>
        /// <returns></returns>
        bool Update(TestPlanGroupTypeAssigns testPlanGroupTypeAssigns);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanGroupTypeAssignID"></param>
        /// <returns></returns>
        long Delete(short testPlanGroupTypeAssignID);



    }
}
