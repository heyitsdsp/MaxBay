using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPSender
{
    public string IP { get; private set; }
    public int sourcePort { get; private set; } 
    public int remotePort { get; private set; }

    IPEndPoint remoteEndPoint;

    Thread receiveThread;

    // udpclient object
    UdpClient client;

    public int port = 25666; 

    // Information
    public string lastReceivedUDPPacket = "";
    public string allReceivedUDPPackets = ""; // Clean up this from time to time!

    public bool newdatahereboys = false;

    public void init(string IPAdress, int RemotePort, int SourcePort = -1) 
    {
        IP = IPAdress;
        sourcePort = SourcePort;
        remotePort = RemotePort;

        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), remotePort);
        if (sourcePort <= -1)
        {
            client = new UdpClient();
            Debug.Log("Sending to " + IP + ": " + remotePort);
        }
        else
        {
            client = new UdpClient(sourcePort);
            Debug.Log("Sending to " + IP + ": " + remotePort + " from Source Port: " + sourcePort);
        }

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    private void ReceiveData()
    {
        //client = sender.client;
        while (true)
        {
            try
            {

                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);

                //Debug.Log(text);
                newdatahereboys = true;
                lastReceivedUDPPacket = text;

                allReceivedUDPPackets = allReceivedUDPPackets + text;
            }
            catch (Exception err)
            {
                Debug.Log(err.ToString());
            }
        }
    }

    public void sendString(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);

        }
        catch (Exception err)
        {
            Debug.Log(err.ToString());
        }
    }

    public void sendInt32(Int32 myInt)
    {
        try
        {
            byte[] data = BitConverter.GetBytes(myInt);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            Debug.Log(err.ToString());
        }
    }

    public void sendInt32Array(Int32[] myInts)
    {
        try
        {
            byte[] data = new byte[myInts.Length * sizeof(Int32)];
            Buffer.BlockCopy(myInts, 0, data, 0, data.Length);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            Debug.Log(err.ToString());
        }
    }

    public void sendInt16Array(Int16[] myInts)
    {
        try
        {
            byte[] data = new byte[myInts.Length * sizeof(Int16)];
            Buffer.BlockCopy(myInts, 0, data, 0, data.Length);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            Debug.Log(err.ToString());
        }
    }

    public string getLatestUDPPacket()
    {
        allReceivedUDPPackets = "";
        return lastReceivedUDPPacket;
    }

    public void ClosePorts()
    {
        Debug.Log("closing receiving UDP on port: " + port);

        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }
}
