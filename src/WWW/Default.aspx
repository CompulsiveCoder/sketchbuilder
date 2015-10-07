<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="duinocom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
<head runat="server">
	<title>sketchbuilder</title>
	<script runat="server">
	string portName = "";
	public void Page_Load(object sender, EventArgs e)
	{
	}
	</script>
	<style>
    body
    {
      font-family: verdana;
      font-size: 12px;
    }

    h1
    {
      font-family: arial;
      font-size: 16px;
    }


		div
		{
			padding: 4px;
		}

		.ctrl
		{
			width: 50px;
			height: 50px;
			padding: 5px;
			text-align: center;
			border: solid 1px blue;
		}
	</style>
</head>
<body>
	<form id="form1" runat="server">
    <h1>sketchbuilder</h1>
    <div><a href="Repositories.aspx">Sketch Repositories</a></div>
    <div><a href="Builders.aspx">Sketch Builders</a></div>
    <div><a href="SerialMonitor.aspx">Serial Monitor</a></div>
	</form>
</body>
</html>

