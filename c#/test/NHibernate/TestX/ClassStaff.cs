using System;

namespace TestX
{
	public class ClassStaff
	{
		int _ID;
		string _Name;
		DateTime _BirthDate;

		public virtual int ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}

		public virtual string Name
		{
			get{ return _Name; }
			set{ _Name = value; }
		}

		public virtual DateTime BirthDate
		{
			get{ return _BirthDate; }
			set{ _BirthDate = value; }
		}
	}
}
