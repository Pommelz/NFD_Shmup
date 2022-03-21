using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;

    private void OnEnable()
    {
        BulletBehaviour.Hit_Event += OnHit;
    }
    private void OnDisable()
    {
        BulletBehaviour.Hit_Event += OnHit;
    }

    private void OnHit(Vector3 hitLocation)
    {
        GameObject.Instantiate(hitParticle, hitLocation, hitParticle.transform.rotation);
    }
}
