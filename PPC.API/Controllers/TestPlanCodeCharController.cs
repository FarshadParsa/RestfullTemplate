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
    public class TestPlanCodeCharController : Controller
    {

        #region Prop

        private readonly ITestPlanCodeCharService _testPlanCodeCharService;

        #endregion

        #region Ctor

        public TestPlanCodeCharController(ITestPlanCodeCharService testPlanCodeCharService)
        {
            _testPlanCodeCharService = testPlanCodeCharService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlanCodeChar()
        {
            try
            {

                List<Core.Models.TestPlanCodeChar> testPlanCodeChar = await _testPlanCodeCharService.GetAllAsync();

                var res = testPlanCodeChar == null
                    ? null
                    : testPlanCodeChar.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanCodeChar List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanCodeCharDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanCodeCharDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTestPlanCodeCharByID(short id)
        {
            try
            {

                Core.Models.TestPlanCodeChar testPlanCodeChar = await _testPlanCodeCharService.GetTestPlanCodeCharByIdAsync(id);

                var res = testPlanCodeChar == null
                    ? null
                    : (new List<Core.Models.TestPlanCodeChar> { testPlanCodeChar }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanCodeChar failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanCodeCharDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanCodeCharDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{codeChar}")]
        public async Task<IActionResult> ExistTestPlanCodeChar(string codeChar)
        {
            try
            {

                var result = _testPlanCodeCharService.ExistTestPlanCodeCharAsync(codeChar);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanCodeChar failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] TestPlanCodeChar testPlanCodeChar)
        {
            try
            {

                short result = _testPlanCodeCharService.Append(testPlanCodeChar);

                var res = new List<short> { result };

                return Ok(ResponseFactory.OKCreator<List<short>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanCodeChar append failed");
                return Ok(ResponseFactory.OKCreator<List<short>>(new List<short>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<short>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] TestPlanCodeChar testPlanCodeChar)
        {
            try
            {

                bool result = _testPlanCodeCharService.Update(testPlanCodeChar);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanCodeChar update failed");
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
                long result = _testPlanCodeCharService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanCodeChar delete failed");
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
