using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController _characterController;

    [Header("References")]
    [SerializeField]
    private InputHandler _inputHandler;

    [Header("Movement Settings")]
    [SerializeField]
    private float _movementSpeed = 5;


    private Vector3 _movementDirection;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _movementDirection = transform.right * _inputHandler.MovementInput().x;
        _movementDirection = _movementDirection.normalized;

        _characterController.Move(_movementDirection * _movementSpeed * Time.deltaTime);
    }
}