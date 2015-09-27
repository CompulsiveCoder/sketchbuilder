using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using sketchbuilder.Builders.GreenKit;
using System.IO;
using System.Diagnostics;

namespace WWW.GreenKit
{
  
  public partial class Upload : System.Web.UI.Page
  {
    public string Output;

    public void Page_Load(object sender, EventArgs e)
    {
      var sourcePath = Request.QueryString ["src"];

      var port = Request.QueryString ["port"];

      var board = Request.QueryString ["board"];

      //var delay = Convert.ToInt32(Request.QueryString ["delay"]);

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

      var code = builder.Build (moistureSensorPins.ToArray(), pumpPins.ToArray(), thresholdPins.ToArray());

      Output = UploadSketch (port, board, code);

    }    

    public string UploadSketch(string port, string board, string code)
    {
      var output = "";

      var tmpDir = Path.GetFullPath ("_tmp");

      var uniqueDir = Path.Combine (tmpDir, Guid.NewGuid().ToString());

      var sketchDir = Path.Combine (uniqueDir, "sketch");

      var srcDir = Path.Combine (sketchDir, "src");

      Directory.CreateDirectory (tmpDir);
      Directory.CreateDirectory (uniqueDir);
      Directory.CreateDirectory (sketchDir);

      Directory.SetCurrentDirectory (sketchDir);

      var sketchPath = Path.Combine (srcDir, "sketch.ino");

      try
      {
        var psi = new ProcessStartInfo();
        psi.FileName = "ino";
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;

        psi.Arguments = "init";
        Process p = Process.Start(psi);
        string strOutput = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        Console.WriteLine(strOutput);
        output += strOutput;

        Directory.CreateDirectory (srcDir);

        File.WriteAllText (sketchPath, code);

        var psi2 = new ProcessStartInfo();
        psi2.FileName = "ino";
        psi2.UseShellExecute = false;
        psi2.RedirectStandardOutput = true;
        psi2.RedirectStandardError = true;

        psi2.Arguments = "build -m " + board;
        Process p2 = Process.Start(psi2);
        string strOutput2 = p2.StandardOutput.ReadToEnd();
        p2.WaitForExit();
        string error2 = p2.StandardError.ReadToEnd();
        Console.WriteLine(error2);
        output += error2;
        Console.WriteLine(strOutput2);
        Console.WriteLine("Finished");

        output += strOutput2;


        var psi3 = new ProcessStartInfo();
        psi3.FileName = "ino";
        psi3.UseShellExecute = false;
        psi3.RedirectStandardOutput = true;
        psi3.RedirectStandardError = true;

        psi3.Arguments = "upload -m " + board + " -p " + port;
        Process p3 = Process.Start(psi3);
        p3.WaitForExit();
        string strOutput3 = p3.StandardOutput.ReadToEnd();
        string error3 = p3.StandardError.ReadToEnd();
        Console.WriteLine(error3);
        output += error3;
        Console.WriteLine(strOutput3);
        Console.WriteLine("Finished");

        output += strOutput3;

      }
      catch(Exception ex) {
        output += ex.ToString ();
      }
      return output;
    }
  }
}

