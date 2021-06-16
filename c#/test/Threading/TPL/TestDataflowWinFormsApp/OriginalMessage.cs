namespace TestDataflowWinFormsApp
{
    public class OriginalMessage
    {
        public long Value { get; set; }
        public string Message { get; set; }

        public OriginalMessage(long value = default, string message = null)
        {
            Value = value;
            Message = message;
        }

        public OriginalMessage(OriginalMessage obj) : this(obj.Value, obj.Message)
        {}

        public override string ToString()
        {
            return $"{{Value:{Value}, Message:{(Message != null ? $"\"{Message}\"" : "null")}}}";
        }
    }
}
