using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PPC.Core.Interface
{
    public interface IPackagingTypesService
    {

        /// <summary>
        /// Query PackagingType
        /// </summary>
        /// <param name="packagingTypeID"></param>
        /// <returns></returns>
        PackagingTypes GetPackagingTypesById(int packagingTypeID);

        /// <summary>
        /// Get  PackagingType  based on id
        /// </summary>
        /// <param name="packagingTypeID"></param>
        /// <returns></returns>
        Task<PackagingTypes> GetPackagingTypesByIdAsync(int packagingTypeID);

        /// <summary>
        /// Get all PackagingType
        /// </summary>
        /// <returns></returns>
        List<PackagingTypes> GetAll();

        /// <summary>
        /// Get all PackagingType Async
        /// </summary>
        /// <returns></returns>
        Task<List<PackagingTypes>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="packagingTypes"></param>
        /// <returns></returns>
        int Append(PackagingTypes packagingTypes);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="packagingTypes"></param>
        /// <returns></returns>
        bool Update(PackagingTypes packagingTypes);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="packagingTypeID"></param>
        /// <returns></returns>
        long Delete(int packagingTypeID);



    }
}
