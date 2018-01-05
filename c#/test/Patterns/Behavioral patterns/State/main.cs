using System;

namespace State
{
    public interface IAutomatState
    {
        string GotApplication();
        string CheckApplication();
        string RentApartment();
        string DispenseKeys();
    }

    public interface IAutomat
    {
        void GotApplication();
        void CheckApplication();
        void RentApartment();

        void SetState(IAutomatState s);
        IAutomatState GetWaitingState();
        IAutomatState GetGotApplicationState();
        IAutomatState GetApartmentRentedState();
        IAutomatState GetFullyRentedState();

        int Count { get; set; }
    }

    public class Automat : IAutomat
    {
        private readonly IAutomatState _waitingState;
        private readonly IAutomatState _gotApplicationState;
        private readonly IAutomatState _apartmentRentedState;
        private readonly IAutomatState _fullyRentedState;
        private IAutomatState _state;
        private int _count;

        public Automat(int n)
        {
            _count = n;
            _waitingState = new WaitingState(this);
            _gotApplicationState = new GotApplicationState(this);
            _apartmentRentedState = new ApartmentRentedState(this);
            _fullyRentedState = new FullyRentedState(this);
            _state = _waitingState;
        }

        public void GotApplication()
        {
            Console.WriteLine(_state.GotApplication());
        }

        public void CheckApplication()
        {
            Console.WriteLine(_state.CheckApplication());
        }

        public void RentApartment()
        {
            Console.WriteLine(_state.RentApartment());
            Console.WriteLine(_state.DispenseKeys());
        }

        public void SetState(IAutomatState s) { _state = s; }

        public IAutomatState GetWaitingState() { return _waitingState; }

        public IAutomatState GetGotApplicationState() { return _gotApplicationState; }

        public IAutomatState GetApartmentRentedState() { return _apartmentRentedState; }

        public IAutomatState GetFullyRentedState() { return _fullyRentedState; }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
    public class WaitingState : IAutomatState
    {
        private Automat _automat;

        public WaitingState(Automat automat)
        {
            _automat = automat;
        }

        public string GotApplication()
        {
            _automat.SetState(_automat.GetGotApplicationState());
            return "Thanks for the application.";
        }

        public string CheckApplication() { return "You have to submit an application."; }

        public string RentApartment() { return "You have to submit an application."; }

        public string DispenseKeys() { return "You have to submit an application."; }
    }

    public class GotApplicationState : IAutomatState
    {
        private readonly Automat _automat;
        private readonly Random _random;

        public GotApplicationState(Automat automat)
        {
            _automat = automat;
            _random = new Random(DateTime.Now.Millisecond);
        }

        public string GotApplication() { return "We already got your application."; }

        public string CheckApplication()
        {
            var yesNo = _random.Next() % 10;

            if (yesNo > 4 && _automat.Count > 0)
            {
                _automat.SetState(_automat.GetApartmentRentedState());
                return "Congratulations, you were approved.";
            }
            else
            {
                _automat.SetState(_automat.GetWaitingState());
                return "Sorry, you were not approved.";
            }
        }

        public string RentApartment() { return "You must have your application checked."; }

        public string DispenseKeys() { return "You must have your application checked."; }
    }

    public class ApartmentRentedState : IAutomatState
    {
        private readonly Automat _automat;

        public ApartmentRentedState(Automat automat)
        {
            _automat = automat;
        }

        public string GotApplication() { return "Hang on, we'ra renting you an apartmeny."; }

        public string CheckApplication() { return "Hang on, we'ra renting you an apartmeny."; }

        public string RentApartment()
        {
            _automat.Count = _automat.Count - 1;
            return "Renting you an apartment....";
        }

        public string DispenseKeys()
        {
            if (_automat.Count <= 0)
                _automat.SetState(_automat.GetFullyRentedState());
            else
                _automat.SetState(_automat.GetWaitingState());
            return "Here are your keys!";
        }
    }

    public class FullyRentedState : IAutomatState
    {
        private Automat _automat;

        public FullyRentedState(Automat automat)
        {
            _automat = automat;
        }

        public string GotApplication() { return "Sorry, we're fully rented."; }

        public string CheckApplication() { return "Sorry, we're fully rented."; }

        public string RentApartment() { return "Sorry, we're fully rented."; }

        public string DispenseKeys() { return "Sorry, we're fully rented."; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var automat = new Automat(9);

            automat.GotApplication();
            automat.CheckApplication();
            automat.RentApartment();

            Console.ReadLine();
        }
    }
}
