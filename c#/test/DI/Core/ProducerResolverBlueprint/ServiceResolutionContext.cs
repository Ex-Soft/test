namespace TestTypeFromStringConfiguration
{
    public class ServiceResolutionContext<TKey, TService>
    {
        public TKey Key { get; }
        public TService Instance { get; }

        public ServiceResolutionContext(TKey key, TService instance)
        {
            Key = key;
            Instance = instance;
        }
    }
}
