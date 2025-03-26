using System;
using System.Collections.Generic;
using System.Text;
using PersianLibrary;

namespace WebApi.Common
{
    #region enums Status

    public enum RawMaterialConfirmationStatus : byte
    {
        Saved = 1,
    }

    public enum DeliveryRawMaterialToProductionStatus : byte
    {
        Saved = 1,
        Deleiverd = 2,
    }
    public enum PaletStatus : byte
    {
        Saved = 1,
        InWareHouse = 2,
        Delivered = 3,
        ReturnedToProduction = 4,
        Reverted = 5
    }

    /// <summary>
    /// وضعیت های برنامه تولید
    /// </summary>
    public enum ProductionPlanStatus : byte
    {
        //Draft =0, 
        //ثبت برنامه ریزی
        Saved = 1,
        //شروع شده
        Started = 2,
        //تولید شده - وزن شده
        Produced = 3,
        //متوقف شده
        Paused = 4,
        // اقدام اصلاحی
        CorrectiveAction = 5,
        // بازکاری شروع شده
        ReworkingStarted = 6,
        // بازکاری پایان یافته
        ReworkingFinished = 7,
        //پایان یافته
        Finished = 8,
        // بازکاری شده
        Reworked = 9,

    }

    /// <summary>
    /// نوع اقدام اصلاحی
    /// </summary>
    public enum CorrectiveActionType : byte
    {
        /// <summary>
        /// اصلاح محصول
        /// </summary>
        ProductCorrection = 1,

        /// <summary>
        /// تغییر محصول
        /// </summary>
        ProductChang = 3,

        /// <summary>
        /// مصرف درصدی
        /// </summary>
        PartialUse = 4,

        /// <summary>
        /// فرآیندی
        /// </summary>
        Processing = 5,

    }


    public enum InvProductStatus : byte
    {
        SemiProduct = 1,                //نیمه محصول
        Weighted = 2,
        ReturnedToProduction = 3,       //بازگشت به تولید
        Warehouse = 4,                  //موجود در انبار
        TransferToInvRM = 5,           //انتقال به انبار مواد اولیه
        TransferToWarehouse = 6,       //انتقال به انبار محصول
        Deleiverd = 7,                  //ارسال شده
        Reverted = 8,                   //برگشت ازمشتری
        Arrived = 9,                    //تحویل شده به مشتری
    }

    public enum QcStatus : byte
    {
        Normal = 1,//عادی
        Pending = 2,//انتظار - تحت بررسی
        Locked = 3,// 
        UnLocked = 4,//بررسی شده

    }

    public enum RNDStatus : byte
    {
        Normal = 1,//عادی
        Pending = 2,//انتظار - تحت بررسی
        Locked = 3,// 
        UnLocked = 4,//بررسی شده

    }

    public enum InvRawMaterialStatus : byte
    {
        Draft = 0,
        Saved = 1,

    }


    #endregion


    public class General
    {

        static string CultureCalendar = "fa-IR";
        public static System.Globalization.CultureInfo CalendarCulterInfo
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

        public static string OrganBranchPrefixName
        { get { return "گروه صنعتي بياضيان - "; } }
        public static string OrganBranchName
        { get { return "شرکت اطلس سلولوز"; } }
        #region Company Name
        public static string CompanyName
        {
            get
            {
                return "شرکت اطلس سلولوز";
            }
        }
        #endregion
        #region CompanyColors
        private static System.Drawing.Color _CompanyColor = System.Drawing.Color.Black;
        private static System.Drawing.Color _CompanyBaseFormColor = System.Drawing.Color.LightGray;

        public static System.Drawing.Color CompanyColor
        {
            get
            {
                try
                {
                    _CompanyColor = System.Drawing.Color.Lavender;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return _CompanyColor;
            }

        }
        public static System.Drawing.Color CompanyBaseFormColor
        {
            get
            {
                try
                {
                    _CompanyBaseFormColor = System.Drawing.Color.Lavender;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return _CompanyBaseFormColor;
            }
        }
        #endregion


        #region Date

        public static string CurrentDateString
        {
            get
            {
                return (new PersianCalendar()).getDateStr(DateTime.Now);
            }
        }

        public static DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
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


        /// <summary>
        /// سال مالی
        /// </summary>
        public static short Year { get => Convert.ToInt16((new System.Globalization.PersianCalendar()).GetYear((new PersianLibrary.PersianCalendar()).ToDateTime(CurrentDateString))); }



        #endregion

        #region CurrentTime
        public static string CurrentTimeString
        {
            get
            {
                return DateTime.Now.ToString("HH:mm");
            }
        }
        public static string CurrentTimeWithSecondString
        {
            get
            {
                return DateTime.Now.ToString("HH:mm:ss");
            }
        }
        public static int CurrentHour
        {
            get
            {
                return (Convert.ToDateTime(CurrentTimeString).Hour);
            }
        }
        public static int CurrentMinute
        {
            get
            {
                return Convert.ToDateTime(CurrentTimeString).Minute;
            }
        }


        #endregion
    }
}
