using System.Collections.Generic;

namespace SimpleDataBinding
{
    class Airplane
    {
        public Airplane(string model, int fuelKg)
        {
            _id = ++lastID; Model = model; _fuelKg = fuelKg;
        }
        private static int lastID = 0;
        public int _id;
        public int ID { get { return _id; } }
        public int _fuelKg;
        public int FuelLeftKg { get { return _fuelKg; } set { _fuelKg = value; } }
        public string _model;
        public string Model { get { return _model; } set { _model = value; } }
        public List<Passenger> _passengers = new List<Passenger>();
        public List<Passenger> Passengers { get { return _passengers; } }
    }
}
