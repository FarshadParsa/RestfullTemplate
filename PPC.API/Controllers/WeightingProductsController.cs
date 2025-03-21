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
using PPC.Base.Utility;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class WeightingProductsController : Controller
    {

        #region Prop

        private readonly IWeightingProductsService _weightingProductsService;

        #endregion

        #region Ctor

        public WeightingProductsController(IWeightingProductsService weightingProductsService)
        {
            _weightingProductsService = weightingProductsService;
        }

        #endregion

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetWeightingProducts(int startDate, int endDate)
        {
            try
            {
                string dateFrom = Utility.FormatPersianDate(startDate);
                string dateTo = Utility.FormatPersianDate(endDate);

                List<Core.Models.WeightingProducts> weightingProducts = await _weightingProductsService.GetAllAsync(dateFrom, dateTo);

                //var res = weightingProducts == null
                //? null 
                //: weightingProducts.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<WeightingProducts>,List<WeightingProductsDTO>> (weightingProducts);


                var res = ExtAutoMapper.JsonMap<List<WeightingProducts>, List<WeightingProductsDTO>>(weightingProducts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get WeightingProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<WeightingProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<WeightingProductsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetWeightingProductsByID(int id)
        {
            try
            {

                Core.Models.WeightingProducts weightingProducts = await _weightingProductsService.GetWeightingProductsByIdAsync(id);

                //var res = weightingProducts == null
                //    ? null 
                //    : (new List<Core.Models.WeightingProducts> { weightingProducts }).ConvertToListDto();

                //var res = weightingProducts == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<WeightingProducts>, List<WeightingProductsDTO>>(new List<WeightingProducts> { weightingProducts });

                var res = new List<WeightingProductsDTO> { ExtAutoMapper.JsonMap<WeightingProducts, WeightingProductsDTO>(weightingProducts) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get weightingProducts failed");
                return Ok(ResponseFactory.OKCreator(new List<WeightingProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<WeightingProductsDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] WeightingProducts weightingProducts)
        {
            try
            {

                int result = _weightingProductsService.Append(weightingProducts);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"WeightingProducts append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] WeightingProducts weightingProducts)
        {
            try
            {

                bool result = _weightingProductsService.Update(weightingProducts);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"WeightingProducts update failed");
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
                long result = _weightingProductsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"WeightingProducts delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetListByProductionPlanPatilID(int id)
        {
            try
            {

                List<Core.Models.WeightingProducts> weightingProducts = await _weightingProductsService.GetListByProductionPlanPatilIdAsync(id);

                //var res = weightingProducts == null
                //? null 
                //: weightingProducts.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<WeightingProducts>,List<WeightingProductsDTO>> (weightingProducts);

                var res = ExtAutoMapper.JsonMap<List<WeightingProducts>, List<WeightingProductsDTO>>(weightingProducts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get WeightingProducts List failed");
                return Ok(ResponseFactory.OKCreator(new List<WeightingProductsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<WeightingProductsDTO>>(e));
            }

        }


    }
}
