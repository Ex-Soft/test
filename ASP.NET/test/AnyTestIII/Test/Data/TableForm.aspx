<%@ Page language="c#" Codebehind="TableForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TableForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TableForm</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script type="text/javascript">
<!--
var
  DelButtName="DelButt",
  DelFuncName="Del",
  EditButtName="EditButt",
  EditFuncName="Edit",
  oTBody,
  TableId="ASPTable",
  InputName,
  InputNameId="InsuredPersonName",
  InputId,
  InputIdId="InsuredPersonId",
  AddNameButt,
  AddNameButtId="btnAddContragent",
  TableHeaderRowsCount=1;

function Add()
{
   var
     oRow,
     oCell,
     row,
     tmpStr;

   if(InputId==null || InputId==undefined)
     InputId=document.getElementById(InputIdId);

   if(InputName==null || InputName==undefined)
     InputName=document.getElementById(InputNameId);

   if(InputName.value.length==0)
     return;

   if(oTBody==null || oTBody==undefined)
     oTBody=TableBody(TableId);

   oRow=document.createElement("TR");
   oTBody.appendChild(oRow);

   row=oTBody.rows.length;

   oCell=document.createElement("TD");
   tmpStr=InputName.value+"<input id=\"InputId"+(row-1)+"\" name=\"InputId"+(row-1)+"\" type=\"hidden\" value=\""+InputId.value+"\">";
   oCell.innerHTML=tmpStr;
   oRow.appendChild(oCell);

   oCell=document.createElement("TD");
   tmpStr="<input id=\"InputSeria"+(row-1)+"\" name=\"InputSeria"+(row-1)+"\" type=\"text\" style=\"width: 100%; \">";
   oCell.innerHTML=tmpStr;
   oRow.appendChild(oCell);

   oCell=document.createElement("TD");
   tmpStr="<input id=\"InputNo"+(row-1)+"\" name=\"InputNo"+(row-1)+"\" type=\"text\" style=\"width: 100%; \">";
   oCell.innerHTML=tmpStr;
   oRow.appendChild(oCell);

   oCell=document.createElement("TD");
   tmpStr="<input id=\"InputDate"+(row-1)+"\" name=\"InputDate"+(row-1)+"\" type=\"text\" style=\"width: 100%; \">";
   oCell.innerHTML=tmpStr;
   oRow.appendChild(oCell);

   oCell=document.createElement("TD");
   tmpStr="<input id=\""+DelButtName+(row-1)+"\" name=\""+DelButtName+(row-1)+"\" type=\"button\" value=\""+DelFuncName+"("+(row-1)+")\" onclick=\""+DelFuncName+"("+(row-1)+")\" style=\"width: 100%; \">";
   oCell.innerHTML=tmpStr;
   oRow.appendChild(oCell);

   oCell=document.createElement("TD");
   tmpStr="<input id=\""+EditButtName+(row-1)+"\" name=\""+EditButtName+(row-1)+"\" type=\"button\" value=\""+EditFuncName+"("+(row-1)+")\" onclick=\""+EditFuncName+"("+(row-1)+")\" style=\"width: 100%; \">";
   oCell.innerHTML=tmpStr;
   oRow.appendChild(oCell);
   
   if(AddNameButt==null || AddNameButt==undefined)
     AddNameButt=document.getElementById(AddNameButtId);
     
   if(row >= MaxRow+TableHeaderRowsCount)
     AddNameButt.disabled=true;
}

function FindMarker(aRow,aMarkerName)
{
   var
     Marker=null,
     Cells=aRow.cells,
     Entry;

   for(var c=0; c<Cells.length; ++c)
   {
      Entry=Cells[c].childNodes;
      for(var e=0; e<Entry.length; ++e)
      {
         if(Entry[e].id!=null && Entry[e].id!=undefined)
         {
            if(Entry[e].id.substring(0,aMarkerName.length)==aMarkerName)
            {
               Marker=Entry[e];
               break;
            }
         }
      }
      if(Marker!=null)
        break;
   } 

   return(Marker);
}

