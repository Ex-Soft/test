using System;

namespace DecoratorII
{
	abstract class Page
	{
		public abstract void Init();
	}

	class MyPage : Page
	{
		public override void Init()
		{
			Console.WriteLine("MyPage.Init()");
		}
	}

	abstract class Decorator : Page
	{
		protected Page
			page;

		public void SetPage(Page aPage)
		{
			page = aPage;
		}

		public override void Init()
		{
			if (page != null)
			{
				page.Init();
			}
		}
	}

	class ConcreteDecoratorA : Decorator
	{
		private string
			addedState;

		public override void Init()
		{
			base.Init();
			addedState = "New State";
			Console.WriteLine("ConcreteDecoratorA.Init()");
		}
	}

	class ConcreteDecoratorB : Decorator
	{
		public override void Init()
		{
			base.Init();
			AddedBehavior();
			Console.WriteLine("ConcreteDecoratorB.Init()");
		}

		void AddedBehavior()
		{
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			MyPage
				mypage = new MyPage();

			ConcreteDecoratorA
				d1 = new ConcreteDecoratorA();

			ConcreteDecoratorB
				d2 = new ConcreteDecoratorB();

			d1.SetPage(mypage);
			d2.SetPage(d1);

			mypage.Init();
			d1.Init();
			d2.Init();
		}
	}
}
