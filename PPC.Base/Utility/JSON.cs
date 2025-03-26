using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Base.Utility
{
    public class JSON
    {
        ///// <summary>
        /////  تبدیل کلاس به رشته جیسون
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Value"></param>
        ///// <returns></returns>
        //public async static Task<string> ToJson<T>(T Value)
        //{
        //    var Result = JsonConvert.SerializeObject(Value, Formatting.None,
        //                new JsonSerializerSettings()
        //                {
        //                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //                });
        //    return Result;
        //}

        /// <summary>
        ///  تبدیل کلاس به رشته جیسون
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Value"></param>
        /// <returns></returns>
        public async static Task<string> ToJson<T>(T Value, ReferenceLoopHandling referenceLoopHandling = ReferenceLoopHandling.Ignore)
        {
            var Result = JsonConvert.SerializeObject(Value, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = referenceLoopHandling
                        });
            return Result;
        }

        /// <summary>
        /// حذف رفرنس از کلاس اصلی
        /// کپی کردن کلاس بدون رفنرنس
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Value"></param>
        /// <returns></returns>
        public async static Task<T> ToClone<T>(T Value)
        {
            var Result = await ToObject<T>(await ToJson(Value));

            return Result;
        }

        /// <summary>
        /// تبدیل به آبجکت
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public async static Task<T> ToObject<T>(string Value)
        {
            var Result = JsonConvert.DeserializeObject<T>(Value,
                        new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });

            return Result;
        }


        public async static Task<List<T>> JArrayToList<T>(JArray jArray)
        {
            //var Result = (List<T>)jArray;
            if (jArray == null || (jArray.Count == 1 && !jArray.First.HasValues))
                return null;

            var Result = (List<T>)(jArray.ToObject(typeof(List<T>)));
            return Result;
        }

        public async static Task<List<T>> JArrayToList<T>(object jArray)
        {
            //var Result = (List<T>)jArray;
            var Result = (List<T>)(((JArray)jArray).ToObject(typeof(List<T>)));
            return Result;
        }

        public async static Task<JArray> ListToJArray<T>(List<T> Value)
        {
            JArray Result = new JArray();
            Result.Add(Value);

            return Result;
        }

        public async static Task<System.Data.DataTable> ToDataTable(string Value)
        {

            System.Data.DataTable dt = (System.Data.DataTable)JsonConvert.DeserializeObject(Value, (typeof(System.Data.DataTable)));

            return dt;
        }



    }

    public static class JSONext
    {
        public async static Task<JArray> ListToJArray<T>(this List<T> list)
        {
            var q = (List<T>)list;
            JArray Result = new JArray();
            Result.Add(list);

            return Result;
        }

    }


}
