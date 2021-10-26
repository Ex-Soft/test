namespace TestDataflowWinFormsApp
{
    public class TransformedMessage
    {
        public OriginalMessage OriginalMessage { get; set; }
        public Error Error { get; set; }

        public TransformedMessage(OriginalMessage originalMessage = null, Error error = null)
        {
            OriginalMessage = originalMessage;
            Error = error;
        }

        public TransformedMessage(TransformedMessage obj) : this(obj.OriginalMessage, obj.Error)
        {}

        public override string ToString()
        {
            return $"{{OriginalMessage:{(OriginalMessage != null ? OriginalMessage : "null")}, Error:{(Error != null ? Error : "null")}}}";
        }
    }
}
