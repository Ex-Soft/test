using System;
using System.Collections.Generic;

namespace ObserverII
{
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObserver();
    }

    public class Subject : ISubject
    {
        List<IObserver>
            list;

        string
            str;

        public string Str
        {
            get
            {
                return str;
            }
            set
            {
                if (str != value)
                {
                    str = value;
                    StrChanged();
                }
            }
        }
        public Subject()
        {
            list = new List<IObserver>();
        }

        public void RegisterObserver(IObserver o)
        {
            list.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            list.Remove(o);
        }

        public void NotifyObserver()
        {
            list.ForEach(item => item.Update(str));
        }

        public void StrChanged()
        {
            NotifyObserver();
        }
    }

    public interface IObserver
    {
        void Update(string str);
    }

    public interface IDisplay
    {
        void Display();
    }

    public class Observer : IObserver, IDisplay
    {
        string
            str,
            name;

        ISubject
            subj;

        public Observer(string name, ISubject subj)
        {
            this.name = name;
            this.subj = subj;
            Subscribe();
        }

        public void Update(string str)
        {
            this.str = str;
            Display();
        }
        public void Display()
        {
            Console.WriteLine("{0}: {1}", name, str);
        }

        public void Subscribe()
        {
            subj.RegisterObserver(this);
        }

        public void Unsubscribe()
        {
            subj.RemoveObserver(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Subject
                subject = new Subject();

            Observer
                observer1 = new Observer("Observer# 1", subject),
                observer2 = new Observer("Observer# 2", subject);

            subject.Str = "Str";

            observer2.Unsubscribe();

            subject.Str = "StrStr";

            Console.ReadLine();
        }
    }
}
