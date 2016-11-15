using System.Collections;

namespace BeatlesClass
{
	class Beatles:IEnumerable
	{
		protected Enumerator enumerator=new Enumerator();

		public IEnumerator GetEnumerator()
		{
			return(enumerator);
		}

		public class Enumerator:IEnumerator
		{
			protected int
				index=-1;

			protected string[]
				names={"John", "Paul", "George", "Ringo"};

			public object Current
			{
				get
				{
					if(index==-1)
						index=0;

					return(names[index]);
				}
			}

			public bool MoveNext()
			{
				if(index<(names.Length-1))
				{
					++index;
					return(true);
				}
				return(false);
			}

			public void Reset()
			{
				index=-1;
			}
		}
	}

	class SmthPerson
	{
		protected int
			FId;

		protected string
			FName;
		
		public int Id
		{
			get
			{
				return(FId);
			}
			set
			{
				if(FId!=value)
					FId=value;
			}
		}

		public string Name
		{
			get
			{
				return(FName);
			}
			set
			{
				if(FName!=value)
					FName=value;
			}
		}

		public SmthPerson():this(int.MinValue,string.Empty)
		{}

		public SmthPerson(SmthPerson obj):this(obj.Id,obj.Name)
		{}

		public SmthPerson(int aId, string aName)
		{
			Id=aId;
			Name=aName;
		}
	}

	class BeatlesII:IEnumerable
	{
		protected Enumerator enumerator=new Enumerator();

		public IEnumerator GetEnumerator()
		{
			return(enumerator);
		}

		public class Enumerator:IEnumerator
		{
			protected int
				index=-1;

			protected SmthPerson[]
				names={new SmthPerson(1,"John"), new SmthPerson(2,"Paul"), new SmthPerson(3,"George"), new SmthPerson(4,"Ringo")};

			public object Current
			{
				get
				{
					if(index==-1)
						index=0;

					return(names[index]);
				}
			}

			public bool MoveNext()
			{
				if(index<(names.Length-1))
				{
					++index;
					return(true);
				}
				return(false);
			}

			public void Reset()
			{
				index=-1;
			}
		}		
	}
}
