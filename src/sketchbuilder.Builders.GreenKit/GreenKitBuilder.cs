using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using sketchbuilder.Core;

namespace sketchbuilder.Builders.GreenKit
{
  public class GreenKitBuilder
  {
    public string SourcePath { get; set; }

    public GreenKitBuilder (string sourcePath)
    {
      SourcePath = sourcePath;
    }

    public string Build(int[] sensorPins, int[] pumpPins, int[] thresholdPins)
    {

      var templateFileName = Path.Combine (SourcePath, "template.ino");

      var templateCode = File.ReadAllText (templateFileName);

      var newCode = templateCode;

      newCode = InsertSensorPinCount (newCode, sensorPins.Length);

      newCode = InsertSensorPins (newCode, sensorPins);

      newCode = InsertPumpPins (newCode, pumpPins);

      newCode = InsertThresholdPins (newCode, thresholdPins);

      return newCode;
    }

    public string InsertSensorPinCount(string template, int pinCount)
    {

      var code = "const int sensorPinCount = " + pinCount + ";";

      var parser = new Parser ();

      return parser.Insert (template, "SensorPinCount", code);
    }

    public string InsertSensorPins(string template, int[] sensorPins)
    {

      var codeSnippet = "const int sensorPins[] = {";

      foreach (var pin in sensorPins) {
        codeSnippet += pin + ",";
      }
      codeSnippet = codeSnippet.TrimEnd (',');
      codeSnippet += "};";

      var parser = new Parser ();

      return parser.Insert (template, "SensorPins", codeSnippet);
    }

    public string InsertPumpPins(string template, int[] pumpPins)
    {

      var codeSnippet = "const int pumpPins[] = {";

      foreach (var pin in pumpPins) {
        codeSnippet += pin + ",";
      }
      codeSnippet = codeSnippet.TrimEnd (',');
      codeSnippet += "};";

      var parser = new Parser ();

      return parser.Insert (template, "PumpPins", codeSnippet);
    }


    public string InsertThresholdPins(string template, int[] thresholdPins)
    {

      var codeSnippet = "int thresholdPins[] = {";

      foreach (var pin in thresholdPins) {
        codeSnippet += pin + ",";
      }
      codeSnippet = codeSnippet.TrimEnd (',');
      codeSnippet += "};";

      var parser = new Parser ();

      return parser.Insert (template, "ThresholdPins", codeSnippet);
    }

    public string ToString(List<char> chars)
    {
      var output = String.Empty;

      foreach (var c in chars.ToArray())
      {
        output += c.ToString();
      }

      return output;
    }
  }
}

