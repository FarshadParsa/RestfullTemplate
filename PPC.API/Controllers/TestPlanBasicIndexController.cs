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
    public class TestPlanBasicIndexController : Controller
    {

        #region Prop

        private readonly ITestPlanBasicIndexService _testPlanBasicIndexService;

        #endregion

        #region Ctor

        public TestPlanBasicIndexController(ITestPlanBasicIndexService testPlanBasicIndexService)
        {
            _testPlanBasicIndexService = testPlanBasicIndexService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlanBasicIndex()
        {
            try
            {

                List<Core.Models.TestPlanBasicIndex> testPlanBasicIndex = await _testPlanBasicIndexService.GetAllAsync();

                var res = testPlanBasicIndex == null
                    ? null
                    : testPlanBasicIndex.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanBasicIndex List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanBasicIndexDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanBasicIndexDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTestPlanBasicIndexByID(short id)
        {
            try
            {

                Core.Models.TestPlanBasicIndex testPlanBasicIndex = await _testPlanBasicIndexService.GetTestPlanBasicIndexByIdAsync(id);

                var res = testPlanBasicIndex == null
                    ? null
                    : (new List<Core.Models.TestPlanBasicIndex> { testPlanBasicIndex }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanBasicIndex failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanBasicIndexDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanBasicIndexDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] TestPlanBasicIndex testPlanBasicIndex)
        {
            try
            {

                short result = _testPlanBasicIndexService.Append(testPlanBasicIndex);

                var res = new List<short> { result };

                return Ok(ResponseFactory.OKCreator<List<short>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanBasicIndex append failed");
                return Ok(ResponseFactory.OKCreator<List<short>>(new List<short>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<short>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] TestPlanBasicIndex testPlanBasicIndex)
        {
            try
            {

                bool result = _testPlanBasicIndexService.Update(testPlanBasicIndex);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanBasicIndex update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        public IActionResult Delete(short id)
        {
            try
            {
                long result = _testPlanBasicIndexService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanBasicIndex delete failed");
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
