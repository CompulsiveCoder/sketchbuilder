<%@ Page Language="C#" Inherits="WWW.SerialMonitorOutput" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>SerialMonitorOutput</title>
</head>
<body>
 <form id="form1" runat="server">
  <div id="output">
    <script language="javascript">
    $( document ).ready(function() {
          $('#output').scrollTop = $('#output').scrollHeight;
    });
    </script>
    <pre id="inner">
    <% =HttpUtility.HtmlEncode(Output) %>
    </pre>
  </div>
 </form>
</body>
</html>

