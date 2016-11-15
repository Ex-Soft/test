using System;
using System.Collections;
using System.Collections.Generic;

namespace Pfz.Collections
{
    /// <summary>
    /// Alternative dictionary interface.
    /// This one does not use ICollection for keys and values, using simple
    /// IEnumerables and also has many multi-action methods, like GetOrCreateValue,
    /// AddMany, RemoveMany and others.
    /// Also, it defines TrimExcess and SetCapacity, which are available in lists
    /// and hashsets but not in dictionaries.
    /// </summary>
	public interface IPfzDictionary:
		IEnumerable
	{
		/// <summary>
		/// Gets the type of the keys used by this dictionary.
		/// </summary>
		Type TypeOfKeys { get; }

		/// <summary>
		/// Gets the type of the values used by this dictionary.
		/// </summary>
		Type TypeOfValues { get; }

		/// <summary>
		/// Gets or sets the value by its key.
		/// When getting, if the value does not exist, throws an ArgumentException.
		/// </summary>
		object this[object key] { get; set; }

		/// <summary>
		/// Gets the Capacity (the number of items that this dictionary supports)
		/// before trying to grow.
		/// </summary>
		int Capacity { get; }

        /// <summary>
        /// Gets the equality comparer used by this dictionary to do key comparisons
        /// </summary>
        object Comparer { get; }

        /// <summary>
		/// Gets the actual number of items in this dictionary.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Returns an object capable of enumerating all the keys in this
		/// dictionary.
		/// </summary>
		IEnumerable Keys { get; }

		/// <summary>
		/// Returns an object capable of enumerating all the values in this
		/// dictionary.
		/// </summary>
		IEnumerable Values { get; }

		/// <summary>
		/// Tries to reduce the Capacity of this dictionary to a value near the Count.
		/// Can return false if it is not possible (by hashing rules) or necessary (because it
		/// has the good size). Can also throw an exception if there is no memory but it is
		/// expected that all items remain intact. (implementation specific).
		/// </summary>
		bool TrimExcess();

		/// <summary>
		/// Tries to change the capacity of this dictionary to a value given
		/// by the user.
		/// Can return false if it is not possible by hashing rules or size.
		/// Can also throw an exception if there is no memory but it is
		/// expected that all items remain intact. (implementation specific).
		/// </summary>
		bool SetCapacity(int value);

		/// <summary>
		/// Clears this dictionary. This does not mean it has reduced its capacity.
		/// </summary>
		void Clear();

		/// <summary>
		/// Verifies if a key is present in this dictionary.
		/// </summary>
		bool ContainsKey(object key);

		/// <summary>
		/// Tries to get a value for a given key. The return can be either true, meaning
		/// a value was found and put in the out value variable, or false meaning that
		/// there are no items with that key (and so the value contains the default(TValue)).
		/// </summary>
		bool TryGetValue(object key, out object value);

		/// <summary>
		/// Tries to get a value for a given key in this dictionary. If one is not found,
		/// adds the given value.
		/// Returns true if a value was found for the key, false if the value was created.
		/// If the value was added, the oldValue should always be default(TValue).
        /// If you simple want to get a value, be it old or new, use GetOrAdd.
		/// </summary>
		bool TryGetValueOrAdd(object key, object value, out object oldValue);

		/// <summary>
		/// Tries to get a value and also remove it.
		/// If the value existed, the out value will contain it. If not, the
		/// default(TValue) will be returned.
		/// In either case, true means a value was there (even null) while
		/// false means an item with that key was not there.
		/// </summary>
		bool TryGetValueAndRemove(object key, out object value);

		/// <summary>
		/// In a single operation, tries to get the value for a given key.
		/// If the key does not exist, the pair (key and value) is added.
		/// If it already exists, the value is replaced.
		/// In any case, the result is true if an oldValue existed, false
		/// otherwise.
		/// </summary>
		bool TryGetValueAndAddOrReplace(object key, object value, out object oldValue);

        /// <summary>
		/// Tries to get the value for a given key but, if it is not there, the
		/// default TValue is returned. This is very useful in cases where the default
		/// already means there is no value (like null results).
		/// </summary>
		object GetValueOrDefault(object key);

		/// <summary>
		/// Exceptions aside, this method always returns a value, be it because a
		/// new value was generated for an item (using the default TValue constructor)
		/// or because the item already existed.
		/// </summary>
		object GetOrCreateValue(object key);

        /// <summary>
		/// Exceptions aside, this method always returns a value, be it because a
		/// new value was generated for an item (using the createValue delegate)
		/// or because the item already existed.
		/// </summary>
		object GetOrCreateValue(object key, Delegate createValue);

		/// <summary>
		/// Gets an item or adds the given value to the dictionary.
		/// The result should be the item that is actually on the dictionary, independent
		/// of the reason.
		/// </summary>
		object GetOrAdd(object key, object value);

		/// <summary>
		/// Tries to removes a value by its key and returns if a value existed and
		/// was removed or not.
		/// </summary>
		bool Remove(object key);

		/// <summary>
		/// Gets the actual value for an item and then removes it.
		/// If the item does not exist, an ArgumentException is thrown.
		/// </summary>
		object GetValueAndRemove(object key);

		/// <summary>
		/// Tries to add an item. If an item with the same key exists, it returns false.
		/// </summary>
		bool TryAdd(object key, object value);

		/// <summary>
		/// Adds an item with the given key and value. If another item with the same key
		/// exists, throws an ArgumentException.
		/// </summary>
		void Add(object key, object value);

		/// <summary>
		/// Executes the same action for all pairs in this dictionary.
		/// This is usually faster than doing a normal foreach over
        /// the dictionary.
		/// </summary>
		void ForEach(Delegate action);

		/// <summary>
		/// Adds many items at once. This one is generally faster than adding 
		/// each item individually because the final size can be pre-calculated.
		/// For thread-safe implementations, this can also reduce the number of
		/// locks taken.
		/// </summary>
		void AddMany(IEnumerable pairs);

		/// <summary>
		/// Adds or replaces many items at once. This one is generally faster than 
		/// adding or replacing each item individually because the final size can be 
		/// pre-calculated.
		/// For thread-safe implementations, this can also reduce the number of
		/// locks taken.
		/// </summary>
		void AddOrReplaceMany(IEnumerable pairs);

		/// <summary>
		/// Tries to add many items at once. This one is generally faster than 
		/// trying to add each item individually because the final size can be 
		/// pre-calculated.
		/// For thread-safe implementations, this can also reduce the number of
		/// locks taken.
		/// </summary>
		void TryAddMany(IEnumerable pairs);

		/// <summary>
		/// Removes many items at once using a collection of keys. This is usually
		/// faster than doing many removes on thread safe implementations as a single 
        /// lock can be obtained.
		/// </summary>
		void RemoveMany(IEnumerable keys);

		/// <summary>
		/// Removes many items at once using a delegate to know if the item shoud be deleted.
		/// This is fast when a good number of items (50% or more) is going to be removed simple
		/// because the number of searches is reduced. But it is also useful on multi-threaded
		/// situations where a single lock can be taken.
		/// </summary>
		void RemoveMany(Delegate checkDelegate);

        /// <summary>
        /// Copies all the pairs in this dictionary to an array.
        /// This is useful if you plan to iterate many times as
        /// this copy will not change and because iterating in
        /// arrays is faster. But, if you plan to iterate only once,
        /// it is still faster to do it over the dictionary directly.
        /// </summary>
        Array ToArray();

        /// <summary>
        /// Copies all the keys in this dictionary to an array.
        /// This is useful if you plan to iterate many times as
        /// this copy will not change and because iterating in
        /// arrays is faster. But, if you plan to iterate only once,
        /// it is still faster to do it over the Keys directly.
        /// </summary>
        Array CopyKeys();

        /// <summary>
        /// Copies all the values in this dictionary to an array.
        /// This is useful if you plan to iterate many times as
        /// this copy will not change and because iterating in
        /// arrays is faster. But, if you plan to iterate only once,
        /// it is still faster to do it over the Values directly.
        /// </summary>
        Array CopyValues();
	}

