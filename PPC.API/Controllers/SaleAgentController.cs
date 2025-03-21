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
    public class SaleAgentController : Controller
    {

        #region Prop

        private readonly ISaleAgentsService _saleAgentsService;

        #endregion

        #region Ctor

        public SaleAgentController(ISaleAgentsService saleAgentsService)
        {
            _saleAgentsService = saleAgentsService;
        }

        #endregion

        [HttpGet]
        [Route("BaseInfo/Customer/SaleAgents/GetSaleAgents")]
        public async Task<IActionResult> GetSaleAgents()
        {
            try
            {

                List<Core.Models.SaleAgents> saleAgents = await _saleAgentsService.GetAllAsync();

                var res = saleAgents.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get SaleAgents List failed");
                return Ok(ResponseFactory.OKCreator(new List<SaleAgentsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SaleAgentsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/SaleAgents/GetSaleAgentsById/{saleAgentID}")]
        public async Task<IActionResult> GetSaleAgentsByID(short saleAgentID)
        {
            try
            {

                Core.Models.SaleAgents saleAgents = await _saleAgentsService.GetSaleAgentsByIdAsync(saleAgentID);

                var res = (new List<Core.Models.SaleAgents> { saleAgents }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get saleAgents failed");
                return Ok(ResponseFactory.OKCreator(new List<SaleAgentsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SaleAgentsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/SaleAgents/ExistSaleAgents/{name}")]
        public async Task<IActionResult> ExistSaleAgents(string name)
        {
            try
            {

                var result = _saleAgentsService.ExistSaleAgentsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get SaleAgents failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("BaseInfo/Customer/SaleAgents/Append")]
        public IActionResult Append([FromBody] SaleAgentsDTO saleAgents)
        {
            try
            {
                SaleAgents saleAgent = new SaleAgents();
                var mapper = Functions.CreateMapper<SaleAgentsDTO, SaleAgents>();
                saleAgent = mapper(saleAgents);

                bool result = _saleAgentsService.Append(saleAgent);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SaleAgents append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Customer/SaleAgents/Update")]
        public IActionResult Update([FromBody] SaleAgentsDTO saleAgents)
        {
            try
            {
                SaleAgents saleAgent = new SaleAgents();
                var mapper = Functions.CreateMapper<SaleAgentsDTO, SaleAgents>();
                saleAgent = mapper(saleAgents);

                bool result = _saleAgentsService.Update(saleAgent);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SaleAgents update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Customer/SaleAgents/Delete/{saleAgentID}")]
        public IActionResult Delete(short saleAgentID)
        {
            try
            {
                long result = _saleAgentsService.Delete(saleAgentID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"SaleAgents update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        [Route("BaseInfo/Customer/SaleAgents/GetSaleAgentsByCode/{saleAgentCode}")]
        public async Task<IActionResult> GetSaleAgentsByCode(string saleAgentCode)
        {
            try
            {
                Core.Models.SaleAgents saleAgents = await _saleAgentsService.GetSaleAgentsByCodeAsync(saleAgentCode);

                var res = (new List<Core.Models.SaleAgents> { saleAgents }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get saleAgents failed");
                return Ok(ResponseFactory.OKCreator(new List<SaleAgentsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SaleAgentsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Customer/SaleAgents/GetSaleAgentsByName/{saleAgentName}")]
        public async Task<IActionResult> GetSaleAgentsByName(string saleAgentName)
        {
            try
            {
                Core.Models.SaleAgents saleAgents = await _saleAgentsService.GetSaleAgentsByNameAsync(saleAgentName);

                var res = (new List<Core.Models.SaleAgents> { saleAgents }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get saleAgents failed");
                return Ok(ResponseFactory.OKCreator(new List<SaleAgentsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SaleAgentsDTO>>(e));
            }

        }



    }
}
