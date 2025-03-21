using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlansService
    {

        /// <summary>
        /// Query TestPlan
        /// </summary>
        /// <param name="testPlanID"></param>
        /// <returns></returns>
        TestPlans GetTestPlansById(int testPlanID);

        /// <summary>
        /// Get  TestPlan  based on id
        /// </summary>
        /// <param name="testPlanID"></param>
        /// <returns></returns>
        Task<TestPlans> GetTestPlansByIdAsync(int testPlanID);

        /// <summary>
        /// Get all TestPlan
        /// </summary>
        /// <returns></returns>
        List<TestPlans> GetAll();

        /// <summary>
        /// Get all TestPlan Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlans>> GetAllAsync();



        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlans"></param>
        /// <returns></returns>
        int Append(TestPlans testPlans);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlans"></param>
        /// <returns></returns>
        bool Update(TestPlans testPlans);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanID"></param>
        /// <returns></returns>
        long Delete(int testPlanID);

        /// <summary>
        /// Existing TestPlansAsync
        /// </summary>
        /// <param name="name">testPlan name</param>
        /// <returns></returns>
        Task<bool> ExistTestPlansAsync(string name);


        /// <summary>
        /// Get Max Code
        /// </summary>
        /// <param id="id">TestPlan Group ID</param>
        /// <returns></returns>
        Task<TestPlans> GetTestPlanMaxCodeByProductGroupID(short productGroupID, string codeChar);

        Task<TestPlans> GetTestPlanMaxCodeByRawMaterialGroupTypeID(short rawMaterialGroupTypeID, string codeChar);

        Task<List<TestPlans>> GetTestPlansForCombo();

        /// <summary>
        /// Get all Latest TestPlan Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlans>> GetLatestTestPlansAsync();

        Task<List<TestPlans>> GetListForDropDownAsync();

        Task<TestPlans> GetLatestTestPlansByIdAsync(int testPlanID);
        Task<TestPlans> GetTestPlanMaxCodeByCodeChar(string codeChar);
        Task<List<TestPlans>> GetAllForDropDownAsync();
    }
}

