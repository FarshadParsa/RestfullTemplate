using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC.Response.Interface
{
    /// <summary>
    /// IResponseOutput
    /// </summary>
    public interface IResponseOutput
    {
        /// <summary>
        /// Success
        /// </summary>
        [JsonIgnore]
        bool Success { get; }

        /// <summary>
        /// Msg
        /// </summary>
        public string Msg { get; }
    }

    /// <summary>
    /// IResponseOutput
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponseOutput<T> : IResponseOutput
    {
        /// <summary>
        /// Data
        /// </summary>
        T Data { get; }
    }
}
