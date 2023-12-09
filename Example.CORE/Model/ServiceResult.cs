using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.CORE.Model
{
    public class ServiceResult<T>
    {

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }


        public static ServiceResult<T> SuccessResult(T Data, string Message, int StatusCode=202)
        {


            return new ServiceResult<T> { Data = Data, Message = Message, StatusCode=StatusCode, Success=true };

        }

        public static ServiceResult<T> FailureResult(string Message, int StatusCode=400)
        {

            return new ServiceResult<T> { Message = Message, StatusCode = StatusCode, Success = false };

        }
    }
}
