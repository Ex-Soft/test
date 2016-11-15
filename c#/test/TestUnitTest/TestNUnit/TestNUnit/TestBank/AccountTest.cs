using Bank;
using NUnit.Framework;

namespace TestBank
{
    [TestFixture]
    public class AccountTest
    {
        private Account _source;
        private Account _destination;

        [SetUp]
        public void Init()
        {
            _source = new Account();
            _source.Deposit(200m);

            _destination = new Account();
            _destination.Deposit(150m);
        }

        [Test]
        public void TransferFunds()
        {
            _source.TransferFunds(_destination, 100m);

            Assert.AreEqual(250m, _destination.Balance);
            Assert.AreEqual(100m, _source.Balance);
        }

        [Test]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void TransferWithInsufficientFunds()
        {
            _source.TransferFunds(_destination, 300m);
        }

        [Test]
        [Ignore("Decide how to implement transaction management")]
        public void TransferWithInsufficientFundsAtomicity()
        {
            try
            {
                _source.TransferFunds(_destination, 300m);
            }
            catch (InsufficientFundsException expected)
            {
            }

            Assert.AreEqual(200m, _source.Balance);
            Assert.AreEqual(150m, _destination.Balance);
        }
    }
}
