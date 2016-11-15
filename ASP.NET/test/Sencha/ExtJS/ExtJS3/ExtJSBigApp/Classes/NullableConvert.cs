using System;

namespace ExtJSBigApp.Classes
{
	public class NullableConvert
	{
		public static decimal? ToDecimal(object o)
		{
			return !Convert.IsDBNull(o) ? Convert.ToDecimal(o) : (decimal?)null;
		}

		public static DateTime? ToDateTime(object o)
		{
			return !Convert.IsDBNull(o) ? Convert.ToDateTime(o) : (DateTime?)null;
		}

		public static Int32? ToInt32(object o)
		{
			return !Convert.IsDBNull(o) ? Convert.ToInt32(o) : (Int32?)null;
		}

		public static Int64? ToInt64(object o)
		{
			return !Convert.IsDBNull(o) ? Convert.ToInt64(o) : (Int64?)null;
		}
	}
}
