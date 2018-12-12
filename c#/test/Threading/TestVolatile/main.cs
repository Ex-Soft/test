//#define TEST_SYSTEM_THREADING_VOLATILE

using System.Diagnostics;
using System.Threading;

namespace TestVolatile
{
    class Program
    {
        #if TEST_SYSTEM_THREADING_VOLATILE
            static int m_flag = 0;
            static int m_value = 0;
        #else
            volatile static int m_flag = 0;
            static int m_value = 0;
        #endif

        static void Main(string[] args)
        {
            Thread
                thread1 = new Thread(Thread1),
                thread2 = new Thread(Thread2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        #if TEST_SYSTEM_THREADING_VOLATILE
            static void Thread1()
            {
                m_value = 5;
                Volatile.Write(ref m_flag, 1); // !!! <- the last !!!
            }

            static void Thread2()
            {
                if (Volatile.Read(ref m_flag) == 1) // !!! <- the first !!!
                    Debug.WriteLine(m_value);
            }
        #else
            static void Thread1()
            {
                m_value = 5;
                m_flag = 1; // !!! <- the last !!!
            }

            static void Thread2()
            {
                if (m_flag == 1) // !!! <- the first !!!
                    Debug.WriteLine(m_value);
            }
        #endif
    }
}
