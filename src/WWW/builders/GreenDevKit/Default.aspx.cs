using System;
using System.Web;
using System.Web.UI;
using duinocom;

namespace WWW.GreenKit
{
	
	public partial class Default : System.Web.UI.Page
	{

    public string Port { get; set; }

    void Page_Load(object sender, EventArgs e)
    {
      var detector = new DuinoPortDetector (null);

      var port = detector.Guess ();

      if (port == null)
        throw new Exception ("No device detected.");

      Port = port.PortName;
    }
	}
}

