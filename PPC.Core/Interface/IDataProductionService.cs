using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataProductionService
    {

        /// <summary>
        /// Query DataProduction
        /// </summary>
        /// <param name="dataProductionID"></param>
        /// <returns></returns>
        DataProduction GetDataProductionById(int dataProductionID);

        /// <summary>
        /// Get  DataProduction  based on id
        /// </summary>
        /// <param name="dataProductionID"></param>
        /// <returns></returns>
        Task<DataProduction> GetDataProductionByIdAsync(int dataProductionID);

        /// <summary>
        /// Get all DataProduction
        /// </summary>
        /// <returns></returns>
        List<DataProduction> GetAll();

        /// <summary>
        /// Get all DataProduction Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataProduction>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataProduction"></param>
        /// <returns></returns>
        int Append(DataProduction dataProduction);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataProduction"></param>
        /// <returns></returns>
        bool Update(DataProduction dataProduction);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataProductionID"></param>
        /// <returns></returns>
        long Delete(int dataProductionID);

        Task<DataProduction> GetByProductionPlanPatilIdAsync(int productionPlanPatilId);

    }
}
