void setup() {
  // put your setup code here, to run once:
  //ayar kısmı

pinMode (10,OUTPUT);
pinMode (11,OUTPUT);
pinMode (12,OUTPUT);
pinMode (6,OUTPUT);
pinMode (7,OUTPUT);
pinMode (8,OUTPUT);
pinMode (2,OUTPUT);
pinMode (3,OUTPUT);
pinMode (4,OUTPUT);

Serial.begin (9600);

}

void loop() {
  // put your main code here, to run repeatedly:aksiyon kısmı 



if (Serial.available())
{
int a=Serial.read();

if(a=='1') {digitalWrite(10,HIGH); digitalWrite(11,LOW);digitalWrite(12,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW); digitalWrite(4,LOW); digitalWrite(6,LOW); digitalWrite(7,LOW); digitalWrite(8,LOW);} 
if(a=='2') {digitalWrite(11,HIGH);digitalWrite(12,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW); digitalWrite(4,LOW); digitalWrite(6,LOW); digitalWrite(7,LOW); digitalWrite(8,LOW); digitalWrite(10,LOW);}
if(a=='3') {digitalWrite(12,HIGH);digitalWrite(11,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW); digitalWrite(4,LOW); digitalWrite(6,LOW); digitalWrite(7,LOW); digitalWrite(8,LOW); digitalWrite(10,LOW);}
if(a=='4') {digitalWrite(6,HIGH);digitalWrite(11,LOW);digitalWrite(12,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW); digitalWrite(4,LOW);  digitalWrite(7,LOW); digitalWrite(8,LOW); digitalWrite(10,LOW);}
if(a=='5') {digitalWrite(7,HIGH);digitalWrite(11,LOW);digitalWrite(12,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW); digitalWrite(4,LOW); digitalWrite(6,LOW);  digitalWrite(8,LOW); digitalWrite(10,LOW);}
if(a=='6') {digitalWrite(8,HIGH);digitalWrite(11,LOW);digitalWrite(12,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW); digitalWrite(4,LOW); digitalWrite(6,LOW); digitalWrite(7,LOW);  digitalWrite(10,LOW);}
if(a=='7') {digitalWrite(2,HIGH);digitalWrite(11,LOW);digitalWrite(12,LOW);  digitalWrite(3,LOW); digitalWrite(4,LOW); digitalWrite(6,LOW); digitalWrite(7,LOW); digitalWrite(8,LOW); digitalWrite(10,LOW);}
if(a=='8') {digitalWrite(3,HIGH);digitalWrite(11,LOW);digitalWrite(12,LOW); digitalWrite(2,LOW);  digitalWrite(4,LOW); digitalWrite(6,LOW); digitalWrite(7,LOW); digitalWrite(8,LOW); digitalWrite(10,LOW);}
if(a=='9') {digitalWrite(4,HIGH);digitalWrite(11,LOW);digitalWrite(12,LOW); digitalWrite(2,LOW); digitalWrite(3,LOW);  digitalWrite(6,LOW); digitalWrite(7,LOW); digitalWrite(8,LOW); digitalWrite(10,LOW);}

}
}
