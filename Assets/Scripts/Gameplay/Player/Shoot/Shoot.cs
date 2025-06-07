using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float _timeToBulletShots = 0;

    [Header("References")]
    [SerializeField]
    internal Gun gun;

    [SerializeField]
    private Transform _shootPosition;

    [SerializeField]
    private Bullet _bullet;

    [Header("Shoot Settings")]

    private float _reloadTime;

    [SerializeField]
    private LayerMask _enemyLayer;

    private void Start()
    {
        _reloadTime = gun.ReloadTime;
    }

    private void Update()
    {
        _timeToBulletShots -= Time.deltaTime;

        if (_timeToBulletShots <= 0)
        {
            Bullet _newBullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity);
            _newBullet.Initialize(gun.BulletSpeed, (int)gun.Damage);

            _timeToBulletShots = _reloadTime;
        }
    }
}