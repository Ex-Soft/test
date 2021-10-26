using System;
using System.Reflection;

namespace TestMultiCastDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var observerSafe = new ObserverSafe();
            observerSafe.CustomEvent += CustomEvent1;
            observerSafe.CustomEvent += CustomEvent2;
            observerSafe.CustomEvent += CustomEvent3;
            observerSafe.OnCustomEvent(new { SenderName = "SenderName" }, new CustomEventArgs("CustomEventMessage", true));

            var observer = new Observer();
            observer.CustomEvent += CustomEvent1;
            observer.CustomEvent += CustomEvent2;
            observer.CustomEvent += CustomEvent3;
            observer.OnCustomEvent(new { SenderName = "SenderName" }, new CustomEventArgs("CustomEventMessage", true) );
        }

        static void CustomEvent1(object sender, CustomEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}()");
        }

        static void CustomEvent2(object sender, CustomEventArgs args)
        {
            if (args.ThrowException)
            {
                throw new Exception($"{MethodBase.GetCurrentMethod()?.Name}()");
            }

            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}()");
        }

        static void CustomEvent3(object sender, CustomEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine($"{MethodBase.GetCurrentMethod()?.Name}()");
        }
    }
}
