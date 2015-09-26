<%@ Page Language="C#" Inherits="WWW.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Blink</title>
  <script type="text/javascript" src="jquery.js"></script>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
	<form id="form1" runat="server">
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

    div,span
    {
      margin: 0px;
      padding: 4px;
    }


    .pin
    {
      width: 30px;
    }

    .pinRow
    {
      border: solid 1px lightgray;
      margin-left: 10px;
    }

    .row
    {
      border: solid 1px lightgray;
    }
    </style>
    <script type="text/javascript">
    $(document).ready(function(){
      renderFields();   
    });

    function fewerLeds()
    {
      var number = parseInt($("#totalLeds").val());

      var newNumber = number-1;

      if (newNumber < 0)
        newNumber = 0;

      $("#totalLeds").val(newNumber);

      renderFields();   
     
    }
    function moreLeds()
    {
      var number = parseInt($("#totalLeds").val());

      var newNumber = number+1;

      if (newNumber < 0)
        newNumber = 0;

      $("#totalLeds").val(newNumber);

      renderFields();     
    }

    function renderFields()
    {
      $("#ledsCont").empty();

      var total = parseInt($("#totalLeds").val());
      var pinNumber = 0;

      for (i = 0; i < total; i++)
      {
        var number = i+1;

        if(number>10){
          alert("Only 10 textboxes allow");
            return false;
        }

        var newTextBoxDiv = $(document.createElement('div')).attr("id", 'ledFieldDiv' + i);
                
        newTextBoxDiv.after().html(
          '<div class="pinRow">LED #' + number +
          'Pin: <input value=' + pinNumber + ' name="ledField' + i + '" id="ledField' + i + '" /> '
        );
            
        newTextBoxDiv.appendTo("#ledsCont");

        pinNumber++;
      }
    }

    function create()
    {
      var sourcePath = $("#sourcePath").val();
      var totalLeds = $("#totalLeds").val();
      var delay = $("#delay").val();

      var ledPins = '';

      var url = 'Create.aspx?ms=' + totalLeds;

      for (i = 0; i < totalLeds; i++)
      {
        ledPins += $('#ledField' + i).val();
        if (i != totalLeds-1)
          ledPins += ',';
      }

      url += '&pins=' + ledPins;

      url += '&delay=' + delay;

      url += '&src=' + sourcePath;

      //alert(url);

      $.ajax({
         url:url,
         type:'GET',
         success: function(data){
             $('#SketchCont').html($(data).find('#body').html());
         }
      });
    }

    function upload()
    {
      var sourcePath = $("#sourcePath").val();
      var totalLeds = $("#totalLeds").val();
      var delay = $("#delay").val();
      var board = $('#board').val();
      var port = $('#port').val();

      var ledPins = '';

      var url = 'Upload.aspx?ms=' + totalLeds;

      for (i = 0; i < totalLeds; i++)
      {
        ledPins += $('#ledField' + i).val();
        if (i != totalLeds-1)
          ledPins += ',';
      }

      url += '&pins=' + ledPins;

      url += '&delay=' + delay;

      url += '&board=' + board;

      url += '&port=' + encodeURIComponent(port);

      url += '&src=' + sourcePath;

      //alert(url);
      $('#OutputCont').text("Loading...");

      $.ajax({
         url:url,
         type:'GET',
         success: function(data){
             $('#OutputCont').html($(data).find('#body').html());
         }
      });
    }

    </script>
		<h1>Multi Blink Builder</h1>
    <div>Use the form below to generate a sketch which blinks LEDs on the specified pins.</div>
    <h2>Sketch Settings</h2>
    <div>Delay: <input width="50" value="1000" id="delay" /></div>
		<h3>LEDs</h3>
		<div>Total: <input width="50" value="1" id="totalLeds" />
			<span class="btn" onclick="fewerLeds();">&lt;</span><span class="btn" onclick="moreLeds();">&gt;</span>
		</div>
    <div id="ledsCont"></div>
    <input type="button" value="Generate Sketch" onclick="create();"/><br/>
    <div id="SketchCont" style="width: 600px;"></div>
    <div>Port: <input id="port" value="<% =Port %>"/></div>
    <div>Board: 
    <select id="board">
      <option value="uno">uno</option>
      <option value="nano328">nano</option>
    </select>
    </div>
    <div><input type="button" value="Upload" onclick="upload();"/></div>
    <div id="OutputCont" style="width: 600px;"></div>
	</form>
</body>
</html>