function Del(row)
{
   var
     tmpDelButt;

   if(oTBody==null || oTBody==undefined)
     oTBody=TableBody(TableId);

   oTBody.deleteRow(row);

   for(var i=row; i<oTBody.rows.length; ++i)
   {
      tmpButt=FindMarker(oTBody.rows[i],DelButtName);
      if(tmpButt!=null && tmpButt!=undefined)
      {
         tmpButt.value=DelFuncName+"("+i+")";
         tmpButt.onclick=new Function(DelFuncName+"("+i+")");
      }

      tmpButt=FindMarker(oTBody.rows[i],EditButtName);
      if(tmpButt!=null && tmpButt!=undefined)
      {
         tmpButt.value=EditFuncName+"("+i+")";
         tmpButt.onclick=new Function(EditFuncName+"("+i+")");
      }
   }

   if(AddNameButt==null || AddNameButt==undefined)
     AddNameButt=document.getElementById(AddNameButtId);

   AddNameButt.disabled=oTBody.rows.length>=MaxRow+TableHeaderRowsCount;
}

function Edit(row)
{
	alert(row);
}

function TableBody(aTableId)
{
   var
     oTableBody=null,
     oTable=document.getElementById(aTableId);
   
   if(oTable==null || oTable==undefined)
     return(oTableBody);
     
   for(var i=0; i<oTable.childNodes.length; ++i)
      if(oTable.childNodes[i].nodeType==1 && oTable.childNodes[i].nodeName.toLowerCase()=="tbody")
        {
           oTableBody=oTable.childNodes[i];
           break;
        }
        
   return(oTableBody);
}

function DeleteRow()
{
   var
     row=parseInt(document.getElementById("RowNo").value);
     
   if(oTBody==null || oTBody==undefined)
     oTBody=TableBody(TableId);
     
   if(!isNaN(row) && row<oTBody.rows.length)
     oTBody.deleteRow(row);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="TableForm" method="post" runat="server">
			<asp:literal id="VarDef" runat="server"></asp:literal>Id&nbsp;<asp:textbox id="InsuredPersonId" runat="server"></asp:textbox>&nbsp;Name&nbsp;<asp:textbox id="InsuredPersonName" runat="server"></asp:textbox>&nbsp;<input id="btnAddContragent" title="Додати контрагента" onclick="Add()" type="button" value="Додати контрагента"><br>
			Row#&nbsp;<asp:textbox id="RowNo" runat="server"></asp:textbox>&nbsp;<input id="btnDelRow" title="Delete" onclick="DeleteRow()" type="button" value="Delete">
			<asp:table id="ASPTable" runat="server" border="1" CellSpacing="0" CellPadding="0">
				<asp:TableRow id="ASPTableRowHeader" runat="server">
					<asp:TableHeaderCell id="ASPTableHeaderCell1" runat="server">П. І. Б.</asp:TableHeaderCell>
					<asp:TableHeaderCell id="ASPTableHeaderCell2" runat="server">Серія</asp:TableHeaderCell>
					<asp:TableHeaderCell id="ASPTableHeaderCell3" runat="server">Номер</asp:TableHeaderCell>
					<asp:TableHeaderCell id="ASPTableHeaderCell4" runat="server">Водійський стаж з</asp:TableHeaderCell>
					<asp:TableHeaderCell id="ASPTableHeaderCell5" runat="server"></asp:TableHeaderCell>
					<asp:TableHeaderCell id="ASPTableHeaderCell6" runat="server"></asp:TableHeaderCell>
				</asp:TableRow>
			</asp:table><asp:button id="ButtonSubmit" runat="server" text="Submit"></asp:button><br>
			<asp:label id="LabelSubmitInfo" runat="server"></asp:label><br>
			<asp:label id="LabelOnLoadInfo" runat="server"></asp:label></form>
	</body>
</HTML>
