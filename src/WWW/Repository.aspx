<%@ Page Language="C#" Inherits="WWW.Repository" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Repository</title>
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

    .folder,.file
    {
      font-size: 9px;
    }

    #editor
    {
      width: 100%;
      height: 200px;
      font-size: 10px;
    }
  </style>
</head>
<body>
  <script src="lib/codemirror.js"></script>
  <link rel="stylesheet" href="lib/codemirror.css">
 <script type="text/javascript" src="jquery.js"></script>
 <script src="https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js"></script>
 <script language="javascript">
  var editor;

  function upload()
  {
    var board = $('#board').val();
    var port = $('#port').val();
    var filePath = $('#sketchFile').val();

    var url = 'Upload.aspx?repo=<% =CurrentRepository %>&file=' + encodeURIComponent(filePath) + '&board=' + board + '&port=' + encodeURIComponent(port);

    //alert(url);

    //location.href = url;


    $('#OutputCont').text("Loading...");
    $('#UploadStatus').text('...');

    $.ajax({
       url:url,
       type:'GET',
       success: function(data){
          $('#OutputCont').html($(data).find('#output').html());
         
          $("#OutputCont").animate({ scrollTop: $("#OutputCont")[0].scrollHeight}, 10);

          var log = $('#OutputCont').html();

          var backgroundColor = 'black';
          var text = '...';

          if (log.indexOf('flash verified') > -1)
          {
            backgroundColor = 'green';
            text = 'Upload Complete';

            startSerialMonitor();
          }
          else
          {
            backgroundColor = 'red';
            text = 'Upload Failed';
          }

          $('#OutputCont').show();
          $('#UploadStatus').html('<span style="font-weight:bold;color:' + backgroundColor + ';">' + text + '</span>');

       }
    });

  }

  function startSerialMonitor()
  {
    var port = $('#port').val();

    var url = 'StartSerialMonitor.aspx?port=' + encodeURIComponent(port);
    //alert(url);
    $('#SerialMonitor').show();
    $('#SerialMonitor').empty();
    $('#SerialMonitor').text('Loading...');


    $.get(url, function(result){
        $result = $(result);

        $('#SerialMonitor').empty();
        $result.find('style').appendTo('#SerialMonitor');
        $result.find('#output').appendTo('#SerialMonitor');
        $result.find('script').appendTo('#SerialMonitor');
    }, 'html');

   /* $.ajax({
       url:url,
       type:'GET',
       success: function(data){
          $('#SerialMonitor').html($(data).find('#output').html());
       }
    });*/

     autoDisplaySerialMonitor()
  }

  function displaySerialMonitor()
  {
    var url = 'SerialMonitorOutput.aspx';


    $.get(url, function(result){
        $result = $(result);

        $('#SerialMonitor').empty();
        $result.find('style').appendTo('#SerialMonitor');
        $result.find('#output').appendTo('#SerialMonitor');
        $result.find('script').appendTo('#SerialMonitor');
        $("#SerialMonitor").animate({ scrollTop: $("#SerialMonitor")[0].scrollHeight}, 10);
    }, 'html');

   /* $.ajax({
       url:url,
       type:'GET',
       success: function(data){
          $('#output').html());
          $('#SerialMonitor').html($(data).find('#output').html());
       }
    });*/
  }

  function autoDisplaySerialMonitor()
  {
    var refreshRate = 2000;
    setTimeout(function()
    {
      displaySerialMonitor();

      autoDisplaySerialMonitor()
    }, refreshRate);
  }

  function editFile(repoName, file)
  {
    var url = "LoadRepositoryFile.aspx?repoName=" + repoName + "&path=" + encodeURIComponent(file);
    alert(url);
     $.ajax({
       url:url,
       type:'GET',
       success: function(data){
          editor.setValue($(data).find('#FileContent').text());
       }
    });
  }
 </script>
 <form id="form1" runat="server">
  <h1><% =CurrentRepository %></h1>
  <div><a href="Repositories.aspx">&laquo; Back to Repositories</a></div>
  <div>Path: <% =CurrentRepositorySourcePath %></div>
  <div>Branch: <% =CurrentRepositoryBranch %></div>
  <div>Sketch: 
    <select name="sketchFile" id="sketchFile">
      <option></option>
    <% foreach (var sketchFilePath in SketchFilePaths){ %>
      <option value='<%= HttpUtility.HtmlEncode(sketchFilePath) %>' <%= (SketchFilePaths.Length == 1 ? "selected" : "") %>> <%= sketchFilePath.TrimStart('/') %></option>
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
  <div><input type="button" id="uploadButton" value="Upload" onclick='upload();'/> <span id="UploadStatus"></span></div>
  <h2>Contents</h2>
  <div>
    <%= GetDirectoryOutput() %>
  </div>
  <h2>Editor</h2>
  <div id="editorCont"><textarea id="FileEditor"></textarea></div>
  <script>
    editor = CodeMirror.fromTextArea(FileEditor, {
      lineNumbers: true
    });
  </script>
  <h2>Output</h2>
  <div id="OutputCont" class="log" style="width: 600px;height:150px;overflow:auto;border:solid 1px lightgray;"></div>
  <h2>Serial Monitor</h2>
  <div id="SerialMonitor" class="log" style="width: 600px;height:150px;overflow:auto;border:solid 1px lightgray;"></div>
 </form>
</body>
</html>

