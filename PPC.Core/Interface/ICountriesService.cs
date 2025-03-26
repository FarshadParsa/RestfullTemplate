using WebApi.Core.Models;
using WebApi.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Core.Interface
{
    public interface ICountriesService
    {

        /// <summary>
        /// Query Country
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        Countries GetCountriesById(short countryID);

        /// <summary>
        /// Get  Country  based on id
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        Task<Countries> GetCountriesByIdAsync(short countryID);

        /// <summary>
        /// Get all Country
        /// </summary>
        /// <returns></returns>
        List<Countries> GetAll();

        /// <summary>
        /// Get all Country Async
        /// </summary>
        /// <returns></returns>
        Task<List<Countries>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        bool Append(Countries countries);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        bool Update(Countries countries);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns></returns>
        long Delete(short countryID);

        /// <summary>
        /// Existing CountriesAsync
        /// </summary>
        /// <param name="name">country name</param>
        /// <returns></returns>
        Task<bool> ExistCountriesAsync(string name);


    }
}
