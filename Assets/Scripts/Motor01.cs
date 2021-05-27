using System; // For String, Int32, Console, ArgumentException
using System.Text; // For Encoding
using System.IO; // For IOException
using System.Net.Sockets; // For TcpClient, NetworkStream, SocketException
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;
using UnityEngine.UI;

public class Motor01 : MonoBehaviour
{

    
    //byte[] byteBuffer = Encoding.ASCII.GetBytes(carIpPort);

    //byte[] byteBuffer = Encoding.ASCII.GetBytes(carIpPort);

    //String server = args[0]; // Server name or IP address
    //String server = carIpAdress; // Server name or IP address

    // Convert input String to bytes

    // Use port argument if supplied, otherwise default to 7

    byte[] byteBuffer;
    public string server;
    public int servPort;
    public Vector2 engineSpeed;
    public float engine1500Forward;
    public float engine1500Turn;
    public string engineSpeedString;
    public string engineTurnString;
    public string engineCommand;


    TcpClient client = null;
    NetworkStream netStream = null;


    

    public void Start()

    {


        // Create socket that is connected to server on specified port
        client = new TcpClient(server, servPort);
            Console.WriteLine("Connected to server... sending echo string");
            
        netStream = client.GetStream();
     }

    public void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        Text textUI = GameObject.Find("Canvas/textEngine").GetComponent<Text>();
        engineSpeed = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        engine1500Forward = engineSpeed[1] * 1500;
        engine1500Turn = engineSpeed[0] * 1500;



        if ((int)Math.Round(engine1500Forward, 0)!=0) 

        {
            // Switch on the engine
            engineTurnString  = ((int)Math.Round(engine1500Turn, 0)).ToString();
            engineSpeedString = ((int)Math.Round(engine1500Forward, 0)).ToString();
            engineCommand = "CMD_MOTOR#" + engineSpeedString + "#" + engineSpeedString + "#" + engineSpeedString + "#" + engineSpeedString + "\n";
            //byteBuffer = Encoding.ASCII.GetBytes("CMD_MOTOR#1500#1500#1500#1500\n");
            byteBuffer = Encoding.ASCII.GetBytes(engineCommand);


            netStream.Write(byteBuffer, 0, byteBuffer.Length);
                Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);
            textUI.text = engineCommand;
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
               // Switch off the engine
                byteBuffer = Encoding.ASCII.GetBytes("CMD_MOTOR#0000#0000#0000#0000\n");
                netStream.Write(byteBuffer, 0, byteBuffer.Length);
                Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);
        }

    }

}



