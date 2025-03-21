using System;
using System.Collections.Generic;
using System.Text;

namespace AC_PPC.Common
{
    public class Utility
    {

        public static string ConvertTimeNumToStr(int time)
        {
            try
            {
                string str = null;

                if (time <= 0) return "00:00";

                if (time >= 2359) return str;

                if (time <= 59)
                {
                    str = time.ToString("00");
                }
                else
                {
                    var hh = (int)(time / 100);
                    var mm = time - (hh * 100);

                    str = hh.ToString("00") + ":" + mm.ToString("00");

                }

                return str;
            }
            catch
            {

                throw;
            }
        }

        public static string ConvertDateNumToStr(int date, char ch = '/')
        {
            try
            {
                string str = null;

                if (date.ToString().Length != 8) return str;

                str = date.ToString().Insert(6, ch.ToString()).Insert(4, ch.ToString());

                return str;
            }
            catch
            {

                throw;
            }
        }

    }
}
