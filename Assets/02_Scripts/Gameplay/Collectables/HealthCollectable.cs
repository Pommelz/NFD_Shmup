using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : BaseCollectable
{
    [SerializeField] int healAmount = 50;



    private void AddHealth()
    {
        
        Disable();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        var temp = other.GetComponent<Health>();
        if (!temp) return;
        temp.GetLife();
        Disable();
    }

    public override void Disable()
    {
        base.Disable();
    }
}
