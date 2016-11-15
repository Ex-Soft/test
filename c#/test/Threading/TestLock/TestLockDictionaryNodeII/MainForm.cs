//#define TEST_STRING
//#define USE_TRY_GET_VALUE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace TestLockDictionaryNodeII
{
    public partial class MainForm : Form
    {
        const string DateTimeFormatString = "mm:ss.fffffff";
        const int MillisecondsTimeoutDefault = 10000;

        private readonly Dictionary<int,
        #if TEST_STRING
            string
        #else
            Victim
        #endif
        >
        _victim = new Dictionary<int,
        #if TEST_STRING
            string
        #else
            Victim
        #endif
        >
            {
                {0,
                #if TEST_STRING
                    string.Empty
                #else
                    new Victim()    
                #endif
                },
                {1,
                #if TEST_STRING
                    string.Empty
                #else
                    new Victim()    
                #endif
                },
                {2,
                #if TEST_STRING
                    string.Empty
                #else
                    new Victim()    
                #endif
                }
            },
        _victimWithInit = new Dictionary<int,
        #if TEST_STRING
            string
        #else
            Victim
        #endif
        >();

        private static ManualResetEvent
            mreBeforeCheckI,
            mreBeforeLock,
            mreBeforeCheckII,
            mreBeforeAdd,
            mreAfterAdd;

        public MainForm()
        {
            InitializeComponent();
            textBoxNodeNo.Text = (_victim.Keys.Count - 1).ToString(CultureInfo.InvariantCulture);
            textBoxMillisecondsTimeout.Text = MillisecondsTimeoutDefault.ToString(CultureInfo.InvariantCulture);
        }

        private void BtnThread1Click(object sender, EventArgs e)
        {
            int
                nodeNo,
                millisecondsTimeout;

            if (!int.TryParse(textBoxNodeNo.Text, out nodeNo))
                nodeNo = _victim.Keys.Count - 1;

            if (!int.TryParse(textBoxMillisecondsTimeout.Text, out millisecondsTimeout))
                millisecondsTimeout = MillisecondsTimeoutDefault;

            var thread1 = new Thread(LockNode);
            thread1.Start(new ThreadParam { NodeNo = nodeNo, MillisecondsTimeout = millisecondsTimeout });
        }

        private void LockNode(object state)
        {
            const string prefix = "Thread #1";

            int
                nodeNo = _victim.Keys.Count - 1,
                millisecondsTimeout = MillisecondsTimeoutDefault;

            ThreadParam param;

            if ((param = state as ThreadParam) != null)
            {
                if (param.NodeNo >= 0 && param.NodeNo < _victim.Keys.Count - 1)
                    nodeNo = param.NodeNo;

                if (param.MillisecondsTimeout >= 0)
                    millisecondsTimeout = param.MillisecondsTimeout;
            }

            WriteToLog(string.Format("{0} {1} starting... (will sleep {2}ms)", DateTime.Now.ToString(DateTimeFormatString), prefix, millisecondsTimeout));

            WriteToLog(string.Format("{0} {1} before trying to lock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

            #if USE_TRY_GET_VALUE
                #if TEST_STRING
                    string
                #else
                    Victim
                #endif
                    nodeValue;

                _victim.TryGetValue(nodeNo, out nodeValue);
            #endif

            lock (
                #if USE_TRY_GET_VALUE
                    nodeValue
                #else
                    _victim[nodeNo]
                #endif
                )
            {
                WriteToLog(string.Format("{0} {1} have locked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
                Thread.Sleep(millisecondsTimeout);
                WriteToLog(string.Format("{0} {1} will unlock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
            }
            WriteToLog(string.Format("{0} {1} have unlocked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

            WriteToLog(string.Format("{0} {1} finished", DateTime.Now.ToString(DateTimeFormatString), prefix));
        }

        void BtnThread2Click(object sender, EventArgs e)
        {
            var thread2 = new Thread(TryGetLock);
            thread2.Start();
        }

        private void TryGetLock()
        {
            const string prefix = "Thread #2";

            WriteToLog(string.Format("{0} {1} starting...", DateTime.Now.ToString(DateTimeFormatString), prefix));

            for (var nodeNo = 0; nodeNo < _victim.Keys.Count; ++nodeNo)
            //foreach (var i in _victim.Keys)
            {
                WriteToLog(string.Format("{0} {1} before trying to lock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
                lock (_victim[nodeNo])
                {
                    WriteToLog(string.Format("{0} {1} have locked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

                    _victim[nodeNo]
                        #if !TEST_STRING
                            .FString
                        #endif
                    = string.Format("{0} {1} have changed node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo);

                    WriteToLog(string.Format("{0} {1} will unlock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
                }
                WriteToLog(string.Format("{0} {1} have unlocked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
            }

            WriteToLog(string.Format("{0} {1} finished", DateTime.Now.ToString(DateTimeFormatString), prefix));
        }

        private void BtnShowClick(object sender, EventArgs e)
        {
            Button btn;

            if ((btn = sender as Button) == null)
                return;

            var dictionary = btn.Name == "btnShow" ? _victim : _victimWithInit;

            foreach (var v in dictionary)
                WriteToLog(string.Format("[{0}] = \"{1}\"", v.Key, v.Value));
        }

        void BtnClearClick(object sender, EventArgs e)
        {
            _victimWithInit.Clear();

            if (mreBeforeCheckI != null)
            {
                mreBeforeCheckI.Dispose();
                mreBeforeCheckI = null;
            }

            if (mreBeforeLock != null)
            {
                mreBeforeLock.Dispose();
                mreBeforeLock = null;
            }

            if (mreBeforeCheckII != null)
            {
                mreBeforeCheckII.Dispose();
                mreBeforeCheckI = null;
            }

            if (mreBeforeAdd != null)
            {
                mreBeforeAdd.Dispose();
                mreBeforeAdd = null;
            }

            if (mreAfterAdd != null)
            {
                mreAfterAdd.Dispose();
                mreAfterAdd = null;
            }

            listBoxLog.Items.Clear();

            radioButtonCheckI.Checked = true;
        }

        void WriteToLog(string message, bool addListItem = true)
        {
            System.Diagnostics.Debug.WriteLine(message);

            if (!addListItem)
                return;

            message = string.Format("{0} ({1}InvokeRequired)", message, !listBoxLog.InvokeRequired ? "!" : string.Empty);

            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(message)));
            else
                listBoxLog.Items.Add(message);
        }

        private void BtnThreadWithInit1Click(object sender, EventArgs e)
        {
            int
                nodeNo,
                millisecondsTimeout;

            if (!int.TryParse(textBoxNodeNo.Text, out nodeNo))
                nodeNo = 0;

            if (!int.TryParse(textBoxMillisecondsTimeout.Text, out millisecondsTimeout))
                millisecondsTimeout = MillisecondsTimeoutDefault;

            var thread1 = new Thread(LockNodeWithInit);
            thread1.Start(new ThreadParam { NodeNo = nodeNo, MillisecondsTimeout = millisecondsTimeout });
        }

        private void BtnThreadWithInit2Click(object sender, EventArgs e)
        {
            int
                nodeNo,
                millisecondsTimeout;

            if (!int.TryParse(textBoxNodeNo.Text, out nodeNo))
                nodeNo = 0;

            if (!int.TryParse(textBoxMillisecondsTimeout.Text, out millisecondsTimeout))
                millisecondsTimeout = MillisecondsTimeoutDefault;

            var thread2 = new Thread(TryGetLockWithInit);
            thread2.Start(new ThreadParam { NodeNo = nodeNo, MillisecondsTimeout = millisecondsTimeout });
        }

        private void LockNodeWithInit(object state)
        {
            const string prefix = "Thread #1";

            int
                nodeNo = 0,
                millisecondsTimeout = MillisecondsTimeoutDefault;

            ThreadParam param;

            if ((param = state as ThreadParam) != null)
            {
                if (param.NodeNo >= 0)
                    nodeNo = param.NodeNo;

                if (param.MillisecondsTimeout >= 0)
                    millisecondsTimeout = param.MillisecondsTimeout;
            }

            WriteToLog(string.Format("{0} {1} starting... (will sleep {2}ms)", DateTime.Now.ToString(DateTimeFormatString), prefix, millisecondsTimeout));

            WriteToLog(string.Format("{0} {1} before trying to lock ((ICollection)_victimWithInit).SyncRoot", DateTime.Now.ToString(DateTimeFormatString), prefix));
            lock (((ICollection)_victimWithInit).SyncRoot)
            {
                WriteToLog(string.Format("{0} {1} have locked ((ICollection)_victimWithInit).SyncRoot successfully", DateTime.Now.ToString(DateTimeFormatString), prefix));

                Thread.Sleep(millisecondsTimeout);

                WriteToLog(string.Format("{0} {1} before trying to add node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
                if (!_victimWithInit.ContainsKey(nodeNo))
                { 
                    var msg = string.Format("{0} {1} node[{2}] has been added", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo);

                    _victimWithInit.Add(nodeNo,
                        #if TEST_STRING
                            msg
                        #else
                            new Victim(msg)
                        #endif
                        );
                }

                Thread.Sleep(millisecondsTimeout);
                WriteToLog(string.Format("{0} {1} will unlock ((ICollection)_victimWithInit).SyncRoot", DateTime.Now.ToString(DateTimeFormatString), prefix));
            }
            WriteToLog(string.Format("{0} {1} have unlocked ((ICollection)_victimWithInit).SyncRoot successfully", DateTime.Now.ToString(DateTimeFormatString), prefix));

            WriteToLog(string.Format("{0} {1} finished", DateTime.Now.ToString(DateTimeFormatString), prefix));
        }

        private void TryGetLockWithInit(object state)
        {
            const string prefix = "Thread #2";

            int
                nodeNo = 0,
                millisecondsTimeout = MillisecondsTimeoutDefault;

            ThreadParam param;

            if ((param = state as ThreadParam) != null)
            {
                if (param.NodeNo >= 0)
                    nodeNo = param.NodeNo;

                if (param.MillisecondsTimeout >= 0)
                    millisecondsTimeout = param.MillisecondsTimeout;
            }

            WriteToLog(string.Format("{0} {1} starting...", DateTime.Now.ToString(DateTimeFormatString), prefix));

            WriteToLog(string.Format("{0} {1} before trying to lock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
            lock (_victimWithInit[nodeNo])
            {
                WriteToLog(string.Format("{0} {1} have locked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

                _victimWithInit[nodeNo]
                    #if !TEST_STRING
                        .FString
                    #endif
                = string.Format("{0} {1} have changed node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo);

                WriteToLog(string.Format("{0} {1} will unlock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
            }
            WriteToLog(string.Format("{0} {1} have unlocked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

            WriteToLog(string.Format("{0} {1} finished", DateTime.Now.ToString(DateTimeFormatString), prefix));
        }

        private void BtnThreadWithInitII1Click(object sender, EventArgs e)
        {
            int
                nodeNo,
                millisecondsTimeout;

            if (!int.TryParse(textBoxNodeNo.Text, out nodeNo))
                nodeNo = 0;

            if (!int.TryParse(textBoxMillisecondsTimeout.Text, out millisecondsTimeout))
                millisecondsTimeout = MillisecondsTimeoutDefault;

            mreBeforeCheckI = new ManualResetEvent(false);
            mreBeforeLock = new ManualResetEvent(false);
            mreBeforeCheckII = new ManualResetEvent(false);
            mreBeforeAdd = new ManualResetEvent(false);
            mreAfterAdd = new ManualResetEvent(false);

            var thread = new Thread(LockNodeWithInitII);
            thread.Name = "Thread #1";
            thread.Start(new ThreadParam { NodeNo = nodeNo, MillisecondsTimeout = millisecondsTimeout });
        }

        private void BtnThreadWithInitII2Click(object sender, EventArgs e)
        {
            int
                nodeNo,
                millisecondsTimeout;

            if (!int.TryParse(textBoxNodeNo.Text, out nodeNo))
                nodeNo = 0;

            if (!int.TryParse(textBoxMillisecondsTimeout.Text, out millisecondsTimeout))
                millisecondsTimeout = MillisecondsTimeoutDefault;

            var thread = new Thread(LockNodeWithInitII);
            thread.Name = "Thread #2";
            thread.Start(new ThreadParam { NodeNo = nodeNo, MillisecondsTimeout = millisecondsTimeout });
        }

        private void BtnMRESetClick(object sender, EventArgs e)
        {
            ManualResetEvent mre = null;
            RadioButton radioButtonNext = null;

            if (radioButtonCheckI.Checked)
            {
                mre = mreBeforeCheckI;
                radioButtonNext = radioButtonBeforeLock;
            }
            else if (radioButtonBeforeLock.Checked)
            {
                mre = mreBeforeLock;
                radioButtonNext = radioButtonCheckII;
            }
            else if (radioButtonCheckII.Checked)
            {
                mre = mreBeforeCheckII;
                radioButtonNext = radioButtonBeforeAdd;
            }
            else if (radioButtonBeforeAdd.Checked)
            {
                mre = mreBeforeAdd;
                radioButtonNext = radioButtonAfterAdd;
            }
            else if (radioButtonAfterAdd.Checked)
                mre = mreAfterAdd;

            if (mre != null)
                mre.Set();

            if (radioButtonNext != null)
                radioButtonNext.Checked = true;
        }

        private void LockNodeWithInitII(object state)
        {
            const string thread1Name = "Thread #1";

            var prefix = Thread.CurrentThread.Name;

            int
                nodeNo = 0,
                millisecondsTimeout = MillisecondsTimeoutDefault;

            ThreadParam param;

            if ((param = state as ThreadParam) != null)
            {
                if (param.NodeNo >= 0)
                    nodeNo = param.NodeNo;

                if (param.MillisecondsTimeout >= 0)
                    millisecondsTimeout = param.MillisecondsTimeout;
            }

            WriteToLog(string.Format("{0} {1} starting... (will sleep {2}ms)", DateTime.Now.ToString(DateTimeFormatString), prefix, millisecondsTimeout));

            #if USE_TRY_GET_VALUE
                #if TEST_STRING
                    string
                #else
                    Victim
                #endif
                    nodeValue;
            #endif

            if (prefix == thread1Name)
            {
                WriteToLog(string.Format("{0} {1} before mreBeforeCheckI.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                mreBeforeCheckI.WaitOne();
                WriteToLog(string.Format("{0} {1} after mreBeforeCheckI.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
            }

            if (!
                #if USE_TRY_GET_VALUE
                    _victimWithInit.TryGetValue(nodeNo, out nodeValue)
                #else
                    _victimWithInit.ContainsKey(nodeNo)
                #endif
            )
            {
                if (prefix == thread1Name)
                {
                    WriteToLog(string.Format("{0} {1} before mreBeforeLock.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                    mreBeforeLock.WaitOne();
                    WriteToLog(string.Format("{0} {1} after mreBeforeLock.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                }

                WriteToLog(string.Format("{0} {1} before trying to lock ((ICollection)_victimWithInit).SyncRoot", DateTime.Now.ToString(DateTimeFormatString), prefix));
                lock (((ICollection)_victimWithInit).SyncRoot)
                {
                    WriteToLog(string.Format("{0} {1} have locked ((ICollection)_victimWithInit).SyncRoot successfully", DateTime.Now.ToString(DateTimeFormatString), prefix));

                    if (prefix == thread1Name)
                    {
                        WriteToLog(string.Format("{0} {1} before mreBeforeCheckII.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                        mreBeforeCheckII.WaitOne();
                        WriteToLog(string.Format("{0} {1} after mreBeforeCheckII.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                    }

                    if (!
                        #if USE_TRY_GET_VALUE
                            _victimWithInit.TryGetValue(nodeNo, out nodeValue)
                        #else
                            _victimWithInit.ContainsKey(nodeNo)
                        #endif
                    )
                    {
                        WriteToLog(string.Format("{0} {1} before trying to add node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

                        var msg = string.Format("{0} {1} node[{2}] has been added", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo);

                        if (prefix == thread1Name)
                        {
                            WriteToLog(string.Format("{0} {1} before mreBeforeAdd.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                            mreBeforeAdd.WaitOne();
                            WriteToLog(string.Format("{0} {1} after mreBeforeAdd.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                        }

                        _victimWithInit.Add(nodeNo,
                            #if TEST_STRING
                                msg
                            #else
                                new Victim(msg)
                            #endif
                        );

                        WriteToLog(msg);

                        if (prefix == thread1Name)
                        {
                            WriteToLog(string.Format("{0} {1} before mreAfterAdd.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                            mreAfterAdd.WaitOne();
                            WriteToLog(string.Format("{0} {1} after mreAfterAdd.WaitOne()", DateTime.Now.ToString(DateTimeFormatString), prefix));
                        }
                    }
                    WriteToLog(string.Format("{0} {1} will unlock ((ICollection)_victimWithInit).SyncRoot", DateTime.Now.ToString(DateTimeFormatString), prefix));
                }
                WriteToLog(string.Format("{0} {1} have unlocked ((ICollection)_victimWithInit).SyncRoot successfully", DateTime.Now.ToString(DateTimeFormatString), prefix));
            }

            WriteToLog(string.Format("{0} {1} before trying to lock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
            lock (_victimWithInit[nodeNo])
            {
                WriteToLog(string.Format("{0} {1} have locked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

                _victimWithInit[nodeNo]
                    #if !TEST_STRING
                        .FString
                    #endif
                += string.Format(" {0} {1} have changed node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo);

                WriteToLog(string.Format("{0} {1} will unlock node[{2}]", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));
            }
            WriteToLog(string.Format("{0} {1} have unlocked node[{2}] successfully", DateTime.Now.ToString(DateTimeFormatString), prefix, nodeNo));

            WriteToLog(string.Format("{0} {1} finished", DateTime.Now.ToString(DateTimeFormatString), prefix));
        }
    }

    class ThreadParam
    {
        public int NodeNo { get; set; }
        public int MillisecondsTimeout { get; set; }
    }

    #if !TEST_STRING
        class Victim
        {
            public string FString { get; set; }

            public Victim(string fString = "")
            {
                FString = fString;
            }

            public override string ToString()
            {
                return string.Format("{{FString: \"{0}\"}}", FString);
            }
        }
    #endif
}
