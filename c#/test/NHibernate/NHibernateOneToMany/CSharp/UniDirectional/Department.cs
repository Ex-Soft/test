using System;
using System.Collections;

namespace UniDirectional
{
	public class UDepartment
	{
		private int id;
		private string name;
		private IDictionary employeeList;
		
		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}
		
		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}
		
		public virtual IDictionary EmployeeList 
		{
			get { return this.employeeList; }
			set { this.employeeList = value; }
		}
	}
}
