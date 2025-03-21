using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PPC.Common;
//using PPC.Common;
using PPC.Core.Interface;
using PPC.Core.Models;
using PPC.Core.Repository;

namespace PPC.Core.Services
{
    //[SerializableAttribute]
    public partial class WeightingProductsService //: BaseService
    {
        #region InvProduct Barcode

        private (string FirstPartCode, short Counter) GetInvProductLastCode(string firstPartOfDate = null, bool internalProduct = true)
        {
            try
            {

                string firstPartCode=null;
                short counter;

                if (firstPartOfDate == null)
                {
                    string firstChar = internalProduct ? "1" : "0";
                    int yy = PPC.Common.General.CurrentYear;
                    int dddd = General.CurrentDayOfYear;

                    var partOfDate = $"{firstChar}{yy.ToString("00").Substring(2, 2)}{dddd.ToString("000")}";

                    var InvProduct = _repositoryFactory.InvProducts.Where(x => x.InvProductCode.StartsWith(partOfDate)).OrderByDescending(x=>x.InvProductCode).FirstOrDefault();
                    
                    var code = InvProduct == null || InvProduct.InvProductCode.Length != 9
                        ? (short)0
                        : Convert.ToInt16(InvProduct.InvProductCode.Substring(6, 3));

                    firstPartCode = partOfDate;
                    counter = code;

                }
                else
                {
                    var fullCode = _repositoryFactory.InvProducts.FirstOrDefault(x => x.InvProductCode.StartsWith(firstPartOfDate));
                    var code = fullCode == null || fullCode.InvProductCode.Length != 9
                        ? (short)0
                        : Convert.ToInt16(fullCode.InvProductCode.Substring(6, 3));

                    counter = code;
                }

                return (firstPartCode, counter);

            }
            catch
            {
                throw;
            }
        }

        public (string FirstPartCode, short Counter) GetInvProductNewCode(string firstPartOfDate)
        {
            try
            {
                var newCode = GetInvProductLastCode(null);
                return (newCode.FirstPartCode, ++newCode.Counter);
            }
            catch
            {
                throw;
            }
        }

        public (string FirstPartCode, short Counter) GetInvProductNewCode(bool internalProduct)
        {
            try
            {
                var newCode = GetInvProductLastCode(null, internalProduct);
                return (newCode.FirstPartCode, ++newCode.Counter);
            }
            catch
            {
                throw;
            }
        }

        //private string GetInvProductLastCode(string firstPartOfDate)
        //{
        //    try
        //    {
        //        var InvProduct = _repositoryFactory.InvProducts.FirstOrDefault(x => x.InvProductCode.StartsWith(firstPartOfDate));

        //        return InvProduct?.InvProductCode;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        #endregion


    }
}
