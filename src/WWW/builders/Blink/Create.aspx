<%@ Page Language="C#" Inherits="WWW.Blink.Create" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Create</title>
</head>
<body>
 <form id="form1" runat="server">
 <div id="body">
 <pre>
 <% =HttpUtility.HtmlEncode(Output) %>
 </pre>
 </div>
 </form>
</body>
</html>

