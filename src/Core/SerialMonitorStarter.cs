using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace sketchbuilder.Core
{
  public class SerialMonitorStarter
  {
    public string Error;

    public SerialMonitorStarter ()
    {
    }

    public void Start(string port)
    {
      var filePath = Path.GetFullPath ("serialOutput.txt");

      Console.WriteLine (filePath);

      //ExecuteCommand ("ino serial -p '" + port + "' > '" + filePath + "'");
      ExecuteCommand (port);
    }

    public void ExecuteCommand(string port)
    {
      try
      {
       /* var spacePos = command.IndexOf (" ");
        var firstPart = command.Substring (0, spacePos);
        var secondPart = command.Substring (spacePos+1, command.Length - spacePos-1).Trim();*/
       // Environment.CurrentDirectory =
        var t = Environment.CurrentDirectory;
        var startInfo = new ProcessStartInfo("bash", "captureSerial.sh '" + port + "'");//firstPart, secondPart);
        startInfo.CreateNoWindow = true;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        var process = Process.Start(startInfo);


        //process.WaitForExit();
        //string output = process.StandardOutput.ReadToEnd();
        //string error = process.StandardError.ReadToEnd();
        //Console.WriteLine(output);
        //Console.WriteLine(error);
        //output += error;
        //output += Environment.NewLine;

        //return output;
      }
      catch(Exception ex)
      {
        throw ex;
       /* string output = "Error" + Environment.NewLine;
        output += ex.ToString () + Environment.NewLine;
        Error += ex.ToString ();
        return output + Environment.NewLine;*/
      }
    }
  }
}

