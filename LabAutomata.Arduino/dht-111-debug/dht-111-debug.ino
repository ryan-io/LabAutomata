#include <DFRobot_DHT11.h>
DFRobot_DHT11 DHT;
#define DHT11_PIN 11

void setup(){
  Serial.begin(9600);
}

void loop(){
  DHT.read(DHT11_PIN);
  Serial.print("temp:");
  Serial.print(DHT.temperature, 1);
  Serial.print("  humi:");
  Serial.println(DHT.humidity, 1);
  delay(1000);
}