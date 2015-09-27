<%@ Page Language="C#" Inherits="WWW.Builders" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Builders</title>
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

    h2
    {
      font-family: arial;
      font-size: 14px;
      border: solid 1px lightgray;
      padding: 4px;
    }

  </style>
</head>
<body>
	<form id="form1" runat="server">
		<h1>Sketch Builders</h1>
    Choose one of the following sketch builders to create a new sketch.
    <ul>
		<% foreach (var builderName in BuilderNames){ %>
      <li>
				<a href="builders/<% =builderName %>/">
				<% =builderName %>
				</a>
      </li>
			</div>
		<% } %>
    </ul>
	</form>
</body>
</html>

