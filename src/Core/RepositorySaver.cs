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

    public void SaveRepositoryPath(string repoName, string remoteRepositoryPath)
    {
      var repositoryFilePath = Path.Combine (RepositoriesDirectory, repoName);
      repositoryFilePath = Path.Combine (repositoryFilePath, "repository.txt");

      File.WriteAllText (repositoryFilePath, remoteRepositoryPath);
    }

    public void SaveRepositoryBranch(string repoName, string remoteRepositoryBranch)
    {
      var repositoryBranchFilePath = Path.Combine (RepositoriesDirectory, repoName);
      repositoryBranchFilePath = Path.Combine (repositoryBranchFilePath, "branch.txt");

      File.WriteAllText (repositoryBranchFilePath, remoteRepositoryBranch);
    }
	}

}

