using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] GameObject hitParticle;
    ObjectPool hitObjects;
    int poolSize;

    private void Awake()
    {
        Transform poolParent = GameObject.Find("PoolParent").transform;
        poolSize = poolParent.childCount;
        hitObjects = new ObjectPool(hitParticle, poolSize, poolParent);
    }

    private void OnEnable()
    {
        PlayerBulletTypeOne.Hit_Event += OnHit;
    }
    private void OnDisable()
    {
        PlayerBulletTypeOne.Hit_Event += OnHit;
    }

    private void OnHit(Vector3 hitLocation)
    {
        GameObject.Instantiate(hitParticle, hitLocation, hitParticle.transform.rotation);
    }
}
