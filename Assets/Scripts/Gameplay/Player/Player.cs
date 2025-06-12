using UnityEngine;

public class Player : MonoBehaviour
{
    private CrowdSystem _crowdSystem;

    [Header("References")]
    [SerializeField]
    private InputHandler _inputHandler;

    [Header("Movement Settings")]
    [SerializeField]
    private float _movementSpeed = 5;

    [SerializeField]
    private float _horizontalLimit = 5;

    private void Start()
    {
        _crowdSystem = GetComponent<CrowdSystem>();

        if (_inputHandler == null)
            _inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        float _horizontalInput = _inputHandler.MovementInput().x;
        float _crowdRadius = Mathf.Max(0, _crowdSystem.GetCrowdDistance());

        float _targetX = transform.position.x + _horizontalInput * _movementSpeed * Time.deltaTime;

        _targetX = Mathf.Clamp(_targetX, -_horizontalLimit / 2f + _crowdRadius, _horizontalLimit / 2f - _crowdRadius);

        transform.position = new Vector3(_targetX, transform.position.y, transform.position.z);
    }
}