using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected BaseResponseResult<T> BaseResponse<T>(T data, HttpStatusCode status = HttpStatusCode.OK, string message = "", bool success = true, bool error = false)
        {
            return new BaseResponseResult<T>(data, status, message, success, error);
        }
    }

     public class BaseResponseResult<T> : IActionResult
    {
        private readonly BaseResponses<T> baseResponse;
        public BaseResponseResult(T data, HttpStatusCode status,string message, bool success, bool error)
        {
            baseResponse = new BaseResponses<T>(data,status, message, success, error);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(baseResponse)
            {
                StatusCode = (int)baseResponse.Status
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }

    public class BaseResponses<T>
    {
        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public BaseResponses(T data, HttpStatusCode status,string message, bool success, bool error)
        {
            this.Status = status;
            this.Success = success;
            this.Error = error;
            this.Message = message;
            this.Data = data;
        }
    }
}