using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public int _health = -5;

    public virtual void AddHealth() { }

    public virtual void Interact() { }
}