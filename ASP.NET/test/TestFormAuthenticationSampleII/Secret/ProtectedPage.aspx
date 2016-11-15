<%@ Page Language="C#" %>

<html>
  <body>
    <h1>Protected Page</h1>
    <hr><br>
    <% Response.Write (Context.User.Identity.Name + ": "); %>
    Be careful investing your money in dot-coms.
  </body>
</html>