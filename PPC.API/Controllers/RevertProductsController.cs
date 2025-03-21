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
    public class RevertProductsController : Controller
    {

        #region Prop

        private readonly IRevertProductsService _revertProductsService;

        #endregion

        #region Ctor

        public RevertProductsController(IRevertProductsService revertProductsService)
        {
            _revertProductsService = revertProductsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRevertProducts()
        {
            try
            {

                List<Core.Models.RevertProducts> revertProducts = await _revertProductsService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<RevertProducts>, List<RevertProductsDTO>>(revertProducts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RevertProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRevertProductsByID(int id)
        {
            try
            {

                Core.Models.RevertProducts revertProducts = await _revertProductsService.GetRevertProductsByIdAsync(id);


                var res = new List<RevertProductsDTO> { ExtAutoMapper.JsonMap<RevertProducts, RevertProductsDTO>(revertProducts) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get revertProducts failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertProductsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RevertProducts revertProducts)
        {
            try
            {

                int result = _revertProductsService.Append(revertProducts);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RevertProducts append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RevertProducts revertProducts)
        {
            try
            {

                bool result = _revertProductsService.Update(revertProducts);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RevertProducts update failed");
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
                long result = _revertProductsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RevertProducts delete failed");
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
