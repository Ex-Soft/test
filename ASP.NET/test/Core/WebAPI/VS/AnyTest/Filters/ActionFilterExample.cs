using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AnyTest.Filters
{
    public class ActionFilterExample : ActionFilterAttribute
    {
        public string Key { get; }

        public ActionFilterExample(string key = null)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                Key = key;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            System.Diagnostics.Debug.WriteLine("ActionFilterExample.OnActionExecuting()");

            string request = null;
            object o = null;

            if (context != null)
            {
                if (!string.IsNullOrWhiteSpace(Key))
                {
                    if (context.ActionArguments.TryGetValue(Key, out o))
                    {
                        request = o.ToString();
                        System.Diagnostics.Debug.WriteLine(request);
                    }
                }
                else
                {
                    if (context.ActionArguments.Keys.Count != 0)
                    {
                        o = context.ActionArguments[context.ActionArguments.Keys.First()];
                        request = o.ToString();
                        System.Diagnostics.Debug.WriteLine(request);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(request) && request.Contains("badrequest", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Result = o != null ? new BadRequestObjectResult(o) : new BadRequestResult();
                return;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            System.Diagnostics.Debug.WriteLine("ActionFilterExample.OnActionExecuted()");
        }
    }
}
