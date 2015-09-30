using System;
using System.IO;

namespace sketchbuilder.Core
{
  public class RepositoryDeleter
  {
    public string RepositoriesDirectory;

    public RepositoryDeleter(string repositoriesDirectory)
    {
      RepositoriesDirectory = repositoriesDirectory;
    }

    public void Delete(string repoName, string remoteRepositoryPath)
    {
      var repositoryPath = Path.Combine (RepositoriesDirectory, repoName);
      Directory.Delete (repositoryPath, true);
    }
  }
}

