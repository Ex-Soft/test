Imports System.Data
Imports System.Data.SqlClient

Partial Class Default_aspx
    Implements ICallbackEventHandler


    Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack And Not IsCallback Then

            Dim ds As New DataSet
            Dim da As New SqlDataAdapter("select au_id, au_lname + ' ' + au_fname as fullname  from authors", "Integrated Security=SSPI;Initial Catalog=pubs;Data Source=.")
            da.Fill(ds)
            DropDownList1.DataTextField = "fullname"
            DropDownList1.DataValueField = "au_id"
            DropDownList1.DataSource = ds
            DropDownList1.DataBind()

            DropDownList1.Attributes.Add("onchange", "GetOrders(this.options[this.selectedIndex].value, 'DropDownList1');")
        End If

        Dim callBack As String = Page.GetCallbackEventReference(Me, "arg", "ClientCallback", "context", "ClientCallbackError")
        Dim clientFunction As String = "function GetOrders(arg, context){ " & callBack & "; }"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "GetOrders", clientFunction, True)

    End Sub
    Function RaisePostBackEvent(ByVal eventArgument As String) As String Implements ICallbackEventHandler.RaiseCallbackEvent

        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("select titles.title_id,title from titles inner join titleauthor on titleauthor.title_id = titles.title_id where au_id = '" & eventArgument & "'", "Integrated Security=SSPI;Initial Catalog=pubs;Data Source=.")
        da.Fill(ds)
        Dim str As New StringBuilder("")
        Dim oRow As DataRow
        For Each oRow In ds.Tables(0).Rows
            str.Append(oRow("title"))
            str.Append("|")
        Next
        Return str.ToString()

    End Function

    Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
End Class
