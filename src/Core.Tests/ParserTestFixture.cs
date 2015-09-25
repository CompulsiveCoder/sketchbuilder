using System;
using NUnit.Framework;
using System.IO;

namespace sketchbuilder.Core.Tests
{
  [TestFixture]
  public class ParserTestFixture
  {
    [Test]
    public void Test_Insert()
    {

      var parser = new Parser();

      var template =  @"My test
// <CustomTag>
Hello world!
// </CustomTag>

End file
";

      var tag = "CustomTag";

      var value = "Hello universe!";

      var output = parser.Insert (template, tag, value);

      Assert.IsTrue(output.Contains(value));
      Console.WriteLine (output);
    }
  }
}

