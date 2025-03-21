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

namespace PPC.API.Controllers
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class CustomerController : Controller
    {

        #region Prop

        private readonly ICustomersService _customersService;

        #endregion

        #region Ctor

        public CustomerController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        #endregion

        [HttpGet]
        [Route("BaseInfo/Customer/GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {

                List<Core.Models.Customers> customers = await _customersService.GetAllAsync();

                var res = customers.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Customers List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomersDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/GetCustomersById/{customerID}")]
        public async Task<IActionResult> GetCustomersByID(int customerID)
        {
            try
            {

                Core.Models.Customers customers = await _customersService.GetCustomersByIdAsync(customerID);

                var res = (new List<Core.Models.Customers> { customers }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customers failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomersDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/ExistCustomers/{name}")]
        public async Task<IActionResult> ExistCustomers(string name)
        {
            try
            {

                var result = _customersService.ExistCustomersAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Customers failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("BaseInfo/Customer/Append")]
        public IActionResult Append([FromBody] CustomersDTO customers)
        {
            try
            {
                Customers customer = new Customers();
                var mapper = Functions.CreateMapper<CustomersDTO, Customers>();
                customer = mapper(customers);

                bool result = _customersService.Append(customer);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Customers append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Customer/Update")]
        public IActionResult Update([FromBody] CustomersDTO customers)
        {
            try
            {
                Customers customer = new Customers();
                var mapper = Functions.CreateMapper<CustomersDTO, Customers>();
                customer = mapper(customers);

                bool result = _customersService.Update(customer);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Customers update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Customer/Delete/{customerID}")]
        public IActionResult Delete(int customerID)
        {
            try
            {
                long result = _customersService.Delete(customerID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Customers update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("BaseInfo/[Controller]/[Action]/{name}")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            try
            {

                var result = _customersService.GetCustomersByNameAsync(name);

                var res = new List<Customers> { await result };

                return Ok(ResponseFactory.OKCreator<List<Customers>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Customers failed");
                return Ok(ResponseFactory.OKCreator<List<Customers>>(new List<Customers>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<Customers>>(e));
            }
        }


    }
}
