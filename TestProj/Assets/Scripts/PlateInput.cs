using UnityEngine;
using System.IO.Ports;

public class PlateInput : MonoBehaviour
{

    public float speed = .2f;
    public float rotateFactor = 2000;
	SerialPort serial = new SerialPort("COM4", 9600);
	public float x, y, z;



	void Start()
    {
		serial.Open();
		serial.ReadTimeout = 2000;
	}

	void Update()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
		//PlayerInput();
		if (!serial.IsOpen)
		{
			serial.Open();
		}
		serial.Write("a");
		float AcX = int.Parse(serial.ReadLine());
		//serial.Write("b");
		//float AcY = int.Parse(serial.ReadLine());
		//serial.Write("c");
		//float AcZ = int.Parse(serial.ReadLine());
		x = AcX / 220;
		//y = AcY / 3000;
		//z = AcZ / 3000;
		transform.localEulerAngles = new Vector3(0, 0 , x);
	}

    private void PlayerInput()
    {
        if (Input.GetButton("RotateDown"))
        {
            transform.Rotate(Vector3.up, rotateFactor * Time.deltaTime);
        }
        if (Input.GetButton("RotateUp"))
        {
            transform.Rotate(Vector3.down, rotateFactor * Time.deltaTime);
        }
    }

	void OnApplicationQuit()
	{
		serial.Close();
	}
}


