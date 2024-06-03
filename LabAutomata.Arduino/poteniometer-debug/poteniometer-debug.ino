void setup() {
  //** Digital means there is only two possible values:
  //      HIGH state -> 1
  //      LOW state -> 0 
  //** Analog means the input/output can be any values between a minima and maxima:
  //      minima = 0; maxima = 1
  //      input could equal: 0.0, 0.35, 0.7, 0.99, 1.0

  // Digital: these in-between values are achieved by pulse-width-modulation (PWM) 
  // PWM occurs when we turn the digial bit on/off very-very quickly
  //    so quick that the human eye cannot perceive this rapid change
  //    the resultant is the appearance that the digital input is somewhere betwen high/low
  //    this is be the supplied power is not on for the full time period 't'
  // the ~ PWM on the Uno board allows us to simulate an analog output via PWM

  // makes digital pin #7 an OUTPUT pin that can
  //  be toggled on/off via HIGH/LOW
 
 
 // pinMode(7, OUTPUT);
  Serial.begin(9600); // serial seup - 9600 baud
  // put your setup code here, to run once:

}

float getVoltage(int reading) {
  const float scaleF = 5.0/1023;
  return scaleF * reading;
}

void runPhotoResistor() {
  //float v = getVoltage(analogRead(A0));
  int v = analogRead(A0);
  int lux = 2.09 * v - 856.05;
  Serial.println(lux);  // print
  delay(500);
}

void loop() {
  runPhotoResistor();
  // digitalWrite(7, HIGH);
  // delay(1000);
  // digitalWrite(7, LOW);
}

