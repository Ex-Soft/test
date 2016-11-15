using System;
using System.Data;

namespace ExtJSBigApp.Classes
{
	public class Staff
	{
		public virtual long ID { get; set; }
		public virtual string Name { get; set; }
		public virtual decimal? Salary { get; set; }
		public virtual int? Dep { get; set; }
		public virtual DateTime? BirthDate { get; set; }
		public virtual long? NullField { get; set; }

		public Staff()
		{}

		public Staff(IDataReader r)
		{
			ID = Convert.ToInt64(r["ID"]);
			Name = Convert.ToString(r["Name"]);
			Salary = NullableConvert.ToDecimal(r["Salary"]);
			Dep = NullableConvert.ToInt32(r["Dep"]);
			BirthDate = NullableConvert.ToDateTime(r["BirthDate"]);
			NullField = NullableConvert.ToInt64(r["NullField"]);
		}
	}
}
