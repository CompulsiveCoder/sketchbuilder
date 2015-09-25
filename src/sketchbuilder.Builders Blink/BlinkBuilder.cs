using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using sketchbuilder.Core;

namespace sketchbuilder.Builders.GreenKit
{
  public class BlinkBuilder
  {
    public string TemplateCode { get; set; }

    public BlinkBuilder ()
    {
      TemplateCode = @"
// <LedPins>
const int ledPins[] = {13};
// </LedPins>

// <Delay>
const int interval = 1000;
// </Delay>

void setup() {          
  for (int i = 0; i < sizeof(ledPins); i++)
  {      
    pinMode(ledPins[i], OUTPUT);  
  }  
}

void loop() {
  for (int i = 0; i < sizeof(ledPins); i++)
  {
    digitalWrite(ledPins[i], !digitalRead(ledPins[i]));
  }
  delay(interval);
}
";
    }

		public string Build(int[] sensorPins, int delay)
    {
      var newCode = TemplateCode;

      newCode = InsertLedPins (newCode, sensorPins);

      newCode = InsertDelay (newCode, delay);

      return newCode;
    }

    public string InsertLedPins(string template, int[] sensorPins)
    {

      var sensorPinsCode = "const int ledPins[] = {";

      foreach (var pin in sensorPins) {
        sensorPinsCode += pin + ",";
      }
      sensorPinsCode = sensorPinsCode.TrimEnd (',');
      sensorPinsCode += "};";

      var parser = new Parser ();

      return parser.Insert (template, "LedPins", sensorPinsCode);
	}

	public string InsertDelay(string template, int delay)
	{

			var code = "const int interval = " + delay + ";";

		var parser = new Parser ();

			return parser.Insert (template, "Delay", code);
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

