using PPC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC.Core.Interface
{
    public interface IPrintingTechniquesService
    {

        /// <summary>
        /// Query PrintingTechnique
        /// </summary>
        /// <param name="printingTechniqueID"></param>
        /// <returns></returns>
        PrintingTechniques GetPrintingTechniquesById(short printingTechniqueID);

        /// <summary>
        /// Get  PrintingTechnique  based on id
        /// </summary>
        /// <param name="printingTechniqueID"></param>
        /// <returns></returns>
        Task<PrintingTechniques> GetPrintingTechniquesByIdAsync(short printingTechniqueID);

        /// <summary>
        /// Get all PrintingTechnique
        /// </summary>
        /// <returns></returns>
        List<PrintingTechniques> GetAll();

        /// <summary>
        /// Get all PrintingTechnique Async
        /// </summary>
        /// <returns></returns>
        Task<List<PrintingTechniques>> GetAllAsync();

        /// <summary>
        /// Get all PrintingTechnique Async
        /// </summary>
        /// <returns></returns>
        Task<List<PrintingTechniques>> GetAllByProductSerieIdAsync(int productSerieID);

        
        /// <summary>
        /// Append a record
        /// </summary>
        /// <param name="printingTechniques"></param>
        /// <returns></returns>
        bool Append(PrintingTechniques printingTechniques);

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="printingTechniques"></param>
        /// <returns></returns>
        bool Update(PrintingTechniques printingTechniques);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="printingTechniqueID"></param>
        /// <returns></returns>
        long Delete(short printingTechniqueID);

        /// <summary>
        /// Existing PrintingTechniquesAsync
        /// </summary>
        /// <param name="name">printingTechnique name</param>
        /// <returns></returns>
        Task<bool> ExistPrintingTechniquesAsync(string name);


        /// <summary>
        /// Get all PrintingTechnique Async
        /// </summary>
        /// <returns></returns>
        Task<List<PrintingTechniques>> GetActivePrintingTechniquesList();


    }
}
