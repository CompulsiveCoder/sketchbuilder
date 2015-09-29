using System;
using System.Web;
using System.Web.UI;
using System.IO;
using sketchbuilder.Core;

namespace WWW
{
  
  public partial class DeleteRepository : System.Web.UI.Page
  {
    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["repo"];

      var repoPath = Request.QueryString ["path"];

      var reposDir = Path.GetFullPath ("repositories");

      var repoDirectory = Path.Combine (reposDir, repoName);

      if (Directory.Exists (repoDirectory)) {
        var deleter = new RepositoryDeleter (reposDir);
        deleter.Delete (repoName, repoPath);
      }

      Response.Redirect ("Repositories.aspx");
    }
  }
}

