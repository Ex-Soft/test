using System;
using System.Collections.Generic;

namespace TestClassWithList
{
	class Obj
	{
		long
			_Id,
			_ParentId;

		string
			_Value;

		public Obj() : this(long.MinValue, long.MinValue, string.Empty)
		{}

		public Obj(Obj obj) : this(obj.Id, obj.ParentId, obj.Value)
		{}

		public Obj(long aId, long aParentId, string aValue)
		{
			_Id = aId;
			_ParentId = aParentId;
			_Value = aValue;
		}

		public long Id
		{
			get
			{
				return _Id;
			}
			set
			{
				if (_Id != value)
					_Id = value;
			}
		}

		public long ParentId
		{
			get
			{
				return _ParentId;
			}
			set
			{
				if (_ParentId != value)
					_ParentId = value;
			}
		}

		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (_Value != value)
					_Value = value;
			}
		}

		public string ToString()
		{
			return string.Format("{{ Id: {0}, ParentId: {1}, Value: {2} }}", Id, ParentId, (Value==null ? "null" : (Value==string.Empty ? "string.Empty" : "\""+Value+"\"")));
		}
	}

	class Container
	{
		long
			_Id;

		List<Obj>
			_Objs;

		public long Id
		{
			get
			{
				return _Id;
			}
			set
			{
				if (_Id != value)
					_Id = value;
			}
		}

		public List<Obj> Objs
		{
			get
			{
				return new List<Obj>(_Objs);
			}
			set
			{
				if(_Objs==null)
					_Objs = new List<Obj>();

				if (value != null)
				{
					_Objs.Clear();
					value.ForEach((item) => { ObjAdd(item); });
				}
				else
				{
					if (_Objs.Count != 0)
						_Objs.Clear();
				}
			}
		}

		public Container(long aId, List<Obj> aObjs)
		{
			_Id = aId;
			Objs = aObjs;
		}

		public void ObjAdd(Obj o)
		{
			_Objs.Add(new Obj(long.MinValue, _Id, o.Value));
		}

		public string ObjsToString()
		{
			string
				OutputString = string.Empty;

			_Objs.ForEach((item) => { if (OutputString != string.Empty) OutputString += ", "; OutputString += item.ToString(); });

			return OutputString;
		}

		public string ToString()
		{
			return string.Format("{{ Id: {0}, Objs: [{1}] }}", Id, ObjsToString());
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Obj>
				L1 = new List<Obj>() { new Obj(1, 1, "1st"), new Obj(2, 1, "2nd"), new Obj(3, 1, "3rd") };

			Container
				c1 = new Container(long.MinValue, null),
				c2 = new Container(33, L1);

			Console.WriteLine(c1.ToString());
			Console.WriteLine(c2.ToString());

			Obj
				tmpObj=new Obj(11,11,"11");

			c1.Objs.Add(tmpObj);
			c1.ObjAdd(tmpObj);
			Console.WriteLine(c1.ToString());
			tmpObj.Value = "13";
			Console.WriteLine(c1.ToString());
			c1.Objs[0].Value = "333";
			Console.WriteLine(c1.ToString());
		}
	}
}
