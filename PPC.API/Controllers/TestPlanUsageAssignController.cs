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
    public class TestPlanAssignController : Controller
    {

        #region Prop

        private readonly ITestPlanAssignService _testPlanAssignService;

        #endregion

        #region Ctor

        public TestPlanAssignController(ITestPlanAssignService testPlanAssignService)
        {
            _testPlanAssignService = testPlanAssignService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlanAssign()
        {
            try
            {

                List<Core.Models.TestPlanAssign> testPlanAssign = await _testPlanAssignService.GetAllAsync();

                //var res = testPlanAssign == null
                //    ? null
                //    : testPlanAssign.ConvertToListDto();
                
                var res = ExtAutoMapper.JsonMap<List<TestPlanAssign>, List<TestPlanAssignDTO>>(testPlanAssign);


                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanAssign List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTestPlanAssignByID(int id)
        {
            try
            {

                Core.Models.TestPlanAssign testPlanAssign = await _testPlanAssignService.GetTestPlanAssignByIdAsync(id);

                //var res = testPlanAssign == null
                //    ? null
                //    : (new List<Core.Models.TestPlanAssign> { testPlanAssign }).ConvertToListDto();

                var res = new List<TestPlanAssignDTO> { ExtAutoMapper.JsonMap<TestPlanAssign, TestPlanAssignDTO>(testPlanAssign) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanAssign failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{code}")]
        public async Task<IActionResult> ExistTestPlanAssign(string code)
        {
            try
            {

                var result = _testPlanAssignService.ExistTestPlanAssignAsync(code);

                var res = new List<TestPlanAssign> { await result };

                return Ok(ResponseFactory.OKCreator<List<TestPlanAssign>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanAssign failed");
                return Ok(ResponseFactory.OKCreator<List<TestPlanAssign>>(new List<TestPlanAssign>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssign>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] TestPlanAssign testPlanAssign)
        {
            try
            {

                int result = _testPlanAssignService.Append(testPlanAssign);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanAssign append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] TestPlanAssign testPlanAssign)
        {
            try
            {

                bool result = _testPlanAssignService.Update(testPlanAssign);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanAssign update failed");
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
                long result = _testPlanAssignService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanAssign delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetTestPlanAssignForDropDown()
        //{
        //    try
        //    {

        //        List<Core.Models.TestPlanAssignViewModel> testPlanAssign = await _testPlanAssignService.GetAllForDropDownAsync();

        //        var res = testPlanAssign == null
        //            ? null
        //            : testPlanAssign.ConvertToListDto();
        //        return Ok(ResponseFactory.OKCreator(res, res.Count()));

        //    }
        //    catch (HttpResponseException)
        //    {
        //        LogManager.Warn($"Get TestPlanAssign List failed");
        //        return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDTO>(), 0));
        //    }
        //    catch (System.Exception e)
        //    {
        //        LogManager.Error("Error Login", e);
        //        return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDTO>>(e));
        //    }

        //}

        [HttpGet]
        public async Task<IActionResult> GetLatestByTestPlanId(int id)
        {
            try
            {

                Core.Models.TestPlanAssign testPlanAssign = await _testPlanAssignService.GetLatestTestPlanAssignByTestPlanIdAsync(id);

                //var res = testPlanAssign == null
                //    ? null
                //    : (new List<Core.Models.TestPlanAssign> { testPlanAssign }).ConvertToListDto();

                var res = new List<TestPlanAssignDTO> { ExtAutoMapper.JsonMap<TestPlanAssign, TestPlanAssignDTO>(testPlanAssign) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanAssign failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{testPlanCode}")]
        public async Task<IActionResult> GetLatestByTestPlanCode(string testPlanCode)
        {
            try
            {

                Core.Models.TestPlanAssign testPlanAssign = await _testPlanAssignService.GetLatestTestPlanAssignByTestPlanCodeAsync(testPlanCode);

                //var res = testPlanAssign == null
                //    ? null
                //    : (new List<Core.Models.TestPlanAssign> { testPlanAssign }).ConvertToListDto();

                var res = new List<TestPlanAssignDTO> { ExtAutoMapper.JsonMap<TestPlanAssign, TestPlanAssignDTO>(testPlanAssign) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanAssign failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanAssignDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanAssignDTO>>(e));
            }

        }


    }
}
