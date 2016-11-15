using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pfz.Collections
{
    /// <summary>
    /// Dictionary returned by the ThreadSafeDictionary&lt;TKey, TValue&gt;.Lock()
    /// method. It is recommended that you use this in a using clause so, when
    /// you finish, you dispose this dictionary and also release the lock held
    /// by it.
    /// All methods present in this dictionary simple avoid new locks, as
    /// the dictionary is already locked.
    /// </summary>
	public sealed class LockedThreadSafeDictionary<TKey, TValue>:
		IDisposableDictionary<TKey, TValue>
    {
        #region _owner - Single private field
            private ThreadSafeDictionary<TKey, TValue> _owner;
        #endregion

        #region Constructor
            internal LockedThreadSafeDictionary(ThreadSafeDictionary<TKey, TValue> owner)
		    {
			    _owner = owner;
		    }
        #endregion
        #region Dispose
            /// <summary>
            /// Releases the lock held over the main dictionary and
            /// also makes this object useless.
            /// </summary>
		    public void Dispose()
		    {
			    var owner = _owner;
			    if (owner != null)
			    {
				    _owner = null;
				    owner._lock.ExitWriteLock();
			    }
		    }
        #endregion

        #region Properties
            #region WasDisposed
                /// <summary>
                /// Gets a value indicating if this locked-dictionary was already
                /// disposed.
                /// </summary>
		        public bool WasDisposed
		        {
			        get
			        {
				        return _owner == null;
			        }
		        }
            #endregion

            #region this[]
                /// <summary>
                /// Gets or sets a value by its key.
                /// </summary>
		        public TValue this[TKey key]
		        {
			        get
			        {
				        var owner = _GetOwner();

				        return owner[key];
			        }
			        set
			        {
                        TValue oldValue;
                        TryGetValueAndAddOrReplace(key, value, out oldValue);
			        }
		        }
            #endregion

            #region Capacity
                /// <summary>
                /// Gets the actual capacity of this dictionary.
                /// This is not a real limit, but the number of buckets that exist.
                /// </summary>
		        public int Capacity
		        {
			        get
			        {
				        var owner = _GetOwner();
				        return owner.Capacity;
			        }
		        }
            #endregion
            #region Count
                /// <summary>
                /// Gets the number of items in this dictionary.
                /// </summary>
		        public int Count
		        {
			        get
			        {
				        var owner = _GetOwner();
				        return owner._count;
			        }
		        }
            #endregion

            #region Comparer
                /// <summary>
                /// Gets the comparer used by this dictionary.
                /// </summary>
		        public IEqualityComparer<TKey> Comparer
		        {
			        get
			        {
				        var owner = _GetOwner();
				        return owner._comparer;
			        }
		        }
            #endregion

            #region Keys
                /// <summary>
                /// Enumerates the keys in this dictionary.
                /// </summary>
		        public IEnumerable<TKey> Keys
		        {
			        get
			        {
				        var owner = _GetOwner();
				        return owner.Keys;
			        }
		        }
            #endregion
            #region Values
                /// <summary>
                /// Enumerates the values in this dictionary.
                /// </summary>
		        public IEnumerable<TValue> Values
		        {
			        get
			        {
				        var owner = _GetOwner();
				        return owner.Values;
			        }
		        }
            #endregion
        #endregion
        #region Methods
            #region _GetOwner
                private ThreadSafeDictionary<TKey, TValue> _GetOwner()
		        {
			        var owner = _owner;

			        if (owner == null)
				        throw new ObjectDisposedException(GetType().FullName);

			        return owner;
		        }
            #endregion

            #region TrimExcess
                /// <summary>
                /// Reduces the capacity of this dictionary to meet its Count property.
                /// </summary>
		        public bool TrimExcess()
		        {
    		        var owner = _GetOwner();
                    return owner._TrimExcess();
		        }
            #endregion
            #region SetCapacity
                /// <summary>
                /// Sets the capacity (number of buckets) of this dictionary to a given value.
                /// </summary>
		        public bool SetCapacity(int value)
		        {
    		        var owner = _GetOwner();
                    return owner._SetCapacity(value);
		        }
            #endregion

            #region Clear
                /// <summary>
                /// Removes all items from this dictionary.
                /// </summary>
		        public void Clear()
		        {
    		        var owner = _GetOwner();
                    owner._Clear();
		        }
            #endregion

            #region ContainsKeys
                /// <summary>
                /// Verifies if an item with the given key exists in this dictionary.
                /// </summary>
		        public bool ContainsKey(TKey key)
		        {
			        var owner = _GetOwner();
			        return owner.ContainsKey(key);
		        }
            #endregion
            #region TryGetValue
                /// <summary>
                /// Tries to get a value by its key.
                /// Returns true if the value is found and puts it into the out variable.
                /// </summary>
		        public bool TryGetValue(TKey key, out TValue value)
		        {
			        var owner = _GetOwner();
			        return owner.TryGetValue(key, out value);
		        }
            #endregion
            #region GetValueOrDefault
                /// <summary>
                /// Gets the value for a given key or, if one does not exists, returns
                /// the default(TValue).
                /// </summary>
		        public TValue GetValueOrDefault(TKey key)
		        {
			        var owner = _GetOwner();
			        return owner.GetValueOrDefault(key);
		        }
            #endregion
            #region GetOrCreateValue
                /// <summary>
                /// Gets a value for a given key or creates a new one using
                /// the default constructor of the TValue type.
                /// </summary>
		        public TValue GetOrCreateValue(TKey key)
		        {
			        return GetOrCreateValue(key, null);
		        }

                /// <summary>
                /// Gets a value for a given key or creates a new one using the given
                /// createValue delegate.
                /// </summary>
		        public TValue GetOrCreateValue(TKey key, Func<TKey, TValue> createValue)
		        {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    if (createValue == null)
                        createValue = ValueConstructorDelegate<TKey, TValue>.GetDefault();

                    var owner = _GetOwner();
                    var comparer = owner._comparer;
                    int hashCode = owner._comparer.GetHashCode(key) & int.MaxValue;
                    int bucketIndex = hashCode % owner._buckets.Length;

                    TValue result;
                    if (owner._TryGetValue(hashCode, key, out result))
                        return result;

                    result = createValue(key);

                    if (owner._count >= owner._buckets.Length*2)
                    {
                        owner._Resize();
                        bucketIndex = hashCode % owner._buckets.Length;
                    }

                    var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, result, owner._buckets[bucketIndex]);
                    owner._buckets[bucketIndex] = newNode;
                    owner._count++;

                    return result;
		        }
            #endregion
            #region TryGetValueOrAdd
                /// <summary>
                /// Tries to get a value for a given key. If a value does not exist,
                /// adds the given one.
                /// If a value already existed, the return is true and the gotValue
                /// will have the existing value. If a value didn't exist,
                /// the return is false (as the TryGetValue failed), the given value
                /// will be added but the gotValue will have the default(TValue).
                /// If you simple was to get a value, be it because you added it
                /// or because it already existed, without knowing if it was you
                /// that added it, call GetOrAdd.
                /// </summary>
		        public bool TryGetValueOrAdd(TKey key, TValue value, out TValue gotValue)
		        {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    var owner = _GetOwner();
                    int hashCode = owner._comparer.GetHashCode(key) & int.MaxValue;
                    return owner._TryGetValueOrAdd(key, value, out gotValue, hashCode);
		        }
            #endregion
            #region TryGetValueAndRemove
                /// <summary>
                /// Tries to get a value by its key and also removes it.
                /// The return is true if a value existed, so the out value will
                /// have it and it will be already gone from the dictionary.
                /// </summary>
		        public bool TryGetValueAndRemove(TKey key, out TValue value)
		        {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    var owner = _GetOwner();
                    int hashCode = owner._comparer.GetHashCode(key) & int.MaxValue;

                    var buckets = owner._buckets;
                    int bucketIndex = hashCode % buckets.Length;

                    _ThreadSafeDictionaryNode<TKey, TValue> previousNode;
                    _ThreadSafeDictionaryNode<TKey, TValue> node;
                    owner._GetNodeAndPreviousNode(bucketIndex, hashCode, key, out node, out previousNode);

                    if (node != null)
                    {
                        owner._RemoveNode(bucketIndex, previousNode, node);

                        value = node._value;
                        return true;
                    }

                    value = default(TValue);
                    return false;
		        }
            #endregion
            #region TryGetValueAndAddOrReplace
                /// <summary>
                /// Tries to get a value for a key and returns it into the oldValue parameter.
                /// Independent if one exists or not, the value is added or replaced by the
                /// given value.
                /// </summary>
		        public bool TryGetValueAndAddOrReplace(TKey key, TValue value, out TValue oldValue)
		        {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    var owner = _GetOwner();
                    int hashCode = owner._comparer.GetHashCode(key) & int.MaxValue;
                    _ThreadSafeDictionaryNode<TKey, TValue> node;

                    int bucketIndex = hashCode % owner._buckets.Length;

                    _ThreadSafeDictionaryNode<TKey, TValue> previousNode;
                    owner._AddOrReplace(key, value, hashCode, bucketIndex, out node, out previousNode);

                    if (node != null)
                    {
                        oldValue = node._value;
                        return true;
                    }

                    oldValue = default(TValue);
                    return false;
		        }
            #endregion

            #region GetOrAdd
		        /// <summary>
		        /// Gets an item or adds the given value to the dictionary.
		        /// The result should be the item that is actually on the dictionary, independent
		        /// of the reason.
		        /// </summary>
                public TValue GetOrAdd(TKey key, TValue value)
                {
                    TValue gotValue;
                    if (TryGetValueOrAdd(key, value, out gotValue))
                        return gotValue;

                    return value;
                }
            #endregion
            #region Add
		        /// <summary>
		        /// Adds an item with the given key and value. If another item with the same key
		        /// exists, throws an ArgumentException.
		        /// </summary>
                public void Add(TKey key, TValue value)
		        {
                    if (!TryAdd(key, value))
                        throw new ArgumentException("There is already a value for the key: " + key);
		        }
            #endregion
            #region TryAdd
		        /// <summary>
		        /// Tries to add an item. If an item with the same key exists, it returns false.
		        /// </summary>
                public bool TryAdd(TKey key, TValue value)
                {
                    TValue ignored;
                    return !TryGetValueOrAdd(key, value, out ignored);
                }
            #endregion
            #region Remove
		        /// <summary>
		        /// Tries to removes a value by its key and returns if a value existed and
		        /// was removed or not.
		        /// </summary>
                public bool Remove(TKey key)
                {
                    TValue value;
                    return TryGetValueAndRemove(key, out value);
                }
            #endregion
            #region GetValueAndRemove
		        /// <summary>
		        /// Gets the actual value for an item and then removes it.
		        /// If the item does not exist, an ArgumentException is thrown.
		        /// </summary>
                public TValue GetValueAndRemove(TKey key)
		        {
                    TValue result;
                    if (TryGetValueAndRemove(key, out result))
                        return result;

                    throw new ArgumentException("There is no value for the key: " + key);
		        }
            #endregion

            #region ForEach
                /// <summary>
                /// Executes the same action for all the pairs in this dictionary. This
                /// is usually faster than iterating the dictionary.
                /// </summary>
		        public void ForEach(ForEachDictionaryDelegate<TKey, TValue> action)
		        {
			        var owner = _GetOwner();
			        owner.ForEach(action);
		        }
            #endregion
            #region AddMany
                /// <summary>
                /// Adds many pairs at once.
                /// If the capacity needs to grow, it is done only once.
                /// </summary>
		        public void AddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		        {
                    if (pairs == null)
                        throw new ArgumentNullException("pairs");

                    int pairCount = pairs.Count();
                    if (pairCount == 0)
                        return;

                    var owner = _GetOwner();
                    owner._AddMany(pairs, pairCount);
		        }
            #endregion
            #region AddOrReplaceMany
                /// <summary>
                /// Adds or replaces many values at once.
                /// If the capacity needs to grow, it is done only once.
                /// </summary>
		        public void AddOrReplaceMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		        {
                    if (pairs == null)
                        throw new ArgumentNullException("pairs");

                    var owner = _GetOwner();
                    int itemsToAdd;
                    bool isEmpty = owner._CountItemsToAdd_ReturnIsEmpty(pairs, out itemsToAdd);

			        if (isEmpty)
				        return;

                    owner._AddOrReplaceMany(pairs, itemsToAdd);
		        }
            #endregion
            #region TryAddMany
                /// <summary>
                /// Tries to add many items at once.
                /// If the capacity needs to grow, it is done only once.
                /// </summary>
		        public void TryAddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		        {
                    if (pairs == null)
                        throw new ArgumentNullException("pairs");

                    var owner = _GetOwner();
                    int itemsToAdd = owner._CountItemsToTryAdd(pairs);

			        if (itemsToAdd == 0)
				        return;

                    owner._TryAddMany(pairs, itemsToAdd);
		        }
            #endregion
            #region RemoveMany
                /// <summary>
                /// Remove many items at once.
                /// </summary>
		        public void RemoveMany(IEnumerable<TKey> keys)
		        {
                    if (keys == null)
                        throw new ArgumentNullException("keys");

                    var owner = _GetOwner();
                    owner._RemoveMany(keys);
		        }

                /// <summary>
                /// Remove many pairs at once. Each pair will call the checkDelegate to know if it
                /// should be removed or not. This is much faster than iterating the entire
                /// dictionary and then removing the unnecessary items.
                /// </summary>
		        public void RemoveMany(RemoveManyDictionaryDelegate<TKey, TValue> checkDelegate)
		        {
                    if (checkDelegate == null)
                        throw new ArgumentNullException("checkDelegate");

                    var owner = _GetOwner();
                    owner._RemoveMany(checkDelegate);
		        }
            #endregion

            #region ToArray
                /// <summary>
                /// Copies all the pairs of this dictionary to an array.
                /// </summary>
		        public KeyValuePair<TKey, TValue>[] ToArray()
		        {
                    var owner = _GetOwner();
                    return owner._ToArray();
		        }
            #endregion
            #region CopyKeys
                /// <summary>
                /// Copies all the keys of this dictionary to an array.
                /// </summary>
		        public TKey[] CopyKeys()
		        {
                    var owner = _GetOwner();
                    return owner._CopyKeys();
		        }
            #endregion
            #region CopyValues
                /// <summary>
                /// Copies all the values of this dictionary to an array.
                /// </summary>
		        public TValue[] CopyValues()
		        {
                    var owner = _GetOwner();
                    return owner._CopyValues();
		        }
            #endregion

            #region GetEnumerator
                /// <summary>
                /// Get an enumerator of all pairs presents in this dictionary.
                /// </summary>
		        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		        {
                    var owner = _GetOwner();
                    return owner.GetEnumerator();
		        }
            #endregion
        #endregion

        #region Private interface implementations (untyped methods)
			Type IPfzDictionary.TypeOfKeys
			{
				get
				{
					return typeof(TKey);
				}
			}
			Type IPfzDictionary.TypeOfValues
			{
				get
				{
					return typeof(TValue);
				}
			}

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            object IPfzDictionary.Comparer
            {
                get
                {
                    var owner = _GetOwner();
                    return owner._comparer;
                }
            }

		    object IPfzDictionary.this[object key]
		    {
			    get
			    {
				    return this[(TKey)key];
			    }
			    set
			    {
				    this[(TKey)key] = (TValue)value;
			    }
		    }

		    IEnumerable IPfzDictionary.Keys
		    {
			    get
                {
                    return Keys;
                }
		    }

		    IEnumerable IPfzDictionary.Values
		    {
			    get
                {
                    return Values;
                }
		    }

		    bool IPfzDictionary.ContainsKey(object key)
		    {
			    return ContainsKey((TKey)key);
		    }

		    bool IPfzDictionary.TryGetValue(object key, out object value)
		    {
                TValue typedValue;
                bool result = TryGetValue((TKey)key, out typedValue);
                value = typedValue;
                return result;
		    }

		    object IPfzDictionary.GetValueOrDefault(object key)
		    {
                return GetValueOrDefault((TKey)key);
		    }

		    object IPfzDictionary.GetOrCreateValue(object key, Delegate createValue)
		    {
                return GetOrCreateValue((TKey)key, (Func<TKey, TValue>)createValue);
		    }

		    bool IPfzDictionary.Remove(object key)
		    {
                return Remove((TKey)key);
		    }

		    bool IPfzDictionary.TryGetValueAndRemove(object key, out object value)
		    {
                TValue typedValue;
                bool result = TryGetValueAndRemove((TKey)key, out typedValue);
                value = typedValue;
                return result;
		    }

		    object IPfzDictionary.GetValueAndRemove(object key)
		    {
			    return (TValue)GetValueAndRemove((TKey)key);
		    }

		    bool IPfzDictionary.TryAdd(object key, object value)
		    {
			    return TryAdd((TKey)key, (TValue)value);
		    }

		    void IPfzDictionary.Add(object key, object value)
		    {
                Add((TKey)key, (TValue)value);
		    }

		    bool IPfzDictionary.TryGetValueAndAddOrReplace(object key, object value, out object oldValue)
		    {
                TValue typedOldValue;
                bool result = TryGetValueAndAddOrReplace((TKey)key, (TValue)value, out typedOldValue);
                oldValue = typedOldValue;
                return result;
		    }

		    void IPfzDictionary.ForEach(Delegate action)
		    {
                ForEach((ForEachDictionaryDelegate<TKey, TValue>)action);
		    }

		    void IPfzDictionary.AddMany(IEnumerable pairs)
		    {
                if (pairs == null)
                    throw new ArgumentNullException("pairs");

                AddMany(pairs.Cast<KeyValuePair<TKey, TValue>>());
		    }

		    void IPfzDictionary.AddOrReplaceMany(IEnumerable pairs)
		    {
                if (pairs == null)
                    throw new ArgumentNullException("pairs");

                AddOrReplaceMany(pairs.Cast<KeyValuePair<TKey, TValue>>());
		    }

		    void IPfzDictionary.TryAddMany(IEnumerable pairs)
		    {
                if (pairs == null)
                    throw new ArgumentNullException("pairs");

                TryAddMany(pairs.Cast<KeyValuePair<TKey, TValue>>());
		    }

		    void IPfzDictionary.RemoveMany(IEnumerable keys)
		    {
                if (keys == null)
                    throw new ArgumentNullException("keys");

                RemoveMany(keys.Cast<TKey>());
		    }

		    void IPfzDictionary.RemoveMany(Delegate checkDelegate)
		    {
                RemoveMany((RemoveManyDictionaryDelegate<TKey, TValue>)checkDelegate);
		    }

		    object IPfzDictionary.GetOrAdd(object key, object value)
		    {
                TValue result = GetOrAdd((TKey)key, (TValue)value);
                return result;
		    }

		    bool IPfzDictionary.TryGetValueOrAdd(object key, object value, out object oldValue)
		    {
                TValue typedOldValue;
                bool result = TryGetValueOrAdd((TKey)key, (TValue)value, out typedOldValue);
                oldValue = typedOldValue;
                return result;
            }

            Array IPfzDictionary.ToArray()
            {
                return ToArray();
            }
            Array IPfzDictionary.CopyKeys()
            {
                return CopyKeys();
            }
            Array IPfzDictionary.CopyValues()
            {
                return CopyValues();
            }

            object IPfzDictionary.GetOrCreateValue(object key)
            {
                return GetOrCreateValue((TKey)key);
            }
        #endregion
	}
}
