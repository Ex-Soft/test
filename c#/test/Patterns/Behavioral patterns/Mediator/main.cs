using System;

namespace Mediator
{
	class Mediator
	{
		DataProviderColleague
			dataProvider;

		DataConsumerColleague
			dataConsumer;

		public void IntroduceColleagues(DataProviderColleague c1, DataConsumerColleague c2)
		{
			dataProvider = c1;
			dataConsumer = c2;
		}

		public void DataChanged()
		{
			int
				i = dataProvider.MyData;

			dataConsumer.NewValue(i);
		}
	}

	class DataConsumerColleague
	{
		public void NewValue(int i)
		{
			Console.WriteLine("New value {0}", i);
		}
	}

	class DataProviderColleague
	{
		Mediator
			mediator;

		int
			iMyData = 0;

		public int MyData
		{
			get
			{
				return iMyData;
			}
			set
			{
				iMyData = value;
			}
		}

		public DataProviderColleague(Mediator m)
		{
			mediator = m;
		}

		public void ChangeData()
		{
			iMyData = 403;

			if (mediator != null)
				mediator.DataChanged();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Mediator
				m = new Mediator();

			DataProviderColleague
				c1 = new DataProviderColleague(m);

			DataConsumerColleague
				c2 = new DataConsumerColleague();

			m.IntroduceColleagues(c1, c2);

			c1.ChangeData();
		}
	}
}
