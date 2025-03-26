using WebApi.Response.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Response.Result
{
    public class ResponseFactory
    {
        public static BaseResponse<T> OKCreator<T>(T Data, int result = 0, string msg = "")
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.Payload.Code = 1;
            response.Payload.Data = Data;
            response.Payload.Message = msg;
            response.Payload.Results = result;

            return response;
        }


        public static BaseResponse<T> OKCreator<T>(string msg = null)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.Payload.Data = default(T);
            response.Payload.Code = 1;
            response.Payload.Message = msg;
            response.Payload.Results = 0;

            return response;
        }

        public static BaseResponse<T> NotOKCreator<T>(Exception ex)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            response.Payload.Data = default(T);
            response.Payload.Code = 0;
            if (ex.InnerException != null)
            {
                response.Payload.Message += ex.InnerException.Message;
            }
            else 
            {
                response.Payload.Message = ex.Message;
            }
            response.Payload.Results = 0;

            return response;
        }
    }
}
