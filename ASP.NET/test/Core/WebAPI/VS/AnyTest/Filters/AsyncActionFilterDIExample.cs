using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnyTest.Filters
{
    public class AsyncActionFilterDIExample : ActionFilterAttribute
    {
        private readonly ISmthService _smthService;

        public AsyncActionFilterDIExample(ISmthService smthService)
        {
            _smthService = smthService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            System.Diagnostics.Debug.WriteLine("AsyncActionFilterDIExample.OnActionExecuting()");

            string request = null;
            object o = null;

            if (context != null && context.ActionArguments.Keys.Count != 0)
            {
                o = context.ActionArguments[context.ActionArguments.Keys.First()];
                request = o.ToString();
                System.Diagnostics.Debug.WriteLine(_smthService.Validate(request));
            }

            if (!string.IsNullOrWhiteSpace(request) && request.Contains("badrequest", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Result = o != null ? new BadRequestObjectResult(o) : new BadRequestResult();
                return;
            }

            var result = await next();

            System.Diagnostics.Debug.WriteLine("AsyncActionFilterDIExample.OnActionExecutionAsync() after");
        }
    }
}
