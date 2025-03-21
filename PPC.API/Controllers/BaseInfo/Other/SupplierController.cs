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
    public class SupplierController : Controller
    {

        #region Prop

        private readonly ISuppliersService _suppliersService;

        #endregion

        #region Ctor

        public SupplierController(ISuppliersService suppliersService)
        {
            _suppliersService = suppliersService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetSuppliers()
        {
            try
            {

                List<Core.Models.Suppliers> suppliers = await _suppliersService.GetAllAsync();

                var res = suppliers.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Suppliers List failed");
                return Ok(ResponseFactory.OKCreator(new List<SuppliersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SuppliersDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetSuppliersByID(short id)
        {
            try
            {

                Core.Models.Suppliers suppliers = await _suppliersService.GetSuppliersByIdAsync(id);

                var res = (new List<Core.Models.Suppliers> { suppliers }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get suppliers failed");
                return Ok(ResponseFactory.OKCreator(new List<SuppliersDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<SuppliersDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistSuppliers/{name}")]
        public async Task<IActionResult> ExistSuppliers(string name)
        {
            try
            {

                var result = _suppliersService.ExistSuppliersAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Suppliers failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] SuppliersDTO suppliers)
        {
            try
            {
                Suppliers supplier = new Suppliers();
                var mapper = Functions.CreateMapper<SuppliersDTO, Suppliers>();
                supplier = mapper(suppliers);

                bool result = _suppliersService.Append(supplier);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Suppliers append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] SuppliersDTO suppliers)
        {
            try
            {
                Suppliers supplier = new Suppliers();
                var mapper = Functions.CreateMapper<SuppliersDTO, Suppliers>();
                supplier = mapper(suppliers);

                bool result = _suppliersService.Update(supplier);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Suppliers update failed");
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
                long result = _suppliersService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Suppliers update failed");
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
