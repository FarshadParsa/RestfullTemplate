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
    public class InvProductController : Controller
    {

        #region Prop

        private readonly IInvProductsService _invProductsService;

        #endregion

        #region Ctor

        public InvProductController(IInvProductsService invProductsService)
        {
            _invProductsService = invProductsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetInvProductsByID(int id)
        {
            try
            {

                Core.Models.InvProducts invProducts = await _invProductsService.GetInvProductsByIdAsync(id);

                //var res = invProducts == null
                //    ? null 
                //    : (new List<Core.Models.InvProducts> { invProducts }).ConvertToListDto();

                //var res = invProducts == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<InvProducts>, List<InvProductsDTO>>(new List<InvProducts> { invProducts });

                var res = new List<InvProductsDTO> { ExtAutoMapper.JsonMap<InvProducts, InvProductsDTO>(invProducts) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invProducts failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] InvProducts invProduct)
        {
            try
            {

                int result = _invProductsService.Append(invProduct);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvProducts append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] InvProducts invProduct)
        {
            try
            {

                bool result = _invProductsService.Update(invProduct);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvProducts update failed");
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
                long result = _invProductsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvProducts delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInstanceByBarcode(string id)
        {
            try
            {

                Core.Models.InvProducts invProducts = await _invProductsService.GetInstanceByBarcodeAsync(id);

                //var res = invProducts == null
                //    ? null 
                //    : (new List<Core.Models.InvProducts> { invProducts }).ConvertToListDto();

                //var res = invProducts == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<InvProducts>, List<InvProductsDTO>>(new List<InvProducts> { invProducts });

                var res = new List<InvProductsDTO> { ExtAutoMapper.JsonMap<InvProducts, InvProductsDTO>(invProducts) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invProducts failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByWeightingProductID(int id)
        {
            try
            {

                List<Core.Models.InvProducts> invProducts = await _invProductsService.GetListByWeightingProductIdAsync(id);

                var res = ExtAutoMapper.JsonMap<List<InvProducts>, List<InvProductsDTO>>(invProducts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetByPaletId(int id)
        {
            try
            {

                List<Core.Models.InvProducts> invProducts = await _invProductsService.GetByPaletIdAsync(id);

                var res = ExtAutoMapper.JsonMap<List<InvProducts>, List<InvProductsDTO>>(invProducts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetInvProducts()
        {
            try
            {

                List<Core.Models.InvProducts> invProducts = await _invProductsService.GetAllInvProductsAsync();

                var res = ExtAutoMapper.JsonMap<List<InvProducts>, List<InvProductsDTO>>(invProducts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductsDTO>>(e));
            }

        }

    }
}
