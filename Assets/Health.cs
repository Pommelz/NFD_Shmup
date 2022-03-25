using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] int hitPointCounter = 2;
    public int HitPointCounter { get => hitPointCounter; }

    public virtual void GetLife()
    {
        hitPointCounter++;
    }

    public virtual void LoseLife()
    {
        hitPointCounter--;
    }

}
