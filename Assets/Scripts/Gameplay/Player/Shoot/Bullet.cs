using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed = 15;

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _lifeTime = 5;

    private void Update()
    {
        transform.Translate(transform.forward * 10 * _bulletSpeed * Time.deltaTime);

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == TagDictionary._enemy)
        {
            HealthSystem _healthSystem = _other.gameObject.GetComponent<HealthSystem>();
            _healthSystem.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}