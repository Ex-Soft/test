using System;
using System.Globalization;
using System.Windows.Forms;

namespace TestEventsIV
{
    class Listener
    {
        readonly string _listenerName;

        public Listener(string listenerName = "")
        {
            _listenerName = !string.IsNullOrWhiteSpace(listenerName) ? listenerName : DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
        }

        public Listener(Listener obj) : this(obj._listenerName)
        {}

        public void OnCustomEvent(object sender, CustomEventArgs args)
        {
            MainForm form;

            if ((form = sender as MainForm) == null)
                return;

            if(form.listBoxLog.InvokeRequired)
                form.listBoxLog.Invoke(new MethodInvoker(() => form.listBoxLog.Items.Add(string.Format("From: \"{0}\" CustomEventArgs: {{ Arg: \"{1}\" }} {2}", _listenerName, args.Arg, " (InvokeRequired)"))));
            else
                form.listBoxLog.Items.Add(string.Format("From: \"{0}\" CustomEventArgs: {{ Arg: \"{1}\" }} {2}", _listenerName, args.Arg, " (!InvokeRequired)"));
        }
    }
}
