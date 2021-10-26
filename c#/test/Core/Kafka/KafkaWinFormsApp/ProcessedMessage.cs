namespace KafkaWinFormsApp
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
    }
}
