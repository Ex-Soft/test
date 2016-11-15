
namespace Pfz.Collections
{
    /// <summary>
    /// Delegate used by ThreadSafe dictionaries on the GetOrCreateDiscardableValue methods.
    /// </summary>
    public delegate void DiscardUnusedValueDelegate<TKey, TValue>(TKey key, TValue unusedValue, TValue usedValue);
}
