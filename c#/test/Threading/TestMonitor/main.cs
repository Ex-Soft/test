using System.Threading;

using static System.Console;

namespace TestMonitor
{
    class PingPongWriter
    {
        readonly int _count;
        bool _ping = true;

        public PingPongWriter(int count)
        {
            _count = count;
        }

        public void WritePing()
        {
            for (var i = 0; i < _count; ++i)
            {
                lock (this)
                {
                    if (!_ping)
                    {
                        Monitor.Wait(this);
                    }

                    WriteLine("Ping");
                    _ping = false;
                    Monitor.Pulse(this);
                }
            }
        }

        public void WritePong()
        {
            for (var i = 0; i < _count; ++i)
            {
                lock (this)
                {
                    if (_ping)
                    {
                        Monitor.Wait(this);
                    }

                    WriteLine("Pong");
                    _ping = true;
                    Monitor.Pulse(this);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var writer = new PingPongWriter(3);

            Thread
                pingThread = new Thread(new ThreadStart(writer.WritePing)),
                pongThread = new Thread(new ThreadStart(writer.WritePong));

            pingThread.Start();
            pongThread.Start();

            pingThread.Join();
            pongThread.Join();
        }
    }
}
