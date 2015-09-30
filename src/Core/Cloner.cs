using System;
using System.IO;
using System.Diagnostics;

namespace sketchbuilder.Core
{
  public class Cloner
  {
    public string WorkingDirectory { get;set; }

    public Cloner (string workingDirectory)
    {
      WorkingDirectory = workingDirectory;
    }

    public string Clone(string name, string remotePath)
    {
      var repoDir = Path.Combine (WorkingDirectory, name);

      Directory.CreateDirectory (repoDir);

      var startInfo = new ProcessStartInfo("git", "clone '" + remotePath + "' '" + repoDir + "'");
      startInfo.UseShellExecute = false;
      startInfo.RedirectStandardOutput = true;
      startInfo.RedirectStandardError = true;
      var process = Process.Start(startInfo);
      process.WaitForExit();
      string output = process.StandardOutput.ReadToEnd();
      string error = process.StandardError.ReadToEnd();
      Console.WriteLine(output);
      Console.WriteLine(error);
      output += error;
      output += Environment.NewLine;
      return output;
    }
  }
}

