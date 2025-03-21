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
    public class CountryController : Controller
    {

        #region Prop

        private readonly ICountriesService _countriesService;

        #endregion

        #region Ctor

        public CountryController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetCountries()
        {
            try
            {

                List<Core.Models.Countries> countries = await _countriesService.GetAllAsync();

                var res = countries.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Countries List failed");
                return Ok(ResponseFactory.OKCreator(new List<CountriesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CountriesDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetCountriesByID(short id)
        {
            try
            {

                Core.Models.Countries countries = await _countriesService.GetCountriesByIdAsync(id);

                var res = (new List<Core.Models.Countries> { countries }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get countries failed");
                return Ok(ResponseFactory.OKCreator(new List<CountriesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<CountriesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistCountries/{name}")]
        public async Task<IActionResult> ExistCountries(string name)
        {
            try
            {

                var result = _countriesService.ExistCountriesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Countries failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] CountriesDTO countries)
        {
            try
            {
                Countries country = new Countries();
                var mapper = Functions.CreateMapper<CountriesDTO, Countries>();
                country = mapper(countries);

                bool result = _countriesService.Append(country);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Countries append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] CountriesDTO countries)
        {
            try
            {
                Countries country = new Countries();
                var mapper = Functions.CreateMapper<CountriesDTO, Countries>();
                country = mapper(countries);

                bool result = _countriesService.Update(country);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Countries update failed");
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
                long result = _countriesService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Countries update failed");
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
