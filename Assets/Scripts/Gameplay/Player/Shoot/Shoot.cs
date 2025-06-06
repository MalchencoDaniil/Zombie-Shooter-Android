using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float _timeToBulletShots = 0;

    [SerializeField]
    private float _reloadTime = 1;

    [SerializeField]
    private Transform _shootPosition;

    [SerializeField]
    private Bullet _bullet;

    [SerializeField]
    private LayerMask _enemyLayer;

    private void Update()
    {
        _timeToBulletShots -= Time.deltaTime;

        if (_timeToBulletShots <= 0)
        {
            Bullet _newBullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity);
            _timeToBulletShots = _reloadTime;
        }
    }
}