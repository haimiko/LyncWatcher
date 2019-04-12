/* 
 * LyncWatcher Arduino sketch
 * Written by Haim Lichaa  2016
 * 
 */
#define VERSION ";1.06;"
#define RED 11   //RED LED lead connected to D11
#define GREEN 10 //GREEN LED lead connected to D10
#define BLUE 9  //BLUE LED lead connected to D9
#define FADETIME 50

int brightness = 25;    // how bright the LED is
int fadeAmount = 5;    // how many points to fade the LED by
const int MIN = brightness;
const int MAX = 200;
void setup()
{
  Serial.begin(9600);
  //Setup the digital pins for output mode
  pinMode(RED, OUTPUT);
  pinMode(GREEN, OUTPUT);
  pinMode(BLUE, OUTPUT);

}

int led = 1;

void loop()
{

  switch (led){
      case 48: //OFF
        oFF();
        break; 
      case 49:
        redFade();
        break;
      case 51://GREEN 
        greenFade();
        break;
      case 50://BLUE
        blueFade();
        break;
      case 52://ALL
      allFade();
      break;
      case 53://FASTRED
      //redFadeFast();
      fast(RED,BLUE,GREEN);
       break;
      case 54:
      digitalWrite(RED,HIGH); //solid red
      digitalWrite(GREEN,LOW); //solid red
      digitalWrite(BLUE,LOW); //solid red
      break;
       case 55:
       digitalWrite(RED,LOW); //solid GREEN
      digitalWrite(GREEN,HIGH); //solid GREEN
      digitalWrite(BLUE,LOW); //solid red
      break;
       case 56:
        digitalWrite(RED,LOW); //solid BLUE
      digitalWrite(GREEN,LOW); //solid GREEN
      digitalWrite(BLUE,HIGH); //solid red
      break;
      case 57:
        fast(BLUE,RED,GREEN);
        break;
      case 121:
        YellowFade();
        break;

  }
  
  if (Serial.available())
  {
    led=Serial.read();
    if (led != 118)
      Serial.println(led);
    switch (led)
    {
     case 118: //V key prints version
      Serial.println(VERSION);
      break;
    case 48: //OFF
      oFF();
      break;
    case 49://RED
     redFade();
      break;
    case 50://BLUE
      blueFade();
      break;
    case 51://GREEN 
      greenFade();
      break;
    case 52://ALL
      allFade();
      break;

    case 53://FASTRED
     // redFadeFast();
     fast(RED,GREEN,BLUE);
      break;
     case 121:
        YellowFade();
        break;
    }
  }
  //Serial.write(led);
}

void oFF(){
     // set the brightness of pin 9:
    analogWrite(RED, 0);
    analogWrite(BLUE, 0);
    analogWrite(GREEN, 0);

}


void redFade(){
     // set the brightness of pin 9:
    analogWrite(RED, brightness);
    analogWrite(BLUE, 0);
    analogWrite(GREEN, 0);
    // change the brightness for next time through the loop:
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(FADETIME);
}

/*
void redFadeFast(){
     // set the brightness of pin 9:
    analogWrite(RED, brightness);
    analogWrite(BLUE, 0);
    analogWrite(GREEN, 0);
    // change the brightness for next time through the loop:
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(10);
}
*/
void fast(int COLOR,int OFFCOLOR1, int OFFCOLOR2){
    analogWrite(COLOR, brightness);
    analogWrite(OFFCOLOR1, 0);
    analogWrite(OFFCOLOR2, 0);
    // change the brightness for next time through the loop:
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(10);
}


void greenFade(){
     // set the brightness of pin 9:
    analogWrite(GREEN, brightness);
    analogWrite(BLUE, 0);
    analogWrite(RED, 0);
    // change the brightness for next time through the loop:
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(FADETIME);
}


void blueFade(){
     // set the brightness of pin 9:
    analogWrite(BLUE, brightness);
    analogWrite(GREEN, 0);
    analogWrite(RED, 0);
    // change the brightness for next time through the loop:
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(FADETIME);
}


void allFade(){
     // set the brightness of pin 9:
    analogWrite(BLUE, brightness);
    analogWrite(GREEN, brightness);
    analogWrite(RED, brightness/2);
    // change the brightness for next time through the lo01
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(FADETIME);
}


void YellowFade(){
     // set the brightness of pin 9:
    analogWrite(BLUE, 0);
    analogWrite(GREEN, brightness-15);
    analogWrite(RED, brightness);
    // change the brightness for next time through the lo01
    brightness = brightness + fadeAmount;
  
    // reverse the direction of the fading at the ends of the fade:
    if (brightness <= MIN || brightness >= MAX) {
      fadeAmount = -fadeAmount;
    }
    // wait for 30 milliseconds to see the dimming effect
    delay(FADETIME);
}


