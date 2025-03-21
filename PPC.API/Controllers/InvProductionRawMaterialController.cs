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
    public class InvProductionRawMaterialController : Controller
    {

        #region Prop

        private readonly IInvProductionRawMaterialsService _invProductionRawMaterialsService;

        #endregion

        #region Ctor

        public InvProductionRawMaterialController(IInvProductionRawMaterialsService invProductionRawMaterialsService)
        {
            _invProductionRawMaterialsService = invProductionRawMaterialsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetInvProductionRawMaterials()
        {
            try
            {

                List<Core.Models.InvProductionRawMaterials> invProductionRawMaterials = await _invProductionRawMaterialsService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<InvProductionRawMaterials>, List<InvProductionRawMaterialsDTO>>(invProductionRawMaterials);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvProductionRawMaterials List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductionRawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductionRawMaterialsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetInvProductionRawMaterialsByID(int id)
        {
            try
            {

                Core.Models.InvProductionRawMaterials invProductionRawMaterials = await _invProductionRawMaterialsService.GetInvProductionRawMaterialsByIdAsync(id);


                var res = new List<InvProductionRawMaterialsDTO> { ExtAutoMapper.JsonMap<InvProductionRawMaterials, InvProductionRawMaterialsDTO>(invProductionRawMaterials) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invProductionRawMaterials failed");
                return Ok(ResponseFactory.OKCreator(new List<InvProductionRawMaterialsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvProductionRawMaterialsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] InvProductionRawMaterials invProductionRawMaterial)
        {
            try
            {

                int result = _invProductionRawMaterialsService.Append(invProductionRawMaterial);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvProductionRawMaterials append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] InvProductionRawMaterials invProductionRawMaterial)
        {
            try
            {

                bool result = _invProductionRawMaterialsService.Update(invProductionRawMaterial);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvProductionRawMaterials update failed");
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
                long result = _invProductionRawMaterialsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvProductionRawMaterials delete failed");
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
