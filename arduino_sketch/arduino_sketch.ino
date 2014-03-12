bool pinModes[12] = {true, false, false, false, false, false, false, false, false, false, false, false};;
bool inSetup = false;
int setupCount = 0;

void setup() {                
  pinMode(2, INPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);
  
  Serial.begin(9600);
}

void loop() {
  while(Serial.available())
  {
    int c = Serial.read();
    if(c == 33)
    {
      inSetup = true;
    }
    if(inSetup)
    {
      //cycle through pins, 2-13 (1)nput/(0)utput
      if(c == '1')
      {
        pinModes[setupCount] = true;
        pinMode(setupCount+2, INPUT);
        setupCount++;
      } else if(c == '0')
      {
        pinModes[setupCount] = false;
        pinMode(setupCount+2, OUTPUT);
        setupCount++;
      } else if(c == '+')
      {
        inSetup = false;
        setupCount = 0;
      }
    } else {
      //output pins
      if(c > 96 && c < 121)
      {
        if(c > 108)
        {
          digitalWrite(c-107, HIGH);
        } else {
          digitalWrite(c-95, LOW);
        }
      }
    }
  }
  
  //input pins
  if(!inSetup)
  {
    for(int i = 0; i < 12; i++)
    {
      if(pinModes[i])
      {
        Serial.write(i+65);
        Serial.write(digitalRead(i+2));
      }
    }
  }
}
