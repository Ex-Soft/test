
namespace Pfz.Collections
{
    /// <summary>
    /// Interface that must be implemented by dictionaries that are both
    /// thread safe and disposable.
    /// </summary>
    public interface IThreadSafeAndDisposableDictionary:
        IThreadSafeDictionary,
        IDisposableDictionary
    {
    }

    /// <summary>
    /// Interface that must be implemented by generic dictionaries that are both
    /// thread safe and disposable.
    /// </summary>
    public interface IThreadSafeAndDisposableDictionary<TKey, TValue>:
        IThreadSafeAndDisposableDictionary,
        IThreadSafeDictionary<TKey, TValue>,
        IDisposableDictionary<TKey, TValue>
    {
    }
}
