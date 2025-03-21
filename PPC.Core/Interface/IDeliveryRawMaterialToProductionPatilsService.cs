using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IDeliveryRawMaterialToProductionPatilsService
    {

        /// <summary>
        /// Query DeliveryRawMaterialToProductionPatils
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionPatilID"></param>
        /// <returns></returns>
        DeliveryRawMaterialToProductionPatils GetDeliveryRawMaterialToProductionPatilsById(int deliveryRawMaterialToProductionPatilID);

        /// <summary>
        /// Get  DeliveryRawMaterialToProductionPatils  based on id
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionPatilID"></param>
        /// <returns></returns>
        Task<DeliveryRawMaterialToProductionPatils> GetDeliveryRawMaterialToProductionPatilsByIdAsync(int deliveryRawMaterialToProductionPatilID);

        /// <summary>
        /// Get all DeliveryRawMaterialToProductionPatils
        /// </summary>
        /// <returns></returns>
        List<DeliveryRawMaterialToProductionPatils> GetAll();

        /// <summary>
        /// Get all DeliveryRawMaterialToProductionPatils Async
        /// </summary>
        /// <returns></returns>
        Task<List<DeliveryRawMaterialToProductionPatils>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionPatils"></param>
        /// <returns></returns>
        int Append(DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionPatils"></param>
        /// <returns></returns>
        bool Update(DeliveryRawMaterialToProductionPatils deliveryRawMaterialToProductionPatils);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="deliveryRawMaterialToProductionPatilID"></param>
        /// <returns></returns>
        long Delete(int deliveryRawMaterialToProductionPatilID);


    }
}
