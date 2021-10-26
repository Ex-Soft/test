using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDIHost
{
    public class MyApplication
    {
        private readonly IServiceProvider _serviceProvider;

        public MyApplication(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Run()
        {
            var caller = _serviceProvider.GetService<ICaller>();

            await Task.CompletedTask;
        }
    }
}
