using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IRawMaterialLotsInventoryService
    {

        /// <summary>
        /// Query RawMaterialLotsInventory
        /// </summary>
        /// <param name="lotNo"></param>
        /// <returns></returns>
        RawMaterialLotsInventory GetInstanceByLotNo(string lotNo);

        /// <summary>
        /// Get  RawMaterialLotsInventory  based on id
        /// </summary>
        /// <param name="lotNo"></param>
        /// <returns></returns>
        Task<RawMaterialLotsInventory> GetInstanceByLotNoAsync(string lotNo);

        /// <summary>
        /// Get all RawMaterialLotsInventory
        /// </summary>
        /// <returns></returns>
        List<RawMaterialLotsInventory> GetAll();

        /// <summary>
        /// Get all RawMaterialLotsInventory Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialLotsInventory>> GetAllAsync();

        Task<List<RawMaterialLotsInventory>> GetListByRawMaterialIDAsync(int rawMaterialId);

        /// <summary>
        /// لیست مواد خام دارای موجودی به تفکیک لات نامبر
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        Task<List<RawMaterialLotsInventory>> GetInWarehouseListByRawMaterialIDAsync(int rawMaterialId);

        /// <summary>
        /// لیست مواد خام دارای موجودی به تفکیک لات نامبر
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        Task<List<RawMaterialLotsInventory>> GetInWarehouseListByRawMaterialIDsAsync(List<int> rawMaterialIdList);

        /// <summary>
        /// دریافت لیست مواد اولیه بر اساس قدیمی ترین تاریخ انقضا بوسیله مجموعه ای از شناسه های مواد اولیه
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        Task<List<RawMaterialLotsInventory>> GetOldestRawMaterialListByRawMaterialIDsAsync(List<int> rawMaterialIdList);

        /// <summary>
        /// لیست مواد خام دارای موجودی به تفکیک لات نامبر
        /// </summary>
        /// <param name="rawMaterialId"></param>
        /// <returns></returns>
        Task<List<RawMaterialLotsInventory>> GetInWarehouseListAsync();



    }
}
