namespace Quickstart
{
	public interface IFoo
	{
		bool DoSomething(string str);
		bool DoSomething2(string str);
		string DoSomething3(string str);
		string DoSomethingStringy(string str);
		bool TryParse(string strIn, out string strOut);
		bool Submit(ref Bar bar);
		int GetCount();
		int GetCountThing();
		bool Add(int i);
		bool Add2(int i);
	}
}
