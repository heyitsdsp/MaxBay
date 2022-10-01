#include <ESP8266WiFi.h>
#include <WiFiUdp.h>
#include <Adafruit_MPU6050.h>
#include <Adafruit_Sensor.h>
#include <Wire.h>

const char* ssid = "Galaxy J6D0AF";
const char* password = "heyitsdsp#68+1";

Adafruit_MPU6050 mpu;
float threshold = 3;

char player_state;
bool player_shoot;

WiFiUDP Udp;
unsigned int port = 25666;
char packet[255];

IPAddress ip(192, 168, 12, 239);
IPAddress gateway(192, 168, 21, 131);
IPAddress subnet(255, 255, 255, 0);

void setup()
{
  Serial.begin(115200);
  Serial.println();

  if (!mpu.begin()) {
  Serial.println("Failed to find MPU6050 chip");
  while (1) {
  delay(10);
  }
  }

  mpu.setAccelerometerRange(MPU6050_RANGE_8_G);
  mpu.setGyroRange(MPU6050_RANGE_500_DEG);
  mpu.setFilterBandwidth(MPU6050_BAND_21_HZ);

  WiFi.hostname("NODE-MC_UWU");
  WiFi.config(ip, gateway, subnet);

  Serial.printf("Connecting to %s ", ssid);
  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    Serial.print(".");
  }

  Serial.println("Connection Successful");
  Udp.begin(port);
  Serial.printf("Listener started at IP %s, at port %d", WiFi.localIP().toString().c_str(), port);
  Serial.println();
}

void loop()
{
  sensors_event_t a, g, temp;
  mpu.getEvent(&a, &g, &temp);

  // Player movement!
  if(g.gyro.x <= threshold * -1)
  {
    player_state = 'L';
  }
  else if(g.gyro.x >= threshold)
  {
    player_state = 'R';
  }
  
  // Player shooting!
  if(player_state == 'L' && g.gyro.y <= threshold * -1)
  {
    player_shoot = true;
  }
  else if(player_state == 'R' && g.gyro.y >= threshold)
  {
    player_shoot = true;
  }
  else if(g.gyro.z >= threshold)
  {
    player_shoot = true;
  }
  else
  {
    player_shoot = false;
  }
  
  int packetSize = Udp.parsePacket();
  if (packetSize)
  {
    Serial.printf("Received %d bytes from %s, port %d", packetSize, Udp.remoteIP().toString().c_str(), Udp.remotePort());
    int len = Udp.read(packet, 255);
    if (len > 0)
    {
      packet[len] = 0;
    }
    Serial.printf("UDP packet contents: %s", packet);
    Serial.println();
  }

  String randata = String(random(100));
  char char_array[randata.length() + 1];
  randata.toCharArray(char_array, randata.length()+1);
  Udp.beginPacket (Udp.remoteIP(), Udp.remotePort());
  Udp.write(player_state);
  Udp.endPacket();

  delay(300);
}
