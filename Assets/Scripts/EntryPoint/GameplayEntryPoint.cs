using System.Collections.Generic;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField]
    private Gun[] _guns;

    [SerializeField]
    private List<Transform> _levels = new List<Transform>();

    private void Awake()
    {
        int _gunId = 0;

        PlayerManager _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.GunInitialize(_guns[_gunId]);

        int _levelId = PlayerPrefs.GetInt(PrefsData.currentLevel);
        Transform _newLevel = Instantiate(_levels[_levelId], _levels[_levelId].transform.position, Quaternion.identity);

        Debug.Log(_levelId);
    }
}