using UnityEngine;

public class PowerupApplier : MonoBehaviour
{
    private IPowerUp[] _powerUps;

    private void Awake()
    {
        _powerUps = GetComponents<IPowerUp>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ApplyPowerUps(other.gameObject);
        Destroy(gameObject);
    }

    private void ApplyPowerUps(GameObject target)
    {
        foreach (IPowerUp powerUp in _powerUps)
            powerUp.Apply(target);
    }

}
