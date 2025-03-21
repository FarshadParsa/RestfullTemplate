using Microsoft.AspNetCore.Mvc;

using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PPC.Base.Models.Exceptions;
using PPC.Base;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ProductGroupTypeController : Controller
    {

        #region Prop

        private readonly IProductGroupTypesService _productGroupTypesService;

        #endregion

        #region Ctor

        public ProductGroupTypeController(IProductGroupTypesService productGroupTypesService)
        {
            _productGroupTypesService = productGroupTypesService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductGroupTypes()
        {
            try
            {

                List<Core.Models.ProductGroupTypes> productGroupTypes = await _productGroupTypesService.GetAllAsync();

                var res = productGroupTypes.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductGroupTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductGroupTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductGroupTypesDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductGroupTypesByID(short id)
        {
            try
            {

                Core.Models.ProductGroupTypes productGroupTypes = await _productGroupTypesService.GetProductGroupTypesByIdAsync(id);

                var res = (new List<Core.Models.ProductGroupTypes> { productGroupTypes }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productGroupTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductGroupTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductGroupTypesDTO>>(e));
            }

        }

        //[HttpGet]
        [HttpGet("[controller]/ExistProductGroupTypes/{name}")]
        public async Task<IActionResult> ExistProductGroupTypes(string name)
        {
            try
            {

                var result = _productGroupTypesService.ExistProductGroupTypesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductGroupTypes failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public IActionResult Append([FromBody] ProductGroupTypesDTO productGroupTypes)
        {
            try
            {
                ProductGroupTypes productGroupType = new ProductGroupTypes();
                var mapper = Functions.CreateMapper<ProductGroupTypesDTO, ProductGroupTypes>();
                productGroupType = mapper(productGroupTypes);

                bool result = _productGroupTypesService.Append(productGroupType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductGroupTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductGroupTypesDTO productGroupTypes)
        {
            try
            {
                ProductGroupTypes productGroupType = new ProductGroupTypes();
                var mapper = Functions.CreateMapper<ProductGroupTypesDTO, ProductGroupTypes>();
                productGroupType = mapper(productGroupTypes);

                bool result = _productGroupTypesService.Update(productGroupType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductGroupTypes update failed");
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
                long result = _productGroupTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductGroupTypes update failed");
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
