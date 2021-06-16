using System;

namespace TestDataflowWinFormsApp
{
    public class PreparedMessage
    {
        public OriginalMessage OriginalMessage { get; set; }
        public Func<OriginalMessage, TransformedMessage> Func { get; set; }

        public PreparedMessage(OriginalMessage originalMessage = null, Func<OriginalMessage, TransformedMessage> func = null)
        {
            OriginalMessage = originalMessage;
            Func = func;
        }

        public PreparedMessage(PreparedMessage obj) : this(obj.OriginalMessage, obj.Func)
        {}

        public override string ToString()
        {
            return $"{{OriginalMessage:{(OriginalMessage != null ? OriginalMessage : "null")}, Func:{(Func != null ? Func : "null")}}}";
        }
    }
}
