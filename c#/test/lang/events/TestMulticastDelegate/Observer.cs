using System;

namespace TestMultiCastDelegate
{
    public delegate void CustomEventHandler(object sender, CustomEventArgs args);

    public class Observer
    {
        public event CustomEventHandler CustomEvent;

        public void OnCustomEvent(object sender, CustomEventArgs args)
        {
            CustomEvent?.Invoke(this, args);
        }
    }

    public class ObserverSafe
    {
        public event CustomEventHandler CustomEvent;

        public void OnCustomEvent(object sender, CustomEventArgs args)
        {
            foreach (Delegate single in CustomEvent.GetInvocationList())
            {
                try
                {
                    single.DynamicInvoke(sender, args);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }    
            }
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public string CustomMessage { get; set; }
        public bool ThrowException { get; set; }

        public CustomEventArgs(string customMessage = "", bool throwException = false)
        {
            CustomMessage = customMessage;
            ThrowException = throwException;
        }

        public CustomEventArgs(CustomEventArgs obj) : this(obj.CustomMessage, obj.ThrowException)
        {}
    }
}
