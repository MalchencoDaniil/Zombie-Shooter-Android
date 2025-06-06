using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _movementSpeed = 5;

    [SerializeField] private Vector3 _movementDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movementDirection * _movementSpeed * Time.fixedDeltaTime);
    }
}