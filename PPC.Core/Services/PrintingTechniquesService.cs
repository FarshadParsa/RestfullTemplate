using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;
using PPC.Response.DTOs;

namespace PPC.Core.Services
{
    public class PrintingTechniquesService : BaseService, IPrintingTechniquesService
    {
        IUnitOfWork _unitOfWork;
        public PrintingTechniquesService(RepositoryFactory repositoryFactory,
            IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }


        public List<PrintingTechniques> GetAll()
        {
            try
            {
                var printingTechniques = _repositoryFactory.PrintingTechniques.Table.ToList();

                return printingTechniques;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PrintingTechniques>> GetAllAsync()
        {
            try
            {

                var printingTechniques = await _repositoryFactory.PrintingTechniques.Table.ToListAsync();
                return printingTechniques;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<PrintingTechniques>> GetAllByProductSerieIdAsync(int productSerieID)
        {
            try
            {

                var db = _repositoryFactory;
                var printingTechniques = (from pt in  db.PrintingTechniques.Table join
                            psta in db.ProductSerieTechniqueAssigns.Table on pt.PrintingTechniqueID equals psta.PrintingTechniqueID
                         where psta.ProductSerieID == productSerieID
                        select pt).ToList();

                return printingTechniques;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public PrintingTechniques GetPrintingTechniquesById(short printingTechniqueID)
        {
            try
            {
                var printingTechniques = _repositoryFactory.PrintingTechniques
                    .FirstOrDefault(x => x.PrintingTechniqueID == printingTechniqueID);

                return printingTechniques;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PrintingTechniques> GetPrintingTechniquesByIdAsync(short printingTechniqueID)
        {
            try
            {
                var printingTechniques = await _repositoryFactory.PrintingTechniques
                    .FirstOrDefaultAsync(x => x.PrintingTechniqueID == printingTechniqueID);

                return printingTechniques;
            }
            catch
            {
                throw;
            }
        }

        public bool Append(PrintingTechniques printingTechniques)
        {
            try
            {
                _repositoryFactory.PrintingTechniques.Add(
                    new PrintingTechniques
                    {
                        PrintingTechniqueID = printingTechniques.PrintingTechniqueID,
                        PrintingTechniqueName = printingTechniques.PrintingTechniqueName,
                        PrintingTechniqueLatinName = printingTechniques.PrintingTechniqueLatinName,
                        IsActive = printingTechniques.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public bool Update(PrintingTechniques printingTechniques)
        {
            try
            {

                _repositoryFactory.PrintingTechniques.UpdateBy(x => x.PrintingTechniqueID == printingTechniques.PrintingTechniqueID,
                    new PrintingTechniques
                    {
                        PrintingTechniqueID = printingTechniques.PrintingTechniqueID,
                        PrintingTechniqueName = printingTechniques.PrintingTechniqueName,
                        PrintingTechniqueLatinName = printingTechniques.PrintingTechniqueLatinName,
                        IsActive = printingTechniques.IsActive,


                    });
                var statuse = _unitOfWork.Commit() > 0;
                return statuse;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public long Delete(short printingTechniqueID)
        {
            try
            {
                var printingTechniques = _repositoryFactory.PrintingTechniques
                    .FirstOrDefault(x => x.PrintingTechniqueID == printingTechniqueID);

                if (printingTechniques == null)
                    throw new System.Exception("PrintingTechniques Notfound.");

                _repositoryFactory.PrintingTechniques.Delete(printingTechniques);
                var statuse = _unitOfWork.Commit();

                return statuse;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> ExistPrintingTechniquesAsync(string name)
        {
            try
            {

                return await _repositoryFactory.PrintingTechniques.FirstOrDefaultAsync(x => x.PrintingTechniqueName.ToUpper() == name.ToUpper()) != null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PrintingTechniques>> GetActivePrintingTechniquesList()
        {
            try
            {

                var printingTechniques = await _repositoryFactory.PrintingTechniques.Table.Where(x => x.IsActive).ToListAsync();
                return printingTechniques;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

    }
}
