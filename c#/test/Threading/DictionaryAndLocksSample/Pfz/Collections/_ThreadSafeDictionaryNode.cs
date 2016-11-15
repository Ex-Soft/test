using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pfz.Collections
{
    internal sealed class _ThreadSafeDictionaryNode<TKey, TValue>
    {
        internal readonly int _hashCode;
        internal readonly TKey _key;
        internal readonly TValue _value;
        internal _ThreadSafeDictionaryNode<TKey, TValue> _nextNode;

        internal _ThreadSafeDictionaryNode(int hashCode, TKey key, TValue value, _ThreadSafeDictionaryNode<TKey, TValue> nextNode)
        {
            _hashCode = hashCode;
            _key = key;
            _value = value;
            _nextNode = nextNode;
        }
    }
}
