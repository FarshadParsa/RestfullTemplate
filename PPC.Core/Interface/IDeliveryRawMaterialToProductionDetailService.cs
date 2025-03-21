using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDeliveryRawMaterialToProductionDetailService
    {

        /// <summary>
        /// Query DeliveryRawMaterialToProductionDetail
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionDetailID"></param>
        /// <returns></returns>
        DeliveryRawMaterialToProductionDetail GetDeliveryRawMaterialToProductionDetailById(int deliveryRawMaterialToProductionDetailID);

        /// <summary>
        /// Get  DeliveryRawMaterialToProductionDetail  based on id
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionDetailID"></param>
        /// <returns></returns>
        Task<DeliveryRawMaterialToProductionDetail> GetDeliveryRawMaterialToProductionDetailByIdAsync(int deliveryRawMaterialToProductionDetailID);

        /// <summary>
        /// Get all DeliveryRawMaterialToProductionDetail
        /// </summary>
        /// <returns></returns>
        List<DeliveryRawMaterialToProductionDetail> GetAll();

        /// <summary>
        /// Get all DeliveryRawMaterialToProductionDetail Async
        /// </summary>
        /// <returns></returns>
        Task<List<DeliveryRawMaterialToProductionDetail>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionDetail"></param>
        /// <returns></returns>
        int Append(DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionDetail"></param>
        /// <returns></returns>
        bool Update(DeliveryRawMaterialToProductionDetail deliveryRawMaterialToProductionDetail);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionDetailID"></param>
        /// <returns></returns>
        long Delete(int deliveryRawMaterialToProductionDetailID);

        /// <summary>
        /// دریافت لیست مواد جهت ارسال به تولید
        /// </summary>
        /// <returns>List of DeliveryRawMaterialToProduction with detail </returns>
        Task<List<DeliveryRawMaterialToProductionDetail>> GetAllToProductionDeliveryAsync();

        /// <summary>
        /// GetRawMaterialToProductionDeliveryListByDeliveryRawMaterialToProductionId
        /// </summary>
        /// <param name="DeliveryRawMaterialToProductionId">DeliveryRawMaterialToProductionId</param>
        /// <returns></returns>
        Task<List<DeliveryRawMaterialToProductionDetail>> GetRawMaterialToProductionDeliveryListByDRMPId(int deliveryRawMaterialToProductionId);


    }
}
