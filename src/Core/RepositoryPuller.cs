using System;
using System.IO;
using System.Diagnostics;

namespace sketchbuilder.Core
{
  public class RepositoryPuller
  {
    public string RepositoriesDirectory;

    public string Error = "";

    public RepositoryPuller (string repositoriesDirectory)
    {
      RepositoriesDirectory = repositoriesDirectory;
    }

    public string Pull(string repoName)
    {
      var repoPath = Path.Combine (RepositoriesDirectory, repoName);

      var repoFilePath = Path.Combine (repoPath, "repository.txt");

      var sourceRepoPath = File.ReadAllText (repoFilePath);

      var repoBranchFilePath = Path.Combine (repoPath, "branch.txt");

      var branch = File.ReadAllText (repoBranchFilePath);

      var cmd = "git pull origin " + branch;

      return ExecuteCommand (cmd);
    }

    public string ExecuteCommand(string command)
    {
      try
      {
        var spacePos = command.IndexOf (" ");
        var firstPart = command.Substring (0, spacePos);
        var secondPart = command.Substring (spacePos+1, command.Length - spacePos-1).Trim();

        var startInfo = new ProcessStartInfo(firstPart, secondPart);
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
      catch(Exception ex)
      {
        string output = "Error" + Environment.NewLine;
        output += ex.ToString () + Environment.NewLine;
        Error += ex.ToString ();
        return output + Environment.NewLine;
      }
    }
  }
}

