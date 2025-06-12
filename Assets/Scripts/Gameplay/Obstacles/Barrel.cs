using TMPro;
using UnityEngine;

public class Barrel : Obstacle
{
    private Shoot _shootController;

    [Header("References")]
    [SerializeField]
    private TextMeshPro _healthText;

    [SerializeField]
    private Transform _barrelMesh;

    [SerializeField]
    private EnemyMovement _movement;

    [Header("Stats")]
    [SerializeField]
    private Vector3 _rotateDirection = new Vector3(1, 0, 0);

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _shootController = FindObjectOfType<Shoot>();

        _healthText.text = _health.ToString();
    }

    private void Update()
    {
        _barrelMesh.transform.Rotate(_rotateDirection * _movement.MovementSpeed * Time.deltaTime);
    }

    public override void AddHealth()
    {
        _health += (int)_shootController._gun.Damage;
        _healthText.text = _health.ToString();

        if (_health >= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == TagDictionary.player)
        {
            if (_health < 0)
            {
                Destroy(_other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}