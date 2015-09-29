using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Collections.Generic;

namespace WWW
{
  
  public partial class Repositories : System.Web.UI.Page
  {
    public string[] Data { get;set; }

    public void Page_Load(object sender, EventArgs e)
    {
      var workingDir = Path.GetFullPath("repositories");

      if (!Directory.Exists (workingDir))
        Directory.CreateDirectory (workingDir);

      var list = new List<string> ();

      foreach (var dir in Directory.GetDirectories(workingDir)) {
        list.Add (Path.GetFileNameWithoutExtension(dir));
      }

      Data = list.ToArray ();
    }
    
  }
}

