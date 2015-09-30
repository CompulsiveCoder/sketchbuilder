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
