using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<LevelButton> _levelButtons = new List<LevelButton>();

    private void Start()
    {
        int _openLevelCount = PlayerPrefs.GetInt(PrefsData.openLevelCount);

        for (int i = 0; i < _levelButtons.Count; i++)
        {
            if (i > _openLevelCount)
                _levelButtons[i]._button.interactable = false;
        }
    }
}