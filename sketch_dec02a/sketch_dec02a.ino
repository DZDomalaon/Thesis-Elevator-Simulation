const int btnPin1 = 2;
const int btnPin2 = 3;
const int btnPin3 = 4;
const int btnPin4 = 5;

const int lift2 = 12;
const int lift3 = 13;


void setup() 
{
  Serial.begin(9600);
  
  pinMode(btnPin1, INPUT);
  pinMode(btnPin2, INPUT);
  pinMode(btnPin3, INPUT);
  pinMode(btnPin4, INPUT);
  pinMode(lift2, INPUT);
  pinMode(lift3, INPUT);

  digitalWrite(btnPin1, LOW);
  digitalWrite(btnPin2, LOW);
  digitalWrite(btnPin3, LOW);
  digitalWrite(btnPin4, LOW);
  digitalWrite(lift2, LOW);
  digitalWrite(lift3 , LOW);
}

void loop() 
{
  
  if(digitalRead(btnPin1) == HIGH)
  {
    Serial.print("UP");
    Serial.write(1);
    Serial.flush(); 
    delay(150);    
  }
  if(digitalRead(btnPin2) == HIGH)
  {
    while(digitalRead(btnPin2) == HIGH)
    {
      Serial.print("DOWN");
      Serial.write(2);
      Serial.flush();
      delay(300); 
    }
  }

  if(digitalRead(btnPin3) == HIGH)
  {
    Serial.print("LEFT");
    Serial.write(3);
    Serial.flush();
    delay(150);    
    
  }
  if(digitalRead(btnPin4) == HIGH)
  {
    Serial.print("RIGHT");
    Serial.write(4);
    Serial.flush();
    delay(150);
  }
  if(digitalRead(lift2) == HIGH)
  {
    Serial.print("lift2");
    delay(150);
  }

  if(digitalRead(lift3) == HIGH)
  {
    Serial.print("lift3");
    delay(150);
  }
}
