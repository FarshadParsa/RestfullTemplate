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
    public class CustomerDossierController : Controller
    {

        #region Prop

        private readonly ICustomerDossierService _customerDossierService;

        #endregion

        #region Ctor

        public CustomerDossierController(ICustomerDossierService customerDossierService)
        {
            _customerDossierService = customerDossierService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetCustomerDossier()
        {
            try
            {

                List<Core.Models.CustomerDossier> customerDossier = await _customerDossierService.GetAllAsync();

                var res = customerDossier == null
                    ? null
                    : customerDossier.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossier List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDossierByID(int id)
        {
            try
            {

                Core.Models.CustomerDossier customerDossier = await _customerDossierService.GetCustomerDossierByIdAsync(id);

                var res = customerDossier == null
                    ? null
                    : (new List<Core.Models.CustomerDossier> { customerDossier }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDossier failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{DossierNo}")]
        public async Task<IActionResult> GetByDossierNo(int dossierNo)
        {
            try
            {

                var result = _customerDossierService.GetByDossierNoAsync(dossierNo);

                var res = new List<CustomerDossier> { await result };

                return Ok(ResponseFactory.OKCreator<List<CustomerDossier>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossier failed");
                return Ok(ResponseFactory.OKCreator<List<CustomerDossier>>(new List<CustomerDossier>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossier>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] CustomerDossier customerDossier)
        {
            try
            {

                int result = _customerDossierService.Append(customerDossier);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossier append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] CustomerDossier customerDossier)
        {
            try
            {

                bool result = _customerDossierService.Update(customerDossier);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossier update failed");
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
                long result = _customerDossierService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossier delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListByCustomerId(int id)
        {
            try
            {

                List<Core.Models.CustomerDossier> customerDossier = await _customerDossierService.GetListByCustomerIdAsync(id);

                var res = customerDossier == null
                    ? null
                    : customerDossier.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossier List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierDTO>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListByProductId(int id)
        {
            try
            {

                List<Core.Models.CustomerDossier> customerDossier = await _customerDossierService.GetListByProductIdAsync(id);

                var res = customerDossier == null
                    ? null
                    : customerDossier.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossier List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{CustomerId}/{ProductId}")]
        public async Task<IActionResult> GetListByCustomerIdProductId(int customerId, int productId)
        {
            try
            {

                List<Core.Models.CustomerDossier> customerDossier = await _customerDossierService.GetListByCustomerIdProductIdAsync(customerId, productId);

                var res = customerDossier == null
                    ? null
                    : customerDossier.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossier List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierDTO>>(e));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetInstanceByMaxDossierNo()
        {
            try
            {
                CustomerDossier customerDossier = await _customerDossierService.GetInstanceByMaxDossierNoAsync();

                var res = customerDossier == null
                    ? null
                    : new List<CustomerDossier> { customerDossier }.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossier List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierDTO>>(e));
            }
        }




    }
}
