using System;

namespace KafkaWinFormsApp
{
    public class Error
    {
        public Exception Exception { get; set; }

        public Error(Exception exception)
        {
            Exception = exception;
        }
    }
}
