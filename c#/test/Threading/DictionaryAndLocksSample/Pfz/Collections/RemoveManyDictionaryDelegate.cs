
namespace Pfz.Collections
{
	/// <summary>
	/// Delegate used by the dictionaries RemoveMany method to check if
	/// a pair should be removed. Returning true the pair is removed while
	/// returning false they remain there.
	/// </summary>
	public delegate bool RemoveManyDictionaryDelegate<TKey, TValue>(TKey key, TValue value);
}
