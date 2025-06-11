using UnityEngine;

public class SocialMediaLinks : MonoBehaviour
{
    public string telegramURL = "https://t.me/fly_popa_gamedev";

    public void OpenTelegram()
    {
        Application.OpenURL(telegramURL);
    }
} 