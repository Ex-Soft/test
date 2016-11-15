using System.Web.Services;
using ExtJSBigApp.Classes;

namespace ExtJSBigApp.services
{
	/// <summary>
	/// Summary description for StaffService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	[System.Web.Script.Services.ScriptService]
	public class StaffService : System.Web.Services.WebService
	{
		[WebMethod]
		public PagedStaffList GetStaffList(int start, int limit)
		{
			return new PagedStaffList()
			{
				Staffs = Staffs.GetPagedStaffList(start, limit),
				Total = Staffs.GetPagedStaffListCount()
			};
		}
	}
}
