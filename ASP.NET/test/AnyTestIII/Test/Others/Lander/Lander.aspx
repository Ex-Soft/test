<%@ Page Inherits="LanderPage" Src="Lander.cs" %>
<html>
  <body>
    <h1>Lunar Lander</h1>
    <form runat="server">
      <hr>
      <table cellpadding="8">
        <tr>
          <td>Altitude (m):</td>
          <td><asp:Label id="Altitude" text="15200.0" runat="server" /></td>
        </tr>
        <tr>
          <td>Velocity (m/sec):</td>
          <td><asp:Label id="Velocity" text="0.0" runat="server" /></td>
        </tr>
        <tr>
          <td>Acceleration (m/sec2):</td>
          <td><asp:Label id="Acceleration" text="-1.6" runat="server" /></td>
        </tr>
        <tr>
          <td>Fuel (kg):</td>
          <td><asp:Label id="Fuel" text="8165.0" runat="server" /></td>
        </tr>
        <tr>
          <td>Elapsed Time (sec):</td>
          <td><asp:Label id="ElapsedTime" text="0.0" runat="server" /></td>
        </tr>
        <tr>
          <td>Throttle (%):</td>
          <td><asp:TextBox id="Throttle" runat="server" /></td>
        </tr>
        <tr>
          <td>Burn Time (sec):</td>
          <td><asp:TextBox id="Seconds" runat="server" /></td>
        </tr>
      </table>
      <br>
      <asp:Button text="Calculate" OnClick="OnCalculate" runat="server" />
      <br><br>
      <h3><asp:Label id="LunarLanderLabelOutput" runat="server" /></h3>
    </form>
  </body>
</html>