using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private Transform _entity;

    [SerializeField]
    private UnityEvent _takeHitEvent;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject == _entity.gameObject)
        {
            _takeHitEvent.Invoke();
        }
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}