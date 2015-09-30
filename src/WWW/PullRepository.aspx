<%@ Page Language="C#" Inherits="WWW.PullRepository" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>PullRepository</title>
</head>
<body>
 <form id="form1" runat="server">
  <div id="output"><% =HttpUtility.HtmlEncode(Output).Replace(Environment.NewLine, "<br/>") %></div>
 </form>
</body>
</html>

