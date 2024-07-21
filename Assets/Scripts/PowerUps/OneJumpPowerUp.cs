using System.Collections;
using System.Collections.Generic;
using BHSCamp;
using UnityEngine;

public class OneJumpPowerUp : MonoBehaviour, IPowerUp 
{
    [SerializeField] private float _jump_multiplier;
     private Jump _jump_component;

    public void Apply(GameObject target)
    {
        _jump_component = target.GetComponent<Jump>();
        _jump_component.SetJumpMultiplier(_jump_multiplier);
    }

}
