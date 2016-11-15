
namespace Pfz.Collections
{
    /// <summary>
    /// Delegate used by PfzDictionaries' ForEach method.
    /// </summary>
	public delegate void ForEachDictionaryDelegate<TKey, TValue>(TKey key, TValue value);
}
