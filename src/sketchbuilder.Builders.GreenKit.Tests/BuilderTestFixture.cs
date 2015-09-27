using System;
using NUnit.Framework;

namespace sketchbuilder.Builders.GreenKit.Tests
{
  [TestFixture]
  public class BuilderTestFixture
  {
    [Test]
    public void Test_Build()
    {
      var src = "/home/j/cloud/primary/Projects/devkit/template";

      var builder = new GreenKitBuilder (src);

      var output = builder.Build (new int[]{ 1, 2 }, new int[]{5,6}, new int[]{4,5});

      Console.WriteLine (output);
    }
  }
}

