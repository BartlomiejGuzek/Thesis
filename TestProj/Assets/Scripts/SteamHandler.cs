using UnityEngine;
using System.Collections;
using Facepunch.Steamworks;

public class SteamHandler : MonoBehaviour
{
    static Facepunch.Steamworks.Client steamClient;
    Facepunch.Steamworks.Overlay steamOverlay;
    Facepunch.Steamworks.Screenshots screenshot;

    public static string playerUsername;
    public static ulong playerSteamID;

    void OnEnable()
    {
        steamClient = new Facepunch.Steamworks.Client(480); // 480 = space wars

        //Check if steam is initialized. If not, throw exception
        if (!steamClient.IsValid)
        {
            steamClient.Dispose();
            throw new System.Exception("Couldn't init Steam - is Steam running? Do you own Half-Life 2? Is steam_appid.txt in your project folder?");
        }
        playerUsername = steamClient.Username;
        playerSteamID = steamClient.SteamId;
    }

    void OnDisable()
    {
        if (steamClient != null)
        {
            steamClient.Dispose();
            steamClient = null;
        }
    }

    public static Texture2D GetAvatar(ulong _steamID)
    {
        Image steamAvatar = steamClient.Friends.GetAvatar(Friends.AvatarSize.Large, _steamID);
        if (steamAvatar.IsLoaded)
        {
            Texture2D returnTexture = new Texture2D((int)steamAvatar.Width, (int)steamAvatar.Height, TextureFormat.RGBA32, false, true);
            returnTexture.LoadRawTextureData(steamAvatar.Data);
            returnTexture.Apply();
            return returnTexture;
        }
        else
            throw new System.Exception("There was a problem while processing the avatar");     
    }
}
