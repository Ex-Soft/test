using System;

namespace MultiTypesWinFormsApp.Consumer
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
