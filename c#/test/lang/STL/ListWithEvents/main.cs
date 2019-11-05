using static System.Console;

namespace ListWithEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            EventList1<SmthClass> list1 = new EventList1<SmthClass>();

            list1.OnAdd += OnAddToList1;
            list1.OnRemove += OnRemoveFromList1;

            SmthClass item = new SmthClass { PString = "PString# 1" };

            list1.Add(item);
            list1.Remove(item);

            EventList2<SmthClass> list2 = new EventList2<SmthClass>();

            list2.OnAdd += OnAddToList2;
            list2.OnRemove += OnRemoveFromList2;

            list2.Add(item);
            list2.Remove(item);

            EventList3<SmthClass> list3 = new EventList3<SmthClass>();

            list3.OnAdd += OnAddToList3;
            list3.OnRemove += OnRemoveFromList3;

            list3.Add(item);
            list3.Remove(item);
        }

        public static void OnAddToList1<T>(object sender, T e)
        {
            WriteLine(e);
        }

        public static void OnRemoveFromList1<T>(object sender, T e)
        {
            WriteLine(e);
        }

        public static void OnAddToList2<T>(object sender, ListEventArgs<T> e)
        {
            WriteLine(e.Item);
        }

        public static void OnRemoveFromList2<T>(object sender, ListEventArgs<T> e)
        {
            WriteLine(e.Item);
        }

        public static void OnAddToList3(object sender, ListEventArgs e)
        {
            WriteLine(e.Item);
        }

        public static void OnRemoveFromList3(object sender, ListEventArgs e)
        {
            WriteLine(e.Item);
        }
    }
}
