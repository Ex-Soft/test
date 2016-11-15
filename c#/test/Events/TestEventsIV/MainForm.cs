using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestEventsIV
{
    public partial class MainForm : Form
    {
        readonly Observer
            _observer;

        readonly Listener
            _listener1,
            _listener2;

        public MainForm()
        {
            InitializeComponent();

            _observer = new Observer();

            _listener1 = new Listener("listener# 1");
            _listener2 = new Listener("listener# 2");

            _observer.CustomEvent += _listener1.OnCustomEvent;
            _observer.CustomEvent += _listener2.OnCustomEvent;
        }

        private void ButtonDoItClick(object sender, EventArgs e)
        {
            _observer.OnCustomEvent(this, new CustomEventArgs("ButtonDoItClick"));
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("Closed");

            _observer.CustomEvent -= _listener1.OnCustomEvent;
            _observer.CustomEvent -= _listener2.OnCustomEvent;
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("Closing");
        }
    }
}
