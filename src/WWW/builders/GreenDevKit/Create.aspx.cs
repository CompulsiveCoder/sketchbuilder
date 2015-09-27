using System;
using System.Web;
using System.Web.UI;
using System.IO;
using sketchbuilder.Builders.GreenKit;
using System.Collections.Generic;

namespace WWW
{
  
  public partial class Create : System.Web.UI.Page
  {
    public string Output;

    public void Page_Load(object sender, EventArgs e)
    {
      var sourcePath = Request.QueryString ["src"];

      var moistureSensorPinStrings = Request.QueryString ["mspins"].Split(',');

      var moistureSensorPins = new List<int> ();
      foreach (var pinString in moistureSensorPinStrings) {
        moistureSensorPins.Add (Convert.ToInt32 (pinString));
      }

      var pumpPinStrings = Request.QueryString ["ppins"].Split(',');

      var pumpPins = new List<int> ();
      foreach (var pinString in pumpPinStrings) {
        pumpPins.Add (Convert.ToInt32 (pinString));
      }

      var thresholdPinStrings = Request.QueryString ["ppins"].Split(',');

      var thresholdPins = new List<int> ();
      foreach (var pinString in thresholdPinStrings) {
        thresholdPins.Add (Convert.ToInt32 (pinString));
      }


      var builder = new GreenKitBuilder (sourcePath);

      Output = builder.Build (moistureSensorPins.ToArray(), pumpPins.ToArray(), thresholdPins.ToArray());
    }    
  }
}

