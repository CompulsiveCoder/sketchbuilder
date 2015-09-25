using System;
using System.Web;
using System.Web.UI;
using System.IO;
using sketchbuilder.Builders.GreenKit;
using System.Collections.Generic;

namespace WWW.Blink
{
  
  public partial class Create : System.Web.UI.Page
  {
    public string Output;

    public void Page_Load(object sender, EventArgs e)
    {
      var sourcePath = Request.QueryString ["src"];

      var port = Request.QueryString ["port"];

	    var board = Request.QueryString ["board"];

			var delay = Convert.ToInt32(Request.QueryString ["delay"]);

      var ledPinStrings = Request.QueryString ["pins"].Split(',');

      var ledPins = new List<int> ();
      foreach (var pinString in ledPinStrings) {
        ledPins.Add (Convert.ToInt32 (pinString));
      }

      var builder = new BlinkBuilder ();

			Output = builder.Build (ledPins.ToArray(), delay);
    }    
  }
}

