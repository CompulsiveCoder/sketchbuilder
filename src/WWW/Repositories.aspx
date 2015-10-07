<%@ Page Language="C#" Inherits="WWW.Repositories" %>
<!DOCTYPE html>
<html>
<head runat="server">
 <title>Repositories</title>
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
    <script type="text/javascript" src="jquery.js"></script>
    <script language="javascript">
    function addRepository()
    {
      var repoName = $("#repoName").val();
      var repoPath = $("#repoPath").val();
      var repoBranch = $("#repoBranch").val();

      var url = 'AddRepository.aspx?name=' + repoName + '&path=' + encodeURIComponent(repoPath) + '&branch=' + encodeURIComponent(repoBranch);
      //alert(url);
      //location.href = url;


      $('#OutputCont').text("Loading...");
      $('#Status').text('...');

      $.ajax({
         url:url,
         type:'GET',
         success: function(data){
            $('#OutputCont').html($(data).find('#output').html());

            var log = $('#OutputCont').html();

            var backgroundColor = 'black';
            var text = '...';

            if (log.indexOf('avrdude done.') > -1)
            {
              backgroundColor = 'green';
              text = 'Add Complete';
            }
            else
            {
              backgroundColor = 'red';
              text = 'Add Failed';
            }

            $('#Status').html('<span style="font-weight:bold;color:' + backgroundColor + ';">' + text + '</span>');
          }
        });

        $('#OutputCont').show();

        location.href='Repository.aspx?repo=' + repoName;
      }

      function pullRepo(name)
      {
        var url = 'PullRepository.aspx?repo=' + name;

       // alert(url);


        $('#OutputCont').text("Loading...");
        $('#Status').text('...');

        $.ajax({
           url:url,
           type:'GET',
           success: function(data){
              $('#OutputCont').html($(data).find('#output').html());

              var log = $('#OutputCont').html();

              var backgroundColor = 'black';
              var text = '...';

              if (log.indexOf('up-to-date.') > -1)
              {
                backgroundColor = 'green';
                text = 'Already up to date';
              }
              else if (log.indexOf('.') > -1)
              {
                backgroundColor = 'green';
                text = 'Pull Complete';
              }
              else
              {
                backgroundColor = 'red';
                text = 'Pull Failed';
              }

              $('#Status').html('<span style="font-weight:bold;color:' + backgroundColor + ';">' + text + '</span>');
           }
        });

        $('#OutputCont').show();
      }

      function deleteRepo(name)
      {
        var url = 'DeleteRepository.aspx?repo=' + name;

       // alert(url);


        $('#OutputCont').text("Loading...");
        $('#Status').text('...');

        $.ajax({
           url:url,
           type:'GET',
           success: function(data){
              $('#OutputCont').html($(data).find('#output').html());

              var log = $('#OutputCont').html();

              var backgroundColor = 'black';
              var text = '...';

              if (log.indexOf('Done') > -1)
              {
                backgroundColor = 'green';
                text = 'Deletion Complete';
              }
              else
              {
                backgroundColor = 'red';
                text = 'Deletion Failed';
              }

              $('#Status').html('<span style="font-weight:bold;color:' + backgroundColor + ';">' + text + '</span>');
           }
        });

        $('#OutputCont').show();
      }
    </script>
    <h1>Git Repositories</h1>
    <div>Choose a repository containing the sketch to upload. </div>
    <div>Check out the <a href="RecommendedRepositories.aspx">recommended repositories</a> for example sketches.</div>
    <div>Name: <input id="repoName" value='<% =RepositoryName %>'/> Url: <input id="repoPath" value='<% =RepositoryPath %>' width="400"/> Branch: <input id="repoBranch" value="master" width="400"/> <input type="button" value="Add Repository" onclick="addRepository()"/> <span id="Status"></span></div>
    <ul>
    <% foreach (var repository in Data){ %>
      <li>
        <a href="Repository.aspx?repo=<% =HttpUtility.UrlEncode(repository) %>"><% =repository %></a>
         - [<a onclick="return confirm('Are you sure?');" href="javascript:pullRepo('<% =HttpUtility.UrlEncode(repository) %>')">Pull</a>]
         - [<a onclick="return confirm('Are you sure?');" href="javascript:deleteRepo('<% =HttpUtility.UrlEncode(repository) %>')">Delete</a>]
      </li>
    <% } %>
    </ul>
    <div id="OutputCont" class="log" style="width: 600px;"></div>
 </form>
</body>
</html>


