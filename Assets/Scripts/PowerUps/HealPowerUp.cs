using BHSCamp;
using UnityEngine;

public class HealPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private int _heal_amount;


    public void Apply(GameObject target)
    {
        IHealable healable = target.GetComponent<IHealable>();
        healable.Heal(_heal_amount);
    }
}
