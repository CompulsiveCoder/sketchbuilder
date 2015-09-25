using System;
using System.Collections.Generic;

namespace sketchbuilder.Core
{
  public class Parser
  {
    public Parser()
    {
    }

    public string Insert(string template, string tag, string value)
    {
      var startTag = "<" + tag + ">";
      var startPosition = template.IndexOf (startTag);
      startPosition += startTag.Length;

      var endPosition = template.IndexOf ("// </" + tag + ">");
      endPosition -= Environment.NewLine.Length;

      var length = endPosition - startPosition;
      var innerContent = template.Substring (startPosition, length);
      innerContent = innerContent.Trim ();

      var chars = new List<char>(template.ToCharArray());

      for (int i = endPosition; i > startPosition; i--) {
        var c = chars [i];
        chars.RemoveAt (i);
      }


      var position = startPosition;
      chars.Insert (position, '\n');
      position++;
      foreach (var c in value.ToCharArray()) {
        chars.Insert(position, c);
        position++;
      }

      return ToString (chars.ToArray());
    }

    public string ToString(char[] chars)
    {
      var output = String.Empty;

      foreach (var c in chars)
      {
        output += c.ToString();
      }

      return output;
    }
  }
}

