using System;
using System.Web;
using System.Web.UI;
using sketchbuilder.Core;
using System.IO;

namespace WWW
{
  
  public partial class AddRepository : System.Web.UI.Page
  {
    public string Output;

    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["name"];
      var repoPath = Request.QueryString ["path"];
      var repoBranch = Request.QueryString ["branch"];

      var reposDir = Path.GetFullPath ("repositories");

      if (Directory.Exists (Path.Combine (reposDir, repoName)))
        Output += "Repository already exists";
      else {
        // TODO: Add to config
        var cloner = new Cloner (reposDir);

        Output += cloner.Clone (repoName, repoPath, repoBranch);

        var saver = new RepositorySaver (reposDir);
        saver.SaveRepositoryPath (repoName, repoPath);
        saver.SaveRepositoryBranch (repoName, repoBranch);
      }
    }
  }
}