    /// <summary>
    /// Alternative dictionary interface.
    /// This one does not use ICollection for keys and values, using simple
    /// IEnumerables and also has many multi-action methods, like GetOrCreateValue,
    /// AddMany, RemoveMany and others.
    /// Also, it defines TrimExcess and SetCapacity, which are available in lists
    /// and hashsets but not in dictionaries.
    /// </summary>
	public interface IPfzDictionary<TKey, TValue>:
		IEnumerable<KeyValuePair<TKey, TValue>>,
		IPfzDictionary
	{
		/// <summary>
		/// Gets or sets (replaces) the value by its key.
		/// When getting, if the value does not exist, throws an ArgumentException.
		/// </summary>
		TValue this[TKey key] { get; set; }

        /// <summary>
        /// Gets the equality comparer used by this dictionary to do key comparisons
        /// </summary>
        new IEqualityComparer<TKey> Comparer { get; }

		/// <summary>
		/// Returns an object capable of enumerating all the keys in this
		/// dictionary.
		/// </summary>
		new IEnumerable<TKey> Keys { get; }

		/// <summary>
		/// Returns an object capable of enumerating all the values in this
		/// dictionary.
		/// </summary>
        new IEnumerable<TValue> Values { get; }

		/// <summary>
		/// Verifies if a key is present in this dictionary.
		/// </summary>
		bool ContainsKey(TKey key);

		/// <summary>
		/// Tries to get a value for a given key. The return can be either true, meaning
		/// a value was found and put in the out value variable, or false meaning that
		/// there are no items with that key (and so the value contains the default(TValue)).
		/// </summary>
		bool TryGetValue(TKey key, out TValue value);

		/// <summary>
		/// Tries to get the value for a given key but, if it is not there, the
		/// default TValue is returned. This is very useful in cases where the default
		/// already means there is no value (like null results).
		/// </summary>
        TValue GetValueOrDefault(TKey key);

		/// <summary>
		/// Exceptions aside, this method always returns a value, be it because a
		/// new value was generated for an item (using the default TValue constructor)
		/// or because the item already existed.
		/// </summary>
		TValue GetOrCreateValue(TKey key);

        /// <summary>
		/// Exceptions aside, this method always returns a value, be it because a
		/// new value was generated for an item (using the createValue delegate)
		/// or because the item already existed.
		/// </summary>
        TValue GetOrCreateValue(TKey key, Func<TKey, TValue> createValue);

		/// <summary>
		/// Gets an item or adds the given value to the dictionary.
		/// The result should be the item that is actually on the dictionary, independent
		/// of the reason.
		/// </summary>
		TValue GetOrAdd(TKey key, TValue value);

		/// <summary>
		/// Tries to get a value for a given key in this dictionary. If one is not found,
		/// adds the given value.
		/// Returns true if a value was found for the key, false if the value was created.
		/// If the value was added, the oldValue should always be default(TValue).
        /// If you simple want to get a value, be it old or new, use GetOrAdd.
		/// </summary>
        bool TryGetValueOrAdd(TKey key, TValue value, out TValue oldValue);

		/// <summary>
		/// Tries to removes a value by its key and returns if a value existed and
		/// was removed or not.
		/// </summary>
        bool Remove(TKey key);

		/// <summary>
		/// Tries to get a value and also remove it.
		/// If the value existed, the out value will contain it. If not, the
		/// default(TValue) will be returned.
		/// In either case, true means a value was there (even null) while
		/// false means an item with that key was not there.
		/// </summary>
        bool TryGetValueAndRemove(TKey key, out TValue value);

		/// <summary>
		/// Gets the actual value for an item and then removes it.
		/// If the item does not exist, an ArgumentException is thrown.
		/// </summary>
        TValue GetValueAndRemove(TKey key);

		/// <summary>
		/// Tries to add an item. If an item with the same key exists, it returns false.
		/// </summary>
        bool TryAdd(TKey key, TValue value);

		/// <summary>
		/// Adds an item with the given key and value. If another item with the same key
		/// exists, throws an ArgumentException.
		/// </summary>
        void Add(TKey key, TValue value);

		/// <summary>
		/// In a single operation, tries to get the value for a given key.
		/// If the key does not exist, the pair (key and value) is added.
		/// If it already exists, the value is replaced.
		/// In any case, the result is true if an oldValue existed, false
		/// otherwise.
		/// </summary>
        bool TryGetValueAndAddOrReplace(TKey key, TValue value, out TValue oldValue);

		/// <summary>
		/// Executes the same action for all pairs in this dictionary.
		/// This is usually faster than doing a normal foreach over
        /// the dictionary.
		/// </summary>
		void ForEach(ForEachDictionaryDelegate<TKey, TValue> action);

		/// <summary>
		/// Adds many items at once. This one is generally faster than adding 
		/// each item individually because the final size can be pre-calculated.
		/// For thread-safe implementations, this can also reduce the number of
		/// locks taken.
		/// </summary>
        void AddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs);

