using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    private int _maxPlayerCount = 15;

    private Player _player;
    private CrowdSystem _crowdSystem;

    [SerializeField]
    private Transform _playerPrefab;

    [SerializeField]
    internal List<Transform> _playerMeshes = new List<Transform>();

    private void Start()
    {
        _player = FindObjectOfType<Player>();

        _crowdSystem = FindObjectOfType<CrowdSystem>();
    }

    public void AddPlayer(int _playerCount)
    {
        if (_playerMeshes.Count + _playerCount >= _maxPlayerCount)
            _playerCount = _maxPlayerCount - _playerMeshes.Count;

        if (_playerMeshes.Count < _maxPlayerCount)
        {
            for (int i = 0; i < _playerCount; i++)
            {
                Transform _newPlayer = Instantiate(_playerPrefab, _player.transform.position, Quaternion.identity);
                _newPlayer.SetParent(_player.transform);

                _playerMeshes.Add(_newPlayer);
                _crowdSystem.PlaceRunner();
            }
        }
    }

    public void RemovePlayer(Transform _playerToRemove)
    {
        _playerMeshes.Remove(_playerToRemove);
        Destroy(_playerToRemove.gameObject);
    }
}