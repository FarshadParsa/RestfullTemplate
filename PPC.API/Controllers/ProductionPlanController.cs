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
using System.Text.Json;
using PPC.Base.Utility;
using Newtonsoft.Json.Linq;
using AtlasCellData.ADO;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class ProductionPlanController : Controller
    {

        #region Prop

        private readonly IProductionPlansService _productionPlansService;

        #endregion

        #region Ctor

        public ProductionPlanController(IProductionPlansService productionPlansService)
        {
            _productionPlansService = productionPlansService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetProductionPlans()
        {
            try
            {

                List<Core.Models.ProductionPlans> productionPlans = await _productionPlansService.GetAllAsync();

                //var res = productionPlans == null
                //    ? null
                //    : productionPlans.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<ProductionPlans>, List<ProductionPlansDTO>>(productionPlans);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductionPlansByID(int id)
        {
            try
            {

                Core.Models.ProductionPlans productionPlans = await _productionPlansService.GetProductionPlansByIdAsync(id);

                //var res = productionPlans == null
                //    ? null
                //    : (new List<Core.Models.ProductionPlans> { productionPlans }).ConvertToListDto();

                var res = new List<ProductionPlansDTO>() { ExtAutoMapper.JsonMap<ProductionPlans, ProductionPlansDTO>(productionPlans) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Append([FromBody] ProductionPlans productionPlan)
        {
            try
            {

                int result = _productionPlansService.Append(productionPlan);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlans append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ProductionPlans productionPlan)
        {
            try
            {

                bool result = _productionPlansService.Update(productionPlan);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlans update failed");
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
                long result = _productionPlansService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"ProductionPlans delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxPlanNoByDate(int id)
        {
            try
            {
                Core.Models.ProductionPlans productionPlans = await _productionPlansService.GetMaxProductionPlanByDateAsync(Utility.FormatPersianDate(id));

                //var res = productionPlans == null
                //    ? null
                //    : (new List<Core.Models.ProductionPlans> { productionPlans }).ConvertToListDto();

                var res = new List<ProductionPlansDTO>() { ExtAutoMapper.JsonMap<ProductionPlans, ProductionPlansDTO>(productionPlans) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get productionPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBatchNumberListByOrderDetailId(int id)
        {
            try
            {
                var result = await _productionPlansService.GetBatchNumbersListByOrderDetailIdAsync(id);

                //var res = result == null
                //    ? null
                //    : result.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<ProductionPlans>, List<ProductionPlansDTO>>(result);

                return Ok(ResponseFactory.OKCreator<List<ProductionPlansDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PackagingPlans failed");
                return Ok(ResponseFactory.OKCreator<List<ProductionPlansDTO>>(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListForDropdown()
        {
            try
            {
                var result = await _productionPlansService.GetListForDropdown();

                var res = ExtAutoMapper.Mapper.Map<List<ProductionPlans>, List<ProductionPlansDTO>>(result);

                return Ok(ResponseFactory.OKCreator<List<ProductionPlansDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PackagingPlans failed");
                return Ok(ResponseFactory.OKCreator<List<ProductionPlansDTO>>(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetInprocessList(int startDate, int endDate)
        {
            try
            {
                string dateFrom = Utility.FormatPersianDate(startDate);
                string dateTo = Utility.FormatPersianDate(endDate);


                List<Core.Models.ProductionPlans> productionPlans = await _productionPlansService.GetInprocessListAsync(dateFrom, dateTo);

                //var res = productionPlans == null
                //    ? null
                //    : productionPlans.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<ProductionPlans>, List<ProductionPlansDTO>>(productionPlans);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetProductionReportById(int id)//productionPlanId
        {
            try
            {
                var DTs = _productionPlansService.GetProductionReport(id);

                var res = new List<string>
                {
                    JSON.ToJson(DTs.productionDT).Result,
                    JSON.ToJson(DTs.bomDT).Result,
                    JSON.ToJson(DTs.packagingDT).Result,
                    JSON.ToJson(DTs.packagingDT).Result,
                };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> ValidateCanFinishPlan(int id)
        {
            try
            {

                bool result = await _productionPlansService.ValidateCanFinishPlanAsync(id);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Validate can finish ProductionPlans failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> FinishPlan(int id)
        {
            try
            {
                bool result = true;
                if (!await _productionPlansService.ValidateCanFinishPlanAsync(id))
                {
                    result = false;
                }
                else
                {
                    result = await _productionPlansService.FinishPlanAsync(id);
                }

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Finish ProductionPlans failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        ///
        //  دریافت برنامه تولید همراه با لیست آخرین فرمولاسیون مصرف شده
        ///
        public async Task<IActionResult> GetLatestUsgedBOM(int id)
        {
            try
            {

                Core.Models.ProductionPlans productionPlan = await _productionPlansService.GetLatestUsgedBOMAsync(id);


                var res = new List<ProductionPlansDTO>() { ExtAutoMapper.JsonMap<ProductionPlans, ProductionPlansDTO>(productionPlan) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));


                //var res = ExtAutoMapper.JsonMap<ProductionPlans, ProductionPlansDTO>(productionPlan);

                //return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : 1));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }


        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetAll(int startDate, int endDate)
        {
            try
            {
                string dateFrom = Utility.FormatPersianDate(startDate);
                string dateTo = Utility.FormatPersianDate(endDate);


                List<Core.Models.ProductionPlans> productionPlans = await _productionPlansService.GetAllAsync(dateFrom, dateTo);

                //var res = productionPlans == null
                //    ? null
                //    : productionPlans.ConvertToListDto();

                var res = ExtAutoMapper.JsonMap<List<ProductionPlans>, List<ProductionPlansDTO>>(productionPlans);

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get ProductionPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProductionPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProductionPlansDTO>>(e));
            }

        }

    }
}
