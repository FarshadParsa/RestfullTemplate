using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanAssignDetailService
    {

        /// <summary>
        /// Query TestPlanAssignDetail
        /// </summary>
        /// <param name="testPlanAssignDetailID"></param>
        /// <returns></returns>
        TestPlanAssignDetail GetTestPlanAssignDetailById(int testPlanAssignDetailID);

        /// <summary>
        /// Get  TestPlanAssignDetail  based on id
        /// </summary>
        /// <param name="testPlanAssignDetailID"></param>
        /// <returns></returns>
        Task<TestPlanAssignDetail> GetTestPlanAssignDetailByIdAsync(int testPlanAssignDetailID);

        /// <summary>
        /// Get all TestPlanAssignDetail
        /// </summary>
        /// <returns></returns>
        List<TestPlanAssignDetail> GetAll();

        /// <summary>
        /// Get all TestPlanAssignDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanAssignDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanAssignDetail"></param>
        /// <returns></returns>
        int Append(TestPlanAssignDetail testPlanAssignDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanAssignDetail"></param>
        /// <returns></returns>
        bool Update(TestPlanAssignDetail testPlanAssignDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanAssignDetailID"></param>
        /// <returns></returns>
        long Delete(int testPlanAssignDetailID);

        ///// <summary>
        ///// Existing TestPlanAssignDetailAsync
        ///// </summary>
        ///// <param name="name">testPlanAssignDetail name</param>
        ///// <returns></returns>
        //Task<bool> ExistTestPlanAssignDetailAsync(string name);

        Task<List<TestPlanAssignDetail>> GetListByTestPlanAssignIdAsync(int testPlanAssignId);


    }
}
