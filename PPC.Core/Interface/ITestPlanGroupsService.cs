using PPC.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ITestPlanGroupsService
    {

        /// <summary>
        /// Query TestPlanGroup
        /// </summary>
        /// <param name="testPlanGroupID"></param>
        /// <returns></returns>
        TestPlanGroups GetTestPlanGroupsById(byte testPlanGroupID);

        /// <summary>
        /// Get  TestPlanGroup  based on id
        /// </summary>
        /// <param name="testPlanGroupID"></param>
        /// <returns></returns>
        Task<TestPlanGroups> GetTestPlanGroupsByIdAsync(byte testPlanGroupID);

        /// <summary>
        /// Get all TestPlanGroup
        /// </summary>
        /// <returns></returns>
        List<TestPlanGroups> GetAll();

        /// <summary>
        /// Get all TestPlanGroup Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanGroups>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="testPlanGroups"></param>
        /// <returns></returns>
        bool Append(TestPlanGroups testPlanGroups);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="testPlanGroups"></param>
        /// <returns></returns>
        bool Update(TestPlanGroups testPlanGroups);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="testPlanGroupID"></param>
        /// <returns></returns>
        long Delete(byte testPlanGroupID);

        /// <summary>
        /// Existing TestPlanGroupsAsync
        /// </summary>
        /// <param name="name">testPlanGroup name</param>
        /// <returns></returns>
        Task<bool> ExistTestPlanGroupsAsync(string name);


        /// <summary>
        /// Get all TestPlanGroup by EntranceTypeId Async
        /// </summary>
        /// <returns></returns>
        Task<List<TestPlanGroups>> GetAllByEntranceTypeAsync(byte id);


    }
}
