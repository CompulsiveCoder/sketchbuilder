<%@ Page Language="C#" Inherits="WWW.RecommendedRepositories" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>RecommendedRepositories</title>
  <style>
    
    body
    {
      font-family: verdana;
      font-size: 11px;
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
  <h1>How To</h1>
  <div><a href="Repositories.aspx">&laquo; Back to Repositories</a></div>
  <div>
  How to use these recommended repositories:
  </div>
  <div>
    <ol>
      <li>Select a repository below</li>
      <li>Click Add Repository on the next page - the code will be cloned from github</li>
      <li>Use form to select a sketch and upload it.</li>
    </ol>
  </div>
  <h1>Repositories</h1>
  <div>Blink: <a href="Repositories.aspx?repoName=blink&repoPath=https://github.com/joonyeechuah/Arduino_blinky.git">https://github.com/joonyeechuah/Arduino_blinky.git</a></div>
  <div>Analog Read Serial: <a href="Repositories.aspx?repoName=AnalogReadSerial&repoPath=https://github.com/CodeReferenceLibrary/AnalogReadSerial.git">https://github.com/CodeReferenceLibrary/AnalogReadSerial.git</a></div>
 </form>
</body>
</html>

