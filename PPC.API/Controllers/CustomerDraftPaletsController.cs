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
    public class CustomerDraftPaletsController : Controller
    {

        #region Prop

        private readonly ICustomerDraftPaletsService _customerDraftPaletsService;

        #endregion

        #region Ctor

        public CustomerDraftPaletsController(ICustomerDraftPaletsService customerDraftPaletsService)
        {
            _customerDraftPaletsService = customerDraftPaletsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetCustomerDraftPalets()
        {
            try
            {

                List<Core.Models.CustomerDraftPalets> customerDraftPalets = await _customerDraftPaletsService.GetAllAsync();

                //var res = customerDraftPalets == null
                //? null 
                //: customerDraftPalets.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<CustomerDraftPalets>,List<CustomerDraftPaletsDTO>> (customerDraftPalets);

                var res = ExtAutoMapper.JsonMap<List<CustomerDraftPalets>, List<CustomerDraftPaletsDTO>>(customerDraftPalets);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDraftPalets List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftPaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftPaletsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDraftPaletsByID(int id)
        {
            try
            {

                Core.Models.CustomerDraftPalets customerDraftPalets = await _customerDraftPaletsService.GetCustomerDraftPaletsByIdAsync(id);

                //var res = customerDraftPalets == null
                //    ? null 
                //    : (new List<Core.Models.CustomerDraftPalets> { customerDraftPalets }).ConvertToListDto();

                //var res = customerDraftPalets == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<CustomerDraftPalets>, List<CustomerDraftPaletsDTO>>(new List<CustomerDraftPalets> { customerDraftPalets });

                var res = new List<CustomerDraftPaletsDTO> { ExtAutoMapper.JsonMap<CustomerDraftPalets, CustomerDraftPaletsDTO>(customerDraftPalets) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDraftPalets failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftPaletsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftPaletsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] CustomerDraftPalets customerDraftPalets)
        {
            try
            {

                int result = _customerDraftPaletsService.Append(customerDraftPalets);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDraftPalets append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] CustomerDraftPalets customerDraftPalets)
        {
            try
            {

                bool result = _customerDraftPaletsService.Update(customerDraftPalets);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDraftPalets update failed");
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
                long result = _customerDraftPaletsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDraftPalets delete failed");
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
