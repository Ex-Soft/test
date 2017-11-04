using System;

namespace TestEventsIV
{
    public delegate void CustomEventHandler(object sender, CustomEventArgs args);

    class Observer
    {
        public event CustomEventHandler CustomEvent;

        public void OnCustomEvent(object sender, CustomEventArgs args)
        {
            if (CustomEvent != null)
                CustomEvent(sender, args);
        }
    }

    public class CustomEventArgs : EventArgs
    {
        public string Arg;

        public CustomEventArgs(string arg="")
        {
            Arg = arg;
        }

        public CustomEventArgs(CustomEventArgs obj) : this(obj.Arg)
        {}
    }
}
