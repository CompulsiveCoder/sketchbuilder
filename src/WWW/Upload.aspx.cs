using System;
using System.Web;
using System.Web.UI;
using duinocom.Upload;
using System.IO;

namespace WWW
{
  
  public partial class Upload : System.Web.UI.Page
  {
    public void Page_Load(object sender, EventArgs e)
    {
      var repoName = Request.QueryString ["repo"];
      var sketchFilePath = Request.QueryString ["file"];
      var board = Request.QueryString ["board"];
      var port = Request.QueryString ["port"];

      var uploader = new DuinoUploader ();
      uploader.UploadSketch (Path.GetDirectoryName (sketchFilePath), port, board);

      if (uploader.IsError) {
        uploader.UploadSketch (Path.GetDirectoryName(Path.GetDirectoryName (sketchFilePath)), port, board);
      }

      //CurrentRepository = repoName;

     // var reposPath = Path.GetFullPath ("repositories");

     // CurrentRepositorySourcePath = new RepositoryReader (reposPath).ReadSourceRepositoryPath (repoName);

     // var currentRepositoryPath = Path.Combine (reposPath, repoName);

     // var list = new List<string> ();

     // foreach (var file in Directory.GetFiles(currentRepositoryPath, "*.ino", SearchOption.AllDirectories))
     //   list.Add (file.Replace(currentRepositoryPath, ""));

     // SketchFilePaths = list.ToArray();
    }

  }
}

