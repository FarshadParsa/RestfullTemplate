using Microsoft.AspNetCore.Mvc;
using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProvinceService
    {

        /// <summary>
        /// Query Provience
        /// </summary>
        /// <returns></returns>
        List<Province> GetActiveProvinces();

        /// <summary>
        /// Query Provience
        /// </summary>
        /// <returns></returns>
        Task<IActionResult> GetActiveProvincesAsync();

        /// <summary>
        /// Query Provience
        /// </summary>
        /// <returns></returns>
        List<Province> GetProvinces();

        /// <summary>
        /// Query Provience
        /// </summary>
        /// <returns></returns>
        List<Province> GetProvincesAsync();

        /// <summary>
        /// Query provinceType 
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        Province FindProvince(int provinceId);

        /// <summary>
        /// Get Province  based on id
        /// </summary>
        /// <param name="provinceId"></param>
        /// <returns></returns>
        Task<Province> FindProvinceAsync(int provinceId);

        /// <summary>
        /// Query provinceType 
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        Province FindProvince(string provinceName);

        /// <summary>
        /// Find Province Async
        /// </summary>
        /// <param name="provinceName"></param>
        /// <returns></returns>
        Task<Province> FindProvinceAsync(string provincename);


        bool Append(Province province);
        bool Update(Province province);
        long Delete(int provinceId);




    }
}
