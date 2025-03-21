using PPC.Response.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC.Response.Result
{
    public partial class ResponseFactory
    {

        public static BaseResponse<T> OKCreator<T>(T Data, int result = 0)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.PPCAPI.Code = 1;
            response.PPCAPI.Data = Data;
            response.PPCAPI.Results = result;

            return response;
        }

        public static BaseResponse<T> OKCreator<T>(T Data, int result = 0, string msg = "")
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.PPCAPI.Code = 1;
            response.PPCAPI.Data = Data;
            response.PPCAPI.Message = msg;
            response.PPCAPI.Results = result;

            return response;
        }


        public static BaseResponse<T> OKCreator<T>(string msg = null)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.PPCAPI.Data = default(T);
            response.PPCAPI.Code = 1;
            response.PPCAPI.Message = msg;
            response.PPCAPI.Results = 0;

            return response;
        }

        //public static BaseResponse<T> NotOKCreator<T>(string msg = null)
        //{
        //    BaseResponse<T> response = new BaseResponse<T>();
        //    response.PPCAPI.Data = default(T);
        //    response.PPCAPI.Code = 0;
        //    response.PPCAPI.Message = msg;
        //    response.PPCAPI.Results = 0;

        //    return response;
        //}
        public static BaseResponse<T> NotOKCreator<T>(Exception ex)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.PPCAPI.Data = default(T);
            response.PPCAPI.Code = 0;
            if (ex.InnerException != null)
            {
                response.PPCAPI.Message += ex.InnerException.Message;
                //response.PPCAPI.Message += Environment.NewLine;
                //response.PPCAPI.Message += Environment.NewLine;
                //response.PPCAPI.Message = ex.Message;
            }
            else //if (ex is PPC.Exception.HandledException)
            {
                response.PPCAPI.Message = ex.Message;
            }
            response.PPCAPI.Results = 0;

            return response;
        }
    }
}
