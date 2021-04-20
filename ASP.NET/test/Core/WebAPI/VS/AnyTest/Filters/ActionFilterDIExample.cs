using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnyTest.Filters
{
    public class ActionFilterDIExample : ActionFilterAttribute
    {
        private readonly ISmthService _smthService;

        public ActionFilterDIExample(ISmthService smthService)
        {
            _smthService = smthService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            System.Diagnostics.Debug.WriteLine("ActionFilterDIExample.OnActionExecuting()");

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
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            System.Diagnostics.Debug.WriteLine("ActionFilterDIExample.OnActionExecuted()");
        }
    }
}
