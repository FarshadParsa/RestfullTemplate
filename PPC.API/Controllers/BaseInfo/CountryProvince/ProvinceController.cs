using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PPC.Base.Models.Exceptions;
using PPC.Core.Interface;
using PPC.Core.Log;
using PPC.Response.DTOs;
using PPC.Response.Result;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using PPC.Core.Extensions;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

using PPC.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PPC.Base;
using PPC.Core.Models;
using PPC.Core.Services;

namespace PPC.API.Controllers
{
    [Authorize]
    [IgnoreAntiforgeryToken]
    public class ProvinceController : Controller
    {

        #region Prop

        private readonly IProvincesService _provincesService;

        #endregion

        #region Ctor

        public ProvinceController(IProvincesService provincesService)
        {
            _provincesService = provincesService;
        }

        #endregion

        [HttpGet]
        [Route("BaseInfo/Provinces/GetProvinces")]
        public async Task<IActionResult> GetProvinces()
        {
            try
            {

                List<Core.Models.Provinces> provinces = await _provincesService.GetAllAsync();

                var res = provinces.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Provinces List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProvincesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProvincesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Provinces/GetProvincesById/{provinceID}")]
        public async Task<IActionResult> GetProvincesByID(short provinceID)
        {
            try
            {

                Core.Models.Provinces provinces = await _provincesService.GetProvincesByIdAsync(provinceID);

                var res = (new List<Core.Models.Provinces> { provinces }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get provinces failed");
                return Ok(ResponseFactory.OKCreator(new List<ProvincesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProvincesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Provinces/ExistProvinces/{name}")]
        public async Task<IActionResult> ExistProvinces(string name)
        {
            try
            {

                var result = _provincesService.ExistProvincesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Provinces failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("BaseInfo/Provinces/Append")]
        public IActionResult Append([FromBody] ProvincesDTO provinces)
        {
            try
            {
                Provinces province = new Provinces();
                var mapper = Functions.CreateMapper<ProvincesDTO, Provinces>();
                province = mapper(provinces);

                bool result = _provincesService.Append(province);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Provinces append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Provinces/Update")]
        public IActionResult Update([FromBody] ProvincesDTO provinces)
        {
            try
            {
                Provinces province = new Provinces();
                var mapper = Functions.CreateMapper<ProvincesDTO, Provinces>();
                province = mapper(provinces);

                bool result = _provincesService.Update(province);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Provinces update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Provinces/Delete/{provinceID}")]
        public IActionResult Delete(short provinceID)
        {
            try
            {
                long result = _provincesService.Delete(provinceID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Provinces update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }


        [HttpGet]
        [Route("BaseInfo/Provinces/GetActiveProvinces")]
        public async Task<IActionResult> GetActiveProvinces()
        {

            try
            {

                List<PPC.Core.Models.Provinces> province = await _provincesService.GetActiveProvincesAsync();

                var res = province.ConvertToListDto();

                return Ok(ResponseFactory.OKCreator<List<ProvincesDTO>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Province List failed");
                return Ok(ResponseFactory.OKCreator<List<ProvincesDTO>>(new List<ProvincesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProvincesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Provinces/ExistProvince/{provinceName}")]
        public async Task<IActionResult> ExistProvince(string provinceName)
        {

            try
            {
                var result = _provincesService.ExistProvincesAsync(provinceName);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Province failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Provinces/ExistProvinceCode/{provinceCode}")]
        public async Task<IActionResult> ExistProvinceCode(string provinceCode)
        {

            try
            {
                var result = _provincesService.ExistProvincesAsync(provinceCode);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Province failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Provinces/GetProvincesByCode/{provinceCode}")]
        public async Task<IActionResult> GetProvincesByCode(string provinceCode)
        {
            try
            {

                Core.Models.Provinces provinces = await _provincesService.GetProvincesByCodeAsync(provinceCode);

                var res = (new List<Core.Models.Provinces> { provinces }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get provinces failed");
                return Ok(ResponseFactory.OKCreator(new List<ProvincesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProvincesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Provinces/GetProvincesByName/{provinceName}")]
        public async Task<IActionResult> GetProvincesByName(string provinceName)
        {
            try
            {

                Core.Models.Provinces provinces = await _provincesService.GetProvincesByNameAsync(provinceName);

                var res = (new List<Core.Models.Provinces> { provinces }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get provinces failed");
                return Ok(ResponseFactory.OKCreator(new List<ProvincesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProvincesDTO>>(e));
            }

        }


        [HttpGet]
        [Route("BaseInfo/Provinces/GetProvincesByCountryID/{id}")]
        public async Task<IActionResult> GetProvincesByCountryID(short id)
        {
            try
            {

                List<Core.Models.Provinces> provinces = await _provincesService.GetAllByCountryIDAsync(id);

                var res = provinces.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Provinces List failed");
                return Ok(ResponseFactory.OKCreator(new List<ProvincesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<ProvincesDTO>>(e));
            }

        }


    }
}
