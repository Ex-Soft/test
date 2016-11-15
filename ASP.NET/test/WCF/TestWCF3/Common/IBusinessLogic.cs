namespace TestWCF
{
    public interface IBusinessLogic
    {
        string DoSmth(string inp);
        IDataContract DoSmthWithClass(IDataContract dataContract);
    }
}
