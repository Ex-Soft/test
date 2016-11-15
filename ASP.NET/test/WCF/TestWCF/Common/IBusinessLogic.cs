namespace TestWCF
{
    public interface IBusinessLogic
    {
        string DoSmth(string inp);
        IDataContract DoDmthWithClass(IDataContract dataContract);
    }
}
