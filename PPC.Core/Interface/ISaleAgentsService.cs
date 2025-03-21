using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ISaleAgentsService
    {

        /// <summary>
        /// Query SaleAgent
        /// </summary>
        /// <param name="saleAgentID"></param>
        /// <returns></returns>
        SaleAgents GetSaleAgentsById(short saleAgentID);

        /// <summary>
        /// Get  SaleAgent  based on id
        /// </summary>
        /// <param name="saleAgentID"></param>
        /// <returns></returns>
        Task<SaleAgents> GetSaleAgentsByIdAsync(short saleAgentID);

        /// <summary>
        /// Get all SaleAgent
        /// </summary>
        /// <returns></returns>
        List<SaleAgents> GetAll();

        /// <summary>
        /// Get all SaleAgent Async
        /// </summary>
        /// <returns></returns>
        Task<List<SaleAgents>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="saleAgents"></param>
        /// <returns></returns>
        bool Append(SaleAgents saleAgents);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="saleAgents"></param>
        /// <returns></returns>
        bool Update(SaleAgents saleAgents);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="saleAgentID"></param>
        /// <returns></returns>
        long Delete(short saleAgentID);

        /// <summary>
        /// Existing SaleAgentsAsync
        /// </summary>
        /// <param name="name">saleAgent name</param>
        /// <returns></returns>
        Task<bool> ExistSaleAgentsAsync(string name);

        /// <summary>
        /// Get  SaleAgent  based on code
        /// </summary>
        /// <param name="saleAgentCode"></param>
        /// <returns></returns>
        Task<SaleAgents> GetSaleAgentsByCodeAsync(string saleAgentCode);

        /// <summary>
        /// Get  SaleAgent  based on name
        /// </summary>
        /// <param name="saleAgentName"></param>
        /// <returns></returns>
        Task<SaleAgents> GetSaleAgentsByNameAsync(string saleAgentName);


    }
}
