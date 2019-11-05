using System;
using System.Collections.Generic;

namespace ListWithEvents
{
    public class EventList3<T>
    {
        readonly List<T> list;

        public event EventHandler<ListEventArgs> OnAdd;
        public event EventHandler<ListEventArgs> OnRemove;

        public EventList3()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
            OnAdd?.Invoke(this, new ListEventArgs(item));
        }

        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            OnRemove?.Invoke(this, new ListEventArgs(item));
            return result;
        }
    }
}
