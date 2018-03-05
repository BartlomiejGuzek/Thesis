using Facepunch.Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    //Reference to UI element 
    public Canvas canvasHUD;
    public Canvas gameOverHUD;
    public TextMeshProUGUI healthCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI gameOverScoreCount;

    /*//private UnityEngine.UI.RawImage playerAvatar;
    //private Text playerNickname;
    //playerAvatar = GetComponentInChildren<RawImage>();
    //playerAvatar.texture = SteamHandler.GetAvatar(SteamHandler.playerSteamID);
    // playerNickname = GetComponentInChildren<Text>();
    //playerNickname.text = SteamHandler.playerUsername;*/

    void Start()
    {
        gameOverHUD.enabled = false;
        canvasHUD.enabled = true;
    }

    public void DisplayGameOverHud(bool _isEnabled)
    {
        gameOverHUD.enabled = true;
        canvasHUD.enabled = false;
    }

    public void UpdateScore(float _score)
    {
        scoreCount.text = _score.ToString();
        gameOverScoreCount.text = _score.ToString();

    }

    public void UpdateHealth(float _health)
    {
        healthCount.text = _health.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("balance");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
