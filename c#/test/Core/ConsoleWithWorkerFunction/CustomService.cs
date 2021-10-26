using System.Threading;
using System.Threading.Tasks;
using ConsoleWithWorkerFunction.WorkerFunctionClient;

using static System.Console;

namespace ConsoleWithWorkerFunction
{
    public class CustomService : WorkerFunction
    {
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);

            WriteLine("CustomService.StartAsync()");

            // Do smth here
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);

            WriteLine("CustomService.StopAsync()");
        }
    }
}
