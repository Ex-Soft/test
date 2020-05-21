using System.Threading;

using static System.Console;

namespace TestAutoResetEvent2
{
    class PingPongWriter
    {
        readonly int _count;

        readonly AutoResetEvent
            _pingAutoResetEvent = new AutoResetEvent(true),
            _pongAutoResetEvent = new AutoResetEvent(false);

        public PingPongWriter(int count)
        {
            _count = count;
        }

        public void WritePing()
        {
            for (var i = 0; i < _count; ++i)
            {
                _pingAutoResetEvent.WaitOne();
                WriteLine("Ping");
                _pingAutoResetEvent.Reset();
                _pongAutoResetEvent.Set();
            }
        }

        public void WritePong()
        {
            for (var i = 0; i < _count; ++i)
            {
                _pongAutoResetEvent.WaitOne();
                WriteLine("Pong");
                _pongAutoResetEvent.Reset();
                _pingAutoResetEvent.Set();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var writer = new PingPongWriter(5);

            Thread
                threadPing = new Thread(writer.WritePing),
                threadPong = new Thread(writer.WritePong);

            threadPing.Start();
            Thread.Sleep(1000);
            threadPong.Start();
            Thread.Sleep(2000);

            threadPing.Join();
            threadPong.Join();
        }
    }
}
