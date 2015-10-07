using System;
using System.Web;
using System.Web.UI;
using System.IO;

namespace WWW
{
  
  public partial class LoadRepositoryFile : System.Web.UI.Page
  {
    public string FileContent { get;set; }

    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["repoName"];
      var filePath = Request.QueryString ["path"];
      var reposPath = Server.MapPath ("repositories");
      var fullPath = Path.Combine (reposPath, repoName);
      fullPath = Path.Combine (fullPath, filePath);
      FileContent = File.ReadAllText (fullPath);
    }
  }
}

