using System;
using System.Web;
using System.Web.UI;
using duinocom.Upload;
using System.IO;

namespace WWW
{
  
  public partial class Upload : System.Web.UI.Page
  {
    public string Output = "";

    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["repo"];
      var sketchFilePath = Request.QueryString ["file"];
      var board = Request.QueryString ["board"];
      var port = Request.QueryString ["port"];

      sketchFilePath = Path.GetFullPath ("repositories") + Path.DirectorySeparatorChar +
        repoName + Path.DirectorySeparatorChar +
        sketchFilePath;

      Console.WriteLine (repoName);
      Console.WriteLine (sketchFilePath);
      Console.WriteLine (board);
      Console.WriteLine (port);

      var uploader = new DuinoUploader ();

      Output += uploader.UploadFromFile (sketchFilePath, port, board);
    }
  }
}

