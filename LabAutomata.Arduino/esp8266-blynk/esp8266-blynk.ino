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

const int m_led_pin_high=6;
const int m_led_pin_low=5;
const int m_pot_pin = A0;
int m_pot_val {0};
int m_pin_val;

BLYNK_WRITE(V0) // LED high/low state
{
  Serial.print("Outputting V0");
  // setting digital pin 6 to type OUTPUT
  m_pin_val = param.asInt(); // assigning incoming value from pin V0 to a variable
  Serial.print("Converted to \n");
  Serial.print(m_pin_val);
  // You can also use:
  // String i = param.asStr();
  // double d = param.asDouble();

  if (m_pin_val) {
    digitalWrite(m_led_pin_high,1);
    digitalWrite(m_led_pin_low,0);
    
  } else {
     digitalWrite(m_led_pin_high,0);
    digitalWrite(m_led_pin_low,1);
  }
}

void potWrite() {
  if (!m_pin_val) {
    Blynk.virtualWrite(V1, 0);
    return;
  }

  m_pot_val = analogRead(m_pot_pin);  // set potVal
  Blynk.virtualWrite(V1, analogRead(m_pot_val)); // write potVal
}

void setup()
{
  // Debug console
  Serial.begin(9600);

  // Set ESP8266 baud rate
  EspSerial.begin(ESP8266_BAUD);
  delay(10);  // allows the serial connection to stabilize

  Blynk.begin(auth, wifi, ssid, pass);
  // You can also specify server:
  //Blynk.begin(auth, wifi, ssid, pass, "blynk.cloud", 80);
  //Blynk.begin(auth, wifi, ssid, pass, IPAddress(192,168,1,100), 8080);

   pinMode(m_led_pin_high,OUTPUT);
   pinMode(m_led_pin_low,OUTPUT);
   m_timer.setInterval(1000L, potWrite); // milliseconds datatype long; pointer to void callback
}

void loop()
{
  Blynk.run();
  m_timer.run();
  // You can inject your own code or combine it with other sketches.
  // Check other examples on how to communicate with Blynk. Remember
  // to avoid delay() function!
}