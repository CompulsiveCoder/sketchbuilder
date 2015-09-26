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
// <PinCount>
const int pinCount = 1;
// </PinCount>
 
// <LedPins>
const int ledPins[] = {13};
// </LedPins>

int ledPinState[pinCount];

// <Delay>
const int interval = 1000;
// </Delay>

void setup() {          
  for (int i = 0; i < pinCount; i++)
  {      
    pinMode(ledPins[i], OUTPUT);  
  }  
}

void loop() {
  for (int i = 0; i < pinCount; i++)
  {
    ledPinState[i] = !ledPinState[i];
    digitalWrite(ledPins[i], ledPinState[i]);
  }
  delay(interval);
}

";
    }

		public string Build(int[] sensorPins, int delay)
    {
      var newCode = TemplateCode;

      newCode = InsertPinCount (newCode, sensorPins.Length);

      newCode = InsertLedPins (newCode, sensorPins);

      newCode = InsertDelay (newCode, delay);

      return newCode;
    }

    public string InsertPinCount(string template, int pinCount)
    {

      var code = "const int pinCount = " + pinCount + ";";

      var parser = new Parser ();

      return parser.Insert (template, "PinCount", code);
    }

    public string InsertLedPins(string template, int[] sensorPins)
    {

      var code = "const int ledPins[] = {";

      foreach (var pin in sensorPins) {
        code += pin + ",";
      }
      code = code.TrimEnd (',');
      code += "};";

      var parser = new Parser ();

      return parser.Insert (template, "LedPins", code);
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

