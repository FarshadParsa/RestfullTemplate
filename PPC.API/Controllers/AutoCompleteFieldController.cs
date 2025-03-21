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
    public class AutoCompleteFieldController : Controller
    {

        #region Prop

        private readonly IAutoCompleteFieldService _autoCompleteFieldService;

        #endregion

        #region Ctor

        public AutoCompleteFieldController(IAutoCompleteFieldService autoCompleteFieldService)
        {
            _autoCompleteFieldService = autoCompleteFieldService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAutoCompleteField()
        {
            try
            {

                List<Core.Models.AutoCompleteField> autoCompleteField = await _autoCompleteFieldService.GetAllAsync();

                var res = autoCompleteField == null
                    ? null
                    : autoCompleteField.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get AutoCompleteField List failed");
                return Ok(ResponseFactory.OKCreator(new List<AutoCompleteFieldDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<AutoCompleteFieldDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAutoCompleteFieldByID(int id)
        {
            try
            {

                Core.Models.AutoCompleteField autoCompleteField = await _autoCompleteFieldService.GetAutoCompleteFieldByIdAsync(id);

                var res = autoCompleteField == null
                    ? null
                    : (new List<Core.Models.AutoCompleteField> { autoCompleteField }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get autoCompleteField failed");
                return Ok(ResponseFactory.OKCreator(new List<AutoCompleteFieldDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<AutoCompleteFieldDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{fieldName}")]
        public async Task<IActionResult> GetAutoCompleteFieldByFieldName(string fieldName)
        {
            try
            {

                var result = await _autoCompleteFieldService.GetAutoCompleteFieldByFieldNameAsync(fieldName);

                var res = result == null
                    ? null
                    :  result .ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get AutoCompleteField failed");
                return Ok(ResponseFactory.OKCreator<List<AutoCompleteField>>(new List<AutoCompleteField>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<AutoCompleteField>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] AutoCompleteField autoCompleteField)
        {
            try
            {

                int result = _autoCompleteFieldService.Append(autoCompleteField);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"AutoCompleteField append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] AutoCompleteField autoCompleteField)
        {
            try
            {

                bool result = _autoCompleteFieldService.Update(autoCompleteField);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"AutoCompleteField update failed");
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
                long result = _autoCompleteFieldService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"AutoCompleteField delete failed");
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


