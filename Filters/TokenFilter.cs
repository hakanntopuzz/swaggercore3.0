using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SchoolAppService.Filters
{
    public class TokenFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            Console.Write($"Token Değeri : {token}");
        }

    }
}
