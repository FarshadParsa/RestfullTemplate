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
using PPC.Core.Services;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class CustomerDossierBOMsController : Controller
    {

        #region Prop

        private readonly ICustomerDossierBOMsService _customerDossierBOMsService;

        #endregion

        #region Ctor

        public CustomerDossierBOMsController(ICustomerDossierBOMsService customerDossierBOMsService)
        {
            _customerDossierBOMsService = customerDossierBOMsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetCustomerDossierBOMs()
        {
            try
            {

                List<Core.Models.CustomerDossierBOMs> customerDossierBOMs = await _customerDossierBOMsService.GetAllAsync();

                var res = customerDossierBOMs == null
                    ? null
                    : customerDossierBOMs.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossierBOMs List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierBOMsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierBOMsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDossierBOMsByID(int id)
        {
            try
            {

                Core.Models.CustomerDossierBOMs customerDossierBOMs = await _customerDossierBOMsService.GetCustomerDossierBOMsByIdAsync(id);

                var res = customerDossierBOMs == null
                    ? null
                    : (new List<Core.Models.CustomerDossierBOMs> { customerDossierBOMs }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDossierBOMs failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierBOMsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierBOMsDTO>>(e));
            }

        }

        
        [HttpPost]
        public async Task<IActionResult> Append([FromBody] CustomerDossierBOMs customerDossierBOMs)
        {
            try
            {

                int result = _customerDossierBOMsService.Append(customerDossierBOMs);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossierBOMs append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] CustomerDossierBOMs customerDossierBOMs)
        {
            try
            {

                bool result = _customerDossierBOMsService.Update(customerDossierBOMs);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossierBOMs update failed");
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
                long result = _customerDossierBOMsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossierBOMs delete failed");
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
                List<Core.Models.CustomerDossierBOMs> bOM = await _customerDossierBOMsService.GetListByCustomerIdAsync(id);

                var res = bOM == null
                    ? null
                    : bOM.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossierBOMs List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierBOMsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierBOMsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByCustomerDossierId(int id)
        {
            try
            {
                List<Core.Models.CustomerDossierBOMs> bOM = await _customerDossierBOMsService.GetListByCustomerDossierIdAsync(id);

                var res = bOM == null
                    ? null
                    : bOM.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossierBOMs List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierBOMsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierBOMsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetListByBOMId(int id)
        {
            try
            {

                List<Core.Models.CustomerDossierBOMs> customerDossierBOMs = await _customerDossierBOMsService.GetAllByBOMIdAsync(id);

                var res = customerDossierBOMs == null
                    ? null
                    : customerDossierBOMs.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDossierBOMs List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDossierBOMsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDossierBOMsDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{customerDossierBOMId}/{isActive}")]
        public IActionResult SetActive(int customerDossierBOMId ,  bool isActive)
        {
            try
            {
                bool result = _customerDossierBOMsService.SetActive(customerDossierBOMId, isActive);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDossierBOMs delete failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


    }
}
