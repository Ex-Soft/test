using System;

namespace CityOnFire
{
	public delegate void FireEventHandler(object sender, FireEventArgs e);

	public class NewTown
	{
		//свойства
		private int build, BuildingNumber; //дом и число домов в городе
		private int day, days; //Текущий день года

		//городские службы
		private Police policeman;
		private Ambulance ambulanceman;
		private FireDetect fireman;

		//события в городе
		public event FireEventHandler Fire;

		//моделирование случайных событий
		private Random rnd=new Random();

		//вероятность пожара в доме в текущий день: p= m/n
		private int m=3, n=10000;

		//конструктор класса
		public NewTown(int TownSize, int Days)
		{
			BuildingNumber=rnd.Next(TownSize);
			days=Days;
			policeman=new Police(this);
			ambulanceman=new Ambulance(this);
			fireman=new FireDetect(this);
			policeman.On();
			ambulanceman.On();
			fireman.On();
		}

		public void LifeOurTown()
		{
			for(day=1; day<=days; day++)
				for(build=1; build<=BuildingNumber; build++)
				{
					if(rnd.Next(n)<=m) //загорелся дом
					{
						//аргументы события
						FireEventArgs e = new FireEventArgs(build, day, true);
						OnFire(e);
						if(e.Permit)
							Console.WriteLine("Пожар потушен! Ситуация нормализована.");
						else
							Console.WriteLine("Пожар продолжается. Требуются дополнительные средства!");
					}
				}
		}

		protected virtual void OnFire(FireEventArgs e)
		{
			if(Fire!=null)
				Fire(this, e);
		}
	}

	public abstract class Receiver
	{
		private NewTown
			town;

		public Receiver(NewTown town)
		{
			this.town=town;
		}

		public void On()
		{
			town.Fire+=new FireEventHandler(It_is_Fire);
		}

		public void Off()
		{
			town.Fire-=new FireEventHandler(It_is_Fire);
			town=null;
		}

		public abstract void It_is_Fire(object sender, FireEventArgs e);
	}

	public class Police:Receiver
	{
		public Police(NewTown town):base(town)
		{}

		public override void It_is_Fire(object sender, FireEventArgs e)
		{
			Console.WriteLine("Пожар в доме {0}. День {1}-й. Милиция ищет виновных!",e.Build,e.Day);
			e.Permit&=true;
		}
	}

	public class FireDetect:Receiver
	{
		public FireDetect(NewTown town):base(town)
		{}

		public override void It_is_Fire(object sender, FireEventArgs e)
		{
			Console.WriteLine("Пожар в доме {0}. День {1}-й. Пожарные тушат пожар!",e.Build,e.Day);
			Random rnd=new Random(e.Build);
			if(rnd.Next(10)>5)
				e.Permit&=false;
			else
				e.Permit&=true;
		}
	}

	public class Ambulance:Receiver
	{
		public Ambulance(NewTown town):base(town)
		{}

		public override void It_is_Fire(object sender, FireEventArgs e)
		{
			Console.WriteLine("Пожар в доме {0}. День {1}-й. Скорая спасает пострадавших!",e.Build,e.Day);
			e.Permit&=true;
		}
	}

	public class FireEventArgs:EventArgs
	{
		private int build;
		private int day;
		private bool permit;

		public int Build
		{
			get{return(build);}
			//set{build=value;}
		}

		public int Day
		{
			get{return(day);}
			//set{day=value;}
		}

		public bool Permit
		{
			get{return(permit);}
			set{permit = value;}
		}

		public FireEventArgs(int build, int day, bool permit)
		{
			this.build=build;
			this.day=day;
			this.permit=permit;
		}
	}

	class MainClass
	{
		[STAThread]
		static void Main()
		{
			NewTown sometown = new NewTown(100,100);
			sometown.LifeOurTown();
			Console.ReadLine();
		}
	}
}
