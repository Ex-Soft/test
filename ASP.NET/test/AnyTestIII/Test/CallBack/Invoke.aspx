<%@ page language="C#" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.SqlClient" %>
<%@ implements interface="System.Web.UI.ICallbackEventHandler" %>

<script language="javascript">
    function UpdateEmployeeViewHandler(result, context) 
    { 
        var o = result.split(",");
        e_ID.innerHTML = o[0]; 
        e_FName.innerHTML = o[1]; 
        e_LName.innerHTML = o[2]; 
        e_Title.innerHTML = o[3]; 
        e_Country.innerHTML = o[4]; 
        e_Notes.innerHTML = o[5]; 
    }
</script>

<script runat="server">
    private const string NorthwindString = "SERVER=(local);DATABASE=northwind;UID=sa;";
    private const string cmdListOfNames = "SELECT employeeid, lastname FROM employees";
    private const string cmdEmployeeDetails = "SELECT firstname, lastname, title, country, notes FROM employees WHERE employeeid={0}";

    public virtual string RaiseCallbackEvent (string eventArgument)
    {
        // Get more info about the specified employee
        int empID = Convert.ToInt32 (eventArgument);
        EmployeeInfo emp = GetEmployeeDetails (empID); 
        
        string[] buf = new string[6];
        buf[0] = emp.ID.ToString ();
        buf[1] = emp.FirstName; 
        buf[2] = emp.LastName; 
        buf[3] = emp.Title; 
        buf[4] = emp.Country; 
        buf[5] = emp.Notes; 
        return String.Join(",", buf);
    }
    
    void Page_Load (Object sender, EventArgs e)
    {
        // Populate the drop-down list
        DataTable dt = GetListofNames();  
        cboEmployees.DataSource = dt;
        cboEmployees.DataTextField = "lastname";
        cboEmployees.DataValueField = "employeeid";
        cboEmployees.DataBind();

        // Prepare the Javascript function to call
        string callbackRef = GetCallbackEventReference(this,
	        "document.all['cboEmployees'].value",
		"UpdateEmployeeViewHandler", "null", "null");
        
        // Bind it to a button
        buttonTrigger.Attributes["onclick"] = String.Format("javascript:{0}", 
            callbackRef);
    }

    public DataTable GetListofNames ()
    {
        // Get the lastnames of all employees
        SqlDataAdapter _adapter = new SqlDataAdapter (cmdListOfNames, NorthwindString);
        DataTable _table = new DataTable ();
        _adapter.Fill (_table);
        return _table;
    }

    public EmployeeInfo GetEmployeeDetails(int empID)
    {
        // Get details about the specified employee
        SqlDataAdapter _adapter = new SqlDataAdapter (
            String.Format(cmdEmployeeDetails, empID), 
            NorthwindString);
        DataTable _table = new DataTable ();
        _adapter.Fill (_table);
        
        // Execute the command and populate the return buffer
        DataRow _row = _table.Rows[0];
        EmployeeInfo info = new EmployeeInfo (); 
        info.ID = empID;
        info.FirstName = _row["firstname"].ToString ();
        info.LastName = _row["lastname"].ToString ();
        info.Title = _row["title"].ToString ();
        info.Country = _row["country"].ToString ();
        info.Notes = _row["notes"].ToString ();

        return info;
    }

public class EmployeeInfo
{
    public int ID;
    public string FirstName;
    public string LastName;
    public string Title;
    public string Country;
    public string Notes;
}
</script>

<html>
<body>
    <form id="Form1" runat="server">
        <h1>Select a name and click for details</h1>
        <asp:dropdownlist id="cboEmployees" runat="server" />
        <input type="button" runat="server" id="buttonTrigger" value="More Info">
        <br />
        <table>
        <tr><td><b>ID</b></td><td><span id="e_ID" /></td></tr>
        <tr><td><b>Name</b></td><td><span id="e_FName" /></td></tr>
        <tr><td><b>Last Name</b></td><td><span id="e_LName" /></td></tr>
        <tr><td><b>Title</b></td><td><span id="e_Title" /></td></tr>
        <tr><td><b>Country</b></td><td><span id="e_Country" /></td></tr>
        <tr><td><b>Notes</b></td><td><i><span id="e_Notes" /></i></td></tr>
        </table>
    </form>
</body>
</html>
