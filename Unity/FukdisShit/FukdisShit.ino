
//Defining the pins:
#include <Wire.h> //Including libraries for OLED display
#include <SeeedOLED.h>
const int upButton = A0; //Move up to digital pin 7
const int downButton = A2; //Move down to digital pin 6
const int tilt2Sens = 7;
const int tiltSens = 3; //Tilt sensor to digital pin 5
const int pushB = 4; 
int timerLight;
int timerDark;
int UnityVariable;
int timer = 0;

int counter = 0;

bool tilt = false;
bool Begin = true;


void setup() {
  
  
  //Initializing the sensors as inputs:
  pinMode(upButton, INPUT);
  pinMode(downButton, INPUT);
  pinMode(tiltSens,INPUT);
  pinMode(tilt2Sens,INPUT);
  pinMode(pushB,INPUT);
  
  //Defining the diitalWrite
 // digitalWrite(upButton,HIGH);
  //digitalWrite(downButton,HIGH);
  digitalWrite(tiltSens,HIGH);
  digitalWrite(tilt2Sens,HIGH);
  digitalWrite(pushB,HIGH);
  //Initializing the Serial monitor
  Serial.begin(9600);
  
   Wire.begin();
  SeeedOled.init();  //initialze SEEED OLED display
  DDRB|=0x21;        
  PORTB |= 0x21;
  
  SeeedOled.clearDisplay();           //clear the screen and set start position to top left corner
  SeeedOled.setNormalDisplay();       //Set display to Normal mode
  SeeedOled.setPageMode();            //Set addressing mode to Page Mode
  SeeedOled.setTextXY(1,0);
  SeeedOled.putString("Light Time Left:");
  SeeedOled.setTextXY(3,0); 
  SeeedOled.putNumber(00);
 
  SeeedOled.setTextXY(5,0);
  SeeedOled.putString("Dark Time Left :");
  SeeedOled.setTextXY(7,0); 
  SeeedOled.putNumber(00);
  
}

void loop() {
  
  // Reading the states of the sensors 
 

  if(Begin == true)
  {
      if(Serial.find("Begin"))
      {
      timer = 0; 
      Begin = false;
      }
    }

  if (analogRead(upButton)> 950)
{
  Serial.write(1);
  Serial.flush();
  delay(15);
}
  if (analogRead(downButton)> 950)
{
  Serial.write(2);
  Serial.flush();
  delay(15);

}
  if (digitalRead(tiltSens)== HIGH && digitalRead(tilt2Sens)== LOW && tilt == false)
{
  tilt = true;
  Serial.write(3);
  Serial.flush();
  delay(30);
}

if (digitalRead(tiltSens)== LOW && digitalRead(tilt2Sens)== HIGH && tilt == true)
{
  tilt = false;
  Serial.write(4);
  Serial.flush();
  delay(30);
}

  if (timerLight <= 9){
    SeeedOled.setTextXY(3,1); 
    SeeedOled.putNumber(timerLight);
    SeeedOled.setTextXY(3,0); 
    SeeedOled.putNumber(0);
    }
  else
   {
    SeeedOled.setTextXY(3,0); 
    SeeedOled.putNumber(timerLight);
   }
 
  if (timerDark <= 9)
  {
    SeeedOled.setTextXY(7,1); 
    SeeedOled.putNumber(timerDark);
    SeeedOled.setTextXY(7,0); 
    SeeedOled.putNumber(0);
   }
   else
   {
   SeeedOled.setTextXY(7,0); 
    SeeedOled.putNumber(timerDark);
   }

if(tilt == true)
{
timer++;
delay(25);

}
else
{
timer--;
delay(25);
}

//
timerLight = 10 + (timer/20);
timerDark  = 10 - (timer/20);

if (timerDark < 0 || timerLight <0)
{
  Serial.write(7);
  Begin = true;
  delay(50);
  Serial.flush();
  
}



}
