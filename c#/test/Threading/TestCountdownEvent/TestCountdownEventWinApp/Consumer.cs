using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TestCountdownEventWinApp
{
    public class Consumer
    {
        private const int MSec = 100;

        private readonly int _batchSize;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly int _id;

        public Action<int> OnBatchStart;
        public Action OnConsume;
        public Func<bool> IsBatchProcessed;
        public Action<string> Pulse;

        public Consumer(int batchSize, CancellationTokenSource cancellationTokenSource, int id)
        {
            _batchSize = batchSize;
            _cancellationTokenSource = cancellationTokenSource;
            _id = id;
        }

        public async Task Consume()
        {
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var i = 0;

            OnBatchStart?.Invoke(_batchSize);

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                Pulse?.Invoke($"#{_id} Consume: {++i}");
                OnConsume?.Invoke();
                await Task.Delay(MSec * rnd.Next(10));

                if (i < _batchSize)
                    continue;

                if (IsBatchProcessed == null)
                    continue;

                if (IsBatchProcessed())
                {
                    Pulse?.Invoke("Commit");
                    i = 0;
                    OnBatchStart?.Invoke(_batchSize);
                }
            }
        }
    }
}
