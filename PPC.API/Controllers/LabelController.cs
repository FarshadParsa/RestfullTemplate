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
    public class LabelController : Controller
    {

        #region Prop

        private readonly ILabelService _labelService;

        #endregion

        #region Ctor

        public LabelController(ILabelService labelService)
        {
            _labelService = labelService;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetLabel()
        {
            try
            {

                List<Core.Models.Label> label = await _labelService.GetAllAsync();

                //var res = label == null
                //    ? null
                //    : label.ConvertToListDto();


                var res =  ExtAutoMapper.JsonMap<List<Label>, List<LabelDTO>>(label) ;

                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Label List failed");
                return Ok(ResponseFactory.OKCreator(new List<LabelDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<LabelDTO>>(e));
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetLabelByID(int id)
        {
            try
            {

                Core.Models.Label label = await _labelService.GetLabelByIdAsync(id);

                //var res = label == null
                //    ? null
                //    : (new List<Core.Models.Label> { label }).ConvertToListDto();

                var res = new List<LabelDTO> { ExtAutoMapper.JsonMap<Label, LabelDTO>(label) };
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get label failed");
                return Ok(ResponseFactory.OKCreator(new List<LabelDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<LabelDTO>>(e));
            }

        }

        [HttpGet("[Controller]/[Action]/{name}")]
        public async Task<IActionResult> GetLabelByName(string name)
        {
            try
            {

                var result = _labelService.GetInstanceByNameAsync(name);

                var res = new List<Label> { await result };

                return Ok(ResponseFactory.OKCreator<List<Label>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Label failed");
                return Ok(ResponseFactory.OKCreator<List<Label>>(new List<Label>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<Label>>(e));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Append([FromBody] Label label)
        {
            try
            {

                int result = _labelService.Append(label);

                var res = new List<int> { result };

                return Ok(ResponseFactory.OKCreator<List<int>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Label append failed");
                return Ok(ResponseFactory.OKCreator<List<int>>(new List<int>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<int>>(e));
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody] Label label)
        {
            try
            {

                bool result = _labelService.Update(label);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Label update failed");
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
                long result = _labelService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Label delete failed");
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
