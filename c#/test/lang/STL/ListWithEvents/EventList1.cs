using System;
using System.Collections.Generic;

namespace ListWithEvents
{
    class EventList1<T>
    {
        readonly List<T> list;

        public event EventHandler<T> OnAdd;
        public event EventHandler<T> OnRemove;

        public EventList1()
        {
            list = new List<T>();
        }

        public void Add(T item)
        {
            list.Add(item);
            OnAdd?.Invoke(this, item);
        }

        public bool Remove(T item)
        {
            bool result = list.Remove(item);
            OnRemove?.Invoke(this, item);
            return result;
        }
    }
}
