using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDataDosingDetailService
    {

        /// <summary>
        /// Query DataDosingDetail
        /// </summary>
        /// <param name="dataDosingDetailID"></param>
        /// <returns></returns>
        DataDosingDetail GetDataDosingDetailById(int dataDosingDetailID);

        /// <summary>
        /// Get  DataDosingDetail  based on id
        /// </summary>
        /// <param name="dataDosingDetailID"></param>
        /// <returns></returns>
        Task<DataDosingDetail> GetDataDosingDetailByIdAsync(int dataDosingDetailID);

        /// <summary>
        /// Get all DataDosingDetail
        /// </summary>
        /// <returns></returns>
        List<DataDosingDetail> GetAll();

        /// <summary>
        /// Get all DataDosingDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<DataDosingDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="dataDosingDetail"></param>
        /// <returns></returns>
        int Append(DataDosingDetail dataDosingDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="dataDosingDetail"></param>
        /// <returns></returns>
        bool Update(DataDosingDetail dataDosingDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="dataDosingDetailID"></param>
        /// <returns></returns>
        long Delete(int dataDosingDetailID);


        Task<List<DataDosingDetail>> GetListByDataProductionIdAsync(int dataProductionId);

    }
}
