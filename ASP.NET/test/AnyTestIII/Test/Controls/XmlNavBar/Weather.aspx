<%@ Register TagPrefix="user" TagName="XmlNavBar"
  Src="XmlNavBar.ascx" %>

<html>
  <body>
    <form runat="server">
      <table width="100%" height="100%">
        <tr height="48">
          <td bgcolor="teal" align="center" colspan="2">
            <span style="color: white; font-family: verdana; font-size: 24pt; font-weight: bold">
              Weather
            </span>
          </td>
        </tr>
        <tr>
          <td width="128" valign="top" bgcolor="royalblue">
            <user:XmlNavBar XmlSrc="Links.xml" ForeColor="white" 
              Font-Name="verdana" Font-Size="10pt" Font-Bold="true"
              MouseOverColor="black" RunAt="server" />
          </td>
          <td align="center" valign="center">
            If it's wet outside, it must be raining
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>