using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDeliveryRawMaterialToProductionService
    {

        /// <summary>
        /// Query DeliveryRawMaterialToProduction
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionID"></param>
        /// <returns></returns>
        DeliveryRawMaterialToProduction GetDeliveryRawMaterialToProductionById(int deliveryRawMaterialToProductionID);

        /// <summary>
        /// Get  DeliveryRawMaterialToProduction  based on id
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionID"></param>
        /// <returns></returns>
        Task<DeliveryRawMaterialToProduction> GetDeliveryRawMaterialToProductionByIdAsync(int deliveryRawMaterialToProductionID);

        /// <summary>
        /// Get all DeliveryRawMaterialToProduction
        /// </summary>
        /// <returns></returns>
        List<DeliveryRawMaterialToProduction> GetAll();

        /// <summary>
        /// Get all DeliveryRawMaterialToProduction Async
        /// </summary>
        /// <returns></returns>
        Task<List<DeliveryRawMaterialToProduction>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProduction"></param>
        /// <returns></returns>
        int Append(DeliveryRawMaterialToProduction deliveryRawMaterialToProduction);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProduction"></param>
        /// <returns></returns>
        bool Update(DeliveryRawMaterialToProduction deliveryRawMaterialToProduction);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionID"></param>
        /// <returns></returns>
        long Delete(int deliveryRawMaterialToProductionID);

        int? GetMaxRequestNo();

        Task<List<DeliveryRawMaterialToProduction>> GetRawMaterialToProductionDeliveryListAsync();

        Task<List<DeliveryRawMaterialToProduction>> GetListByStatus(byte status, string dateFrom, string dateTo);

    }
}
