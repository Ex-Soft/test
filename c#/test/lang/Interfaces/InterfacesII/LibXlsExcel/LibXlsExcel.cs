using System;

namespace LibXlsExcel
{
	public class LibXlsExcel:ILibXls.ILibXls
	{
		object
			FRange;

		public object Range
		{
			set
			{
				if(FRange!=value)
					FRange=value;
			}
			get
			{
				return(FRange);
			}
		}

		public LibXlsExcel():this(null)
		{}

		public LibXlsExcel(object aRange)
		{
			Range=aRange;
		}

		public void WorkbookSave()
		{
			Console.WriteLine("LibXlsExcel.WorkbookSave()");
		}
	}
}
