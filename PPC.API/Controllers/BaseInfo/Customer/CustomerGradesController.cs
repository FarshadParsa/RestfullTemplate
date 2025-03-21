using Microsoft.AspNetCore.Mvc;

using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PPC.Base.Models.Exceptions;
using PPC.Base;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Core.Models;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPC.API.Controllers.BaseInfo.Customer
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class CustomerGradeController : Controller
    {

        #region Prop

        private readonly ICustomerGradesService _customerGradesService;

        #endregion

        #region Ctor

        public CustomerGradeController(ICustomerGradesService customerGradesService)
        {
            _customerGradesService = customerGradesService;
        }

        #endregion

        [HttpGet]
        [Route("BaseInfo/Customer/CustomerGrades/GetCustomerGrades")]
        public async Task<IActionResult> GetCustomerGrades()
        {
            try
            {

                List<CustomerGrades> customerGrades = await _customerGradesService.GetAllAsync();

                var res = customerGrades.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerGrades List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerGradesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerGradesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/CustomerGrades/GetCustomerGradesById/{customerGradeID}")]
        public async Task<IActionResult> GetCustomerGradesByID(byte customerGradeID)
        {
            try
            {

                CustomerGrades customerGrades = await _customerGradesService.GetCustomerGradesByIdAsync(customerGradeID);

                var res = new List<CustomerGrades> { customerGrades }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerGrades failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerGradesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerGradesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/CustomerGrades/ExistCustomerGrades/{name}")]
        public async Task<IActionResult> ExistCustomerGrades(string name)
        {
            try
            {

                var result = _customerGradesService.ExistCustomerGradesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerGrades failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("BaseInfo/Customer/CustomerGrades/Append")]
        public IActionResult Append([FromBody] CustomerGradesDTO customerGrades)
        {
            try
            {
                CustomerGrades customerGrade = new CustomerGrades();
                var mapper = Functions.CreateMapper<CustomerGradesDTO, CustomerGrades>();
                customerGrade = mapper(customerGrades);

                bool result = _customerGradesService.Append(customerGrade);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerGrades append failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Customer/CustomerGrades/Update")]
        public IActionResult Update([FromBody] CustomerGradesDTO customerGrades)
        {
            try
            {
                CustomerGrades customerGrade = new CustomerGrades();
                var mapper = Functions.CreateMapper<CustomerGradesDTO, CustomerGrades>();
                customerGrade = mapper(customerGrades);

                bool result = _customerGradesService.Update(customerGrade);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerGrades update failed");
                return Ok(ResponseFactory.OKCreator(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Customer/CustomerGrades/Delete/{customerGradeID}")]
        public IActionResult Delete(byte customerGradeID)
        {
            try
            {
                long result = _customerGradesService.Delete(customerGradeID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerGrades update failed");
                return Ok(ResponseFactory.OKCreator(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }
    }
}
