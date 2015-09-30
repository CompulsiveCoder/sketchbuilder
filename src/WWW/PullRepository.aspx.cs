using System;
using System.Web;
using System.Web.UI;
using System.IO;
using sketchbuilder.Core;

namespace WWW
{
  
  public partial class PullRepository : System.Web.UI.Page
  {
    public string Output { get;set; }

    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["repo"];

      var reposDir = Path.GetFullPath ("repositories");

      var repoDirectory = Path.Combine (reposDir, repoName);

      if (Directory.Exists (repoDirectory)) {
        var puller = new RepositoryPuller (reposDir);
        Output += puller.Pull (repoName);
      }
    }
  }
}

