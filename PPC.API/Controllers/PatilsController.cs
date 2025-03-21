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
    public class PatilsController : Controller
    {

        #region Prop

        private readonly IPatilsService _patilsService;

        #endregion

        #region Ctor

        public PatilsController(IPatilsService patilsService)
        {
            _patilsService = patilsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPatils()
        {
            try
            {

                List<Core.Models.Patils> patils = await _patilsService.GetAllAsync();

                //var res = patils == null
                //? null 
                //: patils.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<Patils>,List<PatilsDTO>> (patils);

                var res = ExtAutoMapper.JsonMap<List<Patils>, List<PatilsDTO>>(patils);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Patils List failed");
                return Ok(ResponseFactory.OKCreator(new List<PatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PatilsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPatilsByID(int id)
        {
            try
            {

                Core.Models.Patils patils = await _patilsService.GetPatilsByIdAsync(id);

                //var res = patils == null
                //    ? null 
                //    : (new List<Core.Models.Patils> { patils }).ConvertToListDto();

                //var res = patils == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<Patils>, List<PatilsDTO>>(new List<Patils> { patils });

                var res = new List<PatilsDTO> { ExtAutoMapper.JsonMap<Patils, PatilsDTO>(patils) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get patils failed");
                return Ok(ResponseFactory.OKCreator(new List<PatilsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PatilsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] Patils patils)
        {
            try
            {

                int result = _patilsService.Append(patils);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Patils append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Patils patils)
        {
            try
            {

                bool result = _patilsService.Update(patils);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Patils update failed");
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
                long result = _patilsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Patils delete failed");
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
