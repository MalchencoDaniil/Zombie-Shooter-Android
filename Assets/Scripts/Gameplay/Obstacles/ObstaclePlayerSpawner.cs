using UnityEngine;
using TMPro;

public class ObstaclePlayerSpawner : Obstacle
{
    private PlayerManager _playerManager;
    private Shoot _shootController;

    [Header("References")]
    [SerializeField]
    private TextMeshPro _healthText;

    [SerializeField]
    private MeshRenderer _mesh;

    [Space(15)]
    [SerializeField]
    private Material _baseMaterial;

    [SerializeField]
    private Material _takeMaterial;

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _shootController = FindObjectOfType<Shoot>();

        _healthText.text = _health.ToString();

        if (_health >= 0)
        {
            if (_health == 0)
                _mesh.material = _takeMaterial;
        }
    }

    public override void AddHealth()
    {
        _health += (int)_shootController._gun.Damage;
        _healthText.text = _health > 0 ? '+' + _health.ToString() : _health.ToString();

        if (_health >= 0)
            _mesh.material = _takeMaterial;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == TagDictionary.player)
        {
            if (_health < 0)
            {
                _playerManager.RemovePlayer(_other.transform);
                Destroy(gameObject);
            }
            if (_health >= 0)
            {
                _playerManager.AddPlayer(_health);
                Destroy(gameObject);
            }
        }
    }
}