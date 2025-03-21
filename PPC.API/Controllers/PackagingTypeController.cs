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
    public class PackagingTypeController : Controller
    {

        #region Prop

        private readonly IPackagingTypesService _packagingTypesService;

        #endregion

        #region Ctor

        public PackagingTypeController(IPackagingTypesService packagingTypesService)
        {
            _packagingTypesService = packagingTypesService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPackagingTypes()
        {
            try
            {

                List<Core.Models.PackagingTypes> packagingTypes = await _packagingTypesService.GetAllAsync();


                var res = ExtAutoMapper.JsonMap<List<PackagingTypes>, List<PackagingTypesDTO>>(packagingTypes);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PackagingTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<PackagingTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PackagingTypesDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPackagingTypesByID(int id)
        {
            try
            {

                Core.Models.PackagingTypes packagingTypes = await _packagingTypesService.GetPackagingTypesByIdAsync(id);


                var res = new List<PackagingTypesDTO> { ExtAutoMapper.JsonMap<PackagingTypes, PackagingTypesDTO>(packagingTypes) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get packagingTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<PackagingTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PackagingTypesDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] PackagingTypes packagingType)
        {
            try
            {

                int result = _packagingTypesService.Append(packagingType);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PackagingTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] PackagingTypes packagingType)
        {
            try
            {

                bool result = _packagingTypesService.Update(packagingType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PackagingTypes update failed");
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
                long result = _packagingTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PackagingTypes delete failed");
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
