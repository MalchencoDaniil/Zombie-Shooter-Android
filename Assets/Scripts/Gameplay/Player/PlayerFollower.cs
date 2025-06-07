using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Player _player;
    private CharacterController _characterController;

    private PlayerManager _playerManager;

    [Header("Follower Settings")]
    [SerializeField]
    private float _followSpeed = 3f;

    private void Awake()
    {
        _playerManager = FindObjectOfType<PlayerManager>();

        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_player == null || _player == null) return;

        Vector3 _desiredMovement = _player.movementDirection;
        Vector3 _newPosition = transform.position + _desiredMovement;

        float _distance = _newPosition.x - _player.GetStartPosition().x;

        if (Mathf.Abs(_distance) > _player.GetHorizontalLimit())
        {
            _player.limitSide = (_distance > 0) ? LimitSide.Right : LimitSide.Left;

            float _limitedX = _player.GetStartPosition().x + Mathf.Sign(_distance) * _player.GetHorizontalLimit();

            _newPosition.x = _limitedX;
            _desiredMovement = _newPosition - transform.position;
        }

        if (_player.limitSide == LimitSide.None)
            _characterController.Move(_desiredMovement);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == TagDictionary.enemy)
        {
            _playerManager.RemoveFollower(this);
            Destroy(gameObject);
        }
    }
}