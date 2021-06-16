using System;

namespace Adapter
{
    public class LogEntry
    {}

    public interface ILogSaver
    {
        void Save(LogEntry logEntry);
    }

    public class SqlServerLogSaverAdapter : ILogSaver
    {
        private readonly SqlServerLogSaver _sqlServerLogSaver = new SqlServerLogSaver();

        public void Save(LogEntry logEntry)
        {
            switch (logEntry)
            {
                case SimpleLogEntry simpleLogEntry:
                    _sqlServerLogSaver.Save(simpleLogEntry.DateTime, simpleLogEntry.Message);
                    break;
                case ExceptionLogEntry exceptionLogEntry:
                    _sqlServerLogSaver.SaveException(exceptionLogEntry.DateTime, exceptionLogEntry.Message, exceptionLogEntry.Exception);
                    break;
            }
        }
    }
    public class ElasticsearchLogSaverAdapter : ILogSaver
    {
        private readonly ElasticsearchLogSaver _elasticsearchLogSaver = new ElasticsearchLogSaver();

        public void Save(LogEntry logEntry)
        {
            switch (logEntry)
            {
                case SimpleLogEntry simpleLogEntry:
                    _elasticsearchLogSaver.Save(simpleLogEntry);
                    break;
                case ExceptionLogEntry exceptionLogEntry:
                    _elasticsearchLogSaver.SaveException(exceptionLogEntry);
                    break;
            }
        }
    }

    public class SqlServerLogSaver
    {
        public void Save(DateTime dateTime, string message)
        {}
        public void SaveException(DateTime dateTime, string message, Exception exception)
        {}
    }

    public class SimpleLogEntry : LogEntry
    {
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }

    public class ExceptionLogEntry : LogEntry
    {
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }

    public class ElasticsearchLogSaver
    {
        public void Save(SimpleLogEntry simpleLogEntry)
        {}

        public void SaveException(ExceptionLogEntry exceptionLogEntry)
        {}
    }

    public class LogSaver
    {
        public static void Run()
        {
            ILogSaver logSaver = new SqlServerLogSaverAdapter();
            logSaver.Save(new SimpleLogEntry { DateTime = DateTime.Now, Message = "Message" });
            logSaver.Save(new ExceptionLogEntry { DateTime = DateTime.Now, Message = "Message", Exception = new Exception("blah-blah-blah")});

            logSaver = new ElasticsearchLogSaverAdapter();
            logSaver.Save(new SimpleLogEntry { DateTime = DateTime.Now, Message = "Message" });
            logSaver.Save(new ExceptionLogEntry { DateTime = DateTime.Now, Message = "Message", Exception = new Exception("blah-blah-blah") });
        }
    }
}
