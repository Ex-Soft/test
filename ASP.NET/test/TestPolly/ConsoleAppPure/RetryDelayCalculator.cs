namespace ConsoleAppPure
{
    public interface IRetryDelayCalculator
    {
        public TimeSpan Calculate(int attemptNumber);
    }

    public class RetryDelayCalculator : IRetryDelayCalculator
    {
        private readonly Random _random;
        private readonly object _randomLock;

        public RetryDelayCalculator()
        {
            _random = new Random();
            _randomLock = new object();
        }
        
        public TimeSpan Calculate(int attemptNumber)
        {
            int jitter;

            lock (_randomLock)
                jitter = _random.Next(10, 200);

            return TimeSpan.FromSeconds(Math.Pow(2, attemptNumber - 1)) + TimeSpan.FromMilliseconds(jitter);
        }
	}
}
