using System;
using System.Collections;

namespace ObserverI
{
    class Subject
    {
        ArrayList
            list = new ArrayList();

        string
            strImportantSubjectData = "Initial";

        public string ImportantSubjectData
        {
            get
            {
                return strImportantSubjectData;
            }
            set
            {
                strImportantSubjectData = value;
            }
        }

        public void Attach(Observer o)
        {
            list.Add(o);
            o.ObservedSubject = this;
        }

        public void Detach(Observer o)
        {
            o.ObservedSubject = null;

            int
                idx;

            if ((idx = list.IndexOf(o)) != -1)
                list.RemoveAt(idx);
        }

        public void Notify()
        {
            foreach (Observer o in list)
            {
                o.Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        public void GetState()
        {

        }

        public void SetState()
        {

        }
    }

    abstract class Observer
    {
        protected Subject
            s;

        public Subject ObservedSubject
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }

        abstract public void Update();
    }

    class ConcreteObserver : Observer
    {
        string
            observerName;

        public ConcreteObserver(string name)
        {
            observerName = name;
        }

        override public void Update()
        {
            Console.WriteLine("In Observer {0}: data from subject = {1}", observerName, s.ImportantSubjectData);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject
                s = new ConcreteSubject();

            ConcreteObserver
                o1 = new ConcreteObserver("1st observer"),
                o2 = new ConcreteObserver("2nd observer");

            s.Attach(o1);
            s.Attach(o2);

            s.ImportantSubjectData = "This is important subject data";

            s.Notify();

            s.Detach(o2);

            s.Notify();
        }
    }
}
