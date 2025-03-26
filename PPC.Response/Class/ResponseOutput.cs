using WebApi.Response.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Response.Class
{
    /// <summary>
    /// ResponseOutput
    /// </summary>
    public class ResponseOutput<T> : IResponseOutput<T>
    {
        /// <summary>
        /// Success
        /// </summary>
        [JsonIgnore]
        public bool Success { get; private set; }

        /// <summary>
        /// Code
        /// </summary>
        public int Code => Success ? 1 : 0;

        /// <summary>
        /// Msg
        /// </summary>
        public string Msg { get; private set; }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// ResponseOutput
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="msg">msg</param>
        public ResponseOutput<T> Ok(T data, string msg = null)
        {
            Success = true;
            Data = data;
            Msg = msg;

            return this;
        }

        /// <summary>
        /// NotOk
        /// </summary>
        /// <param name="msg">msg</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public ResponseOutput<T> NotOk(string msg = null, T data = default(T))
        {
            Success = false;
            Msg = msg;
            Data = data;

            return this;
        }
    }

    /// <summary>
    /// ResponseOutput
    /// </summary>
    public static partial class ResponseOutput
    {
        /// <summary>
        /// IResponseOutput
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="msg">msg</param>
        /// <returns></returns>
        public static IResponseOutput Ok<T>(T data = default(T), string msg = null)
        {
            return new ResponseOutput<T>().Ok(data, msg);
        }

        /// <summary>
        /// IResponseOutput
        /// </summary>
        /// <returns></returns>
        public static IResponseOutput Ok()
        {
            return Ok<string>();
        }

        /// <summary>
        /// IResponseOutput
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="msg">msg</param>
        /// <returns></returns>
        public static IResponseOutput NotOk<T>(string msg = null, T data = default(T))
        {
            return new ResponseOutput<T>().NotOk(msg, data);
        }

        /// <summary>
        /// IResponseOutput
        /// </summary>
        /// <param name="msg">msg</param>
        /// <returns></returns>
        public static IResponseOutput NotOk(string msg = null)
        {
            return new ResponseOutput<string>().NotOk(msg);
        }

        /// <summary>
        /// IResponseOutput
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public static IResponseOutput Result<T>(bool success)
        {
            return success ? Ok<T>() : NotOk<T>();
        }

        /// <summary>
        /// IResponseOutput
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        public static IResponseOutput Result(bool success)
        {
            return success ? Ok() : NotOk();
        }
    }
}
