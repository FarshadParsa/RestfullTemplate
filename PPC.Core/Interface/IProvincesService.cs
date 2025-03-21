using Microsoft.AspNetCore.Mvc;
using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProvincesService
    {

        /// <summary>
        /// Query Province
        /// </summary>
        /// <param name="provinceID"></param>
        /// <returns></returns>
        Provinces GetProvincesById(short provinceID);

        /// <summary>
        /// Get  Province  based on id
        /// </summary>
        /// <param name="provinceID"></param>
        /// <returns></returns>
        Task<Provinces> GetProvincesByIdAsync(short provinceID);

        /// <summary>
        /// Get all Province
        /// </summary>
        /// <returns></returns>
        List<Provinces> GetAll();

        /// <summary>
        /// Get all Province Async
        /// </summary>
        /// <returns></returns>
        Task<List<Provinces>> GetAllAsync();


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="provinces"></param>
        /// <returns></returns>
        bool Append(Provinces provinces);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="provinces"></param>
        /// <returns></returns>
        bool Update(Provinces provinces);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="provinceID"></param>
        /// <returns></returns>
        long Delete(short provinceID);

        /// <summary>
        /// Existing ProvincesAsync
        /// </summary>
        /// <param name="name">province name</param>
        /// <returns></returns>
        Task<bool> ExistProvincesAsync(string name);

        /// <summary>
        /// Existing Provinces code Async
        /// </summary>
        /// <param name="code">province code</param>
        /// <returns></returns>
        Task<bool> ExistProvincesCodeAsync(string code);

        /// <summary>
        /// Get  Province  by code
        /// </summary>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        Task<Provinces> GetProvincesByCodeAsync(string provinceCode);

        /// <summary>
        /// Get  Province  by name
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        Task<Provinces> GetProvincesByNameAsync(string provinceName);

        Task<List<Provinces>> GetActiveProvincesAsync();

        /// <summary>
        /// Get all Province Async
        /// </summary>
        /// <returns></returns>
        Task<List<Provinces>> GetAllByCountryIDAsync(short countryID);


    }
}
