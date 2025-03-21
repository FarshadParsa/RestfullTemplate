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
    public class TestPlanGroupController : Controller
    {

        #region Prop

        private readonly ITestPlanGroupsService _testPlanGroupsService;

        #endregion

        #region Ctor

        public TestPlanGroupController(ITestPlanGroupsService testPlanGroupsService)
        {
            _testPlanGroupsService = testPlanGroupsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlanGroups()
        {
            try
            {

                List<Core.Models.TestPlanGroups> testPlanGroups = await _testPlanGroupsService.GetAllAsync();

                var res = testPlanGroups.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanGroups List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanGroupsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetTestPlanGroupsByEntranceType(byte id)
        {
            try
            {
                List<Core.Models.TestPlanGroups> testPlanGroups = await _testPlanGroupsService.GetAllByEntranceTypeAsync(id);

                var res = testPlanGroups.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanGroups List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanGroupsDTO>>(e));
            }

        }


        [HttpGet]

        public async Task<IActionResult> GetTestPlanGroupsByID(byte id)
        {
            try
            {

                Core.Models.TestPlanGroups testPlanGroups = await _testPlanGroupsService.GetTestPlanGroupsByIdAsync(id);

                var res = (new List<Core.Models.TestPlanGroups> { testPlanGroups }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanGroups failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanGroupsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanGroupsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistTestPlanGroups/{name}")]
        public async Task<IActionResult> ExistTestPlanGroups(string name)
        {
            try
            {

                var result = _testPlanGroupsService.ExistTestPlanGroupsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanGroups failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] TestPlanGroupsDTO testPlanGroups)
        {
            try
            {
                TestPlanGroups testPlanGroup = new TestPlanGroups();
                var mapper = Functions.CreateMapper<TestPlanGroupsDTO, TestPlanGroups>();
                testPlanGroup = mapper(testPlanGroups);

                bool result = _testPlanGroupsService.Append(testPlanGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanGroups append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] TestPlanGroupsDTO testPlanGroups)
        {
            try
            {
                TestPlanGroups testPlanGroup = new TestPlanGroups();
                var mapper = Functions.CreateMapper<TestPlanGroupsDTO, TestPlanGroups>();
                testPlanGroup = mapper(testPlanGroups);

                bool result = _testPlanGroupsService.Update(testPlanGroup);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanGroups update failed");
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
                long result = _testPlanGroupsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanGroups update failed");
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
