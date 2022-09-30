using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FileManager : MonoBehaviour
{

    public int Remoteport = 25666;

    public UDPSender sender = new UDPSender();

    public string playerState;

    void Start()
    {
        sender.init("192.168.2.232", Remoteport, 25666);
        sender.sendString("Hello from Start. " + Time.realtimeSinceStartup);

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
            sender.sendString("This should be delivered");

        if (sender.newdatahereboys)
        {
            playerState = sender.getLatestUDPPacket();
        }
    }

    public void OnDisable()
    {
        sender.ClosePorts();
    }

    public void OnApplicationQuit()
    {
        sender.ClosePorts();
    }

}
