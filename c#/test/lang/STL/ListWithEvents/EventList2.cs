using System;
using System.Collections.Generic;

namespace ListWithEvents
{
    public class EventList2<T>
    {
        readonly List<T> list;

        public event EventHandler<ListEventArgs<T>> OnAdd;
        public event EventHandler<ListEventArgs<T>> OnRemove;

        public EventList2()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
            OnAdd?.Invoke(this, new ListEventArgs<T>(item));
        }

        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            OnRemove?.Invoke(this, new ListEventArgs<T>(item));
            return result;
        }
    }
}
