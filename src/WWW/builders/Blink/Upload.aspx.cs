﻿using System;
using System.Web;
using System.Web.UI;
using sketchbuilder.Builders.GreenKit;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;
using duinocom.Upload;

namespace WWW.Blink
{

	public partial class Upload : System.Web.UI.Page
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

      var code = builder.Build (ledPins.ToArray(), delay);

      var uploader = new DuinoUploader ();
      Output = uploader.UploadCode(code, port, board);

    }    

    // TODO: Remove
	  /*  public string UploadSketch(string port, string board, string code)
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
        p.WaitForExit();
        string strOutput = p.StandardOutput.ReadToEnd();
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
        p2.WaitForExit();
        string strOutput2 = p2.StandardOutput.ReadToEnd();
        string strError2 = p2.StandardError.ReadToEnd();
				Console.WriteLine(strOutput2);
        Console.WriteLine(strError2);
				Console.WriteLine("Finished");

        output += strOutput2;
        output += strError2;

        if (!output.Contains("failed"))
        {
  				var psi3 = new ProcessStartInfo();
  				psi3.FileName = "ino";
          psi3.UseShellExecute = false;
          psi3.RedirectStandardOutput = true;
          psi3.RedirectStandardError = true;

          psi3.Arguments = "upload -m " + board + " -p " + port;
          Process p3 = Process.Start(psi3);
          Thread.Sleep(2000);
          //p3.BeginOutputReadLine();
          p3.WaitForExit();
          string strOutput3 = p3.StandardOutput.ReadToEnd();
          string strError3 = p3.StandardError.ReadToEnd();
  				Console.WriteLine(strOutput3);
          Console.WriteLine(strError3);
  				Console.WriteLine("Finished");

  				output += strOutput3;
          output += strError3;
        }

			}
			catch(Exception ex) {
				output += ex.ToString ();
			}
			return output;
		}*/
	}
}

