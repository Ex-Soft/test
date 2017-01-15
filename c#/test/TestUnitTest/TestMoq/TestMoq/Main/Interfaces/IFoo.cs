using Main.Classes;

namespace Main.Interfaces
{
	public interface IFoo
	{
		bool DoSomething(string inpString);
		string DoSomethingStringy(string inpString);
		bool TryParse(string inpString, out string result);
		bool Submit(ref Bar bar);
		int GetCount();
		int GetCountThing();
		bool Add(int inpInt);
	}
}
