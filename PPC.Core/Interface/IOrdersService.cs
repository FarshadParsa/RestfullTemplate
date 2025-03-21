using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IOrdersService
    {

        /// <summary>
        /// Query Order
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        Orders GetOrdersById(int orderID);

        /// <summary>
        /// Get  Order  based on id
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        Task<Orders> GetOrdersByIdAsync(int orderID);

        /// <summary>
        /// Get all Order
        /// </summary>
        /// <returns></returns>
        List<Orders> GetAll();

        /// <summary>
        /// Get all Order Async
        /// </summary>
        /// <returns></returns>
        Task<List<Orders>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        int Append(Orders orders);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        bool Update(Orders orders);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        long Delete(int orderID);

        /// <summary>
        /// تحویل شفارش آغاز شده است؟
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<bool> OrderDeliveryHasStarted(int orderId);

        /// <summary>
        /// برنامه ریزی سفارش آغاز شده است
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<bool> OrderPlanningHasStarted(int orderId);

        Task<List<Orders>> GetAllByRegisterDateAsync(string dateFrom, string dateTo, bool? isForiegn);

        Task<Orders> GetOrdersByNoAsync(string orderno);




        #region Planning
        Task<List<Orders>> GetAllPlanningByRegisterDateAsync(string dateFrom, string dateTo, bool? isForiegn);

        #endregion

    }
}
