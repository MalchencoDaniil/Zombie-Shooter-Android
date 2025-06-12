using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool _canInitialize = false;

    private float _bulletSpeed;
    private int _damage;

    [SerializeField]
    private float _lifeTime = 5;

    public void Initialize(float bulletSpeed, int damage)
    {
        _bulletSpeed = bulletSpeed;
        _damage = damage;

        _canInitialize = true;
    }

    private void Update()
    {
        if (!_canInitialize)
            return;

        transform.Translate(transform.forward * 10 * _bulletSpeed * Time.deltaTime);

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == TagDictionary.enemy)
        {
            HealthSystem _healthSystem = _other.gameObject.GetComponent<HealthSystem>();
            _healthSystem.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (_other.gameObject.GetComponent<Obstacle>())
        {
            Obstacle _obstacleSpawner = _other.gameObject.GetComponent<Obstacle>();
            _obstacleSpawner.AddHealth();
            Destroy(gameObject);
        }

        if (_other.gameObject.tag != TagDictionary.player)
            Destroy(gameObject);
    }
}