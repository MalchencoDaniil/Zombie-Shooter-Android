using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameState _gameState;

    [SerializeField]
    private List<EnemyMovement> _enemys = new List<EnemyMovement>();

    private void Start()
    {
        _gameState = FindObjectOfType<GameState>();
    }

    public void Update()
    {
        if (_enemys.Count == 0)
        {
            _gameState.Won();
            return;
        }

        for (int i = 0; i < _enemys.Count; i++)
        {
            if (_enemys[i] == null)
            {
                _enemys.RemoveAt(i);
            }
        }
    }
}