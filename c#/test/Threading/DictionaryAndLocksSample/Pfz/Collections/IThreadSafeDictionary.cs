using System;

namespace Pfz.Collections
{
    /// <summary>
    /// Interface that must be implemented by thread-safe PfzDictionary implementations.
    /// </summary>
	public interface IThreadSafeDictionary:
		IPfzDictionary
	{
		/// <summary>
		/// Locks this dictionary (so no other thread can write to this dictionary
		/// and, depending on the implementation, no other thread can read) and
		/// returns an object that you can use to do many operations that will
		/// not try to reacquire any lock (so, for many operations, this is faster).
		/// At the end of your actions, you should dispose the returned dictionary
		/// to release the lock.
		/// If the thread that does do lock does any call to the normal methods
		/// while the lock is held, it can dead-lock (that's, again, implementation
		/// specific).
		/// </summary>
		IDisposableDictionary Lock();

		/// <summary>
		/// Tries to get a value for the given key.
		/// If the value does not exist, a new one is generated, without holding locks and
		/// when it finishes the creation, gets the lock and a new check is done. If another 
		/// thread put a value while this thread generated a value, the other value, which 
		/// was already registered is returned and the generated value is simple lost (and, 
		/// in case of reference types, will be garbage collected sometime).
		/// </summary>
		object GetOrCreateDiscardableValue(object key);

		/// <summary>
		/// Tries to get a value for the given key.
		/// If the value does not exist, a new one is generated, without holding locks and
		/// when it finishes the creation, gets the lock and a new check is done. If another 
		/// thread put a value while this thread generated a value, the other value, which 
		/// was already registered is returned and the generated value is simple lost (and, 
		/// in case of reference types, will be garbage collected sometime).
		/// </summary>
		object GetOrCreateDiscardableValue(object key, Delegate createValue);

		/// <summary>
		/// Tries to get a value for the given key.
		/// If the value does not exist, a new one is generated, without holding locks and
		/// when it finishes the creation, gets the lock and a new check is done. If another 
		/// thread put a value while this thread generated a value, the discardUnusedValue
		/// delegate is called (so you can dispose, close or do anything necessary to
		/// discard the value generated and which will not be used) and finally the
		/// other result will be returned.
		/// </summary>
		object GetOrCreateDiscardableValue(object key, Delegate createValue, Delegate discardUnusedValue);
	}

    /// <summary>
    /// Interface that must be implemented by thread-safe PfzDictionary implementations.
    /// </summary>
	public interface IThreadSafeDictionary<TKey, TValue>:
		IPfzDictionary<TKey, TValue>,
		IThreadSafeDictionary
	{
		/// <summary>
		/// Locks this dictionary (so no other thread can write to this dictionary
		/// and, depending on the implementation, no other thread can read) and
		/// returns an object that you can use to do many operations that will
		/// not try to reacquire any lock (so, for many operations, this is faster).
		/// At the end of your actions, you should dispose the returned dictionary
		/// to release the lock.
		/// If the thread that does do lock does any call to the normal methods
		/// while the lock is held, it can dead-lock (that's, again, implementation
		/// specific).
		/// </summary>
		new IDisposableDictionary<TKey, TValue> Lock();


		/// <summary>
		/// Tries to get a value for the given key.
		/// If the value does not exist, a new one is generated, without holding locks and
		/// when it finishes the creation, gets the lock and a new check is done. If another 
		/// thread put a value while this thread generated a value, the other value, which 
		/// was already registered is returned and the generated value is simple lost (and, 
		/// in case of reference types, will be garbage collected sometime).
		/// </summary>
		TValue GetOrCreateDiscardableValue(TKey key);

		/// <summary>
		/// Tries to get a value for the given key.
		/// If the value does not exist, a new one is generated, without holding locks and
		/// when it finishes the creation, gets the lock and a new check is done. If another 
		/// thread put a value while this thread generated a value, the other value, which 
		/// was already registered is returned and the generated value is simple lost (and, 
		/// in case of reference types, will be garbage collected sometime).
		/// </summary>
		TValue GetOrCreateDiscardableValue(TKey key, Func<TKey, TValue> createValue);

		/// <summary>
		/// Tries to get a value for the given key.
		/// If the value does not exist, a new one is generated, without holding locks and
		/// when it finishes the creation, gets the lock and a new check is done. If another 
		/// thread put a value while this thread generated a value, the discardUnusedValue
		/// delegate is called (so you can dispose, close or do anything necessary to
		/// discard the value generated and which will not be used) and finally the
		/// other result will be returned.
		/// </summary>
		TValue GetOrCreateDiscardableValue(TKey key, Func<TKey, TValue> createValue, DiscardUnusedValueDelegate<TKey, TValue> discardUnusedValue);
	}
}
