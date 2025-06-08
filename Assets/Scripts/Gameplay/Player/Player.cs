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
    }

    private void Update()
    {
        float _horizontalInput = _inputHandler.MovementInput().x;
        float crowdRadius = _crowdSystem.GetCrowdDistance();

        float targetX = transform.position.x + _horizontalInput * _movementSpeed * Time.deltaTime;

        targetX = Mathf.Clamp(targetX, -_horizontalLimit / 2f + crowdRadius, _horizontalLimit / 2f - crowdRadius);

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}