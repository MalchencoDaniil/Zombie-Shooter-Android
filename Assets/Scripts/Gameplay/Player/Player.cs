using UnityEngine;

public enum LimitSide
{
    Left, 
    Right,
    None
}

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

    [Header("Horizontal Limits")]
    [SerializeField]
    private float _horizontalLimit = 5f;
    private Vector3 _startPosition;

    internal Vector3 movementDirection;

    [HideInInspector]
    public LimitSide limitSide = LimitSide.None;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float horizontalInput = _inputHandler.MovementInput().x;

        Vector3 desiredMovement = transform.right * horizontalInput * _movementSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + desiredMovement;

        float distance = newPosition.x - _startPosition.x;

        if (Mathf.Abs(distance) > _horizontalLimit)
        {
            float limitedX = _startPosition.x + Mathf.Sign(distance) * _horizontalLimit;
            newPosition.x = limitedX;
            desiredMovement = newPosition - transform.position;
        }

        movementDirection = desiredMovement;

        if (limitSide == LimitSide.None)
            _characterController.Move(movementDirection);

        if (horizontalInput > 0 && limitSide == LimitSide.Left)
        {
            _characterController.Move(movementDirection);
            limitSide = LimitSide.None;
        }

        if (horizontalInput < 0 && limitSide == LimitSide.Right)
        {
            _characterController.Move(movementDirection);
            limitSide = LimitSide.None;
        }
    }

    public float GetHorizontalLimit()
    {
        return _horizontalLimit;
    }
    public Vector3 GetStartPosition()
    {
        return _startPosition;
    }
}