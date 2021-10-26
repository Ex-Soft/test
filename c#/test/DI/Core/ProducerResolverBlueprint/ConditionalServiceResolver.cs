using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTypeFromStringConfiguration
{
    public class ConditionalServiceResolver<TKey, TCompareObject, TService>
    {
        private readonly IEnumerable<ServiceResolutionContext<TKey, TService>> _serviceContexts;
        private readonly Func<TCompareObject, TKey, bool> _comparer;

        public ConditionalServiceResolver(IEnumerable<ServiceResolutionContext<TKey, TService>> serviceContexts, Func<TCompareObject, TKey, bool> comparer)
        {
            _serviceContexts = serviceContexts;
            _comparer = comparer;
        }

        public IEnumerable<TService> Resolve(TCompareObject compareObject)
        {
            return Resolve<TService>(compareObject);
        }

        public IEnumerable<TService1> Resolve<TService1>(TCompareObject compareObject)
        {
            return _serviceContexts.Where(x => _comparer(compareObject, x.Key))
                .Select(x => x.Instance)
                .OfType<TService1>();
        }

        public IEnumerable<(TKey key, TService service)> List()
        {
            return _serviceContexts.Select(x => (x.Key, x.Instance));
        }

        public IEnumerable<(TKey key, TService1 service)> List<TService1>() where TService1: TService
        {
            return _serviceContexts
                .Where(x => x.Instance is TService1)
                .Select(x => (x.Key, (TService1)x.Instance));
        }
    }
}