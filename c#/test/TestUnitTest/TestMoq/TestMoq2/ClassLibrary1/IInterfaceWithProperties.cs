using System.Threading;

namespace ClassLibrary1
{
    public interface IInterfaceWithProperties
    {
        Bar Bar { get; set; }
        string Name { get; set; }
        int Value { get; set; }
    }
}
