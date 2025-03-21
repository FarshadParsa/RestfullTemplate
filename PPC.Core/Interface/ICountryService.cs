using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface ICountryService
    {

        /// <summary>
        /// Query countrys 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        Country GetCountryById(int countryId);

        /// <summary>
        /// Get Country  based on id
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        Task<Country> GetCountryByIdAsync(int countryId);

        /// <summary>
        /// Find Country
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Country FindCountry(string countryname);

        /// <summary>
        /// Find Country Async
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<Country> FindCountryAsync(string countryname);

        /// <summary>
        /// Get all Units
        /// </summary>
        /// <returns></returns>
        List<Country> GetAll();

        /// <summary>
        /// Get all Units Async
        /// </summary>
        /// <returns></returns>
        List<Country> GetAllAsync();

        bool Append(Country country);
        bool Update(Country country);
        long DeleteCountry(int countryId);



    }
}
