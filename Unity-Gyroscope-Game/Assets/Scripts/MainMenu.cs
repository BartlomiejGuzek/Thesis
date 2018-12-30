using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO.Ports;
using TMPro;

public class MainMenu : MonoBehaviour 
{
	string selectedPort;
	string[] ports;
	[SerializeField]
	GameObject buttonPrefab;
	Vector3 buttonPosition;
	int x = 118 , y = 35;


	void Start()
	{
		
		ports = SerialPort.GetPortNames();
		foreach (var port in ports)
		{
			print(port);
			buttonPosition = new Vector3( x + 10, y, 0);
			x = x + 190;
			GameObject newButton = Instantiate(buttonPrefab) as GameObject;
			newButton.transform.SetParent(this.transform, false);
			newButton.transform.position = buttonPosition;
			newButton.GetComponentInChildren<TextMeshProUGUI>().text = port;
			Button btn = newButton.GetComponent<Button>();
			btn.onClick.AddListener(() => SetPort(newButton, port));
		}
	}

	public void Dropdown_IndexChanged(int index)
	{
		selectedPort = ports[index];
		print(selectedPort);
		PlayerPrefs.SetString("Port", selectedPort);
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("game");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	void SetPort(GameObject _button, string _port)
	{
		print(_port);
		SerialPort serialPort;                                  // serial port
		float AcY;

		serialPort = new SerialPort(_port, 9600);
		serialPort.ReadTimeout = 2000;
		serialPort.Open();
		PlayerPrefs.SetString("Port", _port);
		/*try
		{
			serialPort.Write("a");
			serialPort.BaseStream.Flush();
			AcY = int.Parse(serialPort.ReadLine());
			if (AcY != 0)
			{
				_button.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(255, 40, 40, 255);
			}
			else
				_button.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(40, 255, 40, 255);
			serialPort.Close();
		}
		catch (System.Exception)
		{

			throw;
		}*/


	}
}
