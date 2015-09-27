<%@ Page Language="C#" Inherits="WWW.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
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

    .pinField
    {
      width: 20px;
    }

    .rowH
    {
      font-weight: bold;
    }

    .row
    {
      border: solid 1px lightgray;
    }

    .subCont
    {
      margin-left: 10px;
    }

    .desc
    {
      font-style: italic;
      font-color: gray;
      font-size: 11px;
    }

    .btn
    {
      width: 30px;
      height: 100px;
      background-color: lightgray;
      border: solid 1px gray;
      margin-left: 4px;
      margin-right: 4px;
      padding: 2px 4px 2px 4px;
      horizontal-align: center;
    }

    .code, .log
    {
      font-family: courier new;
      font-size: 10px;
    }
    </style>
    <script type="text/javascript">
    $(document).ready(function(){
      renderMoistureSensorFields();   
    });

    var maxPins = 10;
    var enabledPumps = new Array(maxPins);

    for (var i = 0; i < enabledPumps.length; ++i)
    {
      enabledPumps[i] = false;
    }

    function fewerMoistureSensors()
    {
      var number = parseInt($("#totalMoistureSensors").val());

      var newNumber = number-1;

      if (newNumber < 0)
        newNumber = 0;

      $("#totalMoistureSensors").val(newNumber);

      renderMoistureSensorFields();   
     
    }
    function moreMoistureSensors()
    {
      var number = parseInt($("#totalMoistureSensors").val());

      var newNumber = number+1;

      if (newNumber < 0)
        newNumber = 0;

      $("#totalMoistureSensors").val(newNumber);

      renderMoistureSensorFields();     
    }

    function renderMoistureSensorFields()
    {
      $("#moistureSensorsCont").empty();

      var total = parseInt($("#totalMoistureSensors").val());
      var pinNumber = 0;

      for (i = 0; i < total; i++)
      {
        var number = i+1;

        if(number>10){
          alert("Only 10 textboxes allow");
            return false;
        }

        var pumpPinNumber = pinNumber+5;

        var thresholdPinNumber = pinNumber+1;

        var newTextBoxDiv = $(document.createElement('div')).attr("id", 'moistureSensorFieldDiv' + i);
                
        newTextBoxDiv.after().html(
          '<div class="pinRow">' +
          '<div class="rowH">Sensor ' + number + '</div>' +
          '<div>Pin: <input value=' + pinNumber + ' class="pinField" name="moistureSensorField' + i + '" id="moistureSensorField' + i + '" /> <span class="desc">(analog input)</span></div> '+
          '<div class="subCont">Pump? <input type="checkbox" onclick="enablePump(\'' + i + '\')" />' +
          '<div id="pumpCont' + i + '" class="subCont">Pump Pin: <input width="30px" class="pinField" value=' + pumpPinNumber + ' name="pumpField' + i + '" id="pumpField' + i + '" />  <span class="desc">(digital output)</span></div>' +
          '<div id="thresholdPinCont' + i + '" class="subCont">Threshold Pin: <input width="30px" class="pinField" value=' + thresholdPinNumber + ' name="thresholdPinField' + i + '" id="thresholdPinField' + i + '" /> <span class="desc">(analog input)</span></div>' +
          '</div>' +
          '</div>'
        );
            
        newTextBoxDiv.appendTo("#moistureSensorsCont");

        if (!enabledPumps[i])
        {
          $('#pumpCont' + i).hide();
          $('#thresholdPinCont' + i).hide();
        }

        pinNumber++;
      }
    }

    function create()
    {
      var sourcePath = $("#sourcePath").val();
      var numberOfMoistureSensors = $("#totalMoistureSensors").val();

      var moisturePins = '';
      var pumpPins = '';
      var thresholdPins = '';

      var url = 'Create.aspx?ms=' + numberOfMoistureSensors;

      for (i = 0; i < numberOfMoistureSensors; i++)
      {
        moisturePins += $('#moistureSensorField' + i).val();
        if (i != numberOfMoistureSensors-1)
          moisturePins += ',';

        if ($('#pumpField' + i).length > 0)
        {
          if (enabledPumps[i])
          {
            pumpPins += $('#pumpField' + i).val();
            thresholdPins += $('#thresholdPinField' + i).val();
          }
          else
          {
            pumpPins += '-1';
            thresholdPins += '-1';
          }

          if (i != numberOfMoistureSensors-1)
          {
            pumpPins += ',';
            thresholdPins += ',';
          }
        }
      }

      url += '&mspins=' + moisturePins;

      url += '&ppins=' + encodeURIComponent(pumpPins);

      url += '&tpins=' + encodeURIComponent(thresholdPins);

      url += '&src=' + sourcePath;

      //alert(url);

      $.ajax({
         url:url,
         type:'GET',
         success: function(data){
             $('#SketchCont').html($(data).find('#body').html());
         }
      });

      $('#SketchCont').show();
    }

    function upload()
    {
      var sourcePath = $("#sourcePath").val();
      var numberOfMoistureSensors = $("#totalMoistureSensors").val();
      var delay = $("#delay").val();
      var board = $('#board').val();
      var port = $('#port').val();

      var moisturePins = '';
      var pumpPins = '';
      var thresholdPins = '';

      var url = 'Upload.aspx?';

      for (i = 0; i < numberOfMoistureSensors; i++)
      {
        moisturePins += $('#moistureSensorField' + i).val();
        if (i != numberOfMoistureSensors-1)
          moisturePins += ',';

        if ($('#pumpField' + i).length > 0)
        {
          if (enabledPumps[i])
          {
            pumpPins += $('#pumpField' + i).val();
            thresholdPins += $('#thresholdPinField' + i).val();
          }
          else
          {
            pumpPins += '-1';
            thresholdPins += '-1';
          }

          if (i != numberOfMoistureSensors-1)
          {
            pumpPins += ',';
            thresholdPins += ',';
          }
        }
      }

      url += '&mspins=' + moisturePins;

      url += '&ppins=' + encodeURIComponent(pumpPins);

      url += '&tpins=' + encodeURIComponent(thresholdPins);

      url += '&board=' + board;

      url += '&port=' + encodeURIComponent(port);

      url += '&src=' + sourcePath;

      //alert(url);

      $('#OutputCont').text("Loading...");
      $('#UploadStatus').text('...');

      $.ajax({
         url:url,
         type:'GET',
         success: function(data){
            $('#OutputCont').html($(data).find('#body').html());

            var log = $('#OutputCont').html();

            var backgroundColor = 'black';
            var text = '...';

            if (log.indexOf('avrdude done.') > -1)
            {
              backgroundColor = 'green';
              text = 'Upload Complete';
            }
            else
            {
              backgroundColor = 'red';
              text = 'Upload Failed';
            }

            $('#UploadStatus').html('<span style="font-weight:bold;color:' + backgroundColor + ';">' + text + '</span>');
         }
      });

      $('#OutputCont').show();
    }

    function enablePump(i)
    {
      enabledPumps[i] = true;
      $('#pumpCont' + i).show();
      $('#thresholdPinCont' + i).show();
    }
    </script>
		<h1>Green Dev Kit</h1>
    <h2>Base Source</h2>
    <div>Source:</div>
    <div><input value='<%= "/home/j/cloud/primary/Projects/devkit/template" %>' id="sourcePath" /></div>
		<h2>Soil Moisture Sensors</h2>
		<div class="row">Total: <input width="50" value="1" id="totalMoistureSensors" />
			<span class="btn" onclick="fewerMoistureSensors();"> - </span><span class="btn" onclick="moreMoistureSensors();"> + </span>
		</div>
    <div id="moistureSensorsCont"></div>
    <input type="button" value="Generate Sketch" onclick="create();"/><br/>
    <div id="SketchCont" class="code" style="width: 100%;height:400px;overflow:auto;border:solid 1px lightgray;display:none;"></div>
    <div>Port: <input id="port" value="<% =Port %>"/></div>
    <div>Board: 
    <select id="board">
      <option value="uno">uno</option>
      <option value="nano328">nano</option>
    </select>
    </div>
    <div><input type="button" value="Upload" onclick="upload();"/> <span id="UploadStatus"></span></div>
    <div id="OutputCont" class="log" style="width: 600px;"></div>
	</form>
</body>
</html>

