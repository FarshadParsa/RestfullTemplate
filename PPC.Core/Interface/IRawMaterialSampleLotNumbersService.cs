using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IRawMaterialLotNumbersService
    {

        /// <summary>
        /// Query RawMaterialLotNumber
        /// </summary>
        /// <param name="rawMaterialLotNumberID"></param>
        /// <returns></returns>
        RawMaterialLotNumbers GetRawMaterialLotNumbersById(int rawMaterialLotNumberID);

        /// <summary>
        /// Get  RawMaterialLotNumber  based on id
        /// </summary>
        /// <param name="rawMaterialLotNumberID"></param>
        /// <returns></returns>
        Task<RawMaterialLotNumbers> GetRawMaterialLotNumbersByIdAsync(int rawMaterialLotNumberID);

        /// <summary>
        /// Get all RawMaterialLotNumber
        /// </summary>
        /// <returns></returns>
        List<RawMaterialLotNumbers> GetAll();

        /// <summary>
        /// Get all RawMaterialLotNumber Async
        /// </summary>
        /// <returns></returns>
        Task<List<RawMaterialLotNumbers>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="rawMaterialLotNumbers"></param>
        /// <returns></returns>
        int Append(RawMaterialLotNumbers rawMaterialLotNumbers);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="rawMaterialLotNumbers"></param>
        /// <returns></returns>
        bool Update(RawMaterialLotNumbers rawMaterialLotNumbers);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="rawMaterialLotNumberID"></param>
        /// <returns></returns>
        long Delete(int rawMaterialLotNumberID);

        /// <summary>
        /// GetInstanceByLotNo
        /// </summary>
        /// <param name="name">rawMaterialLotNumber name</param>
        /// <returns></returns>
        Task<RawMaterialLotNumbers> GetInstanceByLotNoAsync(string lotNo);


    }
}
