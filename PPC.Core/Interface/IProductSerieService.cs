using PPC.Core.Models;
using PPC.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductSeriesService
    {

        /// <summary>
        /// Query ProductSerie
        /// </summary>
        /// <param name="productSerieID"></param>
        /// <returns></returns>
        ProductSeries GetProductSeriesById(int productSerieID);

        /// <summary>
        /// Get  ProductSerie  based on id
        /// </summary>
        /// <param name="productSerieID"></param>
        /// <returns></returns>
        Task<ProductSeries> GetProductSeriesByIdAsync(int productSerieID);

        /// <summary>
        /// Get all ProductSerie
        /// </summary>
        /// <returns></returns>
        List<ProductSeries> GetAll();

        /// <summary>
        /// Get all ProductSerie Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSeries>> GetAllAsync(bool getPrintingTechniques = false);


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productSeries"></param>
        /// <returns></returns>
        int Append(ProductSeries productSeries);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productSeries"></param>
        /// <returns></returns>
        bool Update(ProductSeries productSeries);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productSerieID"></param>
        /// <returns></returns>
        long Delete(int productSerieID);

        /// <summary>
        /// Existing ProductSeriesAsync
        /// </summary>
        /// <param name="name">productSerie name</param>
        /// <returns></returns>
        Task<bool> ExistProductSeriesAsync(string name);

        /// <summary>
        /// Get all ProductSerie Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSeries>> GetAllParentAsync(bool getPrintingTechniques = false);


    }
}


/*
using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IProductSeriesService
    {

        /// <summary>
        /// Query ProductSerie
        /// </summary>
        /// <param name="productSerieID"></param>
        /// <returns></returns>
        ProductSeries GetProductSeriesById(int productSerieID);

        /// <summary>
        /// Get  ProductSerie  based on id
        /// </summary>
        /// <param name="productSerieID"></param>
        /// <returns></returns>
        Task<ProductSeries> GetProductSeriesByIdAsync(int productSerieID);

        /// <summary>
        /// Get all ProductSerie
        /// </summary>
        /// <returns></returns>
        List<ProductSeries> GetAll(bool getPrintingTechniques = false);

        /// <summary>
        /// Get all ProductSerie Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSeries>> GetAllAsync(bool getPrintingTechniques = false);


        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="productSeries"></param>
        /// <returns></returns>
        bool Append(ProductSeries productSeries);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="productSeries"></param>
        /// <returns></returns>
        bool Update(ProductSeries productSeries);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="productSerieID"></param>
        /// <returns></returns>
        long Delete(int productSerieID);

        /// <summary>
        /// Existing ProductSeriesAsync
        /// </summary>
        /// <param name="name">productSerie name</param>
        /// <returns></returns>
        Task<bool> ExistProductSeriesAsync(string name);

        /// <summary>
        /// Get all ProductSerie Async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductSeries>> GetAllParentAsync(bool getPrintingTechniques = false);


    }
}
*/