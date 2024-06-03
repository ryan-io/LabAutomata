// sda - i2c data line
// scl - i2c clock line

#include "LCDIC2.h"
#define INITIAL "Lab Automata"

// the i2c addres is 0x27 -> I'm not sure if this differs or is unique to 1602?
// 16 -> number of columns
// 2 -> number of rows
LCDIC2 lcd(0x27, 16, 2);  //

void setup() {
  if (lcd.begin()) // reset if needed
  
   lcd.print(INITIAL); // set the initial output to this
}

void loop() {
  for (uint8_t i = 0; i < 15; i++) {
    lcd.setCursor(i, 1);
    delay(250);
  }
  for (uint8_t i = 15; i > 0; i--) {
    lcd.setCursor(i, 1);
    delay(250);
  }
}