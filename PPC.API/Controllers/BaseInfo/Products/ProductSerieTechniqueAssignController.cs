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
    public class ProductSerieTechniqueAssignController : Controller
    {

        #region Prop

        private readonly IProductSerieTechniqueAssignsService _productSerieTechniqueAssignsService;

        #endregion

        #region Ctor

        public ProductSerieTechniqueAssignController(IProductSerieTechniqueAssignsService productSerieTechniqueAssignsService)
        {
            _productSerieTechniqueAssignsService = productSerieTechniqueAssignsService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetProductSerieTechniqueAssigns()
        {
            try
            {

                List<Core.Models.ProductSerieTechniqueAssigns> productSerieTechniqueAssigns = await _productSerieTechniqueAssignsService.GetAllAsync();

                var res = productSerieTechniqueAssigns.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductSerieTechniqueAssigns List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductSerieTechniqueAssignsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductSerieTechniqueAssignsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductSerieTechniqueAssignsByID(int id)
        {
            try
            {

                Core.Models.ProductSerieTechniqueAssigns productSerieTechniqueAssigns = await _productSerieTechniqueAssignsService.GetProductSerieTechniqueAssignsByIdAsync(id);

                var res = (new List<Core.Models.ProductSerieTechniqueAssigns> { productSerieTechniqueAssigns }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productSerieTechniqueAssigns failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductSerieTechniqueAssignsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductSerieTechniqueAssignsDTO>>(e));
            }

        }

        

        [HttpPost]

        public IActionResult Append([FromBody] ProductSerieTechniqueAssignsDTO productSerieTechniqueAssigns)
        {
            try
            {
                ProductSerieTechniqueAssigns productSerieTechniqueAssign = new ProductSerieTechniqueAssigns();
                var mapper = Functions.CreateMapper<ProductSerieTechniqueAssignsDTO, ProductSerieTechniqueAssigns>();
                productSerieTechniqueAssign = mapper(productSerieTechniqueAssigns);

                bool result = _productSerieTechniqueAssignsService.Append(productSerieTechniqueAssign);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductSerieTechniqueAssigns append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] ProductSerieTechniqueAssignsDTO productSerieTechniqueAssigns)
        {
            try
            {
                ProductSerieTechniqueAssigns productSerieTechniqueAssign = new ProductSerieTechniqueAssigns();
                var mapper = Functions.CreateMapper<ProductSerieTechniqueAssignsDTO, ProductSerieTechniqueAssigns>();
                productSerieTechniqueAssign = mapper(productSerieTechniqueAssigns);

                bool result = _productSerieTechniqueAssignsService.Update(productSerieTechniqueAssign);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductSerieTechniqueAssigns update failed");
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
                long result = _productSerieTechniqueAssignsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductSerieTechniqueAssigns update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductSerieTechniquesBySerieID(int id)
        {
            try
            {

                List<Core.Models.ProductSerieTechniqueAssigns> productSerieTechniqueAssigns = await _productSerieTechniqueAssignsService.GetProductSerieTechniqueAssignsBySerieIdAsync(id);

                var res = productSerieTechniqueAssigns.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productSerieTechniqueAssigns failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductSerieTechniqueAssignsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductSerieTechniqueAssignsDTO>>(e));
            }

        }


    }
}