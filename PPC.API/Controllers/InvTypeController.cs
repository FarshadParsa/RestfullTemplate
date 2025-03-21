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
    public class InvTypeController : Controller
    {

        #region Prop

        private readonly IInvTypesService _invTypesService;

        #endregion

        #region Ctor

        public InvTypeController(IInvTypesService invTypesService)
        {
            _invTypesService = invTypesService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetInvTypes()
        {
            try
            {

                List<Core.Models.InvTypes> invTypes = await _invTypesService.GetAllAsync();

                //var res = invTypes == null
                //? null 
                //: invTypes.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<InvTypes>,List<InvTypesDTO>> (invTypes);

                var res = ExtAutoMapper.JsonMap<List<InvTypes>, List<InvTypesDTO>>(invTypes);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get InvTypes List failed");
                return Ok(ResponseFactory.OKCreator(new List<InvTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvTypesDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetInvTypesByID(byte id)
        {
            try
            {

                Core.Models.InvTypes invTypes = await _invTypesService.GetInvTypesByIdAsync(id);

                //var res = invTypes == null
                //    ? null 
                //    : (new List<Core.Models.InvTypes> { invTypes }).ConvertToListDto();

                //var res = invTypes == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<InvTypes>, List<InvTypesDTO>>(new List<InvTypes> { invTypes });

                var res = new List<InvTypesDTO> { ExtAutoMapper.JsonMap<InvTypes, InvTypesDTO>(invTypes) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get invTypes failed");
                return Ok(ResponseFactory.OKCreator(new List<InvTypesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InvTypesDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] InvTypes invType)
        {
            try
            {

                char result = _invTypesService.Append(invType);

                var res = new List<char> { result };

                return Ok(ResponseFactory.OKCreator<List<char>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvTypes append failed");
                return Ok(ResponseFactory.OKCreator<List<char>>(new List<char>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<char>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] InvTypes invType)
        {
            try
            {

                bool result = _invTypesService.Update(invType);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvTypes update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public IActionResult Delete(byte id)
        {
            try
            {
                long result = _invTypesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"InvTypes delete failed");
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
