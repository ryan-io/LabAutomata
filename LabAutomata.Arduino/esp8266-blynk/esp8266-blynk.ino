/*************************************************************
  WARNING!
    It's very tricky to get it working. Please read this article:
    http://help.blynk.cc/hardware-and-libraries/arduino/esp8266-with-at-firmware

  You can use this sketch as a debug tool that prints all incoming values
  sent by a widget connected to a Virtual Pin 1 in the Blynk App.

  App project setup:
    Slider widget (0...100) on V1
 *************************************************************/

// Template ID, Device Name and Auth Token are provided by the Blynk.Cloud
// this sketch requires you to define a 'credentials.h' folder
// that contains the information related to your network and Blynk account
// create the 'credentials.h' file in:
//      LabAutomata\LabAutomata.Arduino\libraries\credentials\

#include "credentials.h"
#include "DHT.h"
#include <ESP8266_Lib.h>
#include <BlynkSimpleShieldEsp8266.h>
#include <SoftwareSerial.h>

// Comment this out to disable prints and save space
#define BLYNK_PRINT Serial

// Your ESP8266 baud rate:
#define ESP8266_BAUD 9600
// baud rate should only be 600

// Hardware Serial on Mega, Leonardo, Micro...
// #define EspSerial Serial1
// or Software Serial on Uno, Nano...
SoftwareSerial EspSerial(2, 3); // TX, RX
ESP8266 wifi(&EspSerial);
BlynkTimer m_timer;
DHT m_dhtSys1;

const int LedOnPin=4;
const int LedOffPin=5;
const int DhtSys1Pin=6;
int BlynkSignal;

BLYNK_WRITE(V0) // LED high/low state
{
  Serial.print("Outputting V0");
  // setting digital pin 6 to type OUTPUT
  BlynkSignal = param.asInt(); // assigning incoming value from pin V0 to a variable
  Serial.print("Converted to \n");
  Serial.print(BlynkSignal);
  delay(10);
  // You can also use:
  // String i = param.asStr();
  // double d = param.asDouble();

  if (BlynkSignal) {
    digitalWrite(LedOnPin,1);
    digitalWrite(LedOffPin,0);
    delay(10);
    
  } else {
     digitalWrite(LedOnPin,0);
    digitalWrite(LedOffPin,1);
    delay(10);
  }
}

// void potWrite() {
//   if (!BlynkSignal) {
//     Blynk.virtualWrite(V1, 0);
//     return;
//   }

//   m_pot_val = analogRead(m_pot_pin);  // set potVal
//   Blynk.virtualWrite(V1, analogRead(m_pot_val)); // write potVal
// }

void write() {
  float humidity = m_dhtSys1.getHumidity();
  float temperature = m_dhtSys1.getTemperature();
  Blynk.virtualWrite(V2, temperature);
  Blynk.virtualWrite(V3, humidity);
  delay(10);
}

void setup()
{
  // Debug console
  Serial.begin(9600);

  // Set ESP8266 baud rate
  EspSerial.begin(ESP8266_BAUD);
  delay(10);  // allows the serial connection to stabilize

  m_dhtSys1.setup(DhtSys1Pin);
  Blynk.begin(auth, wifi, ssid, pass);
  // You can also specify server:
  //Blynk.begin(auth, wifi, ssid, pass, "blynk.cloud", 80);
  //Blynk.begin(auth, wifi, ssid, pass, IPAddress(192,168,1,100), 8080);

   pinMode(LedOnPin,OUTPUT);
   pinMode(LedOffPin,OUTPUT);
   m_timer.setInterval(1000L, write); // milliseconds datatype long; pointer to void callback
}

void loop()
{
  Blynk.run();
  m_timer.run();
  delay(100);
  // You can inject your own code or combine it with other sketches.
  // Check other examples on how to communicate with Blynk. Remember
  // to avoid delay() function!
}