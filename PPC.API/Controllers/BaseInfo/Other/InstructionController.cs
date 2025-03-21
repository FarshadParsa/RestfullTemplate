using Microsoft.AspNetCore.Mvc;

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
    public class InstructionController : Controller
    {

        #region Prop

        private readonly IInstructionsService _instructionsService;

        #endregion

        #region Ctor

        public InstructionController(IInstructionsService instructionsService)
        {
            _instructionsService = instructionsService;
        }

        #endregion

        [HttpGet]

        public async Task<IActionResult> GetInstructions()
        {
            try
            {

                List<Core.Models.Instructions> instructions = await _instructionsService.GetAllAsync();

                var res = instructions.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Instructions List failed");
                return Ok(ResponseFactory.OKCreator(new List<InstructionsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InstructionsDTO>>(e));
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetInstructionsByID(short id)
        {
            try
            {

                Core.Models.Instructions instructions = await _instructionsService.GetInstructionsByIdAsync(id);

                var res = (new List<Core.Models.Instructions> { instructions }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get instructions failed");
                return Ok(ResponseFactory.OKCreator(new List<InstructionsDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<InstructionsDTO>>(e));
            }

        }

        [HttpGet]
        [Route("[controller]/ExistInstructions/{name}")]
        public async Task<IActionResult> ExistInstructions(string name)
        {
            try
            {

                var result = _instructionsService.ExistInstructionsAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get Instructions failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]

        public IActionResult Append([FromBody] InstructionsDTO instructions)
        {
            try
            {
                Instructions instruction = new Instructions();
                var mapper = Functions.CreateMapper<InstructionsDTO, Instructions>();
                instruction = mapper(instructions);

                bool result = _instructionsService.Append(instruction);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Instructions append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]

        public IActionResult Update([FromBody] InstructionsDTO instructions)
        {
            try
            {
                Instructions instruction = new Instructions();
                var mapper = Functions.CreateMapper<InstructionsDTO, Instructions>();
                instruction = mapper(instructions);

                bool result = _instructionsService.Update(instruction);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Instructions update failed");
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
                long result = _instructionsService.Delete(id);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Instructions update failed");
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
