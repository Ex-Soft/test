using System;

namespace TestIV
{
	public class ClassStaff
	{
		int
			_ID;

		string
			_Name;

		decimal
			_Salary,
			_SalaryAdd;

		public virtual int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				if (_ID != value)
					_ID = value;
			}
		}

		public virtual string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if (_Name != value)
					_Name = value;
			}
		}

		public virtual decimal Salary
		{
			get
			{
				return _Salary;
			}
			set
			{
				if (_Salary != value)
					_Salary = value;
			}
		}

		public virtual decimal SalaryAdd
		{
			get
			{
				return _SalaryAdd;
			}
			set
			{
				if (_SalaryAdd != value)
					_SalaryAdd = value;
			}
		}
	}
}
