using UnityEngine;
using System.IO.Ports;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour 
{
	[SerializeField]
	private Canvas canvas;
	public bool serialPortIsOpen;
	[SerializeField]
	private GameObject controllerIconOn;
	[SerializeField]
	private GameObject controllerIconOff;
	[SerializeField]
	private TextMeshProUGUI scoreCount;
	[SerializeField]
	private TextMeshProUGUI ammoCount;
	[SerializeField]
	private Canvas gameOver;

	void Start () 
	{
		//gameOver.enabled = false;
	}
	
	void Update () 
	{
		ControllerIcon();
	}

	void ControllerIcon()
	{
		if (serialPortIsOpen)
		{
			controllerIconOn.SetActive(true);
			controllerIconOff.SetActive(false);
		}
		else
		{
			controllerIconOn.SetActive(false);
			controllerIconOff.SetActive(true);
		}
	}


	public void UpdateScore(int _score)
	{
		scoreCount.text = _score.ToString();
	}

	public void UpdateAmmo(int _ammo)
	{
		ammoCount.text = _ammo.ToString();
	}

	public void ShowGameOverScreen(bool _state)
	{
		gameOver.enabled = _state;
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene("game");
	}

}
