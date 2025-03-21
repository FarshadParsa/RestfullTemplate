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
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ProductTypeController : Controller
    {

        #region Prop

        private readonly IProductTypesService _productTypesService;

        #endregion

        #region Ctor

        public ProductTypeController(IProductTypesService productTypesService)
        {
            _productTypesService = productTypesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetProductTypes()
        {
            try
            {

                List<Core.Models.ProductTypes> productTypes = await _productTypesService.GetAllAsync();

                var res = productTypes.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductTypesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetProductTypesByID(short id)
        {
            try
            {

                Core.Models.ProductTypes productTypes = await _productTypesService.GetProductTypesByIdAsync(id);

                var res = (new List<Core.Models.ProductTypes> { productTypes }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductTypesDTO>>(e));
            }

        }

        [HttpGet("[controller]/ExistProductTypes/{name}")]
        public async Task<IActionResult> ExistProductTypes(string name)
        {
            try
            {

                var result = _productTypesService.ExistProductTypesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductTypes failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] ProductTypesDTO productTypes)
        {
            try
            {
                ProductTypes productType = new ProductTypes();
                var mapper = Functions.CreateMapper<ProductTypesDTO, ProductTypes>();
                productType = mapper(productTypes);

                bool result = _productTypesService.Append(productType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] ProductTypesDTO productTypes)
        {
            try
            {
                ProductTypes productType = new ProductTypes();
                var mapper = Functions.CreateMapper<ProductTypesDTO, ProductTypes>();
                productType = mapper(productTypes);

                bool result = _productTypesService.Update(productType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductTypes update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]

        public IActionResult Delete(short id)
        {
            try
            {
                long result = _productTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductTypes update failed");
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
