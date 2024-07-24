using BHSCamp;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _fillImage;

    private void OnEnable()
    {
        _health.OnDamageTaken += UpdateHealthBar;
        _health.OnHealed += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _health.OnDamageTaken -= UpdateHealthBar;
        _health.OnHealed -= UpdateHealthBar;
    }


    private void UpdateHealthBar(int healthChange)
    {
        SetFill(
            (float)_health.CurrentHealth /
            _health.MaxHealth
        );
    }

    private void SetFill(float value)
    {
        _fillImage.fillAmount = Mathf.Clamp01(value);
    }
}
