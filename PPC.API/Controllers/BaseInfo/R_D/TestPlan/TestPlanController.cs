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
    public class TestPlanController : Controller
    {

        #region Prop

        private readonly ITestPlansService _testPlansService;

        #endregion

        #region Ctor

        public TestPlanController(ITestPlansService testPlansService)
        {
            _testPlansService = testPlansService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetTestPlans()
        {
            try
            {

                List<Core.Models.TestPlans> testPlans = await _testPlansService.GetAllAsync();

                var res = testPlans.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetLatestTestPlans()
        {
            try
            {

                List<Core.Models.TestPlans> testPlans = await _testPlansService.GetLatestTestPlansAsync();

                var res = testPlans.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetTestPlansByID(int id)
        {
            try
            {

                Core.Models.TestPlans testPlans = await _testPlansService.GetTestPlansByIdAsync(id);

                var res = (new List<Core.Models.TestPlans> { testPlans }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistTestPlans/{name}")]
        public async Task<IActionResult> ExistTestPlans(string name)
        {
            try
            {

                var result = _testPlansService.ExistTestPlansAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlans failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        public IActionResult Append([FromBody] TestPlans testPlan)
        {
            try
            {
                if (testPlan == null)
                    throw new System.Exception(Resources.Resources.pub_EnterDate);

                if (testPlan.TestPlanDetails?.Count==0)
                {
                    throw new System.Exception(Resources.Resources.TestPlanDetailNotExist);
                }

                //TestPlans testPlan = new TestPlans();
                //try
                //{
                //    var mapper = Functions.CreateMapper<TestPlansDTO, TestPlans>();
                //    testPlan = mapper(testPlans);
                //}
                //catch (System.Exception ex)
                //{
                //    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                //}


                int result = _testPlansService.Append(testPlan);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlans append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }



        [HttpPost]

        public IActionResult Update([FromBody] TestPlansDTO testPlans)
        {
            try
            {
                TestPlans testPlan = new TestPlans();
                try
                {
                    var mapper = Functions.CreateMapper<TestPlansDTO, TestPlans>();
                    testPlan = mapper(testPlans);
                }
                catch (System.Exception ex)
                {
                    return Ok(ResponseFactory.NotOKCreator<List<bool>>(new System.Exception(Resources.Resources.msg_ErrorOnReciveData)));
                }

                bool result = _testPlansService.Update(testPlan);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlans update failed");
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
                long result = _testPlansService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"TestPlans update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        
        [HttpGet("[controller]/[Action]/{id}/{codeChar}")]
        public async Task<IActionResult> GetMaxCodeByProducGroupID(short id, string codeChar)
        {
            try
            {

                Core.Models.TestPlans testPlans = await _testPlansService.GetTestPlanMaxCodeByProductGroupID(id, codeChar);

                var res = (new List<Core.Models.TestPlans> { testPlans }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }
        [HttpGet("[controller]/[Action]/{id}/{codeChar}")]
        public async Task<IActionResult> GetMaxCodeByRawMaterialGroupTypeID(short id, string codeChar)
        {
            try
            {

                Core.Models.TestPlans testPlans = await _testPlansService.GetTestPlanMaxCodeByRawMaterialGroupTypeID(id, codeChar);

                var res = (new List<Core.Models.TestPlans> { testPlans }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTestPlansForComboBox()
        {
            try
            {

                List<Core.Models.TestPlans> testPlans = await _testPlansService.GetTestPlansForCombo();

                var res = testPlans.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListForDropDown()
        {
            try
            {

                List<Core.Models.TestPlans> testPlans = await _testPlansService.GetListForDropDownAsync();

                var res = testPlans.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetLatestTestPlansByID(int id)
        {
            try
            {

                Core.Models.TestPlans testPlans = await _testPlansService.GetLatestTestPlansByIdAsync(id);

                var res = (new List<Core.Models.TestPlans> { testPlans }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet("[controller]/[Action]/{codeChar}")]
        public async Task<IActionResult> GetMaxCodeByCodeChar(string codeChar)
        {
            try
            {

                Core.Models.TestPlans testPlans = await _testPlansService.GetTestPlanMaxCodeByCodeChar(codeChar);

                var res = (new List<Core.Models.TestPlans> { testPlans }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get testPlans failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetTestPlanForDropDown()
        {
            try
            {

                List<Core.Models.TestPlans> testPlanAssign = await _testPlansService.GetAllForDropDownAsync();

                var res = testPlanAssign == null
                    ? null
                    : testPlanAssign.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get TestPlans List failed");
                return Ok(ResponseFactory.OKCreator(new List<TestPlansDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<TestPlansDTO>>(e));
            }

        }


    }
}
