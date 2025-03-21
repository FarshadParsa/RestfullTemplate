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
using PPC.Base.Utility;
using PPC.Core.Services;
using AtlasCellData.ADO;

namespace PPC.API.Controllers
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [IgnoreAntiforgeryToken]
    public class CustomerDraftController : Controller
    {

        #region Prop

        private readonly ICustomerDraftsService _customerDraftsService;

        #endregion

        #region Ctor

        public CustomerDraftController(ICustomerDraftsService customerDraftsService)
        {
            _customerDraftsService = customerDraftsService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetCustomerDrafts()
        {
            try
            {

                List<Core.Models.CustomerDrafts> customerDrafts = await _customerDraftsService.GetAllAsync();

                //var res = customerDrafts == null
                //? null 
                //: customerDrafts.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<CustomerDrafts>,List<CustomerDraftsDTO>> (customerDrafts);

                var res = ExtAutoMapper.JsonMap<List<CustomerDrafts>, List<CustomerDraftsDTO>>(customerDrafts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDrafts List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerDraftsByID(int id)
        {
            try
            {

                Core.Models.CustomerDrafts customerDrafts = await _customerDraftsService.GetCustomerDraftsByIdAsync(id);

                //var res = customerDrafts == null
                //    ? null 
                //    : (new List<Core.Models.CustomerDrafts> { customerDrafts }).ConvertToListDto();

                //var res = customerDrafts == null
                //     ? null 
                //       : ExtAutoMapper.Mapper.Map<List<CustomerDrafts>, List<CustomerDraftsDTO>>(new List<CustomerDrafts> { customerDrafts });

                var res = new List<CustomerDraftsDTO> { ExtAutoMapper.JsonMap<CustomerDrafts, CustomerDraftsDTO>(customerDrafts) };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDrafts failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftsDTO>>(e));
            }

        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] CustomerDrafts customerDraft)
        {
            try
            {

                #region set Ins/Edit DateTime

                customerDraft.InsDate = PPC.Common.General.CurrentDateString;
                customerDraft.InsTime = PPC.Common.General.CurrentTimeString;

                customerDraft.EditDate = PPC.Common.General.CurrentDateString;
                customerDraft.EditTime = PPC.Common.General.CurrentTimeString;

                #endregion

                int result = _customerDraftsService.Append(customerDraft);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDrafts append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] CustomerDrafts customerDraft)
        {
            try
            {

                #region set Edit DateTime

                customerDraft.EditDate = PPC.Common.General.CurrentDateString;
                customerDraft.EditTime = PPC.Common.General.CurrentTimeString;

                #endregion

                bool result = _customerDraftsService.Update(customerDraft);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDrafts update failed");
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
                long result = _customerDraftsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res == null ? 0 : res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"CustomerDrafts delete failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet("[Controller]/[Action]/{startDate}/{endDate}")]
        public async Task<IActionResult> GetListForGrid(int startDate, int endDate)
        {
            try
            {
                string dateFrom = Utility.FormatPersianDate(startDate);
                string dateTo = Utility.FormatPersianDate(endDate);

                List<Core.Models.CustomerDrafts> customerDrafts = await _customerDraftsService.GetListForGridAsync(dateFrom, dateTo);

                //var res = customerDrafts == null
                //? null 
                //: customerDrafts.ConvertToListDto();

                //var res = ExtAutoMapper.Mapper.Map<List<CustomerDrafts>,List<CustomerDraftsDTO>> (customerDrafts);

                var res = ExtAutoMapper.JsonMap<List<CustomerDrafts>, List<CustomerDraftsDTO>>(customerDrafts);

                return Ok(ResponseFactory.OKCreator(res, res == null ? 0 : res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get CustomerDrafts List failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftsDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetNextDraftNo()
        {
            try
            {

                string customerDrafts = await _customerDraftsService.GetNextDraftNoAsync();

                var res = new List<string> { customerDrafts };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDrafts failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftsDTO>>(e));
            }

        }

        [HttpPost]
        public async Task<IActionResult> ValidateCanInsertPalet([FromBody] List<int> paletIdList)
        {
            try
            {

                var palets = await _customerDraftsService.ValidateCanInsertPaletAsync(paletIdList);



                var res = palets==null || palets.Count==0
                    ?null
                    :new List<string> { JSON.ToJson(palets).Result };

                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDrafts failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftsDTO>>(e));
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetCustomerDraftReport(int id)
        {
            try
            {

                var DT = _customerDraftsService.GetCustomerDraftReport(id);


                var res = new List<string> { JSON.ToJson(DT).Result };


                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get customerDrafts failed");
                return Ok(ResponseFactory.OKCreator(new List<CustomerDraftsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CustomerDraftsDTO>>(e));
            }

        }


    }
}
