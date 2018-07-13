using System;
using ESP.Core.Account.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ESP.Core.Account.Web.Filter
{
    public class RestApiAttribute:  Attribute, IExceptionFilter, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as JsonResult;
            if(result!=null)
            {
                var restResult = new RestApiResult
                {
                    Code = 200,
                    Data = result.Value
                };
                context.Result = new JsonResult(restResult);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnException(ExceptionContext context)
        {
            var error = context.Exception;
            if (error != null)
            {
                var restResult = new RestApiResult
                {
                    Code = 500,
                    Data = error.Message
                };
                context.Result = new JsonResult(restResult);
            }
        }
    }
}
