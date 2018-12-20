
int konum;
int bekleme;

void setup() 
{
pinMode (8,OUTPUT);
pinMode (9,OUTPUT);
pinMode (10,OUTPUT);
pinMode (11,OUTPUT);
digitalWrite(8,LOW);
digitalWrite(9,LOW);
digitalWrite(10,LOW);
digitalWrite(11,LOW);
konum=8;
bekleme=3;
Serial.begin (9600);
}

void loop() 
{

int a=Serial.read();
delay(50);

if(a=='1')
{
sola(5);
}
if(a=='2')
{
saga(5);
}
if(a=='3')
{
  sola(0);
  saga(0);
 }


}

void sola(int adim)
{
 
  for (int i=0;i<adim;i++){
    digitalWrite(konum,HIGH);
    delay(bekleme);
    digitalWrite(konum,LOW);
    konumarttir(); 
     
    }
 
 }

 void saga(int adim)
{

  for (int i=0;i<adim;i++){
    digitalWrite(konum,HIGH);
    delay(bekleme);
    digitalWrite(konum,LOW);
    konumazalt();
    }

 }

void konumarttir(){
  konum++;
   
  if (konum==12)konum=8;
  }
void konumazalt(){
  konum--;
  if (konum==7)konum=11;
  }






 
