using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnyTest.Filters
{
    public class AsyncActionFilterExample : ActionFilterAttribute
    {
        public string Key { get; }

        public AsyncActionFilterExample(string key = null)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                Key = key;
            }
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            System.Diagnostics.Debug.WriteLine("AsyncActionFilterExample.OnActionExecutionAsync() before");

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

            var result = await next();

            System.Diagnostics.Debug.WriteLine("AsyncActionFilterExample.OnActionExecutionAsync() after");
        }
    }
}
