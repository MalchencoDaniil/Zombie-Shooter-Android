using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]
    private HealthSystem _healthSystem;

    [SerializeField]
    private Transform _heartPrefab;

    [SerializeField]
    private Transform _content;

    [SerializeField]
    private List<Transform> _hearts = new List<Transform>();

    private void Start()
    {
        _healthSystem.OnTakeDamage.AddListener(RemoveHeart);

        for (int i = 0; i < _healthSystem.CurrentHealth; i++)
        {
            AddHeart();
        }
    }

    public void AddHeart()
    {
        Transform _newHeart = Instantiate(_heartPrefab, _content.position, Quaternion.identity);
        _newHeart.SetParent(_content);

        _hearts.Add(_newHeart);
    }

    public void RemoveHeart()
    {
        Transform _heartToDestroy = _hearts[0];

        _hearts.Remove(_heartToDestroy);
        Destroy(_heartToDestroy.gameObject);
    }
}