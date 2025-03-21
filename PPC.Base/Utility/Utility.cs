using PPC.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC.Base.Utility
{
    public class Utility
    {
        //public  void ClassMapper<T,D>(dynamic source, dynamic target )
        //{
        //    Functions functions = new Functions();
        //    var mapper = functions.CreateMapper<T, D>();
        //    //var mapped = mapper(instances[0]);


        //}


        #region Date
        public static string FormatPersianDate(int? date)
        {
            try
            {
                string strDate = null;

                if (date == null || date.ToString().Length != 8) return strDate;

                strDate = date.ToString().Insert(6, "/").Insert(4, "/");

                return strDate;
            }
            catch
            {

                throw;
            }
        }
        #endregion

        


    }
}
