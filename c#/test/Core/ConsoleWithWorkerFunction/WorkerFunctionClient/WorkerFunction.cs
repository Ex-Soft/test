using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

using static System.Console;

namespace ConsoleWithWorkerFunction.WorkerFunctionClient
{
    public abstract class WorkerFunction : IDisposable, IHostedService
    {
        protected CancellationTokenSource CancellationToken;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                CancellationToken?.Dispose();
                CancellationToken = null;
            }
        }

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            CancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            WriteLine("WorkerFunction.StartAsync()");

            return Task.CompletedTask;
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            WriteLine("WorkerFunction.StopAsync()");

            Dispose();
            return Task.CompletedTask;
        }
    }
}
