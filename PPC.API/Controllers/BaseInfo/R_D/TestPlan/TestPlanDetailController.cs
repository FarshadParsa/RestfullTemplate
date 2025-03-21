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
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class TestPlanDetailController : Controller
    {

        #region Prop

        private readonly ITestPlanDetailsService _testPlanDetailsService;

        #endregion

        #region Ctor

        public TestPlanDetailController(ITestPlanDetailsService testPlanDetailsService)
        {
            _testPlanDetailsService = testPlanDetailsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlanDetails()
        {
            try
            {

                List<Core.Models.TestPlanDetails> testPlanDetails = await _testPlanDetailsService.GetAllAsync();

                var res = testPlanDetails.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanDetailsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetTestPlanDetailsByID(int id)
        {
            try
            {

                Core.Models.TestPlanDetails testPlanDetails = await _testPlanDetailsService.GetTestPlanDetailsByIdAsync(id);

                var res = (new List<Core.Models.TestPlanDetails> { testPlanDetails }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlanDetails failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanDetailsDTO>>(e));
            }

        }

        [HttpPost]

        public IActionResult Append([FromBody] TestPlanDetailsDTO testPlanDetails)
        {
            try
            {
                TestPlanDetails testPlanDetail = new TestPlanDetails();
                try
                {
                    var mapper = Functions.CreateMapper<TestPlanDetailsDTO, TestPlanDetails>();
                    testPlanDetail = mapper(testPlanDetails);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }


                bool result = _testPlanDetailsService.Append(testPlanDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanDetails append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] TestPlanDetailsDTO testPlanDetails)
        {
            try
            {
                TestPlanDetails testPlanDetail = new TestPlanDetails();
                try
                {
                    var mapper = Functions.CreateMapper<TestPlanDetailsDTO, TestPlanDetails>();
                    testPlanDetail = mapper(testPlanDetails);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }

                bool result = _testPlanDetailsService.Update(testPlanDetail);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanDetails update failed");
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
                long result = _testPlanDetailsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlanDetails update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        //[HttpGet("[controller]/GetDetailsByTestPlanId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDetailsByTestPlanId(int id)
        {
            try
            {

                List<Core.Models.TestPlanDetails> testPlanDetails = await _testPlanDetailsService.GetAllByTestPlanIdAsync(id);

                var res = testPlanDetails.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlanDetails List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlanDetailsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlanDetailsDTO>>(e));
            }

        }

    }
}
