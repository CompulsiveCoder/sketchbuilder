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
    }

  }
}

