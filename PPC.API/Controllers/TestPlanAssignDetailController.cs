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
    public class TestPlanAssignDetailController : Controller
    {

        #region Prop

        private readonly ITestPlanAssignDetailService _testPlanAssignDetailService;

        #endregion

        #region Ctor

        public TestPlanAssignDetailController(ITestPlanAssignDetailService testPlanAssignDetailService)
        {
            _testPlanAssignDetailService = testPlanAssignDetailService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlanAssignDetail()
        {
            try
            {

                List<Core.Models.TestPlanAssignDetail> testPlanAssignDetail = await _testPlanAssignDetailService.GetAllAsync();

                var res = testPlanAssignDetail == null
                    ? null
                    : testPlanAssignDetail.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanAssignDetail List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDetailDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTestPlanAssignDetailByID(int id)
        {
            try
            {

                Core.Models.TestPlanAssignDetail testPlanAssignDetail = await _testPlanAssignDetailService.GetTestPlanAssignDetailByIdAsync(id);

                var res = testPlanAssignDetail == null
                    ? null
                    : (new List<Core.Models.TestPlanAssignDetail> { testPlanAssignDetail }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanAssignDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDetailDTO>>(e));
            }

        }

        //[HttpGet("[Controller]/[Action]/{name}")]
        //public async Task<IActionResult> ExistTestPlanAssignDetail(string name)
        //{
        //    try
        //    {

        //        var result = _testPlanAssignDetailService.ExistTestPlanAssignDetailAsync(name);

        //        var res = new List<bool> { await result };

        //        return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get TestPlanAssignDetail failed");
        //        return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error ... ", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] TestPlanAssignDetail testPlanAssignDetail)
        {
            try
            {

                int result = _testPlanAssignDetailService.Append(testPlanAssignDetail);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanAssignDetail append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] TestPlanAssignDetail testPlanAssignDetail)
        {
            try
            {

                bool result = _testPlanAssignDetailService.Update(testPlanAssignDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanAssignDetail update failed");
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
                long result = _testPlanAssignDetailService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanAssignDetail delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListByTestPlanAssignId(int id)
        {
            try
            {
                List<Core.Models.TestPlanAssignDetail> testPlanAssignDetail = await _testPlanAssignDetailService.GetListByTestPlanAssignIdAsync(id);

                var res = testPlanAssignDetail == null
                    ? null
                    : testPlanAssignDetail.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanAssignDetail failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDetailDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDetailDTO>>(e));
            }
        }



    }
}
