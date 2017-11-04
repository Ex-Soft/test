#define TEST_ADD_REMOVE

using System;
using System.Windows.Forms;
using System.IO;

namespace TestDelegateI
{
    internal delegate void Feedback(Int32 value);

    public sealed class Program
    {
        public static void Main(string[] args)
        {
            #if TEST_ADD_REMOVE

                Action
                    a = () => Console.WriteLine("A"),
                    b = a,
                    c = a + b,
                    d = a - b;

                a();
                b();
                c();

                try
                {
                    d();
                }
                catch (NullReferenceException eException)
                {
                    Console.WriteLine(eException.GetType().Name);
                }

            #endif

            StaticDelegateDemo();
            InstanceDelegateDemo();
            ChainDelegateDemo1(new Program());
            ChainDelegateDemo2(new Program());
        }

        static void StaticDelegateDemo()
        {
            Console.WriteLine("-- Static Delegate Demo --");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(Program.FeedbackToConsole));
            Counter(1, 3, new Feedback(FeedbackToMsgBox));
            Console.WriteLine();
        }

        static void InstanceDelegateDemo()
        {
            Console.WriteLine("-- Instance Delegate Demo --");

            Program
                p = new Program();

            Counter(1, 3, new Feedback(p.FeedbackToFile));

            Console.WriteLine();
        }

        static void ChainDelegateDemo1(Program p)
        {
            Console.WriteLine("-- Chain Delegate Demo 1 --");

            Feedback
                fb1 = new Feedback(FeedbackToConsole),
                fb2 = new Feedback(FeedbackToMsgBox),
                fb3 = new Feedback(p.FeedbackToFile),
                fbChain = null;

            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb2);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb3);
            Counter(1, 2, fbChain);
            Console.WriteLine();

            fbChain = (Feedback)Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
            Counter(1, 2, fbChain);
            Console.WriteLine();
        }

        static void ChainDelegateDemo2(Program p)
        {
            Console.WriteLine("-- Chain Delegate Demo 2 --");

            Feedback
                fb1 = new Feedback(FeedbackToConsole),
                fb2 = new Feedback(FeedbackToMsgBox),
                fb3 = new Feedback(p.FeedbackToFile),
                fbChain = null;

            fbChain += fb1;
            fbChain += fb2;
            fbChain += fb3;
            Counter(1, 2, fbChain);
            Console.WriteLine();

            fbChain -= new Feedback(FeedbackToMsgBox);
            Counter(1, 2, fbChain);
            Console.WriteLine();
        }

        static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for (Int32 val = from; val <= to; ++val)
                if (fb != null)
                    fb(val);
        }

        static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item=" + value);
        }

        static void FeedbackToMsgBox(Int32 value)
        {
            MessageBox.Show("Item=" + value);
        }

        void FeedbackToFile(Int32 value)
        {
            StreamWriter
                sw = new StreamWriter("Status", true);

            sw.WriteLine("Item=" + value);
            sw.Close();
        }
    }
}
