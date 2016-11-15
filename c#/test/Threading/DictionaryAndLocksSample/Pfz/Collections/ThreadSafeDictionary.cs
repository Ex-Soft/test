using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Pfz.Threading;
using System.Runtime.CompilerServices;

namespace Pfz.Collections
{
    /// <summary>
    /// A thread safe implementation of a dictionary that allows reads to be done
    /// even when writes are being done. Writes are serialized, though.
    /// </summary>
    public sealed class ThreadSafeDictionary<TKey, TValue>:
		IThreadSafeDictionary<TKey, TValue>,
        IEnumerable<KeyValuePair<TKey, TValue>>
    {
        #region Internal fields - Property exclusive fields are with the properties
            internal _ThreadSafeDictionaryNode<TKey, TValue>[] _buckets;
            internal readonly IReaderWriterLockSlim _lock;
        #endregion

        #region Constructors
			/// <summary>
			/// Creates a dictionary with its default capacity and key comparer.
			/// </summary>
            public ThreadSafeDictionary():
                this(31)
            {
            }

			/// <summary>
			/// Creates a dictionary with the given capacity and the default key comparer.
			/// </summary>
            public ThreadSafeDictionary(int capacity):
                this(capacity, null, null)
            {
            }

			/// <summary>
			/// Create a new thread-safe dictionary using the given readerWriterLock
			/// for synchronization.
			/// </summary>
			public ThreadSafeDictionary(IReaderWriterLockSlim readerWriterLock):
				this(31, readerWriterLock, null)
			{
			}

			/// <summary>
			/// Creates a new dictionary with the given key comparer and using the
            /// default capacity.
			/// </summary>
            public ThreadSafeDictionary(IEqualityComparer<TKey> comparer):
                this(31, null, comparer)
            {
            }

			/// <summary>
			/// Creates a new dictionary with the given capacity and key comparer.
			/// </summary>
			/// <param name="capacity">The capacity to use.</param>
			/// <param name="readerWriterLock">The reader writer lock to use. If null, a SpinReaderWriterLockSlim on
            /// multi-processor computers or an OptimisticReaderWriterLock will be used on single CPU computers.</param>
			/// <param name="comparer">The comparer to use for the keys. A value of null means the default one will be used.</param>
            public ThreadSafeDictionary(int capacity, IReaderWriterLockSlim readerWriterLock, IEqualityComparer<TKey> comparer)
            {
                if (comparer == null)
                    comparer = EqualityComparer<TKey>.Default;

                capacity = _DictionaryHelper._AdaptLength(capacity);
                _buckets = new _ThreadSafeDictionaryNode<TKey,TValue>[capacity];
                _comparer = comparer;

				if (readerWriterLock != null)
					_lock = readerWriterLock;
				else
                {
                    if (Environment.ProcessorCount == 1)
                        _lock = new OptimisticReaderWriterLock();
                    else
					    _lock = new SpinReaderWriterLockSlim();
                }
            }
        #endregion

        #region Properties
            #region this[]
		        /// <summary>
		        /// Gets or sets (replaces) the value by its key.
		        /// When getting, if the value does not exist, throws an ArgumentException.
		        /// </summary>
                public TValue this[TKey key]
                {
                    get
                    {
                        if (key == null)
                            throw new ArgumentNullException("key");

                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;

                        TValue result;
                        if (_TryGetValue(hashCode, key, out result))
                            return result;

                        throw new ArgumentException("There is no value for the key: " + key);
                    }
                    set
                    {
                        TValue oldValue;
                        TryGetValueAndAddOrReplace(key, value, out oldValue);
                    }
                }
            #endregion
            #region Comparer
                internal readonly IEqualityComparer<TKey> _comparer;
                /// <summary>
                /// Gets the equality comparer used by this dictionary to do key comparisons
                /// </summary>
                public IEqualityComparer<TKey> Comparer
                {
                    get
                    {
                        return _comparer;
                    }
                }
            #endregion
            #region Count
                internal int _count;
                /// <summary>
		        /// Gets the actual number of items in this dictionary.
		        /// </summary>
                public int Count
                {
                    get
                    {
                        return _count;
                    }
                }
            #endregion
            #region Capacity
		        /// <summary>
		        /// Gets the Capacity (the number of items that this dictionary supports)
		        /// before trying to grow.
		        /// </summary>
                public int Capacity
                {
                    get
                    {
                        return _buckets.Length;
                    }
                }
            #endregion

            #region Keys
		        /// <summary>
		        /// Returns an object capable of enumerating all the keys in this
		        /// dictionary.
		        /// </summary>
                public IEnumerable<TKey> Keys
                {
                    get
                    {
                        // No lock is needed as all the operations
                        // over the buckets are atomic.
                        // If the dictionary gets resized, we allocate
                        // a new buckets array, but then the user continues
                        // to see the "old" dictionary until the end.
                        var buckets = _buckets;
                        int count = buckets.Length;
                        for(int i=0; i<count; i++)
                        {
                            var node = buckets[i];

                            while(node != null)
                            {
                                yield return node._key;

                                node = node._nextNode;
                            }
                        }
                    }
                }
            #endregion
            #region Values
		        /// <summary>
		        /// Returns an object capable of enumerating all the values in this
		        /// dictionary.
		        /// </summary>
                public IEnumerable<TValue> Values
                {
                    get
                    {
                        var buckets = _buckets;
                        int count = buckets.Length;
                        for(int i=0; i<count; i++)
                        {
                            var node = buckets[i];

                            while(node != null)
                            {
                                yield return node._value;

                                node = node._nextNode;
                            }
                        }
                    }
                }
            #endregion
        #endregion
        #region Methods
            #region _AddOrReplace
                internal void _AddOrReplace(TKey key, TValue value, int hashCode, int bucketIndex, out _ThreadSafeDictionaryNode<TKey, TValue> node, out _ThreadSafeDictionaryNode<TKey, TValue> previousNode)
                {
                    _GetNodeAndPreviousNode(bucketIndex, hashCode, key, out node, out previousNode);

                    if (node != null)
                    {
                        // if we found a node, we create a new node to replace it.
                        var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, value, node._nextNode);

                        // and, if it had an old node, that's the node that we update to point
                        // to the new one. Note that it is important to do a single atomic
                        // update as we have readers that don't do any locking
                        // (references are atomic, so we are fine).
                        if (previousNode != null)
                            previousNode._nextNode = newNode;
                        else
                            _buckets[bucketIndex] = newNode;
                    }
                    else
                    {
                        // in this situation we didn't find a node with the same value, so
                        // we do a simple add.

                        if (_count >= _buckets.Length*2)
                        {
                            _Resize();
                            bucketIndex = hashCode % _buckets.Length;
                        }

                        var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, value, _buckets[bucketIndex]);
                        _buckets[bucketIndex] = newNode;
                        _count++;
                    }
                }
            #endregion
            #region _TryGetValue
                internal bool _TryGetValue(int hashCode, TKey key, out TValue value)
                {
                    var buckets = _buckets;
                    int bucketIndex = hashCode % buckets.Length;

                    var node = buckets[bucketIndex];

					// In the ConcurrentDictionary there is a Thread.MemoryBarrier here.
					// But, considering that nodes can be updated, if the .Net can really
					// read new objects with values assigned before their constructor finished,
					// then I think the Thread.MemoryBarrier should be inside the while node.
					// But, as I never saw such error, I will simple avoid the
					// MemoryBarrier for now.

                    while(node != null)
                    {
						//Thread.MemoryBarrier();

                        if (hashCode == node._hashCode)
                        {
                            if (_comparer.Equals(key, node._key))
                            {
                                value = node._value;
                                return true;
                            }
                        }

                        node = node._nextNode;
                    }

                    value = default(TValue);
                    return false;
                }
            #endregion
            #region _Resize
                internal void _Resize()
                {
                    int newCapacity = _DictionaryHelper._AdaptLength(_count * 2);
                    try
                    {
                        _SetCapacity_SizeMustBeAPrime(newCapacity);
                    }
                    catch(OutOfMemoryException)
                    {
                        // if we had an out of memory exception, the old dictionary
                        // is still there. We can avoid (and it is prefereably to do so) as
                        // an add was already completed. If a new add fail while allocating
                        // a node, then it is a valid exception to show to the users.
                    }
                }
            #endregion
            #region _GetNodeAndPreviousNode
                internal void _GetNodeAndPreviousNode(int bucketIndex, int hashCode, TKey key, out _ThreadSafeDictionaryNode<TKey, TValue> resultNode, out _ThreadSafeDictionaryNode<TKey, TValue> resultPrviousNode)
                {
                    _ThreadSafeDictionaryNode<TKey, TValue> oldNode = null;
                    var node = _buckets[bucketIndex];
                    while(node != null)
                    {
                        if (hashCode == node._hashCode)
                        {
                            if (_comparer.Equals(key, node._key))
                            {
                                resultNode = node;
                                resultPrviousNode = oldNode;
                                return;
                            }
                        }

                        oldNode = node;
                        node = node._nextNode;
                    }

                    resultNode = null;
                    resultPrviousNode = null;
                }
            #endregion
            #region _SetCapacity_SizeMustBeAPrime
                private void _SetCapacity_SizeMustBeAPrime(int newCapacity)
                {
                    var oldBuckets = _buckets;
                    var newBuckets = new _ThreadSafeDictionaryNode<TKey, TValue>[newCapacity];

                    int count = oldBuckets.Length;
                    for(int i=0; i<count; i++)
                    {
                        var node = _buckets[i];

                        while(node != null)
                        {
                            int newBucketIndex = node._hashCode % newCapacity;
                            var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(node._hashCode, node._key, node._value, newBuckets[newBucketIndex]);
                            newBuckets[newBucketIndex] = newNode;

                            node = node._nextNode;
                        }
                    }

                    _buckets = newBuckets;
                }
            #endregion
            #region _RemoveNode
                internal void _RemoveNode(int bucketIndex, _ThreadSafeDictionaryNode<TKey, TValue> oldNode, _ThreadSafeDictionaryNode<TKey, TValue> node)
                {
                    if (oldNode != null)
                        oldNode._nextNode = node._nextNode;
                    else
                        _buckets[bucketIndex] = node._nextNode;

                    _count--;
                }
            #endregion
            #region _ContainsKey
                private bool _ContainsKey(int hashCode, TKey key, _ThreadSafeDictionaryNode<TKey, TValue> node)
                {
                    while(node != null)
                    {
                        if (hashCode == node._hashCode)
                            if (_comparer.Equals(key, node._key))
                                return true;

                        node = node._nextNode;
                    }

                    return false;
                }
            #endregion

            #region ContainsKey
		        /// <summary>
		        /// Verifies if a key is present in this dictionary.
		        /// </summary>
                public bool ContainsKey(TKey key)
		        {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    var buckets = _buckets;
                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                    int bucketIndex = hashCode % buckets.Length;

                    return _ContainsKey(hashCode, key, buckets[bucketIndex]);
		        }
            #endregion
            #region TryGetValue
		        /// <summary>
		        /// Tries to get a value for a given key. The return can be either true, meaning
		        /// a value was found and put in the out value variable, or false meaning that
		        /// there are no items with that key (and so the value contains the default(TValue)).
		        /// </summary>
                public bool TryGetValue(TKey key, out TValue value)
                {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                    return _TryGetValue(hashCode, key, out value);
                }
            #endregion
            #region TryGetValueAndAddOrReplace
		        /// <summary>
		        /// In a single operation, tries to get the value for a given key.
		        /// If the key does not exist, the pair (key and value) is added.
		        /// If it already exists, the value is replaced.
		        /// In any case, the result is true if an oldValue existed, false
		        /// otherwise.
		        /// </summary>
                public bool TryGetValueAndAddOrReplace(TKey key, TValue value, out TValue oldValue)
                {
                   if (key == null)
                        throw new ArgumentNullException("key");

                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                    _ThreadSafeDictionaryNode<TKey, TValue> node;

                    _lock.EnterWriteLock();
                    try
                    {
                        int bucketIndex = hashCode % _buckets.Length;

                        _ThreadSafeDictionaryNode<TKey, TValue> previousNode;
                        _AddOrReplace(key, value, hashCode, bucketIndex, out node, out previousNode);
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }

                    if (node != null)
                    {
                        oldValue = node._value;
                        return true;
                    }

                    oldValue = default(TValue);
                    return false;
                }
            #endregion
            #region TryGetValueOrAdd
                /// <summary>
                /// Tries to get a value for a given key in this dictionary. If one is not found,
                /// adds the given value.
                /// Returns true if a value was found for the key, false if the value was created.
                /// If the value was added, the oldValue should always be default(TValue).
                /// If you simple want to get a value, be it old or new, use GetOrAdd.
                /// </summary>
                public bool TryGetValueOrAdd(TKey key, TValue value, out TValue gotValue)
                {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                    if (_TryGetValue(hashCode, key, out gotValue))
                        return true;

                    _lock.EnterWriteLock();
                    try
                    {
                        return _TryGetValueOrAdd(key, value, out gotValue, hashCode);
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }
            #endregion
            #region _TryGetValueOrAdd
                internal bool _TryGetValueOrAdd(TKey key, TValue value, out TValue gotValue, int hashCode)
                {
                    int bucketIndex = hashCode % _buckets.Length;

                    if (_TryGetValue(hashCode, key, out gotValue))
                        return true;

                    if (_count >= _buckets.Length * 2)
                    {
                        _Resize();
                        bucketIndex = hashCode % _buckets.Length;
                    }

                    var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, value, _buckets[bucketIndex]);
                    _buckets[bucketIndex] = newNode;

                    _count++;
                    return false;
                }
            #endregion
            #region TryGetValueAndRemove
		        /// <summary>
		        /// Tries to get a value and also remove it.
		        /// If the value existed, the out value will contain it. If not, the
		        /// default(TValue) will be returned.
		        /// In either case, true means a value was there (even null) while
		        /// false means an item with that key was not there.
		        /// </summary>
                public bool TryGetValueAndRemove(TKey key, out TValue value)
                {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;

                    _lock.EnterWriteLock();
                    try
                    {
                        var buckets = _buckets;
                        int bucketIndex = hashCode % buckets.Length;

                        _ThreadSafeDictionaryNode<TKey, TValue> previousNode;
                        _ThreadSafeDictionaryNode<TKey, TValue> node;
                        _GetNodeAndPreviousNode(bucketIndex, hashCode, key, out node, out previousNode);

                        if (node != null)
                        {
                            _RemoveNode(bucketIndex, previousNode, node);

                            value = node._value;
                            return true;
                        }
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }

                    value = default(TValue);
                    return false;
                }
            #endregion

            #region Clear
		        /// <summary>
		        /// Clears this dictionary. This does not mean it has reduced its capacity.
		        /// </summary>
                public void Clear()
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        _Clear();
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }

                internal void _Clear()
                {
                    _count = 0;
                    int bucketCount = _buckets.Length;
                    for (int i = 0; i < bucketCount; i++)
                        _buckets[i] = null;
                }
            #endregion
            #region GetValueOrDefault
                /// <summary>
		        /// Tries to get the value for a given key but, if it is not there, the
		        /// default TValue is returned. This is very useful in cases where the default
		        /// already means there is no value (like null results).
		        /// </summary>
                public TValue GetValueOrDefault(TKey key)
                {
                    TValue value;
                    TryGetValue(key, out value);
                    return value;
                }
            #endregion
            #region GetOrCreateValue
		        /// <summary>
		        /// Exceptions aside, this method always returns a value, be it because a
		        /// new value was generated for an item (using the default TValue constructor)
		        /// or because the item already existed.
		        /// </summary>
				public TValue GetOrCreateValue(TKey key)
				{
					return GetOrCreateValue(key, null);
				}

                /// <summary>
		        /// Exceptions aside, this method always returns a value, be it because a
		        /// new value was generated for an item (using the createValue delegate)
		        /// or because the item already existed.
		        /// </summary>
                public TValue GetOrCreateValue(TKey key, Func<TKey, TValue> createValue)
                {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    if (createValue == null)
                        createValue = ValueConstructorDelegate<TKey, TValue>.GetDefault();

                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                    TValue result;
                    if (_TryGetValue(hashCode, key, out result))
                        return result;

                    bool upgraded = false;
                    _lock.EnterUpgradeableLock();
                    try
                    {
                        int bucketIndex = hashCode % _buckets.Length;

                        if (_TryGetValue(hashCode, key, out result))
                            return result;

                        result = createValue(key);

                        _lock.UpgradeToWriteLock(ref upgraded);

                        if (_count >= _buckets.Length*2)
                        {
                            _Resize();
                            bucketIndex = hashCode % _buckets.Length;
                        }

                        var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, result, _buckets[bucketIndex]);
                        _buckets[bucketIndex] = newNode;
                        _count++;
                    }
                    finally
                    {
                        _lock.ExitUpgradeableLock(upgraded);
                    }

                    return result;
                }
            #endregion
            #region GetOrCreateDiscardableValue
                /// <summary>
                /// Gets or creates a value for a given key, using the default constructor for TValue.
                /// If the value needs to be created it is created outside of a lock, so duplicates may be created,
                /// but one of them will never be used (and will be simple lost, if you need to dispose an unused
                /// value, see the overload with a discardUnusedValue delegate).
                /// </summary>
                public TValue GetOrCreateDiscardableValue(TKey key)
                {
                    return GetOrCreateDiscardableValue(key, null);
                }

                /// <summary>
                /// Gets or creates a value for a given key, using the given createDelegate.
                /// If the value needs to be created it is created outside of a lock, so duplicates may be created,
                /// but one of them will never be used (and will be simple lost, if you need to dispose an unused
                /// value, see the overload with a discardUnusedValue delegate).
                /// </summary>
                public TValue GetOrCreateDiscardableValue(TKey key, Func<TKey, TValue> createValue)
                {
                    return GetOrCreateDiscardableValue(key, createValue, null);
                }

                /// <summary>
                /// Gets or creates a value for a given key, using the given createDelegate.
                /// If the value needs to be created it is created outside of a lock, so duplicates may be created,
                /// but one of them will never be used and the discardUnusedValue will be called to
                /// discard it proberly.
                /// </summary>
                public TValue GetOrCreateDiscardableValue(TKey key, Func<TKey, TValue> createValue, DiscardUnusedValueDelegate<TKey, TValue> discardUnusedValue)
                {
                    if (key == null)
                        throw new ArgumentNullException("key");

                    if (createValue == null)
                        createValue = ValueConstructorDelegate<TKey, TValue>.GetDefault();

                    int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                    TValue result;
                    if (_TryGetValue(hashCode, key, out result))
                        return result;

                    result = createValue(key);
                    bool otherResultFound;
                    TValue otherResult;

                    _lock.EnterWriteLock();
                    try
                    {
                        int bucketIndex = hashCode % _buckets.Length;

                        otherResultFound = _TryGetValue(hashCode, key, out otherResult);
                        if (!otherResultFound)
                        {
                            if (_count >= _buckets.Length*2)
                            {
                                _Resize();
                                bucketIndex = hashCode % _buckets.Length;
                            }

                            var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, result, _buckets[bucketIndex]);
                            _buckets[bucketIndex] = newNode;
                            _count++;
                        }
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }

                    if (otherResultFound)
                    {
                        if (discardUnusedValue != null)
                            discardUnusedValue(key, result, otherResult);

                        return otherResult;
                    }

                    return result;
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
            #region SetCapacity
		        /// <summary>
		        /// Tries to change the capacity of this dictionary to a value given
		        /// by the user.
		        /// Can return false if it is not possible by hashing rules or size.
		        /// Can also throw an exception if there is no memory but it is
		        /// expected that all items remain intact. (implementation specific).
		        /// </summary>
                public bool SetCapacity(int newCapacity)
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        return _SetCapacity(newCapacity);
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }

                internal bool _SetCapacity(int newCapacity)
                {
                    int halfCount = (_count + 1) / 2; // half count, rounded up.
                    if (newCapacity < halfCount)
                        newCapacity = halfCount;

                    newCapacity = _DictionaryHelper._AdaptLength(newCapacity);

                    if (newCapacity == _buckets.Length)
                        return false;

                    _SetCapacity_SizeMustBeAPrime(newCapacity);
                    return true;
                }
            #endregion
            #region TrimExcess
		        /// <summary>
		        /// Tries to reduce the Capacity of this dictionary to a value near the Count.
		        /// Can return false if it is not possible (by hashing rules) or necessary (because it
		        /// has the good size). Can also throw an exception if there is no memory but it is
		        /// expected that all items remain intact. (implementation specific).
		        /// </summary>
                public bool TrimExcess()
                {
                    _lock.EnterWriteLock();
                    try
                    {
                        return _TrimExcess();
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }

                internal bool _TrimExcess()
                {
                    int newCapacity = _DictionaryHelper._AdaptLength(_count);
                    if (newCapacity >= _buckets.Length)
                        return false;

                    _SetCapacity_SizeMustBeAPrime(newCapacity);
                    return true;
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

			#region Lock
				/// <summary>
				/// Locks this dictionary, avoiding any other thread to change this
				/// dictionary, and returns a disposable dictionary instance that you
				/// should use to do all your actions, that will avoid new lock. When 
				/// you finish your actions you should dispose such dictionary to release 
				/// the lock.
				/// If you try to use this dictionary instead of the locked one while
				/// you hold the lock you will probably cause a dead-lock.
				/// </summary>
				public LockedThreadSafeDictionary<TKey, TValue> Lock()
				{
					var result = new LockedThreadSafeDictionary<TKey, TValue>(this);
					_lock.EnterWriteLock();
					return result;
				}
			#endregion
            #region ForEach
                /// <summary>
                /// Executes the same action for all items in this dictionary.
                /// This is done in a no-lock technique and avoids copying the 
                /// pairs in this dictionary. This is usually faster than
                /// iterating over the dictionary with a normal foreach clause.
                /// </summary>
                public void ForEach(ForEachDictionaryDelegate<TKey, TValue> action)
		        {
                    if (action == null)
                        throw new ArgumentNullException("action");

                    var buckets = _buckets;
                    int length = buckets.Length;
                    for(int i=0; i<length; i++)
                    {
                        var node = buckets[i];

                        while(node != null)
                        {
                            action(node._key, node._value);

                            node = node._nextNode;
                        }
                    }
		        }
            #endregion
            #region RemoveMany
		        /// <summary>
		        /// Removes many items at once using a delegate to know if the item shoud be deleted.
		        /// This is fast when a good number of items (50% or more) is going to be removed simple
		        /// because the number of searches and the number of locks is reduced.
		        /// </summary>
                public void RemoveMany(RemoveManyDictionaryDelegate<TKey, TValue> checkDelegate)
                {
                    if (checkDelegate == null)
                        throw new ArgumentNullException("checkDelegate");

                    _lock.EnterWriteLock();
                    try
                    {
                        _RemoveMany(checkDelegate);
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }

                internal void _RemoveMany(RemoveManyDictionaryDelegate<TKey, TValue> checkDelegate)
                {
                    var buckets = _buckets;
                    int count = buckets.Length;
                    for (int bucketIndex = 0; bucketIndex < count; bucketIndex++)
                    {
                        _ThreadSafeDictionaryNode<TKey, TValue> oldNode = null;
                        var node = buckets[bucketIndex];

                        while (node != null)
                        {
                            if (checkDelegate(node._key, node._value))
                                _RemoveNode(bucketIndex, oldNode, node);

                            oldNode = node;
                            node = node._nextNode;
                        }
                    }
                }

		        /// <summary>
		        /// Removes many items at once using a collection of keys. This is usually
		        /// faster than doing many remoes as a single lock is obtained.
		        /// </summary>
                public void RemoveMany(IEnumerable<TKey> keys)
                {
                    if (keys == null)
                        throw new ArgumentNullException("keys");

                    _lock.EnterWriteLock();
                    try
                    {
                        _RemoveMany(keys);
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
                }

                internal void _RemoveMany(IEnumerable<TKey> keys)
                {
                    foreach (var key in keys)
                    {
                        if (key == null)
                            throw new ArgumentException("keys can't contain null values.", "keys");

                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                        int bucketIndex = hashCode % _buckets.Length;

                        _ThreadSafeDictionaryNode<TKey, TValue> node;
                        _ThreadSafeDictionaryNode<TKey, TValue> previousNode;
                        _GetNodeAndPreviousNode(bucketIndex, hashCode, key, out node, out previousNode);

                        if (node != null)
                            _RemoveNode(bucketIndex, previousNode, node);
                    }
                }
            #endregion
            #region AddMany
		        /// <summary>
		        /// Adds many items at once. This one is generally faster than adding 
		        /// each item individually because the final size can be pre-calculated.
		        /// </summary>
                public void AddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		        {
                    if (pairs == null)
                        throw new ArgumentNullException("pairs");

                    int pairCount = pairs.Count();
                    if (pairCount == 0)
                        return;

                    _lock.EnterWriteLock();
                    try
                    {
                        _AddMany(pairs, pairCount);
                    }
                    finally
                    {
                        _lock.ExitWriteLock();
                    }
		        }

                internal void _AddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs, int pairCount)
                {
                    int newCount = _count + pairCount;
                    if (newCount > Capacity)
                        _SetCapacity_SizeMustBeAPrime(_DictionaryHelper._AdaptLength(Math.Max(newCount, Capacity*2)));

                    foreach (var pair in pairs)
                    {
                        var key = pair.Key;
                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                        int bucketIndex = hashCode % _buckets.Length;
                        var firstNode = _buckets[bucketIndex];

                        if (_ContainsKey(hashCode, key, firstNode))
                            throw new ArgumentException("There is already a value for the key: " + key);

                        var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, pair.Value, firstNode);
                        _buckets[bucketIndex] = newNode;
                        _count++;
                    }
                }
            #endregion
            #region AddOrReplaceMany
		        /// <summary>
		        /// Adds or replaces many items at once. This one is generally faster than 
		        /// adding or replacing each item individually because the final size can be 
		        /// pre-calculated.
		        /// </summary>
                public void AddOrReplaceMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		        {
                    if (pairs == null)
                        throw new ArgumentNullException("pairs");

                    bool upgraded = false;
                    _lock.EnterUpgradeableLock();
                    try
                    {
                        int itemsToAdd;
                        bool isEmpty = _CountItemsToAdd_ReturnIsEmpty(pairs, out itemsToAdd);

						if (isEmpty)
							return;

                        _lock.UpgradeToWriteLock(ref upgraded);

                        _AddOrReplaceMany(pairs, itemsToAdd);
                    }
                    finally
                    {
                        _lock.ExitUpgradeableLock(upgraded);
                    }
		        }

                internal bool _CountItemsToAdd_ReturnIsEmpty(IEnumerable<KeyValuePair<TKey, TValue>> pairs, out int itemsToAdd)
                {
                    bool isEmpty = true;
                    int count = 0;
                    foreach (var pair in pairs)
                    {
                        isEmpty = false;

                        var key = pair.Key;
                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                        int bucketIndex = hashCode % _buckets.Length;
                        var firstNode = _buckets[bucketIndex];

                        if (!_ContainsKey(hashCode, key, firstNode))
                            count++;
                    }

                    itemsToAdd = count;
                    return isEmpty;
                }
                internal void _AddOrReplaceMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs, int itemsToAdd)
                {
                    int newCount = _count + itemsToAdd;
                    if (newCount > Capacity)
                        _SetCapacity_SizeMustBeAPrime(_DictionaryHelper._AdaptLength(Math.Max(newCount, Capacity*2)));

                    foreach (var pair in pairs)
                    {
                        var key = pair.Key;
                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                        int bucketIndex = hashCode % _buckets.Length;

                        _ThreadSafeDictionaryNode<TKey, TValue> node;
                        _ThreadSafeDictionaryNode<TKey, TValue> previousNode;
                        _AddOrReplace(key, pair.Value, hashCode, bucketIndex, out node, out previousNode);
                    }
                }
            #endregion
            #region TryAddMany
		        /// <summary>
		        /// Tries to add many items at once. This one is generally faster than 
		        /// trying to add each item individually because the final size can be 
		        /// pre-calculated.
		        /// </summary>
                public void TryAddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		        {
                    if (pairs == null)
                        throw new ArgumentNullException("pairs");

                    bool upgraded = false;
                    _lock.EnterUpgradeableLock();
                    try
                    {
                        int itemsToAdd = _CountItemsToTryAdd(pairs);

						if (itemsToAdd == 0)
							return;

                        _lock.UpgradeToWriteLock(ref upgraded);

                        _TryAddMany(pairs, itemsToAdd);
                    }
                    finally
                    {
                        _lock.ExitUpgradeableLock(upgraded);
                    }
		        }

                internal int _CountItemsToTryAdd(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
                {
                    int count = 0;
                    foreach (var pair in pairs)
                    {
                        var key = pair.Key;
                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                        int bucketIndex = hashCode % _buckets.Length;
                        var firstNode = _buckets[bucketIndex];

                        if (!_ContainsKey(hashCode, key, firstNode))
                            count++;
                    }

                    return count;
                }
                internal void _TryAddMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs, int itemsToAdd)
                {
                    int newCount = _count + itemsToAdd;
                    if (newCount > Capacity)
                        _SetCapacity_SizeMustBeAPrime(_DictionaryHelper._AdaptLength(Math.Max(newCount, Capacity*2)));

                    foreach (var pair in pairs)
                    {
                        var key = pair.Key;
                        int hashCode = _comparer.GetHashCode(key) & int.MaxValue;
                        int bucketIndex = hashCode % _buckets.Length;
                        var firstNode = _buckets[bucketIndex];

                        if (_ContainsKey(hashCode, key, firstNode))
                            continue;

                        var newNode = new _ThreadSafeDictionaryNode<TKey, TValue>(hashCode, key, pair.Value, firstNode);
                        _buckets[bucketIndex] = newNode;
                    }
                }
            #endregion

            #region GetEnumerator
                /// <summary>
                /// Gets an enumerator so you can see all the key-value pairs present
                /// in this dictionary.
                /// </summary>
                public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
                {
                    var buckets = _buckets;
                    int count = buckets.Length;
                    for(int i=0; i<count; i++)
                    {
                        var node = buckets[i];

                        while(node != null)
                        {
                            yield return new KeyValuePair<TKey, TValue>(node._key, node._value);

                            node = node._nextNode;
                        }
                    }
                }
            #endregion
            #region ToArray
                /// <summary>
                /// Copies all the pairs in this dictionary to an array.
                /// This is useful if you plan to iterate many times as
                /// this copy will not change and because iterating in
                /// arrays is faster. But, if you plan to iterate only once,
                /// it is still faster to do it over the dictionary directly.
                /// </summary>
                public KeyValuePair<TKey, TValue>[] ToArray()
                {
                    _lock.EnterReadLock();
                    try
                    {
                        return _ToArray();
                    }
                    finally
                    {
                        _lock.ExitReadLock();
                    }
                }

                internal KeyValuePair<TKey, TValue>[] _ToArray()
                {
                    if (_count == 0)
                        return EmptyArray<KeyValuePair<TKey, TValue>>.Instance;

                    var result = new KeyValuePair<TKey, TValue>[_count];
                    int position = 0;
                    var buckets = _buckets;
                    for (int i = 0; i < buckets.Length; i++)
                    {
                        var node = buckets[i];

                        while (node != null)
                        {
                            result[position] = new KeyValuePair<TKey, TValue>(node._key, node._value);
                            position++;

                            node = node._nextNode;
                        }
                    }

                    return result;
                }
            #endregion
            #region CopyKeys
                /// <summary>
                /// Copies all the keys in this dictionary to an array.
                /// This is useful if you plan to iterate many times as
                /// this copy will not change and because iterating in
                /// arrays is faster. But, if you plan to iterate only once,
                /// it is still faster to do it over the Keys directly.
                /// </summary>
                public TKey[] CopyKeys()
                {
                    _lock.EnterReadLock();
                    try
                    {
                        return _CopyKeys();
                    }
                    finally
                    {
                        _lock.ExitReadLock();
                    }
                }

                internal TKey[] _CopyKeys()
                {
                    if (_count == 0)
                        return EmptyArray<TKey>.Instance;

                    var result = new TKey[_count];
                    int position = 0;
                    var buckets = _buckets;
                    for (int i = 0; i < buckets.Length; i++)
                    {
                        var node = buckets[i];

                        while (node != null)
                        {
                            result[position] = node._key;
                            position++;

                            node = node._nextNode;
                        }
                    }

                    return result;
                }
            #endregion
            #region CopyValues
                /// <summary>
                /// Copies all the values in this dictionary to an array.
                /// This is useful if you plan to iterate many times as
                /// this copy will not change and because iterating in
                /// arrays is faster. But, if you plan to iterate only once,
                /// it is still faster to do it over the Values directly.
                /// </summary>
                public TValue[] CopyValues()
                {
                    // it is faster to get a single lock than to get many locks.
                    _lock.EnterReadLock();
                    try
                    {
                        return _CopyValues();
                    }
                    finally
                    {
                        _lock.ExitReadLock();
                    }
                }

                internal TValue[] _CopyValues()
                {
                    if (_count == 0)
                        return EmptyArray<TValue>.Instance;

                    var result = new TValue[_count];
                    int position = 0;
                    var buckets = _buckets;
                    for (int i = 0; i < buckets.Length; i++)
                    {
                        var node = buckets[i];

                        while (node != null)
                        {
                            result[position] = node._value;
                            position++;

                            node = node._nextNode;
                        }
                    }

                    return result;
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
                    return _comparer;
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

			IDisposableDictionary IThreadSafeDictionary.Lock()
			{
				return Lock();
			}
			IDisposableDictionary<TKey, TValue> IThreadSafeDictionary<TKey, TValue>.Lock()
			{
				return Lock();
			}

			object IThreadSafeDictionary.GetOrCreateDiscardableValue(object key)
			{
				return GetOrCreateDiscardableValue((TKey)key);
			}

			object IThreadSafeDictionary.GetOrCreateDiscardableValue(object key, Delegate createValue)
			{
				return GetOrCreateDiscardableValue((TKey)key, (Func<TKey, TValue>)createValue);
			}

			object IThreadSafeDictionary.GetOrCreateDiscardableValue(object key, Delegate createValue, Delegate discardUnusedValue)
			{
				return GetOrCreateDiscardableValue((TKey)key, (Func<TKey, TValue>)createValue, (DiscardUnusedValueDelegate<TKey, TValue>)discardUnusedValue);
			}
        #endregion
	}
}
