using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public class ProcessedMessage
    {
        public ISpecificRecord Message { get; set; }
        public Error Error { get; set; }

        public ProcessedMessage(ISpecificRecord message = default, Error error = null)
        {
            Message = message;
            Error = error;
        }
    }
}
