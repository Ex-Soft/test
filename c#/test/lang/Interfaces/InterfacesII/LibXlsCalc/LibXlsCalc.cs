using System;

namespace LibXlsCalc
{
	public class LibXlsCalc:ILibXls.ILibXls
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

		public LibXlsCalc():this(null)
		{}

		public LibXlsCalc(object aRange)
		{
			Range=aRange;
		}

		public void WorkbookSave()
		{
			Console.WriteLine("LibXlsCalc.WorkbookSave()");
		}
	}
}
