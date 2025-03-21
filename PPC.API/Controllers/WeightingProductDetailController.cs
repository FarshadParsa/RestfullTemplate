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
    public class WeightingProductDetailController : Controller
    {

        #region Prop

        private readonly IWeightingProductDetailService _weightingProductDetailService;

        #endregion

        #region Ctor

        public WeightingProductDetailController(IWeightingProductDetailService weightingProductDetailService)
        {
            _weightingProductDetailService = weightingProductDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetWeightingProductDetail()
        {
            try
            {

                List<Core.Models.WeightingProductDetail> weightingProductDetail = await _weightingProductDetailService.GetAllAsync();

                //var res = weightingProductDetail == null
                //? null 
                //: weightingProductDetail.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<WeightingProductDetail>,List<WeightingProductDetailDTO>> (weightingProductDetail);

                var res = ExtAutoMapper.JsonMap<List<WeightingProductDetail>, List<WeightingProductDetailDTO>>(weightingProductDetail);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get WeightingProductDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<WeightingProductDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<WeightingProductDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetWeightingProductDetailByID(int id)
        {
            try
            {

                Core.Models.WeightingProductDetail weightingProductDetail = await _weightingProductDetailService.GetWeightingProductDetailByIdAsync(id);

                //var res = weightingProductDetail == null
                //    ? null 
                //    : (new List<Core.Models.WeightingProductDetail> { weightingProductDetail }).ConvertToListDto();

                //var res = weightingProductDetail == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<WeightingProductDetail>, List<WeightingProductDetailDTO>>(new List<WeightingProductDetail> { weightingProductDetail });

                var res = new List<WeightingProductDetailDTO> { ExtAutoMapper.JsonMap<WeightingProductDetail, WeightingProductDetailDTO>(weightingProductDetail) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get weightingProductDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<WeightingProductDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<WeightingProductDetailDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] WeightingProductDetail weightingProductDetail)
        {
            try
            {

                int result = _weightingProductDetailService.Append(weightingProductDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"WeightingProductDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] WeightingProductDetail weightingProductDetail)
        {
            try
            {

                bool result = _weightingProductDetailService.Update(weightingProductDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"WeightingProductDetail update failed");
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
                long result = _weightingProductDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"WeightingProductDetail delete failed");
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
