using System;
using System.IO;

namespace sketchbuilder.Core
{
  public class RepositoryReader
  {
    public string RepositoriesDirectory;

    public RepositoryReader (string repositoriesDirectory)
    {
      RepositoriesDirectory = repositoriesDirectory;
    }

    public string ReadSourceRepositoryPath(string repoName)
    {
      var repoPath = Path.Combine (RepositoriesDirectory, repoName);

      var filePath = Path.Combine (repoPath, "repository.txt");

      var sourceRepoPath = File.ReadAllText (filePath);

      return sourceRepoPath;
    }
  }
}

