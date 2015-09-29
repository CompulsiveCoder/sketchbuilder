<%@ Page Language="C#" Inherits="WWW.Repositories" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Repositories</title>
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
    <script type="text/javascript" src="jquery.js"></script>
    <script language="javascript">
    function addRepository()
    {
      var repoName = $("#repoName").val();
      var repoPath = $("#repoPath").val();

      var url = 'AddRepository.aspx?name=' + repoName + '&path=' + encodeURIComponent(repoPath);
      //alert(url);
      location.href = url;
    }
    </script>
    <h1>Git Repositories</h1>
    <div>Choose a repository containing the sketch to upload. </div>
    <div>Name: <input id="repoName"/> Url: <input id="repoPath" width="400"/><input type="button" value="Add Repository" onclick="addRepository()"/></div>
    <ul>
    <% foreach (var repository in Data){ %>
      <li>
        <a href="Repository.aspx?repo=<% =HttpUtility.UrlEncode(repository) %>">
        <% =repository %>
        </a> - <a onclick="return confirm('Are you sure?');" href="DeleteRepository.aspx?repo=<% =HttpUtility.UrlEncode(repository) %>">Delete</a>
      </li>
    <% } %>
    </ul>
 </form>
</body>
</html>


