namespace TestWCF
{
    public class BusinessLogic : IBusinessLogic
    {
        public string DoSmth(string inp)
        {
            return "return: " + (string.IsNullOrEmpty(inp) ? "\"" + inp + "\"" : "null");
        }

        public IDataContract DoDmthWithClass(IDataContract dataContract)
        {
            dataContract.StringField += dataContract.StringField;
            return dataContract;
        }
    }
}
