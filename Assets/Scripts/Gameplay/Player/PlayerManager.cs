using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    private Player _player;

    [SerializeField]
    private Transform _playerPrefab;

    [SerializeField]
    internal List<Transform> _playerMeshes = new List<Transform>();

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void AddPlayer(int _playerCount)
    {
        for (int i = 0; i < _playerCount; i++)
        {
            Transform _newPlayer = Instantiate(_playerPrefab, _player.transform.position, Quaternion.identity);
            _newPlayer.SetParent(_player.transform);

            _playerMeshes.Add(_newPlayer);
        }
    }

    public void RemovePlayer(Transform _playerToRemove)
    {
        _playerMeshes.Remove(_playerToRemove);
        Destroy(_playerToRemove.gameObject);
    }
}