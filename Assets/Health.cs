using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] int hitPointCounter = 2;
    public int HitPointCounter { get => hitPointCounter; }
    bool isEnemy = true;
    private DisableAfterDeath disabler;

    private void Awake()
    {
        disabler = GetComponent<DisableAfterDeath>();
    }

    public virtual void GetLife()
    {
        hitPointCounter++;
    }

    public virtual void LoseLife()
    {
        hitPointCounter--;
        if (hitPointCounter <= 0) disabler.Disable();
    }

}
