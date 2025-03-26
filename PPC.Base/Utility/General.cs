using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Base.Utility
{
    


    internal  class General
    {

        static string CultureCalendar = "fa-IR";
        internal  static System.Globalization.CultureInfo CalendarCulterInfo
        {
            get
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(CultureCalendar);

                return culture;
            }
            set
            {
                CultureCalendar = value.Name.ToString();
            }
        }



        #region Date

        internal static string CurrentDateString
        {
            get
            {
                return (new WebApi.Base.Utility.PersianLibrary.PersianCalendar()).getDateStr(DateTime.Now);
            }
        }

        /// <summary>
        /// return yyyyMMdd
        /// </summary>
        public static int CurrentDateNum
        {
            get => CurrentYear * 10000 + CurrentMonth * 100 + CurrentDay;
        }

        /// <summary>
        /// return yy/MM/dd
        /// </summary>
        public static string CurrentDateShortNum
        {
            get => $"{(CurrentYear - (((int)(CurrentYear / 100)) * 100)).ToString("00")}{CurrentMonth.ToString("00")}{CurrentDay.ToString("00")}";
        }
        public static int CurrentYear { get => (new System.Globalization.PersianCalendar()).GetYear((new PersianLibrary.PersianCalendar()).ToDateTime(CurrentDateString)); }
        public static int CurrentMonth { get => (new System.Globalization.PersianCalendar()).GetMonth((new PersianLibrary.PersianCalendar()).ToDateTime(CurrentDateString)); }
        public static int CurrentDay { get => (new System.Globalization.PersianCalendar()).GetDayOfMonth((new PersianLibrary.PersianCalendar()).ToDateTime(CurrentDateString)); }
        public static int CurrentDayOfYear { get => (new System.Globalization.PersianCalendar()).GetDayOfYear((new PersianLibrary.PersianCalendar()).ToDateTime(CurrentDateString)); }


        #endregion

        internal static DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        #region CurrentTime
        internal  static string CurrentTimeString
        {
            get
            {
                return DateTime.Now.ToString("HH:mm");
            }
        }
        internal  static string CurrentTimeWithSecondString
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss");
            }
        }
        internal  static int CurrentHour
        {
            get
            {
                return (Convert.ToDateTime(CurrentTimeString).Hour);
            }
        }
        internal  static int CurrentMinute
        {
            get
            {
                return Convert.ToDateTime(CurrentTimeString).Minute;
            }
        }


        #endregion
    }
}
