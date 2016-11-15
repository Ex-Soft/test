#define ERROR_HANDLING
//#define THROW_EXCEPTION

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SynchronizationContextI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mToolStripButtonThreads_Click(object sender, EventArgs e)
        {
            // let's see the thread id
            int id = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine("mToolStripButtonThreads_Click thread: " + id);

            // grab the sync context associated to this
            // thread (the UI thread), and save it in uiContext
            // note that this context is set by the UI thread
            // during Form creation (outside of your control)
            // also note, that not every thread has a sync context attached to it.
            SynchronizationContext uiContext = SynchronizationContext.Current;

            // create a thread and associate it to the run method
            Thread thread = new Thread(Run);

            // start the thread, and pass it the UI context,
            // so this thread will be able to update the UI
            // from within the thread
            thread.Start(uiContext);
        }

        private void Run(object state)
        {
            // lets see the thread id
            int id = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine("Run thread: " + id);

            // grab the context from the state
            SynchronizationContext uiContext = state as SynchronizationContext;

            for (int i = 0; i < 1000; i++)
            {
                // normally you would do some code here
                // to grab items from the database. or some long
                // computation
                Thread.Sleep(10);

                // use the ui context to execute the UpdateUI method,
                // this insure that the UpdateUI method will run on the UI thread.

                #if ERROR_HANDLING
                    try
                    {
                        uiContext.Send(UpdateUI, "line " + i.ToString());
                    }
                    catch(InvalidAsynchronousStateException e)
                    {
                        Debug.WriteLine(string.Format("InvalidAsynchronousStateException: \"{0}\"", e.Message));
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                #else
                    uiContext.Post(UpdateUI, "line " + i.ToString());
                #endif
            }
        }

        /// <summary>
        /// This method is executed on the main UI thread.
        /// </summary>
        private void UpdateUI(object state)
        {
            #if THROW_EXCEPTION
                throw new Exception("Boom");
            #else
                int id = Thread.CurrentThread.ManagedThreadId;
                Debug.WriteLine("UpdateUI thread:" + id);
                string text = state as string;
                mListBox.Items.Add(text);
            #endif
        }
    }
}
