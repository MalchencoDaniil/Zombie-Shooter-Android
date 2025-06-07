using UnityEngine;
using TMPro;

public class ObstaclePlayerSpawner : Obstacle
{
    private Shoot _shootController;
    private PlayerManager _playerManager;


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

    [Header("Obstacle Settings")]
    [SerializeField]
    private int _health = -5;

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _shootController = FindObjectOfType<Shoot>();

        _healthText.text = _health.ToString();

        _mesh.material = _baseMaterial;
    }

    public override void Interact()
    {

    }

    public void AddHealth()
    {
        _health += (int)_shootController.gun.Damage;
        _healthText.text = _health > 0 ? '+' + _health.ToString() : _health.ToString();

        if (_health == 0)
            _mesh.material = _takeMaterial;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.GetComponent<Player>() || _other.gameObject.GetComponent<PlayerFollower>())
        {
            if (_health < 0)
            {
                Destroy(gameObject);
            }
            if (_health >= 0)
            {
                //_playerManager.SpawnFollowers(_health);
                Destroy(gameObject);
            }
        }
    }
}