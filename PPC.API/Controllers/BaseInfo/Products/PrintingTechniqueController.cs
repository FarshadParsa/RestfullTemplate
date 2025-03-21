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
    public class PrintingTechniqueController : Controller
    {

        #region Prop

        private readonly IPrintingTechniquesService _printingTechniquesService;

        #endregion

        #region Ctor

        public PrintingTechniqueController(IPrintingTechniquesService printingTechniquesService)
        {
            _printingTechniquesService = printingTechniquesService;
        }

        #endregion

        [HttpGet]
        [Route("BaseInfo/Products/PrintingTechniques/GetPrintingTechniques")]
        public async Task<IActionResult> GetPrintingTechniques()
        {
            try
            {

                List<Core.Models.PrintingTechniques> printingTechniques = await _printingTechniquesService.GetAllAsync();

                var res = printingTechniques.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PrintingTechniques List failed");
                return Ok(ResponseFactory.OKCreator(new List<PrintingTechniquesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PrintingTechniquesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Products/PrintingTechniques/GetPrintingTechniquesById/{printingTechniqueID}")]
        public async Task<IActionResult> GetPrintingTechniquesByID(short printingTechniqueID)
        {
            try
            {

                Core.Models.PrintingTechniques printingTechniques = await _printingTechniquesService.GetPrintingTechniquesByIdAsync(printingTechniqueID);

                var res = (new List<Core.Models.PrintingTechniques> { printingTechniques }).ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res != null ? 1 : 0));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get printingTechniques failed");
                return Ok(ResponseFactory.OKCreator(new List<PrintingTechniquesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PrintingTechniquesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Products/PrintingTechniques/ExistPrintingTechniques/{name}")]
        public async Task<IActionResult> ExistPrintingTechniques(string name)
        {
            try
            {

                var result = _printingTechniquesService.ExistPrintingTechniquesAsync(name);

                var res = new List<bool> { await result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PrintingTechniques failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }


        [HttpPost]
        [Route("BaseInfo/Products/PrintingTechniques/Append")]
        public IActionResult Append([FromBody] PrintingTechniquesDTO printingTechniques)
        {
            try
            {
                PrintingTechniques printingTechnique = new PrintingTechniques();
                var mapper = Functions.CreateMapper<PrintingTechniquesDTO, PrintingTechniques>();
                printingTechnique = mapper(printingTechniques);

                bool result = _printingTechniquesService.Append(printingTechnique);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PrintingTechniques append failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpPost]
        [Route("BaseInfo/Products/PrintingTechniques/Update")]
        public IActionResult Update([FromBody] PrintingTechniquesDTO printingTechniques)
        {
            try
            {
                PrintingTechniques printingTechnique = new PrintingTechniques();
                var mapper = Functions.CreateMapper<PrintingTechniquesDTO, PrintingTechniques>();
                printingTechnique = mapper(printingTechniques);

                bool result = _printingTechniquesService.Update(printingTechnique);

                var res = new List<bool> { result };

                return Ok(ResponseFactory.OKCreator<List<bool>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PrintingTechniques update failed");
                return Ok(ResponseFactory.OKCreator<List<bool>>(new List<bool>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<bool>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Products/PrintingTechniques/Delete/{printingTechniqueID}")]
        public IActionResult Delete(short printingTechniqueID)
        {
            try
            {
                long result = _printingTechniquesService.Delete(printingTechniqueID);

                var res = new List<long> { result };

                return Ok(ResponseFactory.OKCreator<List<long>>(res, res.Count()));
            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"PrintingTechniques update failed");
                return Ok(ResponseFactory.OKCreator<List<long>>(new List<long>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error ... ", e);
                return Ok(ResponseFactory.NotOKCreator<List<long>>(e));
            }
        }

        [HttpGet]
        [Route("BaseInfo/Products/PrintingTechniques/GetActivePrintingTechniquesList")]
        public async Task<IActionResult> GetActivePrintingTechniquesList()
        {
            try
            {

                List<Core.Models.PrintingTechniques> printingTechniques = await _printingTechniquesService.GetActivePrintingTechniquesList();

                var res = printingTechniques.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PrintingTechniques List failed");
                return Ok(ResponseFactory.OKCreator(new List<PrintingTechniquesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PrintingTechniquesDTO>>(e));
            }

        }

        [HttpGet]
        [Route("BaseInfo/Products/PrintingTechniques/GetListByProductSerieID/{id}")]
        public async Task<IActionResult> GetListByProductSerieID(int id)
        {
            try
            {

                List<Core.Models.PrintingTechniques> printingTechniques = await _printingTechniquesService.GetAllByProductSerieIdAsync(id);

                var res = printingTechniques.ConvertToListDto();
                return Ok(ResponseFactory.OKCreator(res, res.Count()));

            }
            catch (HttpResponseException)
            {
                LogManager.Warn($"Get PrintingTechniques List failed");
                return Ok(ResponseFactory.OKCreator(new List<PrintingTechniquesDTO>(), 0));
            }
            catch (System.Exception e)
            {
                LogManager.Error("Error Login", e);
                return Ok(ResponseFactory.NotOKCreator<List<PrintingTechniquesDTO>>(e));
            }

        }


        

    }
}
