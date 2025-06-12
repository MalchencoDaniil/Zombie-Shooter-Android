using UnityEngine;

public class GameState : MonoBehaviour
{
    public void Won()
    {
        PlayerPrefs.SetInt(PrefsData.openLevelCount, PlayerPrefs.GetInt(PrefsData.openLevelCount) + 1);
        SceneTransistion._instance.SceneLoad(0);
    }

    public void Loss()
    {
        SceneTransistion._instance.SceneLoad(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}