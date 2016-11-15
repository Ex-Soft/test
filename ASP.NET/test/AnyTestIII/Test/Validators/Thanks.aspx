<%@ Page Language="C#" %>

<html>
  <body>
    Here's the information you entered:<br><br>
    <ul>
      <%
        Response.Write ("<li>Name: " + Request["Name"]);
        Response.Write ("<li>E-mail address: " + Request["EMail"]);

        if (Request["Address"] != null) {
            StringBuilder sb =
                new StringBuilder ("<li>Address: ", 64);
            sb.Append (Request["Address"]);
            sb.Append (", ");
            sb.Append (Request["City"]);
            sb.Append (", ");
            sb.Append (Request["State"]);
            sb.Append (" ");
            sb.Append (Request["ZipCode"]);
            Response.Write (sb.ToString ());
        }

        if (Request["CreditCardNumber"] != null)
            Response.Write ("<li>Credit card number: " +
                Request["CreditCardNumber"]);
      %>
    </ul>
    Thanks for signing up with Spammers, Inc.!
  </body>
</html>