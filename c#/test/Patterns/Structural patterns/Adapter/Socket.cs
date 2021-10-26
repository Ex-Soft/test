using static System.Console;

namespace Adapter
{
    public class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "220V";
        }
    }

    public interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    public class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "220V";
        }
    }

    public class NewElectricitySystemAdapter : INewElectricitySystem
    {
        private readonly OldElectricitySystem _adaptee;

        public NewElectricitySystemAdapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            return _adaptee.MatchThinSocket();
        }
    }
    public class ElectricityConsumer
    {
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    public class Socket
    {
        public static void Run()
        {
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new NewElectricitySystemAdapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);
        }
    }
}
