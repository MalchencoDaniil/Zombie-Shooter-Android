using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private HealthSystem _playerHealthSystem;

    private void Start()
    {
        _playerHealthSystem = FindObjectOfType<PlayerManager>().GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (!_other.gameObject.GetComponent<Shoot>() || !_other.gameObject.GetComponent<ObstaclePlayerSpawner>())
        {
            _playerHealthSystem.TakeDamage(1);
        }
    }
}