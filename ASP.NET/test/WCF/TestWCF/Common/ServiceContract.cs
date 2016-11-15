namespace TestWCF
{
    public class ServiceContract : IServiceContract
    {
        IBusinessLogic
            _businessLogic;

        public ServiceContract(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public string DoSmth(string inp)
        {
            return _businessLogic.DoSmth(inp);
        }

        public DataContract DoDmthWithClass(DataContract dataContract)
        {
            return (DataContract)_businessLogic.DoDmthWithClass(dataContract);
        }
    }
}
