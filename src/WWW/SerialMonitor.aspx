<%@ Page Language="C#" Inherits="WWW.SerialMonitor" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Serial Monitor</title>
</head>
<body>
 <style>
 body
 {
  font-family: verdana;
  font-size: 11px;
 }
 </style>
 <script type="text/javascript" src="jquery.js"></script>
 <script language="javascript">
  function start()
  {
    var url = 'StartSerialMonitor.aspx';

    $('#OutputCont').show();
    $('#OutputCont').empty();
    $('#OutputCont').text('Loading...');

    $.ajax({
       url:url,
       type:'GET',
       success: function(data){
          $('#OutputCont').html($(data).find('#output').html());
       }
    });


    autoDisplay();
  }

  function display()
  {
    var url = 'SerialMonitorOutput.aspx';

    $.ajax({
       url:url,
       type:'GET',
       success: function(data){
          $('#OutputCont').html($(data).find('#output').html());

       }
    });

  }

  function autoDisplay()
  {
    var refreshRate = 2000;
    setTimeout(function()
    {
      display();
    }, refreshRate);
  }

 </script>
 <form id="form1" runat="server">
  <div><a href="javascript:start();">Start</a></div>
  <div id="OutputCont">
  </div>
 </form>
</body>
</html>

 