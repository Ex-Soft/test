using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestClassWithListRO
{
	#region Class Obj
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
			return string.Format("{{ Id: {0}, ParentId: {1}, Value: {2} }}", Id, ParentId, (Value == null ? "null" : (Value == string.Empty ? "string.Empty" : "\"" + Value + "\"")));
		}
	}
	#endregion

	class Container
	{
		long
			_Id;

		List<Obj>
			_Objs;

		ReadOnlyCollection<Obj>
			_ObjsRO;

		public Container() : this(long.MinValue, null)
		{}

		public Container(Container obj) : this(obj.Id, obj.ObjsRO)
		{}

		public Container(long aId, IList<Obj> aObjs)
		{
			_Id = aId;
			_Objs = new List<Obj>();
			_ObjsRO = new ReadOnlyCollection<Obj>(_Objs);
			if (aObjs != null)
				ObjAdd(aObjs);
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

		public ReadOnlyCollection<Obj> ObjsRO
		{
			get
			{
				return _ObjsRO;
			}
		}

		public void ObjAdd(IList<Obj> list)
		{
			if (_Objs.Count != 0)
				_Objs.Clear();

			if (list == null)
				return;

			for (int i = 0; i < list.Count; ++i)
				ObjAdd(list[i]);
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
			Obj
				//tmpObj = new Obj(1, 1, null);
				//tmpObj = new Obj(1, 1, string.Empty);
				tmpObj = new Obj(1, 1, "1st");

			Console.WriteLine(tmpObj.ToString());

			Container
				c1 = new Container();

			Console.WriteLine("c1:");
			Console.WriteLine(c1.ToString());
			Console.WriteLine();

			List<Obj>
				L1 = new List<Obj>() { new Obj(1, 1, "1st"), new Obj(2, 1, "2nd"), new Obj(3, 1, "3rd") };

			c1.Id = 1;
			c1.ObjAdd(L1);
			for (int i = 0; i < c1.ObjsRO.Count; ++i)
				c1.ObjsRO[i].Id = i + 1;
			Console.WriteLine("c1:");
			Console.WriteLine(c1.ToString());
			Console.WriteLine();

			Container
				c2 = new Container(c1);

			Console.WriteLine("c2:");
			Console.WriteLine(c2.ToString());
			Console.WriteLine();

			Container
				c3 = new Container(1, L1);

			Console.WriteLine("c3:");
			Console.WriteLine(c3.ToString());
			Console.WriteLine();
		}
	}
}
