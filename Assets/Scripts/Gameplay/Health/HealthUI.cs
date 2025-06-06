using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private HealthSystem _healthSystem;

    [SerializeField]
    private TMPro.TextMeshPro _healthText;

    private void Start()
    {
        _healthText.text = _healthSystem.CurrentHealth.ToString();

        _healthSystem.OnTakeDamage.AddListener(CanvasUpateHealth);
        CanvasUpateHealth();
    }

    private void OnDestroy()
    {
        if (_healthSystem != null)
        {
            _healthSystem.OnTakeDamage.RemoveListener(CanvasUpateHealth);
        }
    }

    public void CanvasUpateHealth()
    {
        _healthText.text = _healthSystem.CurrentHealth.ToString();
    }
}