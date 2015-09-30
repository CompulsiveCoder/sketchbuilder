using System;
using System.Web;
using System.Web.UI;
using sketchbuilder.Core;
using System.IO;
using System.Collections.Generic;
using duinocom;

namespace WWW
{
  
  public partial class Repository : System.Web.UI.Page
  {

    public string CurrentRepository { get;set; }

    public string CurrentRepositorySourcePath { get;set; }

    public string CurrentRepositoryBranch { get;set; }

    public string[] SketchFilePaths { get;set; }

    public string Port;

    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["repo"];

      CurrentRepository = repoName;

      var reposPath = Path.GetFullPath ("repositories");

      CurrentRepositorySourcePath = new RepositoryReader (reposPath).ReadSourceRepositoryPath (repoName);

      var currentRepositoryPath = Path.Combine (reposPath, repoName);

      var list = new List<string> ();

      foreach (var file in Directory.GetFiles(currentRepositoryPath, "*.ino", SearchOption.AllDirectories))
        list.Add (file.Replace(currentRepositoryPath, ""));

      SketchFilePaths = list.ToArray();

      var detector = new DuinoPortDetector (null);

      var port = detector.Guess ();

      if (port != null)
        Port = port.PortName;
      else
        Port = "[no device detected]";

      var repoDirPath = Path.Combine (Path.GetFullPath ("repositories"), repoName);
      var branchFilePath = Path.Combine (repoDirPath, "branch.txt");

      CurrentRepositoryBranch = File.ReadAllText (branchFilePath);
    }

    public string[] GetRepositoryDirectories()
    {
      return GetRepositoryDirectories ("/");
    }

    public string[] GetRepositoryDirectories(string subDir)
    {
      var dir = Path.Combine (Path.GetFullPath ("repositories"), CurrentRepository);
      return Directory.GetDirectories (dir);
    }

    public string Format(string dir)
    {
      var baseDir = Path.Combine (Path.GetFullPath ("repositories"), CurrentRepository);
      return dir.Replace (baseDir, "").TrimStart('/');
    }

    public string GetDirectoryOutput()
    {
      return GetDirectoryOutput ("/");
    }

    public string GetDirectoryOutput(string dir)
    {
      if (!Path.GetFileName (dir).StartsWith (".")) {
        var workspaceDir = Path.Combine (Path.GetFullPath ("repositories"), CurrentRepository);

        if (dir == "/")
          dir = "";

        dir = Path.Combine (workspaceDir, dir);  

        var output = "";

        foreach (var subDir in Directory.GetDirectories(dir)) {
          output = @"<div class='folder'><a href=''>" + Format (subDir) + @"/</a>";

          output += GetDirectoryOutput (subDir);

          output += "</div>";
        }

         foreach (var file in Directory.GetFiles(dir)){
          output += "<div class='file'><a href='javascript:editFile(\"" + Format(file) + "\");'>" + Format (file) + "</a></div>";
        }


        return output;
      } else
        return "";
    }

  }
}

