using System;

namespace ListWithEvents
{
    public class ListEventArgs<T> : EventArgs
    {
        public T Item { get; set; }

        public ListEventArgs(T item)
        {
            Item = item;
        }
    }

    public class ListEventArgs : EventArgs
    {
        public object Item { get; set; }

        public ListEventArgs(object item)
        {
            Item = item;
        }
    }
}
