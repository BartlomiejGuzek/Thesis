using UnityEngine;
using System.IO.Ports;
using System.Collections;
using System;
using System.Threading;

public class Controller : MonoBehaviour
{
	public float smoothFactor = 2000;						// #DEBUG value that multiplies rotation values
	public float x, y, z;                                   // values from MPU
	private Vector3 currentAngle;
	SerialPort serialPort;									// serial port
	[SerializeField]
	private UIHandler uiHandler;							// UI Handler object
	private Thread thread;                                  // Thread for Arduino communication
	private float AcX, AcY, AcZ;
	private string port;



	void Start()
	{
		//serialPort.Close();
		port = PlayerPrefs.GetString("Port");
		if(PlayerPrefs.GetString("Port") == null)
		{
			port = "COM4";
		}
		else
			port = PlayerPrefs.GetString("Port");
		serialPort = new SerialPort(port, 9600);
		serialPort.ReadTimeout = 2000;
		serialPort.Open();
		thread = new Thread(GetValues);
		thread.Name = "GetValuesThread";
		thread.IsBackground = true;
		thread.Start();
	}

	void Update()
	{
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(y , 0 , -x), Time.deltaTime * 2);
		//transform.rotation = Quaternion.Euler(y, 0, -x);
	}

	void GetValues()
	{
		while (serialPort.IsOpen)
		{
			uiHandler.serialPortIsOpen = serialPort.IsOpen;
			if (!serialPort.IsOpen)
			{
				uiHandler.serialPortIsOpen = serialPort.IsOpen;
				serialPort.Open();
			}
			try
			{
				serialPort.WriteLine("a");
				serialPort.BaseStream.Flush();
				AcX = int.Parse(serialPort.ReadLine());
				serialPort.Write("b");
				serialPort.BaseStream.Flush();
				AcY = int.Parse(serialPort.ReadLine());
			}
			catch(Exception e)
			{
				print(e.Message);
			}	
			x = AcX / 180;
			y = AcY / 180;
		}
	}

	void OnApplicationQuit()
	{
		serialPort.Close();
		//thread.Abort();
	}
}

public class Class1
{
}