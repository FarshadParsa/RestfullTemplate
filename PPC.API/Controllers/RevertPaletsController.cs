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
    public class RevertPaletsController : Controller
    {

        #region Prop

        private readonly IRevertPaletsService _revertPaletsService;

        #endregion

        #region Ctor

        public RevertPaletsController(IRevertPaletsService revertPaletsService)
        {
            _revertPaletsService = revertPaletsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetRevertPalets()
        {
            try
            {

                List<Core.Models.RevertPalets> revertPalets = await _revertPaletsService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<RevertPalets>, List<RevertPaletsDTO>>(revertPalets);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get RevertPalets List failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertPaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertPaletsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetRevertPaletsByID(int id)
        {
            try
            {

                Core.Models.RevertPalets revertPalets = await _revertPaletsService.GetRevertPaletsByIdAsync(id);


                var res = new List<RevertPaletsDTO> { ExtAutoMapper.JsonMap<RevertPalets, RevertPaletsDTO>(revertPalets) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get revertPalets failed");
                return Ok(ResponseFactory.OKCreator(new List<RevertPaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<RevertPaletsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] RevertPalets revertPalets)
        {
            try
            {

                int result = _revertPaletsService.Append(revertPalets);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RevertPalets append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] RevertPalets revertPalets)
        {
            try
            {

                bool result = _revertPaletsService.Update(revertPalets);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RevertPalets update failed");
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
                long result = _revertPaletsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"RevertPalets delete failed");
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
