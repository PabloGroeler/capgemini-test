using System.Collections.Generic;
using capgemini_test.src.Core.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace capgemini_test.src.Core.CrossCutting.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null) return;

            if (context.Exception is HttpResponseException exception)
            {
                context.Result = exception.ToResult();
            }
            else
            {
                context.Result = new JsonResult(new { Erros = new List<string> { context.Exception.Message } })
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ContentType = "application/problem+json"
                };
            }

            context.ExceptionHandled = true;
        }
    }
}