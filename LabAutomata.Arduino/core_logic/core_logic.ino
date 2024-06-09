// Template ID, Device Name and Auth Token are provided by the Blynk.Cloud
// this sketch requires you to define a 'credentials.h' folder
// that contains the information related to your network and Blynk account
// create the 'credentials.h' file in:
//      LabAutomata\LabAutomata.Arduino\libraries\credentials\

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ includes
#include "credentials.h"
#include <BlynkSimpleShieldEsp8266.h>
#include <SoftwareSerial.h>
#include <PubSubClient.h>
#include <NTPCLient.h>
#include <ESP8266WiFi.h>
#include <WiFiUdp.h>

// library for DHT11 & DHT22, non-blocking
#include "DHT.h"
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ defines
// Comment this out to disable prints and save space
#define BLYNK_PRINT Serial

// ESP8266 baud rate:
#define ESP8266_BAUD 9600

#define SYS1_TEMP_VPIN V2
#define SYS2_TEMP_VPIN V3
#define SYS3_TEMP_VPIN V4
#define SYS1_RH_VPIN V5

// uncomment the appropriate temp/humidity sensor time for a
// default sampling rate
// const long DhtSampleRate =  1000L;  // DHT11
const long DhtSampleRate = 2000L;       // DHT22

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ object allocations
// hardware Serial on Mega, Leonardo, Micro...
// #define EspSerial Serial1
// or Software Serial on Uno, Nano...
SoftwareSerial m_esp8266Serial(2, 3); // TX, RX

// wifi connectivity
ESP8266 m_wiFi(&m_esp8266Serial);

// timer for writing to Blynk virtual pins and publishing 
// MQTT message w/ sensor payload
BlynkTimer m_timerDhtSampleRate;

// object to consume DHT API
DHT m_dhtSys1;
DHT m_dhtSys2;
DHT m_dhtSys3;
int m_blynkSignal;

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ pins
const int LedOnPin=4;
const int LedOffPin=5;
const int DhtSys1Pin=6;
const int DhtSys2Pin=7;
const int DhtSys3Pin=8;

// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ code
BLYNK_WRITE(V0) // LED high/low state
{
  // You can also use:
  // String i = param.asStr();
  // double d = param.asDouble();
  m_blynkSignal = param.asInt(); // assigning incoming value from pin V0 to a variable
  
  if (m_blynkSignal) {
    digitalWrite(LedOnPin,1);
    digitalWrite(LedOffPin,0);
  } else {
     digitalWrite(LedOnPin,0);
    digitalWrite(LedOffPin,1);
  }
}

void write() {
  float humidity1 = m_dhtSys1.getHumidity();
  float temperature1 = m_dhtSys1.getTemperature();

  float humidity2 = m_dhtSys2.getHumidity();
  float temperature2 = m_dhtSys2.getTemperature();

  float humidity3 = m_dhtSys3.getHumidity();
  float temperature3 = m_dhtSys3.getTemperature();

  // print("Sensor 1", temperature1, humidity1);
  // print("Sensor 2", temperature2, humidity2);
  // print("Sensor 3", temperature3, humidity3);
  // Serial.println("~~~~~~~~~~~~~~~~~~~~");

  Blynk.beginGroup();
  Blynk.virtualWrite(SYS1_TEMP_VPIN, temperature1);
  Blynk.virtualWrite(SYS2_TEMP_VPIN, temperature2);
  Blynk.virtualWrite(SYS3_TEMP_VPIN, temperature3);
  Blynk.virtualWrite(SYS1_RH_VPIN, humidity1);
  Blynk.endGroup();

  Blynk.syncVirtual(SYS1_TEMP_VPIN,SYS2_TEMP_VPIN, SYS3_TEMP_VPIN, SYS1_RH_VPIN);
}

// serial print 
// void print(char*name, float t, float h) {
//   Serial.print(name);
//   Serial.print(":  Temperature: ");
//   Serial.print(t);
//   Serial.print(" -- Humidity: ");
//   Serial.print(h);
//   Serial.print('\n');
// }

void setup()
{
  Serial.begin(9600);

  // set ESP8266 baud rate
  m_esp8266Serial.begin(ESP8266_BAUD);

  delay(10);  // allows the serial connection to stabilize
  
  m_timerDhtSampleRate.setInterval(DhtSampleRate, write);
  //m_mqttClient.setClient();
  m_dhtSys1.setup(DhtSys1Pin);
  m_dhtSys2.setup(DhtSys2Pin);
  m_dhtSys3.setup(DhtSys3Pin);

  Blynk.begin(auth, m_wiFi, ssid, pass);
  // You can also specify server:
  //Blynk.begin(auth, wifi, ssid, pass, "blynk.cloud", 80);
  //Blynk.begin(auth, wifi, ssid, pass, IPAddress(192,168,1,100), 8080);

   pinMode(LedOnPin,OUTPUT);
   pinMode(LedOffPin,OUTPUT);

   //m_timer.setInterval(1000L, write); // milliseconds datatype long; pointer to void callback
}

// avoid the use of delay() in loop() with Blynk
// use Blynk's timers
// these timers are implemented with SimpleTimer which is non-blocking
// and will result in a better UX
void loop()
{
  Blynk.run();
  m_timerDhtSampleRate.run();
}