		/// <summary>
		/// Adds or replaces many items at once. This one is generally faster than 
		/// adding or replacing each item individually because the final size can be 
		/// pre-calculated.
		/// For thread-safe implementations, this can also reduce the number of
		/// locks taken.
		/// </summary>
        void AddOrReplaceMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs);

		/// <summary>
		/// Tries to add many items at once. This one is generally faster than 
		/// trying to add each item individually because the final size can be 
		/// pre-calculated.
		/// For thread-safe implementations, this can also reduce the number of
		/// locks taken.
		/// </summary>
        void TryAddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs);

		/// <summary>
		/// Removes many items at once using a collection of keys. This is usually
		/// faster on thread safe implementations as a single lock can be obtained.
		/// </summary>
        void RemoveMany(IEnumerable<TKey> keys);

		/// <summary>
		/// Removes many items at once using a delegate to knwo if the item shoud be deleted.
		/// This is fast when a good number of items (50% or more) is going to be removed simple
		/// because the number of searches is reduced. But it is also useful on multi-threaded
		/// situations where a single lock can be taken.
		/// </summary>
        void RemoveMany(RemoveManyDictionaryDelegate<TKey, TValue> checkDelegate);

        /// <summary>
        /// Copies all the pairs in this dictionary to an array.
        /// This is useful if you plan to iterate many times as
        /// this copy will not change and because iterating in
        /// arrays is faster. But, if you plan to iterate only once,
        /// it is still faster to do it over the dictionary directly.
        /// </summary>
		new KeyValuePair<TKey, TValue>[] ToArray();

        /// <summary>
        /// Copies all the keys in this dictionary to an array.
        /// This is useful if you plan to iterate many times as
        /// this copy will not change and because iterating in
        /// arrays is faster. But, if you plan to iterate only once,
        /// it is still faster to do it over the Keys directly.
        /// </summary>
        new TKey[] CopyKeys();

        /// <summary>
        /// Copies all the values in this dictionary to an array.
        /// This is useful if you plan to iterate many times as
        /// this copy will not change and because iterating in
        /// arrays is faster. But, if you plan to iterate only once,
        /// it is still faster to do it over the Values directly.
        /// </summary>
        new TValue[] CopyValues();
	}
}
