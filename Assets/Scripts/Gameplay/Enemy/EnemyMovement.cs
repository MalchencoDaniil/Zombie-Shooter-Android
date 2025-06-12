using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private PlayerManager _playerManager;

    [SerializeField]
    private bool _canDestroyPlayer = true;

    [SerializeField] private float _movementSpeed = 5;

    [SerializeField] private Vector3 _movementDirection;

    public float MovementSpeed => _movementSpeed;
    public Vector3 MovementDirection => _movementDirection;

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movementDirection * _movementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == TagDictionary.player && _canDestroyPlayer)
        {
            _playerManager.RemovePlayer(_other.transform);
        }
    }
}