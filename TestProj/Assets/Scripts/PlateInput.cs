using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlateInput : MonoBehaviour
{

    public float speed = .2f;
    public float rotateFactor = 2000;
    public float x, y, z;

    SerialPort serialPort = new SerialPort("COM4", 115200);

    void Start ()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1;
    }
	
	
	void Update ()
    {
        //Checking if serial port is open
        if (serialPort.IsOpen)
        {
            try
            {
                //Need to write a char to start reading from dmp
                serialPort.Write("s");
                //On read event
                SerialEvent(serialPort);
               /* Debug.Log("x=" +x);
                Debug.Log("y=" + y);
                Debug.Log("z=" + z);*/
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        //transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
        //transform.Rotate(x, y, z);
        //transform.Rotate(Vector3.back * x, rotateFactor * Time.deltaTime);
        //transform.localEulerAngles = new Vector3(-x,-y,-z);
        /*if(Input.GetButton("RotateDown"))
        {
            transform.Rotate(Vector3.back, rotateFactor * Time.deltaTime);
        }
        if (Input.GetButton("RotateUp"))
        {
            transform.Rotate(Vector3.forward, rotateFactor * Time.deltaTime);
        }*/



    }

    void FixedUpdate()
    {
        
    }

    void OnApplicationQuit()
    {
        serialPort.Close();
    }
    void SerialEvent(SerialPort myPort)
    {

        string buffer = serialPort.ReadLine();

        if (buffer != null)
        {
            if (buffer.Contains("ypr"))
            {
                Debug.Log(buffer);
                /* string[] values = buffer.Split('|');
                 x = float.Parse(values[1]);
                 y = float.Parse(values[2]);
                 z = float.Parse(values[3]);*/
                /*foreach (string s in values)
                {
                    //Debug.Log(s);
                }*/
            }
            // Debug.Log(buffer);
        }
    }


}
