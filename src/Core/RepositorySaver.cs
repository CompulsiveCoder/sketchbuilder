using System;
using System.Web;
using sketchbuilder.Core;
using System.IO;

namespace sketchbuilder.Core
{
  
	public class RepositorySaver
	{
    public string RepositoriesDirectory;

    public RepositorySaver(string repositoriesDirectory)
    {
      RepositoriesDirectory = repositoriesDirectory;
    }

    public void Save(string repoName, string remoteRepositoryPath)
    {
      var repositoryFilePath = Path.Combine (RepositoriesDirectory, repoName);
      repositoryFilePath = Path.Combine (repositoryFilePath, "repository.txt");

      File.WriteAllText (repositoryFilePath, remoteRepositoryPath);
    }
	}

}

