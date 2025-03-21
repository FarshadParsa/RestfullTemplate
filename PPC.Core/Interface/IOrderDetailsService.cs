using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IOrderDetailsService
    {

        /// <summary>
        /// Query OrderDetail
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        OrderDetails GetOrderDetailsById(int orderDetailID);

        /// <summary>
        /// Get  OrderDetail  based on id
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        Task<OrderDetails> GetOrderDetailsByIdAsync(int orderDetailID);

        /// <summary>
        /// Get all OrderDetail
        /// </summary>
        /// <returns></returns>
        List<OrderDetails> GetAll();

        /// <summary>
        /// Get all OrderDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<OrderDetails>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        int Append(OrderDetails orderDetails);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        bool Update(OrderDetails orderDetails);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        long Delete(int orderDetailID);

        /// <summary>
        /// Existing OrderDetailsAsync
        /// </summary>
        /// <param name="name">orderDetail name</param>
        /// <returns></returns>
        Task<bool> ExistOrderDetailsAsync(int id);

        Task<List<OrderDetails>> GetAllByOrderIdAsync(int orderId);

        Task<List<OrderDetails>> GetDropdownList();


        /// <summary>
        /// لیست جزییات سفارشات دارای برنامه تولید
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        Task<List<OrderDetails>> GetPlannedListAsync(string dateFrom, string dateTo, List<byte> orderStatus = null);

        Task<List<OrderDetails>> GetListToAssignBOMAsync(string startDate, string endDate);

        /// <summary>
        /// اطلاعات جهت تغییر سفارش
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<OrderDetails>> GetForSearchByProductId(int productId);


    }
}
