using Microsoft.AspNetCore.Mvc;
using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using global::PPC.Base.Models.Exceptions;
using global::PPC.Base;
using global::PPC.Core.Interface;
using global::PPC.Core.Log;
using global::PPC.Core.Models;
using global::PPC.Response.DTOs;
using global::PPC.Response.Result;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ProductGroupController : Controller
    {

        #region Prop

        private readonly IProductGroupsService _productGroupsService;

        #endregion

        #region Ctor

        public ProductGroupController(IProductGroupsService productGroupsService)
        {
            _productGroupsService = productGroupsService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetProductGroups()
        {
            try
            {

                List<Core.Models.ProductGroups> productGroups = await _productGroupsService.GetAllAsync();

                var res = productGroups.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductGroups List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductGroupsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetProductGroupsByID(short id)
        {
            try
            {

                Core.Models.ProductGroups productGroups = await _productGroupsService.GetProductGroupsByIdAsync(id);

                var res = (new List<Core.Models.ProductGroups> { productGroups }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productGroups failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductGroupsDTO>>(e));
            }

        }

        //[HttpGet]
        [HttpGet("[controller]/ExistProductGroups/{name}")]
        public async Task<IActionResult> ExistProductGroups(string name)
        {
            try
            {

                var result = _productGroupsService.ExistProductGroupsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductGroups failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] ProductGroupsDTO productGroups)
        {
            try
            {
                ProductGroups productGroup = new ProductGroups();
                var mapper = Functions.CreateMapper<ProductGroupsDTO, ProductGroups>();
                productGroup = mapper(productGroups);

                bool result = _productGroupsService.Append(productGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductGroups append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] ProductGroupsDTO productGroups)
        {
            try
            {
                ProductGroups productGroup = new ProductGroups();
                var mapper = Functions.CreateMapper<ProductGroupsDTO, ProductGroups>();
                productGroup = mapper(productGroups);

                bool result = _productGroupsService.Update(productGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductGroups update failed");
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
                long result = _productGroupsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductGroups update failed");
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
