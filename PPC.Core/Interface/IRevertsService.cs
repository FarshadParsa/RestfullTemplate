using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
namespace PPC.Core.Interface
{
    public interface IRevertsService
    {

        /// <summary>
        /// Query Reverts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Reverts GetRevertsById(int id);

        /// <summary>
        /// Get  Reverts  based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Reverts> GetRevertsByIdAsync(int id);

        /// <summary>
        /// Get all Reverts
        /// </summary>
        /// <returns></returns>
        List<Reverts> GetList();

        /// <summary>
        /// Get all Reverts Async
        /// </summary>
        /// <returns></returns>
        Task<List<Reverts>> GetListAsync(
            Expression<Func<Reverts, bool>> predicate = null,
            params Expression<Func<Reverts, object>>[] includes);


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="reverts"></param>
        /// <returns></returns>
        int Append(Reverts reverts);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="reverts"></param>
        /// <returns></returns>
        bool Update(Reverts reverts);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long Delete(int id);

        Task<List<Reverts>> GetListByDate(
            string dateFrom,
            string dateTo,
            params Expression<Func<Reverts, object>>[] includes);



    }
}
