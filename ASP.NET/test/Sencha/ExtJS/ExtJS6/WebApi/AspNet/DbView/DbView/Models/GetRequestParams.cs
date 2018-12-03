namespace DbView.Models
{
    public class GetRequestParams
    {
        public ulong _dc { get; set; }
        public bool needMetadata { get; set; }
        public int page { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
    }
}