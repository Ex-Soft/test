using System;

namespace Pfz.Collections
{
    /// <summary>
    /// Interface that must be implemented by IPfzDictionaries that also support dispose.
    /// This is used, for example, by the WeakDictionaries and also by the "Locked" dictionaries,
    /// which release the lock over the main dictionary when disposed.
    /// </summary>
	public interface IDisposableDictionary:
		IPfzDictionary,
		IAdvancedDisposable
	{
	}

    /// <summary>
    /// Interface that must be implemented by IPfzDictionaries that also support dispose.
    /// This is used, for example, by the WeakDictionaries and also by the "Locked" dictionaries,
    /// which release the lock over the main dictionary when disposed.
    /// </summary>
    public interface IDisposableDictionary<TKey, TValue>:
		IPfzDictionary<TKey, TValue>,
		IDisposableDictionary
	{
	}
}
