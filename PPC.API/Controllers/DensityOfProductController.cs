using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class DensityOfProductController : Controller
    {

        #region Prop

        private readonly IDensityOfProductsService _densityOfProductsService;

        #endregion

        #region Ctor

        public DensityOfProductController(IDensityOfProductsService densityOfProductsService)
        {
            _densityOfProductsService = densityOfProductsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetDensityOfProducts()
        {
            try
            {

                List<Core.Models.DensityOfProducts> densityOfProducts = await _densityOfProductsService.GetAllAsync();

                var res = densityOfProducts.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DensityOfProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<DensityOfProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DensityOfProductsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetDensityOfProductsByID(int id)
        {
            try
            {

                Core.Models.DensityOfProducts densityOfProducts = await _densityOfProductsService.GetDensityOfProductsByIdAsync(id);

                var res = (new List<Core.Models.DensityOfProducts> { densityOfProducts }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get densityOfProducts failed");
                return Ok(ResponseFactory.OKCreator(new List<DensityOfProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DensityOfProductsDTO>>(e));
            }

        }

        
        [HttpPost]
        public async Task<IActionResult> Append([FromBody] List<DensityOfProducts> densityOfProduct)
        {
            try
            {

                List<DensityOfProducts> result = _densityOfProductsService.Append(densityOfProduct);

                var res = new List<List<DensityOfProducts>> { result };

                return Ok(ResponseFactory.OKCreator<List<List<DensityOfProducts>>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DensityOfProducts append failed");
                return Ok(ResponseFactory.OKCreator<List<List<DensityOfProducts>>>(new List<List<DensityOfProducts>>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<List<DensityOfProducts>>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] DensityOfProducts densityOfProduct)
        {
            try
            {

                bool result = _densityOfProductsService.Update(densityOfProduct);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DensityOfProducts update failed");
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
                long result = _densityOfProductsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"DensityOfProducts delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDensitiesByProduct(int id)
        {
            try
            {

                List<Core.Models.DensityOfProducts> densityOfProducts = await _densityOfProductsService.GetAllByProductAsync(id);

                var res = densityOfProducts.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get DensityOfProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<DensityOfProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<DensityOfProductsDTO>>(e));
            }

        }


    }
}
