using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace PPC.Base.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Converted into a complete physical path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToPhysicalPath(this string path)
        {
            return $"{Directory.GetCurrentDirectory()}{path}".Replace('\\', Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Format as yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string StringFormat(this DateTime? obj)
        {
            if (!obj.HasValue)
            {
                return string.Empty;
            }
            return StringFormat(obj.Value);
        }

        /// <summary>
        /// Format as yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string StringFormat(this DateTime obj)
        {
            return obj.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Format as yyyy-MM-dd
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DateFormat(this DateTime? obj)
        {
            if (!obj.HasValue)
            {
                return string.Empty;
            }
            return DateFormat(obj.Value);
        }

        /// <summary>
        /// Format as yyyy-MM-dd
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string DateFormat(this DateTime obj)
        {
            return obj.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// millisecond timestamp
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime obj)
        {
            TimeSpan ts = obj - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        public static bool IsNullOrWhiteSpace(this String value)
        {
            if (value == null) return true;

            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsWhiteSpace(value[i])) return false;
            }

            return true;
        }


        #region Strings
        /// <summary>
        /// بررسي صحت تاريخ 
        /// </summary>
        /// <param name="str">رشته تاريخي</param>
        /// <returns>عبارت منطقي</returns>
        public static Boolean IsDate(this String str, string dateFormat, CultureInfo culture)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(str, dateFormat, culture, System.Globalization.DateTimeStyles.None, out dateValue))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// تبديل كاركترهاي ويژه اس كيو ال جهت ثبت در بانك 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String ToSqlString(this String str)
        {
            return str.ToString().Replace("'", "''").Replace("%", "%%");
        }
        /// <summary>
        /// حذف كليه فضاهاي خالي
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String TrimFull(this String str)
        {
            return str.Replace(" ", "").Replace(" ", "");
        }

        public static string FirstLetterToUpperCaseOrConvertNullToEmptyString(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static string FirstCharToUpper(this string input)
        {
            input = input.ToLower();
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        /// <summary>
        /// داده ساعت است يا خير
        /// </summary>
        /// <param name="str">رشته ساعت</param>
        /// <returns></returns>
        public static Boolean IsTime(this String str)
        {
            bool result = true;
            if (str.Trim().Length.Equals(0))
                result = false;

            else if (!str.Contains(":"))
                result = false;

            else if (str.IndexOf(":").Equals(0))
                result = false;

            else if (str.IndexOf(":").Equals(str.Length - 1))
                result = false;

            else if (str.Length < 3)
                result = false;

            else
            {
                double num;
                result = double.TryParse(str.Replace(" ", "O").Replace(":", ""), out num);
            }
            return result;
        }
        /// <summary>
        /// بررسي 2رشته عددي كه آيا اولي از دومي بزرگتر است
        /// </summary>
        /// <param name="Number1">رشته اولي</param>
        /// <param name="Number2">رشته دومي</param>
        /// <returns></returns>
        public static Boolean GreaterThan(this String Number1, String Number2)
        {
            try
            {
                if (Convert.ToDecimal(Number1) > Convert.ToDecimal(Number2))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// بررسي 2رشته عددي كه آيا اولي از دومي بزرگتر يامساوي است
        /// </summary>
        /// <param name="Number1">رشته اولي</param>
        /// <param name="Number2">رشته دومي</param>
        /// <returns></returns>
        public static Boolean GreaterThanOrEqual(this String Number1, String Number2)
        {
            try
            {
                if (Convert.ToDecimal(Number1) >= Convert.ToDecimal(Number2))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// بررسي 2رشته عددي كه آيا اولي از دومي كوچكتر است
        /// </summary>
        /// <param name="Number1">رشته اولي</param>
        /// <param name="Number2">رشته دومي</param>
        /// <returns></returns>
        public static Boolean LessThan(this String Number1, String Number2)
        {
            try
            {
                if (Convert.ToDecimal(Number1) < Convert.ToDecimal(Number2))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// بررسي 2رشته عددي كه آيا اولي از دومي كوچكتر يامساوي است
        /// </summary>
        /// <param name="Number1">رشته اولي</param>
        /// <param name="Number2">رشته دومي</param>
        /// <returns></returns>
        public static Boolean LessThanOrEqual(this String Number1, String Number2)
        {
            try
            {
                if (Convert.ToDecimal(Number1) <= Convert.ToDecimal(Number2))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Objects

        /// <summary>
        /// Convert NULL To String.Empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String ToEmptyString(this object str)
        {
            if (str == null || str == DBNull.Value)
                return string.Empty;
            else
                return str.ToString();

        }

        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Byte ToByteZero(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return 0;

            Byte.TryParse(obj.ToString(), out byte num);

            return num;
        }
        /// <summary>
        /// تبديل به عدد 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Byte ToByte(this object obj)
        {
            return Byte.Parse(obj.ToString());
        }

        /// <summary>
        /// تبديل به مقدار منتطقی
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean ToBool(this object obj)
        {

            if (obj.ToEmptyString().Equals("1"))
                return true;
            return false;
            return Convert.ToBoolean(obj);
        }
        /// <summary>
        /// Nullتبديل به مقدار منتطقی با کنترل مقادیر 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean ToBoolFalse(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return false;
            else
                return Convert.ToBoolean(obj);
        }

        public static System.Byte[] ToByteArray(this object obj)
        {
            Byte[] num = null;

            try
            {
                num = (Byte[])obj;
            }
            catch { }

            return num;
        }


        /// <summary>
        /// تبديل به عدد 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Int16 ToInt16(this object obj)
        {
            return Int16.Parse(obj.ToString());
        }



        /// <summary>
        /// تبديل به عدد 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Nullable<System.Int16> ToNullableInt16(this object obj)
        {
            if (obj == null)
                return null;

            return Int16.Parse(obj.ToString());
        }

        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Int16 ToInt16Zero(this object obj)
        {
            Int16 num = 0;
            Int16.TryParse(obj.ToEmptyString(), out num);
            return num;
        }


        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Double ToDoubleZero(this object obj)
        {
            Double num = 0;
            Double.TryParse(obj.ToEmptyString(), out num);
            return num;
        }

        /// <summary>
        ///GUID تبديل به
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Guid ToGuid(this string str)
        {
            return new Guid(str);// Guid.Parse(obj);
        }

        public static System.Guid ToGuid(this object obj)
        {
            Guid t;
            if (Guid.TryParse(obj.ToEmptyString(), out t))
            {
                return (Guid)obj;
            }

            byte[] bytes = new byte[16];
            BitConverter.GetBytes(obj.ToInt64()).CopyTo(bytes, 0);
            Guid g = new Guid(bytes);
            return g;
        }
        public static System.Guid ToGuid(this int obj)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(obj.ToInt32()).CopyTo(bytes, 0);
            return new Guid(bytes);
        }


        /// <summary>
        /// Guid تبديل به 
        /// Null با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Guid ToGuidZero(this object obj)
        {
            if (obj.IsNullOrEmpty())
                return Guid.Empty;
            else
                return Guid.Parse(obj.ToString());
        }

        #region Convert List To DataTable

        #region no :1

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            System.Reflection.PropertyInfo[] Props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (System.Reflection.PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable ToDataTables<T>(this IList<T> data)
        {
            System.ComponentModel.PropertyDescriptorCollection props = System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                System.ComponentModel.PropertyDescriptor prp = props[i];
                table.Columns.Add(prp.Name, prp.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static DataTable ToDataTable<T>(this List<dynamic> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            System.Reflection.PropertyInfo[] Props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (System.Reflection.PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (dynamic item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable ConvertToDataTable(this object data)
        {
            //try
            //{

            //    //var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //    //DataTable dataTable = (DataTable)Newtonsoft.Json.JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            //    return dataTable;
            //}
            //catch
            //{

            //    throw;
            //}
            return null;
        }

        public static bool HasNull(this DataTable table)
        {
            if (table == null)
                return true;
            foreach (DataColumn column in table.Columns)
            {
                if (table.Rows.OfType<DataRow>().Any(r => r.IsNull(column)))
                    return true;
            }

            return false;
        }

        #endregion

        #region no : 2

        public static List<T> ConvertDataTableToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {

                foreach (System.Reflection.PropertyInfo pro in temp.GetProperties())
                {

                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] == DBNull.Value)
                            pro.SetValue(obj, dr[column.ColumnName].ToEmptyString(), null);
                        else
                            pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        #endregion

        #endregion


        #region DataGrid

        //public static void HideCellError(this System.Windows.Forms.DataGridView datagridView)
        //{
        //    datagridView.Rows.Cast<System.Windows.Forms.DataGridViewRow>().ToList()
        //        .ForEach(r => r.Cells.Cast<System.Windows.Forms.DataGridViewCell>().ToList().ForEach(c => c.ErrorText = string.Empty));
        //}
        //public static void HideRowError(this System.Windows.Forms.DataGridView datagridView)
        //{
        //    datagridView.Rows.Cast<System.Windows.Forms.DataGridViewRow>().ToList()
        //        .ForEach(r => r.ErrorText = string.Empty);
        //}



        #endregion
        /// <summary>
        /// تبديل به عدد 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Int32 ToInt32(this object obj)
        {

            return Int32.Parse(obj.ToString());
        }

        /// <summary>
        /// تبديل به عدد 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public static System.Int32? ToInt32Nullable(this object obj)
        //{
        //    if (obj == null)
        //        return DBNull.Value;

        //    return Int32.Parse(obj.ToString());
        //}

        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToIntZero(this object obj)
        {
            int num = 0;
            int.TryParse(obj.ToEmptyString(), out num);
            return num;
        }

        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Int32 ToInt32Zero(this object obj)
        {
            Int32 num = 0;
            Int32.TryParse(obj.ToEmptyString(), out num);
            return num;
        }
        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Int64 ToInt64(this object obj)
        {
            return Convert.ToInt64(obj);
        }
        /// <summary>
        /// NULLتبديل به عدد با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Decimal ToDecimal(this object obj)
        {
            return Decimal.Parse(obj.ToString());

        }

        public static decimal ToDecimalZero(this object obj)
        {

            decimal num = 0;
            decimal.TryParse(obj.ToEmptyString(), out num);
            return num;

        }


        /// <summary>
        /// تبديل به عدد اعشار
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToFloat(this object obj)
        {
            return float.Parse(obj.ToString());
        }
        /// <summary>
        /// NULLتبديل به عدد اعشار با كنترل مقادير 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float ToFloatZero(this object obj)
        {

            float num = 0;
            float.TryParse(obj.ToEmptyString(), out num);
            return num;

        }

        public static System.Boolean Between(this int num, int num1, int num2)
        {
            try
            {
                return num >= num1 && num <= num2;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        /// <summary>
        /// آيا مقدار خالي است 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean IsEmpty(this object obj)
        {
            bool result = false;
            if (obj.ToEmptyString().Trim().Equals(""))
                result = true;
            return result;
        }
        /// <summary>
        /// آيا مقدار صفر است 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean IsZero(this object obj)
        {
            bool result = false;
            if (obj.ToEmptyString().Trim().Equals(""))
                result = true;
            else
            {
                decimal num = 0;
                decimal.TryParse(obj.ToEmptyString(), out num);
                if (num.Equals(0))
                    result = true;
            }
            return result;
        }
        /// <summary>
        /// است NULL آيا مقدار غیر
        /// </summary> 
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean IsNotNull(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return false;
            else
                return true;
        }

        public static System.Boolean IsNotNullEmpty(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToString().Equals(string.Empty))
                return false;
            else
                return true;
        }

        /// <summary>
        /// است NULL آيا مقدار
        /// </summary> 
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean IsNull(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return true;
            else
                return false;
        }

        /// <summary>
        /// است NULL آيا مقدار
        /// </summary> 
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean IsNullOrEmpty(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToString().Trim() == "")
                return true;
            else
                return false;
        }

        /// <summary>
        /// آيا مقدار خالي يا صفر است
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static System.Boolean IsEmptyOrZero(this object obj)
        {
            if (obj.ToEmptyString().Trim().Equals("") || obj.ToString().Trim().Equals("0"))
                return true;
            else
                return false;
        }

        public static System.Boolean IsNullOrZero(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToEmptyString().Trim().Equals("0"))
                return true;
            else
                return false;
        }


        public static System.Boolean IsNullOrZeroOrNeg(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToEmptyString().Trim().Length == 0 || obj.ToInt64() <= 0)
                return true;
            else
                return false;
        }

        public static System.Boolean IsNullOrNeg(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToInt64() <= 0)
                return true;
            else
                return false;
        }


        #endregion

        #region Integers

        /// <summary>
        /// آيا عدد بين 2عدد قرار دارد
        /// </summary>
        /// <param name="Number">عدد اصلي</param>
        /// <param name="number1">عدد1</param>
        /// <param name="number2">عدد2</param>
        /// <returns></returns>
        public static System.Boolean IsBetween(this Int16 Number, Int16 number1, Int16 number2)
        {
            if (Number >= number1 && Number <= number2)
                return true;
            else
                return false;
        }
        /// <summary>
        /// آيا عدد بين 2عدد قرار دارد
        /// </summary>
        /// <param name="Number">عدد اصلي</param>
        /// <param name="number1">عدد1</param>
        /// <param name="number2">عدد2</param>
        /// <returns></returns>
        public static System.Boolean IsBetween(this Int32 Number, Int32 number1, Int32 number2)
        {
            if (Number >= number1 && Number <= number2)
                return true;
            else
                return false;
        }
        /// <summary>
        /// آيا عدد بين 2عدد قرار دارد
        /// </summary>
        /// <param name="Number">عدد اصلي</param>
        /// <param name="number1">عدد1</param>
        /// <param name="number2">عدد2</param>
        /// <returns></returns>
        public static System.Boolean IsBetween(this Int64 Number, Int64 number1, Int64 number2)
        {
            if (Number >= number1 && Number <= number2)
                return true;
            else
                return false;
        }
        /// <summary>
        /// آيا عدد بين 2عدد قرار دارد
        /// </summary>
        /// <param name="Number">عدد اصلي</param>
        /// <param name="number1">عدد1</param>
        /// <param name="number2">عدد2</param>
        /// <returns></returns>
        public static System.Boolean IsBetween(this Decimal Number, Decimal number1, Decimal number2)
        {
            if (Number >= number1 && Number <= number2)
                return true;
            else
                return false;
        }



        #endregion

        #region Boolean
        public static Boolean Not(this Boolean logic)
        {
            return !logic;
        }
        public static Boolean Not(this Boolean? logic)
        {
            return !Convert.ToBoolean(logic);
        }
        public static Byte ToByte(this Boolean logic)
        {
            return Convert.ToByte(logic);
        }
        public static Byte ToByte(this Boolean? logic)
        {
            return Convert.ToByte(logic);
        }

        #endregion


        public static Boolean NotEquals(this object eq, int obj)
        {
            return !(eq.Equals((Object)obj));
        }

        public static Boolean NotEquals(this object eq, object obj)
        {
            return !(eq.Equals(obj));
        }


        /// <summary>
        /// تعیین معتبر بودن کد ملی
        /// </summary>
        /// <param name="nationalCode">کد ملی وارد شده</param>
        /// <returns>
        /// در صورتی که کد ملی صحیح باشد خروجی <c>true</c> و در صورتی که کد ملی اشتباه باشد خروجی <c>false</c> خواهد بود
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        public static Boolean IsValidNationalCode(this String nationalCode)
        {
            //در صورتی که کد ملی وارد شده تهی باشد

            if (String.IsNullOrEmpty(nationalCode))
                throw new Exception("لطفا کد ملی را صحیح وارد نمایید");


            //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
            if (nationalCode.Length != 10)
                throw new Exception("طول کد ملی باید ده کاراکتر باشد");

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new System.Text.RegularExpressions.Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                throw new Exception("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;


            //عملیات شرح داده شده در محاسبه فرمول
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }

        #region Compare


        /// <summary>
        /// Compares two lists and returns the differences between them.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="list1">The first list to compare.</param>
        /// <param name="list2">The second list to compare.</param>
        /// <param name="compareFunc">The function to compare two elements of type T.</param>
        /// <returns>
        /// A tuple containing two lists:
        /// - The first list contains elements in list1 not in list2.
        /// - The second list contains elements in list2 not in list1.
        /// </returns>
        public static (List<T> Differences1, List<T> Differences2) GetListDifferences<T>(
            this List<T> list1,
            List<T> list2,
            Func<T, T, bool> compareFunc)
        {
            if (list1 == null) throw new ArgumentNullException(nameof(list1));
            if (list2 == null) throw new ArgumentNullException(nameof(list2));
            if (compareFunc == null) throw new ArgumentNullException(nameof(compareFunc));

            var differences1 = new List<T>();
            var differences2 = new List<T>();

            foreach (var item in list1)
            {
                if (list2.All(x => !compareFunc(item, x)))
                    differences1.Add(item);
            }

            foreach (var item in list2)
            {
                if (list1.All(x => !compareFunc(item, x)))
                    differences2.Add(item);
            }

            return (differences1, differences2);

        }


        public static List<T> GetTest<T>(this List<T> list1)
        {
            return null;
        }


        #endregion



    }
}

