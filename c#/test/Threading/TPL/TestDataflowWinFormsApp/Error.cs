using System;

namespace TestDataflowWinFormsApp
{
    public class Error
    {
        public Exception Exception { get; set; }

        public Error(Exception exception = null)
        {
            Exception = exception;
        }

        public Error(Error obj) : this(obj.Exception)
        {}
    }
}
