using Microsoft.AspNetCore.Mvc;

using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PPC.Base.Models.Exceptions;
using PPC.Base;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.API.Controllers
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ProductSerieController : Controller
    {

        #region Prop

        private readonly IProductSeriesService _productSeriesService;

        #endregion

        #region Ctor

        public ProductSerieController(IProductSeriesService productSeriesService)
        {
            _productSeriesService = productSeriesService;
        }

        #endregion

        [HttpGet]
        [Route("[controller]/[action]/{getPrintingTechnique?}/{showParent?}")]
        public async Task<IActionResult> GetProductSeries(bool getPrintingTechnique = false, bool showParent = true)
        {
            try
            {
                List<Core.Models.ProductSeries> productSeries;

                if (showParent)
                    productSeries = await _productSeriesService.GetAllParentAsync(getPrintingTechnique);
                else
                    productSeries = await _productSeriesService.GetAllAsync(getPrintingTechnique);

                var res = productSeries.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductSeries List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductSeriesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductSeriesDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetProductSeriesByID(int id)
        {
            try
            {

                Core.Models.ProductSeries productSeries = await _productSeriesService.GetProductSeriesByIdAsync(id);

                var res = (new List<Core.Models.ProductSeries> { productSeries }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productSeries failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductSeriesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductSeriesDTO>>(e));
            }

        }

        //[HttpGet]

        [HttpGet("[controller]/ExistProductSeries/{name}")]
        public async Task<IActionResult> ExistProductSeries(string name)
        {
            try
            {

                var result = _productSeriesService.ExistProductSeriesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductSeries failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] ProductSeries productSerie)
        {
            try
            {
                //ProductSeries productSerie = new ProductSeries();
                //var mapper = Functions.CreateMapper<ProductSeriesDTO, ProductSeries>();
                //productSerie = mapper(productSeries);

                int result = _productSeriesService.Append(productSerie);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductSeries append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] ProductSeries productSerie)
        {
            try
            {
                //ProductSeries productSerie = new ProductSeries();
                //var mapper = Functions.CreateMapper<ProductSeriesDTO, ProductSeries>();
                //productSerie = mapper(productSeries);

                bool result = _productSeriesService.Update(productSerie);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductSeries update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            try
            {
                long result = _productSeriesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductSeries update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

    }
}
