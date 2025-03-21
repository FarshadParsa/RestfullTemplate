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
    public class PaletDetailController : Controller
    {

        #region Prop

        private readonly IPaletDetailService _paletDetailService;

        #endregion

        #region Ctor

        public PaletDetailController(IPaletDetailService paletDetailService)
        {
            _paletDetailService = paletDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPaletDetail()
        {
            try
            {

                List<Core.Models.PaletDetail> paletDetail = await _paletDetailService.GetAllAsync();

                //var res = paletDetail == null
                //? null 
                //: paletDetail.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<PaletDetail>,List<PaletDetailDTO>> (paletDetail);

                var res = ExtAutoMapper.JsonMap<List<PaletDetail>, List<PaletDetailDTO>>(paletDetail);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PaletDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetPaletDetailByID(int id)
        {
            try
            {

                Core.Models.PaletDetail paletDetail = await _paletDetailService.GetPaletDetailByIdAsync(id);

                //var res = paletDetail == null
                //    ? null 
                //    : (new List<Core.Models.PaletDetail> { paletDetail }).ConvertToListDto();

                //var res = paletDetail == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<PaletDetail>, List<PaletDetailDTO>>(new List<PaletDetail> { paletDetail });

                var res = new List<PaletDetailDTO> { ExtAutoMapper.JsonMap<PaletDetail, PaletDetailDTO>(paletDetail) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get paletDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<PaletDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PaletDetailDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] PaletDetail paletDetail)
        {
            try
            {

                int result = _paletDetailService.Append(paletDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PaletDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] PaletDetail paletDetail)
        {
            try
            {

                bool result = _paletDetailService.Update(paletDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PaletDetail update failed");
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
                long result = _paletDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PaletDetail delete failed");
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
