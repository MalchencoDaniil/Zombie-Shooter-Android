using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Button _button;

    public void OpenLevel(int _levelID)
    {
        PlayerPrefs.SetInt(PrefsData.currentLevel, _levelID);
    }
}