using Facepunch.Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour
{
    //Reference to UI element 
    public static TextMeshProUGUI healthCount;
    public static TextMeshProUGUI scoreCount;

    /*//private UnityEngine.UI.RawImage playerAvatar;
    //private Text playerNickname;
    //playerAvatar = GetComponentInChildren<RawImage>();
    //playerAvatar.texture = SteamHandler.GetAvatar(SteamHandler.playerSteamID);
    // playerNickname = GetComponentInChildren<Text>();
    //playerNickname.text = SteamHandler.playerUsername;*/

    void Start()
    {
        
    }

    public void UpdateScore(float _score)
    {
        scoreCount.text = _score.ToString();
    }

    public void UpdateHealth(float _health)
    {
        healthCount.text = _health.ToString();
    }

}
