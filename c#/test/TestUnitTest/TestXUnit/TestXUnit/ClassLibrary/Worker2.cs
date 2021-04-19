namespace ClassLibrary
{
    public interface IWorker2
    {
        string Double(string str);
    }

    public class Worker2 : IWorker2
    {
        public string Double(string str)
        {
            return str != null ? str + str : null;
        }
    }
}
