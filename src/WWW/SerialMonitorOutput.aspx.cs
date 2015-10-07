using System;
using System.Web;
using System.Web.UI;
using System.IO;

namespace WWW
{
  
  public partial class SerialMonitorOutput : System.Web.UI.Page
  {
    public string Output = "";

    public void Page_Load(object sender, EventArgs e)
    {
      Output += File.ReadAllText (Server.MapPath ("serialOutput.txt"));
    }
    
  }
}

