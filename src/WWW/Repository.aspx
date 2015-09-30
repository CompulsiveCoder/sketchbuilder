﻿<%@ Page Language="C#" Inherits="WWW.Repository" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Repository</title>
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
 <script type="text/javascript" src="jquery.js"></script>
 <script language="javascript">
  function upload()
  {
    var board = $('#board').val();
    var port = $('#port').val();
    var filePath = $('#sketchFile').val();

    var url = 'Upload.aspx?repo=<% =CurrentRepository %>&file=' + encodeURIComponent(filePath) + '&board=' + board + '&port=' + encodeURIComponent(port);

    alert(url);

    location.href = url;
  }
 </script>
 <form id="form1" runat="server">
  <h1><% =CurrentRepository %></h1>
  <div>Git remote path: <% =CurrentRepositorySourcePath %></div>
  <div>Sketch: 
    <select name="sketchFile" id="sketchFile">
      <option></option>
    <% foreach (var sketchFilePath in SketchFilePaths){ %>
      <option value='<% =HttpUtility.HtmlEncode(sketchFilePath) %>'><%= sketchFilePath.TrimStart('/') %></option>
    <% } %>
    </select>
  </div>
  <div>Port: <input id="port" value="<% =Port %>"/></div>
    <div>Board: 
    <select id="board">
      <option value="uno">uno</option>
      <option value="nano328">nano</option>
    </select>
    </div>
  <div><input type="button" id="uploadButton" value="Upload" onclick='upload();'/></div>

 </form>
</body>
</html>
