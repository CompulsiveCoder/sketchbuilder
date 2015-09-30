using System;
using System.Web;
using System.Web.UI;
using sketchbuilder.Core;
using System.IO;

namespace WWW
{
  
  public partial class StartSerialMonitor : System.Web.UI.Page
  {
    public void Page_Load(object sender, EventArgs e)
    {
      File.Delete (Path.GetFullPath ("serialOutput.txt"));

      var port = Request.QueryString ["port"];

      var starter = new SerialMonitorStarter ();
      starter.Start (port);
    }
  }
}

