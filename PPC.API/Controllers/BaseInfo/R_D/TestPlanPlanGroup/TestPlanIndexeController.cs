using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using PPC.Base.Models.Exceptions;
using PPC.Base;
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
    public class TestPlanIndexController : Controller
    {

        #region Prop

        private readonly ITestPlanIndexesService _testPlanIndexesService;

        #endregion

        #region Ctor

        public TestPlanIndexController(ITestPlanIndexesService testPlanIndexesService)
        {
            _testPlanIndexesService = testPlanIndexesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetTestPlanIndexes()
        {
            try
            {

                List<Core.Models.TestPlanIndexes> testPlanIndexes = await _testPlanIndexesService.GetAllAsync();

                var res = testPlanIndexes.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanIndexes List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanIndexesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanIndexesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetTestPlanIndexesByID(int id)
        {
            try
            {

                Core.Models.TestPlanIndexes testPlanIndexes = await _testPlanIndexesService.GetTestPlanIndexesByIdAsync(id);

                var res = (new List<Core.Models.TestPlanIndexes> { testPlanIndexes }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanIndexes failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanIndexesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanIndexesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistTestPlanIndexes/{name}")]
        public async Task<IActionResult> ExistTestPlanIndexes(string name)
        {
            try
            {

                var result = _testPlanIndexesService.ExistTestPlanIndexesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanIndexes failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] TestPlanIndexesDTO testPlanIndexes)
        {
            try
            {
                TestPlanIndexes testPlanIndex = new TestPlanIndexes();
                var mapper = Functions.CreateMapper<TestPlanIndexesDTO, TestPlanIndexes>();
                testPlanIndex = mapper(testPlanIndexes);

                bool result = _testPlanIndexesService.Append(testPlanIndex);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanIndexes append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] TestPlanIndexesDTO testPlanIndexes)
        {
            try
            {
                TestPlanIndexes testPlanIndex = new TestPlanIndexes();
                var mapper = Functions.CreateMapper<TestPlanIndexesDTO, TestPlanIndexes>();
                testPlanIndex = mapper(testPlanIndexes);

                bool result = _testPlanIndexesService.Update(testPlanIndex);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanIndexes update failed");
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
                long result = _testPlanIndexesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanIndexes update failed");
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
