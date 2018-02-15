// http://hamidmosalla.com/2017/08/03/moq-working-with-setupget-verifyget-setupset-verifyset-setupproperty/
// http://www.blackwasp.co.uk/MoqPropertyExpectations.aspx
// http://www.blackwasp.co.uk/MoqPropertyExpectations_2.aspx

namespace ClassLibrary2
{
    public interface IPropertyManager
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        void MutateFirstName(string name);
    }

    public class PropertyManager : IPropertyManager
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void MutateFirstName(string name)
        {
            this.FirstName = name;
        }
    }

    public class PropertyManagerConsumer
    {
        private readonly IPropertyManager _propertyManager;

        public PropertyManagerConsumer(IPropertyManager propertyManager)
        {
            _propertyManager = propertyManager;
        }

        public void ChangeName(string name)
        {
            _propertyManager.FirstName = name;
        }

        public string GetName()
        {
            return _propertyManager.FirstName;
        }

        public void ChangeRemoteName(string name)
        {
            _propertyManager.MutateFirstName(name);
        }
    }
}
