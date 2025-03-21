using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IOrderDetailPackagingsService
    {

        /// <summary>
        /// Query OrderDetailPackaging
        /// </summary>
        /// <param name="orderDetailPackagingID"></param>
        /// <returns></returns>
        OrderDetailPackagings GetOrderDetailPackagingsById(int orderDetailPackagingID);

        /// <summary>
        /// Get  OrderDetailPackaging  based on id
        /// </summary>
        /// <param name="orderDetailPackagingID"></param>
        /// <returns></returns>
        Task<OrderDetailPackagings> GetOrderDetailPackagingsByIdAsync(int orderDetailPackagingID);

        /// <summary>
        /// Get all OrderDetailPackaging
        /// </summary>
        /// <returns></returns>
        List<OrderDetailPackagings> GetAll();

        /// <summary>
        /// Get all OrderDetailPackaging Async
        /// </summary>
        /// <returns></returns>
        Task<List<OrderDetailPackagings>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="orderDetailPackagings"></param>
        /// <returns></returns>
        int Append(OrderDetailPackagings orderDetailPackagings);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="orderDetailPackagings"></param>
        /// <returns></returns>
        bool Update(OrderDetailPackagings orderDetailPackagings);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="orderDetailPackagingID"></param>
        /// <returns></returns>
        long Delete(int orderDetailPackagingID);



    }
}
