using System;

namespace TestDataflowSimple
{
    public class Error
    {
        public Exception Exception { get; set; }

        public Error(Exception exception)
        {
            Exception = exception;
        }

        public Error(Error obj) : this(obj.Exception)
        {}
    }
}
