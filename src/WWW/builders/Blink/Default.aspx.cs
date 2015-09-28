using System;
using System.Web;
using System.Web.UI;
using duinocom;

namespace WWW
{
	
	public partial class Default : System.Web.UI.Page
	{
    public string Port;

    void Page_Load(object sender, EventArgs e)
    {
      var detector = new DuinoPortDetector (null);

      var port = detector.Guess ();

      if (port != null)
        Port = port.PortName;
      else
        Port = "[no device detected]";
    }
	}
}

