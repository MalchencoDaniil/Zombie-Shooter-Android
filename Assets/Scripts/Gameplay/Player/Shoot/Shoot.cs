using UnityEngine;
public class Shoot : MonoBehaviour
{
    private float _timeToBulletShots = 0;

    internal Gun _gun;

    private PlayerManager _playerManager;

    [Header("References")]
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
        _playerManager = FindObjectOfType<PlayerManager>();
        _gun = _playerManager.PlayerGun;

        _reloadTime = _gun.ReloadTime;
    }

    private void Update()
    {
        _timeToBulletShots -= Time.deltaTime;

        if (_timeToBulletShots <= 0)
        {
            Bullet _newBullet = Instantiate(_bullet, _shootPosition.position, Quaternion.identity);
            _newBullet.Initialize(_gun.BulletSpeed, (int)_gun.Damage);

            _timeToBulletShots = _reloadTime;
        }
    }
}