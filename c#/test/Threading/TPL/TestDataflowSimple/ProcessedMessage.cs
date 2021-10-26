namespace TestDataflowSimple
{
    public class ProcessedMessage<T>
    {
        public T Message { get; set; }
        public Error Error { get; set; }

        public ProcessedMessage(T message = default, Error error = null)
        {
            Message = message;
            Error = error;
        }

        public ProcessedMessage(ProcessedMessage<T> obj) : this(obj.Message, obj.Error)
        {}
    }
}
