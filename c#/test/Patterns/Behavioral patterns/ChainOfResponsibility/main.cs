using System;

namespace ChainOfResponsibility
{
    #region Logger

    [Flags]
    public enum LogLevel
    {
        None = 0,                 //        0
        Info = 1,                 //        1
        Debug = 2,                //       10
        Warning = 4,              //      100
        Error = 8,                //     1000
        FunctionalMessage = 16,   //    10000
        FunctionalError = 32,     //   100000
        All = 63                  //   111111
    }

    #endregion

    class Program
    {
        #region GoF

        /// <summary>
        /// The 'Handler' abstract class
        /// </summary>
        abstract class Handler
        {
            protected Handler successor;

            public void SetSuccessor(Handler successor)
            {
                this.successor = successor;
            }

            public abstract void HandleRequest(int request);
        }

        /// <summary>
        /// The 'ConcreteHandler1' class
        /// </summary>
        class ConcreteHandler1 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 0 && request < 10)
                {
                    Console.WriteLine("{0} handled request {1}",
                        this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        /// <summary>
        /// The 'ConcreteHandler2' class
        /// </summary>
        class ConcreteHandler2 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 10 && request < 20)
                {
                    Console.WriteLine("{0} handled request {1}",
                        this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        /// <summary>
        /// The 'ConcreteHandler3' class
        /// </summary>
        class ConcreteHandler3 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 20 && request < 30)
                {
                    Console.WriteLine("{0} handled request {1}",
                        this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        #endregion

        #region Logger

        /// <summary>
        /// Abstract Handler in chain of responsibility pattern.
        /// </summary>
        public abstract class Logger
        {
            protected LogLevel logMask;

            // The next Handler in the chain
            protected Logger next;

            public Logger(LogLevel mask)
            {
                this.logMask = mask;
            }

            /// <summary>
            /// Sets the Next logger to make a list/chain of Handlers.
            /// </summary>
            public Logger SetNext(Logger nextlogger)
            {
                next = nextlogger;
                return nextlogger;
            }

            public void Message(string msg, LogLevel severity)
            {
                if ((severity & logMask) != 0) //True only if all logMask bits are set in severity
                {
                    WriteMessage(msg);
                }
                if (next != null)
                {
                    next.Message(msg, severity);
                }
            }

            abstract protected void WriteMessage(string msg);
        }

        public class ConsoleLogger : Logger
        {
            public ConsoleLogger(LogLevel mask)
                : base(mask)
            { }

            protected override void WriteMessage(string msg)
            {
                Console.WriteLine("Writing to console: " + msg);
            }
        }

        public class EmailLogger : Logger
        {
            public EmailLogger(LogLevel mask)
                : base(mask)
            { }

            protected override void WriteMessage(string msg)
            {
                // Placeholder for mail send logic, usually the email configurations are saved in config file.
                Console.WriteLine("Sending via email: " + msg);
            }
        }

        class FileLogger : Logger
        {
            public FileLogger(LogLevel mask)
                : base(mask)
            { }

            protected override void WriteMessage(string msg)
            {
                // Placeholder for File writing logic
                Console.WriteLine("Writing to Log File: " + msg);
            }
        }

        #endregion

        static void Main(string[] args)
        {
            #region GoF

            // Setup Chain of Responsibility
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }

            #endregion

            #region Logger

            // Build the chain of responsibility
            Logger logger, logger1, logger2;
            logger = new ConsoleLogger(LogLevel.All);
            logger1 = logger.SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError));
            logger2 = logger1.SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));

            // Handled by ConsoleLogger since the console has a loglevel of all
            logger.Message("Entering function ProcessOrder().", LogLevel.Debug);
            logger.Message("Order record retrieved.", LogLevel.Info);

            // Handled by ConsoleLogger and FileLogger since filelogger implements Warning & Error
            logger.Message("Customer Address details missing in Branch DataBase.", LogLevel.Warning);
            logger.Message("Customer Address details missing in Organization DataBase.", LogLevel.Error);

            // Handled by ConsoleLogger and EmailLogger as it implements functional error
            logger.Message("Unable to Process Order ORD1 Dated D1 For Customer C1.", LogLevel.FunctionalError);

            // Handled by ConsoleLogger and EmailLogger
            logger.Message("Order Dispatched.", LogLevel.FunctionalMessage);

            #endregion

            // Wait for user
            Console.ReadKey();
        }
    }
}
