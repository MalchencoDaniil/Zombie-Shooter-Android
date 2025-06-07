using UnityEngine;

[CreateAssetMenu(menuName = "Gun", fileName = "GunSettings")]
public class Gun : ScriptableObject
{
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _damage = 25f;

    [SerializeField]
    private float _reloadTime = 0.5f;

    public float BulletSpeed => _bulletSpeed;
    public float Damage => _damage;

    public float ReloadTime => _reloadTime;
}