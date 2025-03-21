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
using System;
using Microsoft.CodeAnalysis.Host.Mef;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ProductController : Controller
    {

        #region Prop

        private readonly IProductsService _productsService;

        #endregion

        #region Ctor

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {

                List<Core.Models.Products> products = await _productsService.GetAllAsync();

                //var res = products.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<Products>, List<ProductsDTO>>(products);


                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetProductsByID(int id)
        {
            try
            {

                Core.Models.Products products = await _productsService.GetProductsByIdAsync(id);

                var res = (new List<Core.Models.Products> { products }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get products failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        //[HttpGet]

        [HttpGet("[controller]/ExistProducts/{name}")]
        public async Task<IActionResult> ExistProducts(string name)
        {
            try
            {

                var result = _productsService.ExistProductsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] Products products)
        {
            try
            {
                int result = _productsService.Append(products);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Products append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] ProductsDTO products)
        {
            try
            {
                Products product = new Products();
                var mapper = Functions.CreateMapper<ProductsDTO, Products>();
                product = mapper(products);

                bool result = _productsService.Update(product);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Products update failed");
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
                long result = _productsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Products update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetProductsWithProductType()
        {
            try
            {

                List<Core.Models.Products> products = await _productsService.GetAllWithProductTypeAsync();

                var res = products.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetNextSerialCode()
        {
            try
            {

                string maxSerialCode = await _productsService.GetMaxSerialCodeAsync();

                if (maxSerialCode == null || maxSerialCode.Length != 3)
                {
                    maxSerialCode = "A01";
                }
                else
                {
                    maxSerialCode = maxSerialCode.ToUpper();
                    char char0 = maxSerialCode[0];
                    char char1 = maxSerialCode[1];
                    char char2 = maxSerialCode[2];

                    char nextChar0 = (char)(((int)char0) + 1);
                    char nextChar1 = (char)(((int)char1) + 1);
                    char nextChar2 = (char)(((int)char2) + 1);



                    if (char.IsDigit(char1))
                    {
                        string str = "";
                        byte num = Convert.ToByte(maxSerialCode.Substring(1, 2));
                        if (num < 99)
                        {
                            maxSerialCode = $"{char0}{(++num).ToString("00")}";
                        }
                        else
                        {
                            if (char0 == 'Z')
                                maxSerialCode = $"A01";
                            else
                                maxSerialCode = $"{nextChar0}01";
                        }
                    }
                    else
                    {
                        string str = "";
                        byte num = Convert.ToByte(maxSerialCode[2].ToString());
                        if (num < 9)
                        {
                            maxSerialCode = $"{char0}{char1}{(++num).ToString()}";
                        }
                        else
                        {
                            if (char1 == 'Z')
                                maxSerialCode = nextChar0 + "A1";
                            else
                                maxSerialCode = $"{char0}{nextChar1}1";
                        }
                    }
                }

                var res = new List<string> { maxSerialCode.ToUpper() };
                return Ok(ResponseFactory.OKCreator(res, res.Count()));



            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products Next Serial Code failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetMaxSerialCode()
        {
            try
            {
                string maxSerialCode = await _productsService.GetMaxSerialCodeAsync();
                var res = maxSerialCode == null
                    ? null
                    : new List<string> { maxSerialCode.ToUpper() };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products Max Serial Code failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetMaxBOMcode()
        {
            try
            {
                string maxBOMcode = await _productsService.GetMaxBOMcodeAsync();
                var res = maxBOMcode == null
                    ? null
                    : new List<string> { maxBOMcode.ToUpper() };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products Max BOM Code failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetNextBOMcode()
        {
            try
            {
                string maxBOMcode = await _productsService.GetMaxBOMcodeAsync();
                string nextBOMcode = (Convert.ToInt16(maxBOMcode)+1).ToString("000");
                var res = new List<string> { nextBOMcode };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products Lext BOM Code failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetByFinalRawMaterialID(int id)
        {
            try
            {

                Products products = await _productsService.GetListByFinalRawMaterialID(id);

                var res = new List<ProductsDTO>() { ExtAutoMapper.JsonMap<Products, ProductsDTO>(products) };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByPaletId(int id)
        {
            try
            {

                List<Core.Models.Products> products = await _productsService.GetProductsByPaletIdAsync(id );

                var res = products.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Products List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductsDTO>>(e));
            }

        }

    }
}
