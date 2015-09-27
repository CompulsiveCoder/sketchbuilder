<%@ Page Language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="duinocom" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html>
<head runat="server">
	<title>Web Cam</title>
	<script runat="server">
	string portName = "";
	public void Page_Load(object sender, EventArgs e)
	{
		Response.Redirect("Builders.aspx");
	}
	</script>
	<style>
		body
		{
			font-family: Verdana;
			font-size: 11px;
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
	</form>
</body>
</html>

