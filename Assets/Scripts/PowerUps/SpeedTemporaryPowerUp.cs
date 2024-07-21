using BHSCamp;
using UnityEngine;

public class SpeedTemporaryPowerUp : TemporaryPowerUp, IPowerUp
{

    [SerializeField] private float  _speed_multiplier;
    private IMove _move;


    public override void Apply(GameObject target)
    {
        _move = target.GetComponent<IMove>();
        _move.SetVelocityMultiplier(_speed_multiplier);
        base.Apply(target);
    }


    protected override void OnExpire()
    {
        _move.SetVelocityMultiplier(1f);
    }
}
