using UnityEngine;

public class InviseTemporaryPowerUp : TemporaryPowerUp
{
    private Invisible _invisibility;


    public override void Apply(GameObject target)
    {
        _invisibility = target.GetComponent<Invisible>();
        _invisibility.GetInvise();
        
        base.Apply(target);
    }


    protected override void OnExpire()
    {
        _invisibility.LeaveInvise();
    }


}
